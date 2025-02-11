using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitService : IWorkPermitService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkPermitService>();

        private readonly IWorkPermitDao workPermitDao;
        private readonly IWorkPermitDTODao workPermitDTODao;
        private readonly IGasTestElementDao gasTestElementDao;
        private readonly IGasTestElementInfoDao gasTestElementInfoDao;
        private readonly ISapWorkOrderOperationDao sapWorkOrderOperationDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;        
        private readonly IObjectLockingService objectLockService;
        private readonly IUserService userService;

        private readonly ILogService logService;
        private readonly ITimeService timeService;
        private readonly IEditHistoryService editHistoryService;

        private static readonly List<WorkPermitStatus> oldPriorityPagePermitStatuses = new List<WorkPermitStatus>
                                                                                           {
                                                                                               WorkPermitStatus.Pending,
                                                                                               WorkPermitStatus.Approved,
                                                                                               WorkPermitStatus.Issued
                                                                                           };

        public WorkPermitService() : this(
            new ObjectLockingService(),
            new UserService(),
            new LogService(),
            new TimeService(),
            new EditHistoryService())
        {
        }

        public WorkPermitService(
            IObjectLockingService objectLockService,
            IUserService userService,
            ILogService logService,
            ITimeService timeService,
            IEditHistoryService editHistoryService)
        {
            workPermitDao = DaoRegistry.GetDao<IWorkPermitDao>();
            workPermitDTODao = DaoRegistry.GetDao<IWorkPermitDTODao>();
            gasTestElementDao = DaoRegistry.GetDao<IGasTestElementDao>();
            gasTestElementInfoDao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
            sapWorkOrderOperationDao = DaoRegistry.GetDao<ISapWorkOrderOperationDao>();
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            craftOrTradeDao = DaoRegistry.GetDao<ICraftOrTradeDao>();            

            this.objectLockService = objectLockService;
            this.logService = logService;
            this.timeService = timeService;
            this.userService = userService;
            this.editHistoryService = editHistoryService;
        }


        public void ArchiveCompletedWorkPermitsBySiteConfiguration(Site site)
        {
            try
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                if (siteConfiguration.DaysBeforeArchivingClosedWorkPermits > 0)
                {
                    DateTime requestDateTime = timeService.GetTime(site.TimeZone).SubtractDays(siteConfiguration.DaysBeforeArchivingClosedWorkPermits);
                    List<WorkPermit> completedPendingWPs = workPermitDao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(requestDateTime, site.IdValue, WorkPermitStatus.Complete);
                    User remoteAppUser = userService.GetRemoteAppUser();
                    Guid guid = Guid.NewGuid();

                    foreach (WorkPermit workpermit in completedPendingWPs)
                    {
                        ObjectLockResult lockResult = objectLockService.GetLock(workpermit, remoteAppUser.IdValue, guid.ToString());
                        if (lockResult.Succeeded)
                        {
                            try
                            {
                                workpermit.SetWorkPermitStatus(WorkPermitStatus.Archived);
                                DateTime currentTimeAtSite = timeService.GetTime(site.TimeZone);
                                workpermit.LastModifiedDate = currentTimeAtSite;
                                workPermitDao.Update(workpermit);
                            }
                            catch (Exception ex)
                            {
                                logger.ErrorFormat("An error has occured while Archiving Work Permit {0}" + Environment.NewLine + " Message: {1}" + Environment.NewLine + " Stack trace: {2}" + Environment.NewLine + "", workpermit.Id, ex.Message, ex.StackTrace);
                            }
                            finally
                            {
                                objectLockService.ReleaseLock(workpermit, remoteAppUser.IdValue);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("An error has occured: {0}" + Environment.NewLine + " Stack trace: {1}", ex.Message, ex.StackTrace);                
            }
        }

        public void UpdateWorkPermitsOnDeletedCraftOrTrade(long? craftOrTradeId)
        {            
            workPermitDao.UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade(craftOrTradeId);
        }

        public void CloseInactiveIssuedWorkPermitsBySiteConfiguration(Site site)
        {
            try
            {
                SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
                if (siteConfiguration.DaysBeforeClosingIssuedWorkPermits > 0)
                {
                    DateTime requestDateTime = timeService.GetTime(site.TimeZone).SubtractDays(siteConfiguration.DaysBeforeClosingIssuedWorkPermits);

                    List<WorkPermit> inactivePendingWPs = workPermitDao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(requestDateTime, site.IdValue, WorkPermitStatus.Issued);
                    User remoteAppUser = userService.GetRemoteAppUser();
                    Guid guid = Guid.NewGuid();

                    foreach (WorkPermit workpermit in inactivePendingWPs)
                    {
                        ObjectLockResult lockResult = objectLockService.GetLock(workpermit, remoteAppUser.IdValue, guid.ToString());
                        if (lockResult.Succeeded)
                        {
                            try
                            {
                                //close (well, actually mark as complete) work permit
                                workpermit.SetWorkPermitStatus(WorkPermitStatus.Complete);
                                DateTime currentTimeAtSite = timeService.GetTime(site.TimeZone);
                                workpermit.LastModifiedDate = currentTimeAtSite;
                                workPermitDao.Update(workpermit);
                            }
                            catch (Exception ex)
                            {
                                logger.ErrorFormat("An error has occured while Archiving Work Permit {0}" + Environment.NewLine + " Message: {1}" + Environment.NewLine + " Stack trace: {2}", workpermit.Id, ex.Message, ex.StackTrace);
                            }
                            finally
                            {
                                objectLockService.ReleaseLock(workpermit, remoteAppUser.IdValue);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("An error has occured: {0}" + Environment.NewLine + " Stack trace: {1}", ex.Message, ex.StackTrace);
            }
        }
        
        public void DeleteInactivePendingWorkPermitsBySiteConfiguration(Site site)
        {
            SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
            if (siteConfiguration.DaysBeforeDeletingPendingWorkPermits > 0)
            {
                DateTime requestDateTime = timeService.GetTime(site.TimeZone).SubtractDays(siteConfiguration.DaysBeforeDeletingPendingWorkPermits);
                
                List<WorkPermit> inactivePendingWPs = workPermitDao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(requestDateTime, site.IdValue, WorkPermitStatus.Pending);
                User remoteAppUser = userService.GetRemoteAppUser();
                Guid guid = Guid.NewGuid();

                foreach (WorkPermit workpermit in inactivePendingWPs)
                {
                    ObjectLockResult lockResult = objectLockService.GetLock(workpermit, remoteAppUser.IdValue, guid.ToString());
                    if (lockResult.Succeeded)
                    {
                        try
                        {
                            workPermitDao.Remove(workpermit);
                        }
                        finally
                        {
                            objectLockService.ReleaseLock(workpermit, remoteAppUser.IdValue);
                        }
                    }
                }
            }
        }

        public void DeleteRejectedWorkPermits()
        {
            Guid guid = Guid.NewGuid();
            User remoteAppUser = userService.GetRemoteAppUser();

            List<WorkPermit> rejectedWorkPermits =
                workPermitDao.QueryAllWorkPermitsByStatus(WorkPermitStatus.Rejected);

            foreach (WorkPermit workpermit in rejectedWorkPermits)
            {
                ObjectLockResult lockResult = objectLockService.GetLock(workpermit, remoteAppUser.IdValue, guid.ToString());
                if (lockResult.Succeeded)
                {
                    try
                    {
                        workPermitDao.Remove(workpermit);
                    }
                    finally
                    {
                        objectLockService.ReleaseLock(workpermit, remoteAppUser.IdValue);
                    }
                }
            }
        }



        public List<WorkPermit> QueryEditablePermitsByFunctionalLocations(IFlocSet flocSet)
        {
            return workPermitDao.QueryByFunctionalLocationsAndStatuses(flocSet, WorkPermit.EditableStatuses);
        }


        //ayman USPipeline workpermit
        public WorkPermit QueryBySapOperationWorkOrderDetailsForUSPipeline(string workOrderNumber, string operationNumber, string subOperation)
        {
            subOperation = subOperation.EmptyToNull();
            return workPermitDao.QueryBySapWorkOrderOperationKeysForUSPipeline(workOrderNumber, operationNumber, subOperation);
        }


        public WorkPermit QueryBySapOperationWorkOrderDetails(string workOrderNumber, string operationNumber, string subOperation)
        {
            subOperation = subOperation.EmptyToNull();
            return workPermitDao.QueryBySapWorkOrderOperationKeys(workOrderNumber, operationNumber, subOperation);
        }


        public List<WorkPermitDTO> QueryByDateRangeAndStatuses(IFlocSet flocSet, IList<WorkPermitStatus> statuses, Range<Date> range,
                WorkAssignment workAssignment)
        {
            DateTime? endDate;

            if (range.UpperBound != null)
                endDate = range.UpperBound.CreateDateTime(Time.END_OF_DAY);
            else
                endDate = null;

            return workPermitDTODao.QueryByDateRangeAndStatuses(flocSet, statuses,
                                                                range.LowerBound.CreateDateTime(Time.START_OF_DAY),
                                                                endDate, workAssignment);
        }

        public List<WorkPermitDTO> QueryByDateRangeAndStatusesForTemplate(IFlocSet flocSet, IList<WorkPermitStatus> statuses, Range<Date> range,
               WorkAssignment workAssignment, bool template, string username)
        {
            DateTime? endDate;

            if (range.UpperBound != null)
                endDate = range.UpperBound.CreateDateTime(Time.END_OF_DAY);
            else
                endDate = null;

            return workPermitDTODao.QueryByDateRangeAndStatusesForTemplate(flocSet, statuses,
                                                                range.LowerBound.CreateDateTime(Time.START_OF_DAY),
                                                                endDate, workAssignment, template, username);
        }

        public List<WorkPermitDTO> QueryOldPriorityPageWorkPermits(IFlocSet flocSet, ShiftPattern shiftPattern)
        {
            DateTime currentTimeAtSite = timeService.GetTime(shiftPattern.Site.TimeZone);
            return workPermitDTODao.QueryByFLOCsAndShiftForThisDate(flocSet, oldPriorityPagePermitStatuses, 
                                                                    shiftPattern, 
                                                                    currentTimeAtSite);
        }

        //ayman USPipeline workpermit
        public WorkPermit QueryByIdForUSPipeline(long id)
        {
            return workPermitDao.QueryByIdForUSPipeline(id);
        }

        public WorkPermit QueryById(long id)
        {
            return workPermitDao.QueryById(id);
        }

        public WorkPermit QueryByIdTemplate(long id, string templateName, string categories)
        {
            return workPermitDao.QueryByIdTemplate(id, templateName, categories);
        }

        public List<NotifiedEvent> Insert(WorkPermit workPermit)
        {
            UpdateWorkPermitInCaseThatItsCraftOrTradeHasBeenDeleted(workPermit);
            //ayman USPipeline Workpermit
            WorkPermit workPermitToReturn = null;

            if (workPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID 
                || workPermit.FunctionalLocation.Site.Id == Site.SELC_ID) //mangesh uspipeline to selc
                {
                    workPermitToReturn = workPermitDao.InsertUSPipeline(workPermit);
                }
                else
                {
                    workPermitToReturn = workPermitDao.Insert(workPermit);
                }

                editHistoryService.TakeSnapshot(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitCreate, workPermitToReturn));
            return notifiedEvents;
        }

        

        public WorkPermit Insert(WorkPermit workPermit, SapWorkOrderOperation operation)
        {
            UpdateWorkPermitInCaseThatItsCraftOrTradeHasBeenDeleted(workPermit);
            SapWorkOrderOperation newOperation = sapWorkOrderOperationDao.Insert(operation);
            workPermit.SapOperationId = newOperation.Id;
            WorkPermit insertedPermit = workPermitDao.Insert(workPermit);
            editHistoryService.TakeSnapshot(workPermit);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitCreate, insertedPermit);
            return insertedPermit;
        }

        public List<NotifiedEvent> Remove(WorkPermit workPermit)
        {
            workPermitDao.Remove(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitRemove, workPermit));
            return notifiedEvents;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(WorkPermit workPermit)
        {
            workPermitDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(WorkPermit workPermit)
        {
            if (workPermit.IsTemplate)
            {
                workPermitDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitUpdate, workPermit));
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertTemplate(WorkPermit workPermit)
        {
            if (workPermit.IsTemplate)
            {
                workPermitDao.InsertTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitCreateTemplate, workPermit));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(WorkPermit workPermit)
        {
            UpdateWorkPermitInCaseThatItsCraftOrTradeHasBeenDeleted(workPermit);
            RemoveGasTestElementsNoLongerNeededInDatabase(workPermit);

            DateTime currentTimeAtSite = timeService.GetTime(workPermit.FunctionalLocation.Site.TimeZone);
            workPermit.LastModifiedDate = currentTimeAtSite;

                workPermitDao.Update(workPermit);
                editHistoryService.TakeSnapshot(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitUpdate, workPermit));
            return notifiedEvents;
        }

        
        private void UpdateWorkPermitInCaseThatItsCraftOrTradeHasBeenDeleted(WorkPermit workPermit)
        {
            // In the time that it took to create/edit this work permit, it is possible that the associated 
            // craft or trade has been deleted via the administration screen.  If the user has selected a
            // 'user specified' craft or trade, this check is not neccessary.
            if (workPermit.Specifics.CraftOrTrade is CraftOrTrade)
            {
                long? craftOrTradeId = (workPermit.Specifics.CraftOrTrade as CraftOrTrade).Id;
                if (craftOrTradeDao.QueryByIdAndNotDeleted(craftOrTradeId.Value) == null)
                {
                    workPermit.Specifics.CraftOrTrade = new UserSpecifiedCraftOrTrade(workPermit.CraftOrTradeName);                    
                }
            }            
        }
        
        /// <summary>
        /// Go though Gas Tests in the database and remove them if they're no longer in the workpermit
        /// </summary>        
        private void RemoveGasTestElementsNoLongerNeededInDatabase(WorkPermit workPermit)
        {
            List<GasTestElement> gasTestElementsFromDB = 
                    gasTestElementDao.QueryAllGasTestElementByWorkPermitIdAndSiteId(workPermit.IdValue,workPermit.FunctionalLocation.Site.IdValue);                //ayman USPipeline workpermit

            foreach (GasTestElement databaseElement in gasTestElementsFromDB)
            {
                if (workPermit.GasTests.Elements.DoesNotHave(e => e.Id == databaseElement.Id))
                {
                    gasTestElementDao.Remove(databaseElement);
                }
                
//                GasTestElement foundElement = workPermit.GasTests.Elements.Find(
//                    e => (e.Id == databaseElement.Id));
//
//                if (foundElement == null)
//                {
//                    gasTestElementDao.Remove(databaseElement);
//                }
            }
        }

        public List<NotifiedEvent> InsertLog(WorkPermit workPermit, User modifiedBy, string logComments, ShiftPattern updatingUserShiftPattern, bool isOperatingEngineerLog, WorkAssignment workAssignment, Role createdByRole)
        {
            DateTime now = timeService.GetTime(workPermit.FunctionalLocation.Site.TimeZone);            

            Log logItem = new Log(null,
                                  null,
                                  null,
                                  DataSource.PERMIT,
                                  new List<FunctionalLocation> { workPermit.FunctionalLocation },
                                  false,
                                  false,
                                  false,
                                  false,
                                  false,
                                  false,                                  
                                  logComments,
                                  logComments,
                                  now,
                                  updatingUserShiftPattern,
                                  modifiedBy,
                                  modifiedBy,
                                  now,
                                  now,
                                  false,
                                  isOperatingEngineerLog,
                                  createdByRole,
                                  LogType.Standard,
                                  workAssignment);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.AddRange(logService.Insert(logItem));
            return notifiedEvents;
        }

        public List<NotifiedEvent> CopyWorkPermit(WorkPermit sourcePermit, WorkPermit destinationPermit, List<WorkPermitSection> sectionsToCopy, User currentUser)
        {
            // The destination might have changed between when the user selects the destination,
            // and when this copy operation actually occurs. Check again:

            //ayman USPipeline workpermit
            WorkPermit latestDestinationPermit;
            if (destinationPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID 
                || destinationPermit.FunctionalLocation.Site.Id == Site.SELC_ID) //mangesh uspipeline to selc
            {
                latestDestinationPermit = workPermitDao.QueryByIdForUSPipeline(destinationPermit.IdValue);
            }
            else
            {
                latestDestinationPermit = workPermitDao.QueryById(destinationPermit.IdValue);
            }

            if (latestDestinationPermit.HasEditableStatus() == false)
            {
                throw new WorkPermitNotEditableException(latestDestinationPermit.PermitNumber,
                                                         latestDestinationPermit.WorkPermitStatus);
            }

            WorkPermitGasTests gasTestsToRemove = destinationPermit.GasTests;

            sectionsToCopy.ForEach(
                sectionToCopy => CopyWorkPermitSection(sourcePermit, destinationPermit, sectionToCopy));

            destinationPermit.LastModifiedBy = currentUser;
            destinationPermit.LastModifiedDate = timeService.GetTime(sourcePermit.FunctionalLocation.Site.TimeZone);
            destinationPermit.Version = Constants.CURRENT_VERSION;

            workPermitDao.Update(destinationPermit);
            editHistoryService.TakeSnapshot(destinationPermit);

            if (sectionsToCopy.Exists(sectionToCopy => sectionToCopy.Equals(WorkPermitSection.GasTests)))
            {
                RemoveAllGasTestElements(gasTestsToRemove);
            }

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitUpdate, destinationPermit));
            return notifiedEvents;
        }

        private void RemoveAllGasTestElements(WorkPermitGasTests gasTests)
        {
            foreach (GasTestElement gasTestElement in gasTests.Elements)
            {
                GasTestElementInfo gasTestElementInfo = gasTestElement.ElementInfo;

                gasTestElementDao.Remove(gasTestElement);

                if (gasTestElementInfo.IsStandard == false)
                {
                    gasTestElementInfoDao.Remove(gasTestElementInfo);
                }
            }
        }

        private static void CopyWorkPermitSection(WorkPermit sourcePermit, WorkPermit destinationPermit,
                                           WorkPermitSection sectionToCopy)
        {
            if (sectionToCopy.Equals(WorkPermitSection.Tools))
                destinationPermit.Tools = sourcePermit.Tools.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.EquipmentPreparationCondition))
                destinationPermit.EquipmentPreparationCondition = sourcePermit.EquipmentPreparationCondition.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.JobWorksitePreparation))
                destinationPermit.JobWorksitePreparation = sourcePermit.JobWorksitePreparation.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.CommunicationMethod))
                destinationPermit.CommunicationMethod = sourcePermit.CommunicationMethod.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.RadiationInformation))
                destinationPermit.RadiationInformation = sourcePermit.RadiationInformation.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.Asbestos))
                destinationPermit.Asbestos = sourcePermit.Asbestos.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.FireConfinedSpaceRequirements))
                destinationPermit.FireConfinedSpaceRequirements = sourcePermit.FireConfinedSpaceRequirements.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.RespiratoryProtectionRequirements))
                destinationPermit.RespiratoryProtectionRequirements =
                    sourcePermit.RespiratoryProtectionRequirements.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.SpecialPPERequirements))
                destinationPermit.SpecialProtectionRequirements = sourcePermit.SpecialProtectionRequirements.Copy();
            else if (sectionToCopy.Equals(WorkPermitSection.SpecialPrecautionsOrConsiderations))
                destinationPermit.SpecialPrecautionsOrConsiderations = sourcePermit.SpecialPrecautionsOrConsiderations;
            else if (sectionToCopy.Equals(WorkPermitSection.GasTests))
            {
                destinationPermit.GasTests = sourcePermit.GasTests.Copy();
            }
            else if (sectionToCopy.Equals(WorkPermitSection.NotificationAuthorization))
                sourcePermit.CopyNotificationAuthorizationTo(destinationPermit);
            else if (sectionToCopy.Equals(WorkPermitSection.Miscellaneous))
                destinationPermit.DocumentLinks = sourcePermit.CloneDocumentLinksWithoutIds();
            else
            {
                //no error to be thrown now since there are other uses for these sections..just ignore
                //throw new ApplicationException("Copying section:<" + sectionToCopy + "> not implemented.");
            }
        }

        //Adde by Mukesh for WOrkpermit Sign
        
       public WorkPermitSign GetWorkPermitSign(string WorkPermitId, int SiteId)
        {
            return workPermitDao.GetWorkPermitSign(WorkPermitId, SiteId);
        }

    

       public void InserUpdateWorkPermitSign(WorkPermitSign workPermitSign)
       {
           workPermitDao.InserUpdateWorkPermitSign(workPermitSign);
       }
       public BADGE GetBadgeInfo(string Badgenumber, string strConnection, string strQuery)
       {
           return workPermitDao.GetBadgeInfo(Badgenumber, strConnection, strQuery);
       }
     public  LenleConnection GetWorkPermitSignLenelConnection()
       {
           return workPermitDao.GetWorkPermitSignLenelConnection();
       }

    }
}
