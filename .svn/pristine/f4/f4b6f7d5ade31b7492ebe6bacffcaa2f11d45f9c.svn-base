using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FunctionalLocationOperationalModeService : IFunctionalLocationOperationalModeService
    {
        private readonly IFunctionalLocationOperationalModeDTODao opModeDTODao;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ITargetAlertService targetAlertService;
        private readonly ITargetDefinitionService targetDefinitionService;
        private readonly IActionItemService actionItemService;
        private readonly IEditHistoryService editHistoryService;
        private readonly ITimeService timeService;
        private readonly IFunctionalLocationOperationalModeDao opModeDao;
        
        public FunctionalLocationOperationalModeService() : this(
            new FunctionalLocationService(),
            new TargetAlertService(),
            new TargetDefinitionService(),
            new ActionItemService(),
            new EditHistoryService(),
            new TimeService())
        {
        }

        public FunctionalLocationOperationalModeService(
            IFunctionalLocationService functionalLocationService,
            ITargetAlertService targetAlertService,
            ITargetDefinitionService targetDefinitionService,
            IActionItemService actionItemService,
            IEditHistoryService editHistoryService,
            ITimeService timeService)
        {
            opModeDTODao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeDTODao>();
            this.functionalLocationService = functionalLocationService;
            this.targetAlertService = targetAlertService;
            this.targetDefinitionService = targetDefinitionService;
            this.actionItemService = actionItemService;
            this.editHistoryService = editHistoryService;
            this.timeService = timeService;
            opModeDao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeDao>();
        }

        public List<FunctionalLocationOperationalModeDTO> GetBySiteId(long siteId)
        {
            return opModeDTODao.GetAllBySite(siteId);
        }

        public void Update(List<FunctionalLocationOperationalModeDTO> modifiedOpModeList, User lastModifiedUser)
        {
            List<FunctionalLocation> functionalLocationList = new List<FunctionalLocation>();

            foreach (FunctionalLocationOperationalModeDTO opModeDto in modifiedOpModeList)
            {
                FunctionalLocationOperationalMode opMode =
                    new FunctionalLocationOperationalMode(opModeDto.IdValue, opModeDto.OperationalMode,
                                                          opModeDto.AvailabilityReason, opModeDto.LastModifiedDate);
                
                opModeDao.Update(opMode);
                
                editHistoryService.TakeSnapshot(opMode, lastModifiedUser);
                FunctionalLocation functionalLocation = functionalLocationService.QueryById(opModeDto.FunctionalLocationId);
                functionalLocationList.Add(functionalLocation);

                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FunctionalLocationOperationalModeUpdate, functionalLocation);
            }
            UpdateActionItemsAndTargetDefinition(functionalLocationList);
        }
        
        /// <summary>
        ///  Insert a Default Operational Mode for a Unit Level Functional Location.
        /// </summary>
        /// <param name="unitLevelFunctionalLocation">Functional Location to Insert an Operational Mode</param>
        /// <param name="createdByUser">User creating the Operational Mode</param>
        public void InsertDefault(FunctionalLocation unitLevelFunctionalLocation, User createdByUser)
        {
            /*Amit Shukla Comment this line and test the complete thing Request No 11 */
            /*Older Code commented star Amit Shukla*/
            //if (FunctionalLocationType.Level3 != unitLevelFunctionalLocation.Type)
            //{
            //    throw new ExpectedUnitLevelFLOCException(
            //        string.Format("Attempted to insert an Operational Mode for FLOC {0}, but it's not a Unit.",
            //                      unitLevelFunctionalLocation.FullHierarchy));
            //}
            /*Older Code commented End Amit Shukla*/
            // Allowing system to insert data for functional location operational mode for Level 2 and 1 locations also
            /*New Code Start Amit Shukla*/
            if (!(FunctionalLocationType.Level3 == unitLevelFunctionalLocation.Type ||FunctionalLocationType.Level2 == unitLevelFunctionalLocation.Type ||FunctionalLocationType.Level1 == unitLevelFunctionalLocation.Type))
            {
                 throw new ExpectedUnitLevelFLOCException(
                    string.Format("Attempted to insert an Operational Mode for FLOC {0}, but it's not a Unit.",
                                  unitLevelFunctionalLocation.FullHierarchy));
            }
            /*New Code End Amit Shukla*/

            DateTime currentTimeAtSite = timeService.GetTime(unitLevelFunctionalLocation.Site.TimeZone);

            long functionalLocationId = unitLevelFunctionalLocation.IdValue;

            FunctionalLocationOperationalModeHistory defaultMode =
                new FunctionalLocationOperationalModeHistory(functionalLocationId,
                                                             OperationalMode.Normal, AvailabilityReason.None,
                                                             currentTimeAtSite, createdByUser);

            FunctionalLocationOperationalMode functionalLocationOperationalMode =
                new FunctionalLocationOperationalMode(functionalLocationId,
                                                         defaultMode.OperationalMode,
                                                         defaultMode.AvailabilityReason, currentTimeAtSite);

            opModeDao.Insert(functionalLocationOperationalMode);
            editHistoryService.TakeSnapshot(functionalLocationOperationalMode, createdByUser);
        }

        private void UpdateActionItemsAndTargetDefinition(List<FunctionalLocation> functionalLocationList)
        {
            targetDefinitionService.UpdateBoundaryExceededByUnitId(functionalLocationList, false);
            targetAlertService.ClearAllTargetAlertsAtOrBelowFlocs(functionalLocationList);
            actionItemService.ClearActionItemsAtOrBelowFlocs(functionalLocationList);
        }

        public FunctionalLocationOperationalModeDTO GetByFunctionalLocationId(long functionalLocationId)
        {
            FunctionalLocation floc = functionalLocationService.QueryById(functionalLocationId);

            //if (floc.Type < FunctionalLocationType.Level3 )   
            //{
            //    throw new ApplicationException("Can not get Functional Location Operational Mode on functional locations higher than the Unit level");
            //}

            FunctionalLocationOperationalModeDTO operationalModeDTO = opModeDTODao.GetForLevel3AndBelowFloc(floc.IdValue);

            return operationalModeDTO;
        }
    }
}