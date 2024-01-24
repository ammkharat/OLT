using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public class NotificationAdapter
    {
        #region MetaData

        // The data held in the notification object takes the form //log or action item
        //
        // NotificationObj[n].NotificationNumber:           Unique notification identifier //description
        // NotificationObj[n].NotificationType:             Source of the notification //description        
        // NotificationObj[n].ShortText:                    Operator generated short text //description 
        // NotificationObj[n].FunctionalLocation:           Targeted functinoal location //floc
        // NotificationObj[n].EquipmentNumber:              Optional, equipement number //description
        // NotificationObj[n].CreateDate:                   Date of notification creation //description
        // NotificationObj[n].CreateTime:                   Time of notification creation //description
        // NotificationObj[n].IncidentID:                   Optional, related incident number    //description
        // NotificationObj[n].LongText:                     Descriptive text //description
        // NotificationObj[n].PlantID:                      Target PlantId for notification  //siteid?

        // Optionally, the notification object may contain tasks //one per action item instance
        //
        // NotificationObj[n].Tasks[n].TaskCode:            ID for the task //description
        // NotificationObj[n].Tasks[n].TaskCodeText:        Short Description of the task code //description
        // NotificationObj[n].Tasks[n].TaskText:            Description of the task //description
        // NotificationObj[n].Tasks[n].Creator:             ID of the person who created task //description
        // NotificationObj[n].Tasks[n].CreationDate:        Date task created //description
        // NotificationObj[n].Tasks[n].PlannedStartDate:    Date for the start of the task //action item start
        // NotificationObj[n].Tasks[n].PlannedStartTime:    Time for the start of the task
        // NotificationObj[n].Tasks[n].PlannedFinishDate:   Date for the end of the task //action item end
        // NotificationObj[n].Tasks[n].PlannedFinishTime:   Time for the end of the task
        // NotificationObj[n].Tasks[n].ExceptionText:       Task exception code //description
        // NotificationObj[n].Tasks[n].ContactPerson:       Person contact details //description

        #endregion

        private static readonly ILog logger = LogManager.GetLogger(typeof (NotificationAdapter));
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly NotificationDetails[] notificationDetailsArray;
        private readonly ISAPNotificationService sapNotificationService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ISiteService siteService;
        private readonly ITimeService timeService;
        private readonly IUserService userService;

        public NotificationAdapter(NotificationDetails[] notificationDetailsArray) : this(
            notificationDetailsArray,
            GenericServiceRegistry.Instance.GetService<ISiteService>(),
            GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
            GenericServiceRegistry.Instance.GetService<IActionItemDefinitionService>(),
            GenericServiceRegistry.Instance.GetService<ISAPNotificationService>(),
            GenericServiceRegistry.Instance.GetService<ITimeService>(),
            GenericServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
            GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>(),
            GenericServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        public NotificationAdapter(
            NotificationDetails[] notificationDetailsArray,
            ISiteService siteService,
            IFunctionalLocationService functionalLocationService,
            IActionItemDefinitionService actionItemDefinitionService,
            ISAPNotificationService sapNotificationService,
            ITimeService timeService,
            ISiteConfigurationService siteConfigurationService,
            IBusinessCategoryService businessCategoryService,
            IUserService userService)
        {
            this.notificationDetailsArray = notificationDetailsArray;

            this.sapNotificationService = sapNotificationService;
            this.actionItemDefinitionService = actionItemDefinitionService;
            this.functionalLocationService = functionalLocationService;
            this.siteService = siteService;
            this.timeService = timeService;
            this.siteConfigurationService = siteConfigurationService;
            this.businessCategoryService = businessCategoryService;
            this.userService = userService;
        }

        public void IntegrateNotificationObjectToOperatorLogTool()
        {
            //
            // Iterate through the notification collection and add to the OLT database
            // either automated Action Items of items for log import selection
            //
            foreach (var details in notificationDetailsArray)
            {
                Thread.CurrentThread.CurrentUICulture =
                    LanguageCode.GetCultureInfoFromSAPALanguageCode(details.LanguageCode);


                //ayman SAP mapping
                if(details.PlantID == "7030" || details.PlantID == "7600")
                {
                    details.PlantID = "9991";
                }

                var site = siteService.QueryByPlantId(details.PlantID);
                if (!IsSiteInOlt(site, details))
                {
                    continue; // move on to the next Notification
                }

                var functionalLocation = functionalLocationService.QueryByFullHierarchy(details.FunctionalLocation,
                    site.IdValue);
                if (!IsFunctionalLocationInOlt(details, functionalLocation))
                {
                    continue; // move on to the next Notification
                }

                var notificationType = details.NotificationType;

                if (notificationType == SAPNotificationType.WorkRequest ||
                    notificationType == SAPNotificationType.EmergencyIncident ||
                    notificationType == SAPNotificationType.ActivityReport)
                {
                    CreateSapNotification(details, site, functionalLocation, "WR/EI/AR");
                }
                else if (notificationType == SAPNotificationType.ActionManagement && details.Tasks.IsEmpty())
                {
                    CreateSapNotification(details, site, functionalLocation, "AM");
                }
                else if (notificationType == SAPNotificationType.ActionManagement && !details.Tasks.IsEmpty())
                {
                    CreateActionItemDefinition(details, site, functionalLocation,
                        StringResources.ActionItemDefinition_DescriptionHeader_ActionManagement);
                }
                else if (notificationType == SAPNotificationType.ManagementChange && !details.Tasks.IsEmpty())
                {
                    CreateActionItemDefinition(details, site, functionalLocation,
                        StringResources.ActionItemDefinition_DescriptionHeader_ManagementChange);
                }
                else
                {
                    logger.WarnFormat(
                        "Notification {0} for unknown Type {1} was received. OLT won't process the Notification.",
                        details.NotificationNumber, notificationType);
                }
            }
        }

        private bool IsSiteInOlt(Site site, NotificationDetails details)
        {
            if (site == null)
            {
                logger.ErrorFormat("Notification Adapter Error for {0}. No OLT Site was found for Plant Id: {1}.",
                    details.NotificationNumber, details.PlantID);
                return false;
            }
            return true;
        }

        private bool IsFunctionalLocationInOlt(NotificationDetails details, FunctionalLocation functionalLocation)
        {
            if (functionalLocation == null)
            {
                logger.ErrorFormat(
                    "Notification Adapter Error for {0}. No OLT Functional Location was found for SAP FLOC: {1}.",
                    details.NotificationNumber, details.FunctionalLocation);
                return false;
            }
            return true;
        }

        private void CreateSapNotification(NotificationDetails details, Site site, FunctionalLocation functionalLocation,
            string notificationTypes)
        {
            try
            {
                var sapNotification = CreateSAPNotificationForNotification(functionalLocation, details, site);

                logger.DebugFormat("{0} Notification {1} without Tasks for FLOC: {2}",
                    notificationTypes, details.NotificationNumber, details.FunctionalLocation);

                var existingSAPNotification =
                    sapNotificationService.QueryByNotificationNumber(sapNotification.NotificationNumber);

                if (existingSAPNotification == null)
                {
                    sapNotificationService.Insert(sapNotification);
                }
                else
                {
                    logger.DebugFormat("Notification {0} exists already. The NotificationAdapter will ignore this.",
                        existingSAPNotification.NotificationNumber);
                }
            }
            catch (WorkOrderToOltObjectBuilderException e)
            {
                logger.Error(e.Message); // continue on to the next Operation Line.
            }
            catch (OLTException e)
            {
                // continue on to the next Operation Line.
                logger.ErrorFormat("OLT Error inserting Notification {0} for Floc {1}: {2}", details.NotificationNumber,
                    details.FunctionalLocation, e.Message);
            }
            catch (Exception e)
            {
                // continue on to the next Operation Line.
                logger.ErrorFormat("Unknown Error inserting Notification {0} for Floc {1}: {2}",
                    details.NotificationNumber, details.FunctionalLocation, e.Message);
            }
        }

        private void CreateActionItemDefinition(NotificationDetails details, Site site,
            FunctionalLocation functionalLocation, string header)
        {
            // SAP has sent us notifications at the division level. Action item definitions cannot be created
            // at level 1 or 2 so ignore it.
            if (Equals(functionalLocation.Type, FunctionalLocationType.Level1) ||
                Equals(functionalLocation.Type, FunctionalLocationType.Level2))
            {
                logger.WarnFormat(
                    "SAP Notification {0} is ignored because the functional location ({1}) is at at invalid level.",
                    details.NotificationNumber, functionalLocation.FullHierarchy);
                return;
            }

            var taskCount = 0;
            foreach (var notificationTask in details.Tasks)
            {
                taskCount++;
                try
                {
                    var actionItemDefinition =
                        CreateActionItemForNotification(functionalLocation, site, details, notificationTask, header,
                            taskCount);

                    var siteId = site.IdValue;

                    var nameCount = actionItemDefinitionService.GetCountOfSAPSourced(actionItemDefinition.Name, siteId);

                    // If we find nameCount!=0 then there is already something from SAP with this name and we shouldn't be creating an Action Item.
                    // Only insert pending Action Items.  Do not update Action Items.
                    if (nameCount != 0)
                    {
                        continue;
                    }

                    var siteConfiguration = siteConfigurationService.QueryBySiteId(siteId);

                    if (AutoApproveSAPNotification(siteConfiguration, details.NotificationType))
                    {
                        //
                        //  AID Last Modified By and Last Modidifed Date should have been set earlier.
                        //
                        actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy,
                            actionItemDefinition.LastModifiedDate);
                    }

                    var sapWorkOrderOperation =
                        new SapWorkOrderOperation(null, details.NotificationNumber,
                            taskCount.ToString(CultureInfo.InvariantCulture), string.Empty,
                            SapOperationType.ActionItemDefinition);

                    logger.DebugFormat("Action Item Definition Insert: {0}{1}", actionItemDefinition.Name,
                        Environment.NewLine);
                    actionItemDefinitionService.Insert(actionItemDefinition, sapWorkOrderOperation);
                }
                catch (WorkOrderToOltObjectBuilderException e)
                {
                    logger.Error(e.Message); // continue to next Task
                }
            }
        }

        private static bool AutoApproveSAPNotification(SiteConfiguration siteConfiguration, string notificationType)
        {
            if (notificationType == SAPNotificationType.ActionManagement)
                return siteConfiguration.AutoApproveSAPAMActionItemDefinition;

            if (notificationType == SAPNotificationType.ManagementChange)
                return siteConfiguration.AutoApproveSAPMCActionItemDefinition;

            return false;
        }

        /// <summary>
        ///     Create the SAP notification object or return null if there is a problem with the data
        /// </summary>
        /// <param name="functionalLocation"></param>
        /// <param name="notificationDetails"></param>
        /// <param name="site"></param>
        private static SAPNotification CreateSAPNotificationForNotification(FunctionalLocation functionalLocation,
            NotificationDetails notificationDetails, Site site)
        {
            DateTime creationDateTime;
            var parsed = DateTimeExtensions.TryParse(notificationDetails.CreateDate, notificationDetails.CreateTime,
                out creationDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format("Could not parse CreateDate, {0}, and/or CreateTime, {1}, into a Valid DateTime.",
                        notificationDetails.CreateDate, notificationDetails.CreateTime));
            }

            var creationDateTimeAsLocal = ConvertCreationTimeToLocalTime(creationDateTime, site);
            //End of Add            

            return new SAPNotification(functionalLocation,
                BuildNotificationDescription(notificationDetails),
                notificationDetails.NotificationType,
                notificationDetails.ShortText,
                notificationDetails.LongText,
                notificationDetails.IncidentID,
                creationDateTimeAsLocal,
                notificationDetails.NotificationNumber, false);
        }

        private static DateTime ConvertCreationTimeToLocalTime(DateTime creationDateTime, Site site)
        {
            var schedulerTimeZone = GetSchedulerTimeZone();
            return schedulerTimeZone != site.TimeZone
                ? OltTimeZoneInfo.ConvertTime(creationDateTime, schedulerTimeZone,
                    site.TimeZone)
                : creationDateTime;
        }

        private static OltTimeZoneInfo GetSchedulerTimeZone()
        {
            var serverTimeZoneAsString = ConfigurationManager.AppSettings["ServerTimeZone"];

            if (string.IsNullOrEmpty(serverTimeZoneAsString))
            {
                throw new TimeZoneConversionException("Could not find a configuration setting for ServerTimeZone");
            }
            return
                OltTimeZoneInfo.FindSystemTimeZoneById(serverTimeZoneAsString);
        }

        /// <summary>
        ///     Create the Action Item definition (pending) returns null if action item definition cannot be created
        /// </summary>
        /// <param name="functionalLocation"></param>
        /// <param name="site"></param>
        /// <param name="notificationDetails"></param>
        /// <param name="notificationTask"></param>
        /// <param name="descriptionHeader"></param>
        /// <param name="taskCount"></param>
        public ActionItemDefinition CreateActionItemForNotification(FunctionalLocation functionalLocation,
            Site site,
            NotificationDetails notificationDetails,
            Tasks notificationTask,
            string descriptionHeader,
            int taskCount)
        {
            //
            // if the dates are not valid then get out
            //
            DateTime startDateTime;
            var parsed = DateTimeExtensions.TryParse(notificationTask.PlannedStartDate,
                notificationTask.PlannedStartTime, out startDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse PlannedStartDate, {0}, and/or PlannedStartTime, {1}, into a Valid DateTime for Notification {2}; Task {3}.",
                        notificationTask.PlannedStartDate, notificationTask.PlannedStartTime,
                        notificationDetails.NotificationNumber, notificationTask.TaskCode));
            }
            DateTime endDateTime;
            parsed = DateTimeExtensions.TryParse(notificationTask.PlannedFinishDate, notificationTask.PlannedFinishTime,
                out endDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse PlannedFinishDate, {0}, and/or PlannedFinishTime, {1}, into a Valid DateTime for Notification {2}; Task {3}.",
                        notificationTask.PlannedFinishDate, notificationTask.PlannedFinishTime,
                        notificationDetails.NotificationNumber, notificationTask.TaskCode));
            }

            ISchedule schedule = new SingleSchedule(new Date(startDateTime), new Time(startDateTime),
                new Time(endDateTime), site);

            var name = string.Format(StringResources.ActionItemDefinition_Name, notificationDetails.NotificationNumber,
                taskCount);
            var flocList = new List<FunctionalLocation> {functionalLocation};
            var description = BuildDescription(descriptionHeader, notificationDetails, notificationTask);
            var sapUser = userService.GetSAPUser();
            var currentTimeAtSite = timeService.GetTime(site.TimeZone);
            var category = businessCategoryService.GetDefaultSAPNotificationCategory(functionalLocation.Site.IdValue);
            var status = ActionItemDefinitionStatus.Pending;
            const bool requiresApproval = true;
            const bool active = false;
            const bool responseRequired = false;
            var operationalMode = OperationalMode.Normal;

            var actionItemDefinition = new ActionItemDefinition(name,
                category,
                status,
                schedule,
                description,
                DataSource.SAP,
                requiresApproval,
                active,
                responseRequired,
                sapUser,
                currentTimeAtSite,
                sapUser,
                currentTimeAtSite,
                flocList,
                new List<TargetDefinitionDTO>(0),
                new List<DocumentLink>(0),
                operationalMode,
                null,
                true, null, null,null,false,false,false,null);    //ayman visibility groups     //ayman custom fields DMND0010030
            return actionItemDefinition;
        }

        private static string BuildDescription(string descriptionHeader, NotificationDetails notificationDetails,
            Tasks notificationTask)
        {
            var sb = new StringBuilder();
            sb.Append(descriptionHeader);
            sb.Append(BuildNotificationDescription(notificationDetails));
            sb.Append(StringResources.ActionItemDefinition_Description + ": ");
            sb.Append(BuildNotificationTaskDescription(notificationTask));

            return sb.ToString();
        }

        /// <summary>
        ///     Builds and returns a string with notification details description
        ///     Format: Work Request Created. Notification Number: {0}. Short Text: {1}. Equipment Number: {2}.
        ///     Created Date/Time: {3},{4}. Incident ID: {5}. Long Text: {6}
        /// </summary>
        /// <param name="notificationDetails">NotificationDetail object to build the string from</param>
        /// <returns>A simple string containing a description</returns>
        public static string BuildNotificationDescription(NotificationDetails notificationDetails)
        {
            var sb = new StringBuilder();
            if (notificationDetails.NotificationNumber.HasValue())
                sb.AppendFormat(StringResources.NotificationDetails_NotificationNumber + ". ",
                    notificationDetails.NotificationNumber);

            if (notificationDetails.ShortText.HasValue())
                sb.AppendFormat(StringResources.NotificationDetails_ShortText + ". ", notificationDetails.ShortText);

            if (notificationDetails.EquipmentNumber.HasValue())
                sb.AppendFormat(StringResources.NotificationDetails_EquipmentNumber + ". ",
                    notificationDetails.EquipmentNumber);

            if (notificationDetails.CreateDate.HasValue())
                sb.AppendFormat
                    (
                        StringResources.NotificationDetails_CreateDate + ". ",
                        notificationDetails.CreateDate,
                        notificationDetails.CreateTime
                    );

            if (notificationDetails.IncidentID.HasValue())
                sb.AppendFormat(StringResources.NotificationDetails_IncidentID + ". ", notificationDetails.IncidentID);

            if (notificationDetails.LongText.HasValue())
                sb.AppendFormat(StringResources.NotificationDetails_LongText + ". ", notificationDetails.LongText);

            return sb.ToString();
        }

        /// <summary>
        ///     Builds and returns a string with notification task description
        /// </summary>
        /// <param name="task">Task object to build the string from</param>
        /// <returns>A simple string containing a description</returns>
        public static string BuildNotificationTaskDescription(Tasks task)
        {
            var sb = new StringBuilder();
            if (task.TaskCode.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_TaskCode + ". ", task.TaskCode);

            if (task.TaskCodeText.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_TaskCodeText + ". ", task.TaskCodeText);

            if (task.TaskText.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_TaskText + ". ", task.TaskText);

            if (task.Creator.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_Creator + ". ", task.Creator);

            if (task.CreationDate.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_CreationDate + ". ", task.CreationDate);

            if (task.PlannedStartDate.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_PlannedStartDate + ". ", task.PlannedStartDate,
                    task.PlannedStartTime);

            if (task.PlannedFinishDate.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_PlannedFinishDate + ". ", task.PlannedFinishDate,
                    task.PlannedFinishTime);

            if (task.ExceptionText.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_ExceptionText + ". ", task.ExceptionText);

            if (task.ContactPerson.HasValue())
                sb.AppendFormat(StringResources.TaskDescription_ContactPerson + ". ", task.ContactPerson);

            return sb.ToString();
        }

        private static void DoSiteNullCheck(Site site, string plantId)
        {
            if (site == null)
            {
                var siteErrorString = string.Format
                    (
                        "Notification Adapter Error. No OLT Site was found for Plant Id: {0}. ",
                        plantId
                    );
                throw new ApplicationException(siteErrorString);
            }
        }

        private static void DoFunctionalLocationNullCheck(NotificationDetails details,
            FunctionalLocation functionalLocation)
        {
            if (functionalLocation == null)
            {
                var functionalLocationErrorString = string.Format
                    ("Notification Adapter Error. No OLT Functional Location was found for SAP FLOC: {0}. ",
                        details.FunctionalLocation
                    );
                throw new ApplicationException(functionalLocationErrorString);
            }
        }
    }
}