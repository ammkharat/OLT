using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmExcursionEventPriorityPageDTODao : AbstractManagedDao, IOpmExcursionEventPriorityPageDTODao
    {
        private const string QUERY_UNRESPONDED_EXCURSIONS_OPEN_OR_RECENTLY_CLOSED =
            "QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed";

        private const string QUERY_RESPONDED_EXCURSIONS_STILL_EXCEEDING_OPERATING_LIMITS =
            "QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits";

        private readonly IOpmExcursionDao excursionDao;
        private readonly IOpmExcursionResponseDao opmExcursionResponseDao;
        private readonly IOpmToeDefinitionDao opmToeDefinitionDao;
        private readonly IOpmToeDefinitionCommentDao opmToeDefinitionCommentDao;

        public OpmExcursionEventPriorityPageDTODao()
        {
            excursionDao = DaoRegistry.GetDao<IOpmExcursionDao>();
            opmExcursionResponseDao = DaoRegistry.GetDao<IOpmExcursionResponseDao>();
            opmToeDefinitionDao = DaoRegistry.GetDao<IOpmToeDefinitionDao>();
            opmToeDefinitionCommentDao = DaoRegistry.GetDao<IOpmToeDefinitionCommentDao>();
        }

        public List<ExcursionEventPriorityPageDTO>
            QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(
            DateTime fromDateTime, List<FunctionalLocation> flocs)
        {
            var csvFunctionalLocationIds = flocs.BuildIdStringFromList();

            var command = ManagedCommand;
            command.AddParameter("@FromDateTime", fromDateTime.ToSQLServerFriendlyDate());
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            return command.QueryForListResult(PopulateInstance, QUERY_UNRESPONDED_EXCURSIONS_OPEN_OR_RECENTLY_CLOSED);
        }

        public List<ExcursionEventPriorityPageDTO>
            QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(
            DateTime fromDateTime, List<FunctionalLocation> flocs)
        {
            var csvFunctionalLocationIds = flocs.BuildIdStringFromList();

            var command = ManagedCommand;
            command.AddParameter("@FromDateTime", fromDateTime.ToSQLServerFriendlyDate());
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            return command.QueryForListResult(PopulateInstance,
                QUERY_RESPONDED_EXCURSIONS_STILL_EXCEEDING_OPERATING_LIMITS);
        }

        private ExcursionEventPriorityPageDTO PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("ExcursionId");
            var floc = reader.Get<string>("FunctionalLocation");

            var historianTag = reader.Get<string>("HistorianTag");
            var toeVersion = reader.Get<long>("ToeVersion");
            var toeName = reader.Get<string>("ToeName");
            var toeType = ToeType.Get(reader.Get<int>("ToeType"));
            var status = ExcursionStatus.Get(reader.Get<int>("Status"));
            var startDate = reader.Get<DateTime>("StartDateTime");
            var endDate = reader.Get<DateTime?>("EndDateTime");
            var lastUpdatedDate = reader.Get<DateTime>("LastUpdatedDateTime");
            var hasResponse = reader.Get<int>("HasResponse") == 1;
            var excursionIds = reader.Get<string>("ExcursionIds");

            var excursionIdList = CreateListOfIdsFromCommaString(excursionIds);

            var excursionList = GetExcursions(excursionIdList);

            var result = new ExcursionEventPriorityPageDTO(
                id, new List<string> {floc}, excursionList, historianTag, toeVersion, status, toeType, toeName,
                startDate, endDate, lastUpdatedDate,
                hasResponse);

            return result;
        }

        private List<OpmExcursion> GetExcursions(List<long> excursionIdList)
        {
            var excursions = new List<OpmExcursion>();

            foreach (
                var excursion in
                    excursionIdList.Select(QueryOpmExcursionById)
                        .Where(excursion => excursion != null && !excursions.Contains(excursion)))
            {
                excursions.Add(excursion);
            }

            return excursions;
        }

        private static List<long> CreateListOfIdsFromCommaString(string commaString)
        {
            var idList = new List<long>();
            if (string.IsNullOrWhiteSpace(commaString)) return idList;

            var ids = commaString.Split(',');
            if (ids.Length <= 0) return idList;

            foreach (var id in ids)
            {
                int convertedId;
                if (int.TryParse(id, out convertedId))
                {
                    idList.Add(convertedId);
                }
            }

            return idList;
        }

        public OpmExcursion QueryOpmExcursionById(long idValue)
        {
            var opmExcursion = excursionDao.QueryById(idValue);
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

    }
}