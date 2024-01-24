using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Clients;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ExcursionImportService : IExcursionImportService
    {
        private const int ExcursionBatchSize = 50;
        private const int ExcursionBatchSleepInterval = 10000;
        private static readonly ILog logger = GenericLogManager.GetLogger<ExcursionImportService>();

        private readonly OpmExcursionToOpmExcursionDTOConverter excursionDTOConverter;
        private readonly IOpmExcursionDao excursionDao;
        private readonly IOpmExcursionImportStatusDTODao excursionImportStatusDTODao;
        private readonly IOpmExcursionResponseDao excursionResponseDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly OpmXhqImporter importer;
        private readonly OpmXhqServiceSettings settings;
        private readonly OpmTagValueToOpmTagValueDTOConverter tagValueDTOConverter;
        private readonly OpmToeDefinitionToOpmToeDefinitionDTOConverter toeDefinitionDTOConverter;
        private readonly IOpmToeDefinitionDao toeDefinitionDao;

        public ExcursionImportService()
        {
            settings = new OpmXhqServiceSettings();
            importer = new OpmXhqImporter(settings);
            tagValueDTOConverter = new OpmTagValueToOpmTagValueDTOConverter();
            excursionDao = DaoRegistry.GetDao<IOpmExcursionDao>();
            excursionResponseDao = DaoRegistry.GetDao<IOpmExcursionResponseDao>();
            toeDefinitionDao = DaoRegistry.GetDao<IOpmToeDefinitionDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            toeDefinitionDTOConverter = new OpmToeDefinitionToOpmToeDefinitionDTOConverter(functionalLocationDao);
            excursionDTOConverter = new OpmExcursionToOpmExcursionDTOConverter(functionalLocationDao);
            excursionImportStatusDTODao = DaoRegistry.GetDao<IOpmExcursionImportStatusDTODao>();
        }

        public OpmExcursionImportStatusDTO GetLastSuccessfulExcursionImportStatus()
        {
            var lastSuccessfulExcursionImportStatusDto = excursionImportStatusDTODao.QueryLastSuccessfulImport();

            return lastSuccessfulExcursionImportStatusDto;
        }

        public void UpdateExcursionImportStatus(OpmExcursionImportStatusDTO opmExcursionImportStatusDTO)
        {
            if (opmExcursionImportStatusDTO == null) return;

            if (opmExcursionImportStatusDTO.Status == OpmExcursionImportStatus.Available)
            {
                excursionImportStatusDTODao.UpdateAvailableImportStatus(
                    opmExcursionImportStatusDTO.LastSuccessfulExcursionImportDateTime);
            }
            else
            {
                excursionImportStatusDTODao.UpdateUnavailableImportStatus(DateTime.Now);
            }
        }

        public DateTime GetMostRecentExcursionUpdateDateTime()
        {
            var existingExcursion = excursionDao.QueryMostRecentExcursionUpdateDateTime();

            if (existingExcursion != null)
            {
                return existingExcursion.LastUpdatedDateTime;
            }
            // This will only happen the first time the import is performed and no excursion data exists in the OLT database
            return DateTime.Now.SubtractDays(3);
        }

        public void NotifyOpmExcursionImportStatus(OpmExcursionImportStatusDTO opmExcursionImportStatusDTO,
            ApplicationEvent applicationEvent)
        {
            ServiceUtility.PushEventIntoQueue(applicationEvent, opmExcursionImportStatusDTO);
        }

        public void NotifyOpmExcursionItemRefresh(Site site)
        {
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.OpmExcursionItemRefresh, site);
        }

        public OpmExcursionImportResult ImportOpmExcursionDtosFromDate(DateTime dateAndTimeQueryFrom)
        {
            List<OpmExcursionImportRejection> rejectionList;

            var excursionList = importer.GetOpmExcursions(dateAndTimeQueryFrom);

            var excursions =
                excursionDTOConverter.ConvertToOpmExcursionDTOs(excursionList, out rejectionList);

            logger.Debug(
                string.Format(
                    "OPM Excursion Import: ({0}), {1} Excursions were created from the OPM XHQ excursion data (but have not yet been processed for insert or update)",
                    dateAndTimeQueryFrom.ToShortDateAndTimeString(), excursions.Count));

            if (rejectionList.Count > 0)
            {
                logger.Debug(
                    string.Format(
                        "OPM Excursion Import: ({0}), {1} Excursions were rejected due to validation or other errors after being converted from the OPM XHQ excursion list.",
                        dateAndTimeQueryFrom.ToShortDateAndTimeString(), rejectionList.Count));
            }

            var notifiedCount = UpdateExcursionBatch(excursions);

            logger.Debug(string.Format("OPM Excursion Import: ({0}), {1} were updated.", dateAndTimeQueryFrom,
                notifiedCount));

            return new OpmExcursionImportResult(rejectionList, excursions);
        }

        public OpmToeDefinitionImportResult ImportOpmToeDefinition(string historianTag, long? versionId)
        {
            var notifiedEvents = new List<NotifiedEvent>();
            OpmToeDefinitionImportRejection rejection;

            var toeDefinition = importer.GetOpmToeDefinition(historianTag, versionId);

            var toeDefinitionDto = toeDefinitionDTOConverter.ConvertToOpmToeDefinitionDTO(historianTag, versionId, toeDefinition, out rejection);

            if (rejection == null)
            {
                logger.Debug(
                    string.Format(
                        "OPM TOE Definition Import: (Historian Tag:{0} Version:{1}), A TOE Definition was created from the OPM XHQ data (but has not yet been processed for insert or update)",
                        historianTag, versionId));
            }
            else
            {
                logger.Debug(
                    string.Format(
                        "OPM Excursion Import: (Historian Tag:{0} Version:{1}), A TOE Definition was rejected due to validation or other errors after being converted from the OPM XHQ data.",
                        historianTag, versionId));
            }

            if (toeDefinitionDto != null)
            {
                notifiedEvents.AddRange(Update(toeDefinitionDto));
            }

            return new OpmToeDefinitionImportResult(rejection, toeDefinitionDto);
        }

        public OpmTagValueDTO GetCurrentOpmTagValue(string historianTag)
        {
            try
            {
                var opmTagValue = importer.GetCurrentTagValue(historianTag);
                return tagValueDTOConverter.ConvertToOpmTagValueDTO(opmTagValue);
            }
            catch (Exception e)
            {
                logger.Warn("OPM CURRENT TAG RETREIVAL FAILURE FOR: " + historianTag + " MESSAGE: " + e.Message);
                return null;
            }
        }

        private int UpdateExcursionBatch(List<OpmExcursionDTO> opmExcursionDTOs)
        {
            var notifiedCount = 0;
            if (opmExcursionDTOs.IsNullOrEmpty()) return notifiedCount;

            var createdExcursions = new List<OpmExcursion>();
            var updatedExcursions = new List<OpmExcursion>();

            foreach (var opmExcursionDTO in opmExcursionDTOs)
            {
                Update(opmExcursionDTO, createdExcursions, updatedExcursions);
            }

            notifiedCount += BatchNotify(createdExcursions, ApplicationEvent.OpmExcursionBatchCreate);
            notifiedCount += BatchNotify(updatedExcursions, ApplicationEvent.OpmExcursionBatchUpdate);

            return notifiedCount;
        }

        private int BatchNotify(List<OpmExcursion> excursions, ApplicationEvent applicationEvent)
        {
            var excursionSlices = new List<List<OpmExcursion>>();
            excursions.ForEachSlice(ExcursionBatchSize, excursionSlices.Add);

            foreach (var excursionSlice in excursionSlices)
            {
                var excursionBatch = new OpmExcursionBatch(
                    excursionSlice);
                ServiceUtility.PushEventIntoQueue(applicationEvent, excursionBatch);
            }

            return excursions.Count;
        }

        private void Update(OpmExcursionDTO opmExcursionDTO, List<OpmExcursion> createdExcursions,
            List<OpmExcursion> updatedExcursions)
        {
            long id;
            bool shouldNotifyOfUpdate;

            /// <summary>
            /// Changed for: INC0121679 
            /// Changed By: Komal Sahu (ksahu)
            /// Changed Date: 20/04/2017
            /// Description: If LastUpdatedDateTime contains any future date, then replace it with current date and make a log entry in the RemoteApp log file.
            /// </summary>
            /// Change starts/////////
            
            DateTime lastUpdatedDateFromOPM = opmExcursionDTO.LastUpdatedDateTime;
            if (DateTime.Compare(lastUpdatedDateFromOPM, DateTime.Now) > 0)
            {
                opmExcursionDTO.LastUpdatedDateTime = DateTime.Now;

                logger.Warn(" FUTURE DATE ERROR OCCURRED at " + Convert.ToString(DateTime.Now) + ": OLT has received LastUpdatedDateTime from OPM as " + Convert.ToString(lastUpdatedDateFromOPM) + " . And it is being replaced by current date " + Convert.ToString(opmExcursionDTO.LastUpdatedDateTime)+" . ");
            }

            /// Change Ends/////////
            
            if (ExcursionExists(opmExcursionDTO, out id, out shouldNotifyOfUpdate))
            {
                opmExcursionDTO.Id = id;

                var excursionToUpdate = excursionDTOConverter.ConvertToOpmExcursion(opmExcursionDTO);

                excursionDao.Update(excursionToUpdate);
                SetExcursionResponse(excursionToUpdate);
                if (shouldNotifyOfUpdate)
                {
                    updatedExcursions.Add(excursionToUpdate);
                }
            }
            else
            {
                var excursionToInsert = excursionDTOConverter.ConvertToOpmExcursion(opmExcursionDTO);

                excursionDao.Insert(excursionToInsert);
                SetExcursionResponse(excursionToInsert);

                createdExcursions.Add(excursionToInsert);
            }
        }

        private void SetExcursionResponse(OpmExcursion excursion)
        {
            if (excursion == null || excursion.Id.HasValue == false) return;

            var excursionResponse = excursionResponseDao.QueryByExcursionId(excursion.Id.Value) ??
                                    new OpmExcursionResponse(excursion);

            excursion.OpmExcursionResponse = excursionResponse;
        }

        private bool ExcursionExists(OpmExcursionDTO excursionDto, out long id, out bool shouldNotifyOfUpdate)
        {
            var existingExcursion = excursionDao.QueryByOpmExcursionId(excursionDto.OpmExcursionId);

            id = existingExcursion != null ? existingExcursion.IdValue : -1;

            shouldNotifyOfUpdate = true;
            if (existingExcursion != null)
            {
                if (
                    excursionDto.EndDateTime == existingExcursion.EndDateTime
                    &&
                    excursionDto.Status == existingExcursion.Status
                    &&
                    excursionDto.Peak == existingExcursion.Peak
                    &&
                    excursionDto.IlpNumber == existingExcursion.IlpNumber
                    &&
                    excursionDto.EngineerComments == existingExcursion.EngineerComments
                    &&
                    excursionDto.ReasonCode == existingExcursion.ReasonCode
                    )
                {
                    shouldNotifyOfUpdate = false;
                     }
            }


            return existingExcursion != null;
        }

        private List<NotifiedEvent> Update(OpmToeDefinitionDTO toeDefinitionDTO)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            long id;
            bool shouldUpdateAndNotify;

            if (ToeDefinitionExists(toeDefinitionDTO, out id, out shouldUpdateAndNotify))
            {
                toeDefinitionDTO.Id = id;

                var toeDefinitionToUpdate = toeDefinitionDTOConverter.ConvertToOpmToeDefinition(toeDefinitionDTO);

                if (shouldUpdateAndNotify)
                {
                    toeDefinitionDao.Update(toeDefinitionToUpdate);

// TODO: enable event notification for TOE updates only when the client begins processing them
//                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.OpmToeDefinitionUpdate,
//                    toeDefinitionToUpdate));
                }
            }
            else
            {
                var toeDefinitionToInsert = toeDefinitionDTOConverter.ConvertToOpmToeDefinition(toeDefinitionDTO);

                toeDefinitionDao.Insert(toeDefinitionToInsert);

// TODO: enable event notification for TOE updates only when the client begins processing them
//                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.OpmToeDefinitionCreate,
//                    toeDefinitionToInsert));
            }

            return notifiedEvents;
        }

        private bool ToeDefinitionExists(OpmToeDefinitionDTO toeDefinitionDTO, out long id, out bool shouldUpdateAndNotify)
        {
            var existingToeDefinition = toeDefinitionDao.QueryByTagAndVersion(toeDefinitionDTO.HistorianTag,
                toeDefinitionDTO.ToeVersion);

            id = existingToeDefinition != null ? existingToeDefinition.IdValue : -1;
            shouldUpdateAndNotify = true;

            if (existingToeDefinition != null)
            {
                if (existingToeDefinition.HistorianTag == toeDefinitionDTO.HistorianTag
                    && existingToeDefinition.ToeVersion == toeDefinitionDTO.ToeVersion
                    && existingToeDefinition.ToeVersionPublishDate == toeDefinitionDTO.ToeVersionPublishDate)
                {
                    shouldUpdateAndNotify = false;
                }
            }

            return existingToeDefinition != null;
        }
    }
}