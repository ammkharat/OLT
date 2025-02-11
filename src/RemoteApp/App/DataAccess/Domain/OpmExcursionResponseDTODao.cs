﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmExcursionResponseDTODao : AbstractManagedDao, IOpmExcursionResponseDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_NAMES = "QueryOpmExcursionResponseDTOByDateRangeAndFlocNames";
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_NAMES_FOR_SHIFT_HANDOVER = "QueryOpmExcursionResponseDTOForShiftHandover";
        private readonly ILog logger = GenericLogManager.GetLogger<OpmExcursionResponseDTODao>();
        private readonly IUserDao userDao;

        public OpmExcursionResponseDTODao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();

        }

        public List<OpmExcursionResponseDTO> QueryByDateRangeAndFlocs(DateRange dateRange, List<FunctionalLocation> flocs)
        {
            var csvFunctionalLocationIds =
                flocs.BuildIdStringFromList();
            var command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult(PopulateInstance, QUERY_BY_DATE_RANGE_AND_FLOC_NAMES);
        }
        public List<OpmExcursionResponseDTO> QueryByDateRangeAndFlocsForShiftHandover(DateTime startOfShift,DateTime endOfShift, List<FunctionalLocation> flocs)
        {
            var csvFunctionalLocationIds =
                flocs.BuildIdStringFromList();
            var command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", startOfShift);
            command.AddParameter("@EndOfDateRange", endOfShift);

            return command.QueryForListResult(PopulateInstance, QUERY_BY_DATE_RANGE_AND_FLOC_NAMES_FOR_SHIFT_HANDOVER);
        }


        private  OpmExcursionResponseDTO PopulateInstance(SqlDataReader reader)
        {
            var fullNameOfLastModifiedByWithUserName = string.Empty;
            var lastModfiedById = reader.Get<long?>("LastModifiedByUserId");
            var responseLastUpdatedDateTime = default(DateTime?);
            if (lastModfiedById.HasValue)
            {
                var lastModifiedBy = userDao.QueryById(lastModfiedById.Value);

                fullNameOfLastModifiedByWithUserName = lastModifiedBy.FullNameWithUserName;
                responseLastUpdatedDateTime = reader.Get<DateTime?>("LastModifiedDateTime");
            }
            var id = reader.Get<long>("Id");
            var opmExcursionId = reader.Get<long>("OpmExcursionId");
            var functionalLocation = reader.Get<string>("FunctionalLocation");
            var toeName = reader.Get<string>("ToeName");
            var toeType = ToeType.Get(reader.Get<int>("ToeType"));
            var excursionStatus = ExcursionStatus.Get(reader.Get<int>("Status"));
            var startDateTime = reader.Get<DateTime>("StartDateTime");
            var endDateTime = reader.Get<DateTime?>("EndDateTime");
            var unitOfMeasure = reader.Get<string>("UnitOfMeasure");
            var peak = reader.Get<decimal>("Peak");
            var average = reader.Get<decimal>("Average");
            var duration = reader.Get<int>("Duration");
            var ilpNumber = reader.Get<long?>("IlpNumber");
            var engineerComments = reader.Get<string>("EngineerComments");
            var oltOperatorResponse = reader.Get<string>("Response");
            var reasonCode = reader.Get<string>("ReasonCode");
            var toeLimitValue = reader.Get<decimal>("ToeLimitValue");

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            var assest = reader.Get<string>("Asset");
            var code = reader.Get<string>("Code");

            return new OpmExcursionResponseDTO(
                id, opmExcursionId,
                functionalLocation,
                toeName,
                toeType,
                excursionStatus,
                startDateTime,
                endDateTime,
                unitOfMeasure,
                peak,
                average,
                duration,
                ilpNumber,
                engineerComments,
                oltOperatorResponse,
                reasonCode,
                responseLastUpdatedDateTime,
                fullNameOfLastModifiedByWithUserName,
                toeLimitValue,
                assest, //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
                code
                );
        }
    }
}