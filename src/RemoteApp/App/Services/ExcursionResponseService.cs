using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ExcursionResponseService : IExcursionResponseService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ExcursionResponseService));

        private readonly IOpmExcursionResponseDTODao dtoDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly ILogService logService;
        private readonly IOpmExcursionDao opmExcursionDao;
        private readonly IOpmExcursionEventPriorityPageDTODao opmExcursionEventPriorityPageDTODao;
        private readonly IOpmExcursionResponseDao opmExcursionResponseDao;
        private readonly IOpmToeDefinitionCommentDao opmToeDefinitionCommentDao;
        private readonly IOpmToeDefinitionDao opmToeDefinitionDao;


        public ExcursionResponseService()
        {
            opmExcursionDao = DaoRegistry.GetDao<IOpmExcursionDao>();
            opmExcursionResponseDao = DaoRegistry.GetDao<IOpmExcursionResponseDao>();
            opmExcursionEventPriorityPageDTODao = DaoRegistry.GetDao<IOpmExcursionEventPriorityPageDTODao>();
            opmToeDefinitionDao = DaoRegistry.GetDao<IOpmToeDefinitionDao>();
            logService = new LogService();
            opmToeDefinitionCommentDao = DaoRegistry.GetDao<IOpmToeDefinitionCommentDao>();
            dtoDao = DaoRegistry.GetDao<IOpmExcursionResponseDTODao>();
            editHistoryService = new EditHistoryService();
        }

        public List<OpmExcursionResponseDTO> QueryDTOsByDateRangeAndFlocs(DateRange dateRange, List<FunctionalLocation> flocs)
        {
            return dtoDao.QueryByDateRangeAndFlocs(dateRange, flocs);
        }

        public List<OpmExcursionResponseDTO> QueryDTOsByDateRangeAndFlocsForShiftHandover(DateTime startOfShift,
            DateTime endOfShift, List<FunctionalLocation> flocs)
        {
            return dtoDao.QueryByDateRangeAndFlocsForShiftHandover(startOfShift, endOfShift, flocs);
        }

        public OpmExcursion QueryById(long idValue)
        {
            var opmExcursion = opmExcursionDao.QueryById(idValue);
            var opmExcursionResponse = opmExcursionResponseDao.QueryByExcursionId(opmExcursion.IdValue);
            opmExcursion.OpmExcursionResponse = opmExcursionResponse ?? new OpmExcursionResponse(opmExcursion);
            var opmToeDefinition = opmToeDefinitionDao.QueryByTagAndVersion(opmExcursion.HistorianTag,
                opmExcursion.ToeVersion);
            opmExcursion.OpmToeDefinition = opmToeDefinition;

            if (opmToeDefinition != null && opmToeDefinition.Id.HasValue)
            {
                var opmToeDefinitionComment =
                    opmToeDefinitionCommentDao.QueryByOltToeDefinitionId(opmToeDefinition.IdValue);
                opmExcursion.OpmToeDefinition.OpmToeDefinitionComment = opmToeDefinitionComment ??
                                                                        new OpmToeDefinitionComment(opmToeDefinition);
            }
            return opmExcursion;
        }

        public OpmExcursionEditPackage CreateEditPackage(List<long> opmExcursionIds)
        {
            if (opmExcursionIds.Count == 0) return null;
            var opmExcursions = new List<OpmExcursion>();

            foreach (var opmExcursionId in opmExcursionIds)
            {
                var opmExcursion = opmExcursionDao.QueryById(opmExcursionId);
                var opmExcursionResponse = opmExcursionResponseDao.QueryByExcursionId(opmExcursion.IdValue);
                opmExcursion.OpmExcursionResponse = opmExcursionResponse ?? new OpmExcursionResponse(opmExcursion);
                opmExcursions.Add(opmExcursion);
            }
            var lastOpmExcursion = opmExcursions.OrderBy(excursion => excursion.StartDateTime).Last();
            var opmToeDefinition = opmToeDefinitionDao.QueryByTagAndVersion(lastOpmExcursion.HistorianTag,
                lastOpmExcursion.ToeVersion);
            if (opmToeDefinition != null)
            {
                opmExcursions.OrderBy(excursion => excursion.StartDateTime).Last().OpmToeDefinition = opmToeDefinition;
                var opmToeDefinitionComment =
                    opmToeDefinitionCommentDao.QueryByOltToeDefinitionId(opmToeDefinition.IdValue);
                opmExcursions.OrderBy(excursion => excursion.StartDateTime)
                    .Last()
                    .OpmToeDefinition.OpmToeDefinitionComment
                    = opmToeDefinitionComment ??
                      new OpmToeDefinitionComment(opmToeDefinition);
            }
            return new OpmExcursionEditPackage(opmExcursions);
        }

        public List<NotifiedEvent> UpdateEditPackageChanges(OpmExcursionEditPackage editedPackage)
        {
            var notifiedEvents = new List<NotifiedEvent>();
            if (editedPackage.IsToeCommentDirty && editedPackage.OpmToeDefinition != null)
            {
                var opmToeDefinitionComment = editedPackage.OpmToeDefinition.OpmToeDefinitionComment;
                if (opmToeDefinitionComment.IsInDatabase())
                {
                    opmToeDefinitionCommentDao.Update(opmToeDefinitionComment);
                }
                else
                {
                    opmToeDefinitionCommentDao.Insert(opmToeDefinitionComment);
                }
                editHistoryService.TakeSnapshot(opmToeDefinitionComment);
            }

            foreach (var excursion in editedPackage.Excursions)
            {
                if (excursion.OpmExcursionResponse.IsDirty)
                {
                    var existingResponse = opmExcursionResponseDao.QueryByExcursionId(excursion.IdValue);
                    if (existingResponse != null)
                    {
                        excursion.OpmExcursionResponse.Id = existingResponse.Id;
                        opmExcursionResponseDao.Update(excursion.OpmExcursionResponse);
                    }
                    else
                    {
                        opmExcursionResponseDao.Insert(excursion.OpmExcursionResponse);
                    }
                    editHistoryService.TakeSnapshot(excursion.OpmExcursionResponse);
                    notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.OpmExcursionUpdate,
                        excursion));
                }
            }

            if (editedPackage.ExcursionLog != null)
            {
                notifiedEvents.AddRange(logService.Insert(editedPackage.ExcursionLog));
            }

            // handle the case where the only thing changed was the toe def so grid and event details are updated.
            if (
                !editedPackage.Excursions.Any(excursion => excursion.OpmExcursionResponse.IsDirty)
                &&
                editedPackage.IsToeCommentDirty)
            {
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.OpmExcursionUpdate,
                    editedPackage.Excursions.First()));
            }

            return notifiedEvents;
        }

        public List<ExcursionEventPriorityPageDTO>
            QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(DateTime fromDateTime,
                List<FunctionalLocation> flocs)
        {
            var excursionEvents =
                opmExcursionEventPriorityPageDTODao
                    .QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(fromDateTime, flocs);

            return excursionEvents;
        }

        public List<ExcursionEventPriorityPageDTO>
            QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(DateTime fromDateTime,
                List<FunctionalLocation> flocs)
        {
            var excursionEvents =
                opmExcursionEventPriorityPageDTODao
                    .QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(fromDateTime,
                        flocs);

            return excursionEvents;
        }
    }
}