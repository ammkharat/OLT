using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.Validation.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;
using DevExpress.Office.Utils;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class OpmExcursionToOpmExcursionDTOConverter
    {
        private readonly IFunctionalLocationDao functionalLocationDao;

        public OpmExcursionToOpmExcursionDTOConverter(IFunctionalLocationDao functionalLocationDao)
        {
            this.functionalLocationDao = functionalLocationDao;
        }

        public List<OpmExcursionDTO> ConvertToOpmExcursionDTOs(IEnumerable<OPMExcursion> excursionList,
            out List<OpmExcursionImportRejection> rejectionList)
        {
            rejectionList = new List<OpmExcursionImportRejection>();

            var excursionDtos = new List<OpmExcursionDTO>();

            foreach (var opmExcursion in excursionList ?? new List<OPMExcursion>())
            {
                OpmExcursionImportRejection rejection;

                var opmExcursionDTO = BuildOpmExcursionDTO(opmExcursion, out rejection);

                if (opmExcursionDTO != null)
                {
                    excursionDtos.Add(opmExcursionDTO);
                }
                else if (rejection != null)
                {
                    rejectionList.Add(rejection);
                }
            }

            return excursionDtos;
        }

        public OpmExcursion ConvertToOpmExcursion(OpmExcursionDTO excursionDto)
        {
            if (excursionDto == null) return null;

            var opmExcursion = new OpmExcursion(excursionDto.IdValue, excursionDto.OpmExcursionId,
                excursionDto.ToeVersion, excursionDto.HistorianTag, excursionDto.FunctionalLocation,
                excursionDto.FunctionalLocationId,
                excursionDto.ToeName, excursionDto.ToeType, excursionDto.Status, excursionDto.StartDateTime,
                excursionDto.EndDateTime, excursionDto.UnitOfMeasure, excursionDto.Peak, excursionDto.Average,
                excursionDto.Duration, excursionDto.OpmTrendUrl, excursionDto.IlpNumber, excursionDto.EngineerComments,
                excursionDto.ReasonCode, excursionDto.LastUpdatedDateTime, excursionDto.ToeLimitValue);

            return opmExcursion;
        }

        private OpmExcursionDTO BuildOpmExcursionDTO(OPMExcursion excursion,
            out OpmExcursionImportRejection rejection)
        {
            var toeType = OpmXhqImporterDataConversionUtility.GetToeType(excursion.ToeType);
            var excursionStatus = OpmXhqImporterDataConversionUtility.GetExcursionStatus(excursion.Status);
            var toePeakValue = OpmXhqImporterDataConversionUtility.ConvertNullableDecimalToDecimalValue(excursion.Peak);
            var toeAverageValue =
                OpmXhqImporterDataConversionUtility.ConvertNullableDecimalToDecimalValue(excursion.Average);
            var toeDurationValue =
                OpmXhqImporterDataConversionUtility.ConvertNullableDecimalToDecimalValue(excursion.Duration);
            var lastUpdatedDateTime =
                OpmXhqImporterDataConversionUtility.ConvertNullableDateTimeToDateTimeValue(excursion.LastUpdatedDateTime);
            var toeLimitValue =
                OpmXhqImporterDataConversionUtility.ConvertNullableDecimalToDecimalValue(excursion.ToeLimitValue);

            var opmExcursionDto = new OpmExcursionDTO(-1, excursion.ExcursionId, excursion.ToeVersion,
                excursion.HistorianTag,
                excursion.FunctionalLocation, -1,
                excursion.ToeName, toeType, excursionStatus, excursion.StartDateTime, excursion.EndDateTime,
                lastUpdatedDateTime,
                excursion.UnitOfMeasure, toePeakValue, toeAverageValue, toeDurationValue, excursion.IlpNumber,
                excursion.EngineerComments, excursion.ReasonCode, toeLimitValue, excursion.OPMTrendURLLink);

            rejection = Validate(opmExcursionDto);

            if (rejection == null)
            {
                return opmExcursionDto;
            }

            return null;
        }

        private OpmExcursionImportRejection Validate(OpmExcursionDTO opmExcursionDto)
        {
            OpmExcursionImportRejection rejection = null;

            long? flocId = null;

            if (opmExcursionDto.ToeType == ToeType.InvalidToeType)
            {
                var message =
                    string.Format(StringResources.OpmToeDefinitionImportValidationError_InvalidToeType,
                        opmExcursionDto.ToeType.TagValue);

                rejection = BuildRejection(message, opmExcursionDto);
                return rejection;
            }

            if (opmExcursionDto.Status == ExcursionStatus.InvalidExcursionStatus)
            {
                var message =
                    string.Format(StringResources.OpmExcursionImportValidationError_InvalidExcursionStatus,
                        opmExcursionDto.Status.TagValue);

                rejection = BuildRejection(message, opmExcursionDto);
                return rejection;
            }

            if (!string.IsNullOrEmpty(opmExcursionDto.FunctionalLocation) &&
                FunctionalLocationNotFound(opmExcursionDto.FunctionalLocation, out flocId))
            {
                var message =
                    string.Format(StringResources.OpmExcursionImportValidationError_FunctionalLocationNotFound,
                        opmExcursionDto.FunctionalLocation);

                rejection = BuildRejection(message, opmExcursionDto);
                return rejection;
            }

            opmExcursionDto.FunctionalLocationId = flocId.Value;

            {
                var stringFieldsTooLongList = GetStringsTooLongImportFieldList(opmExcursionDto);

                if (stringFieldsTooLongList.Count > 0)
                {
                    var errorMessage =
                        string.Format(StringResources.OpmExcursionImportValidationError_StringFieldTooLong,
                            stringFieldsTooLongList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, opmExcursionDto);
                    return rejection;
                }
            }

            {
                var missingFieldList = GetMissingImportFieldList(opmExcursionDto);

                if (missingFieldList.Count > 0)
                {
                    var errorMessage = string.Format(StringResources.OpmExcursionImportValidationError_FieldMissing,
                        missingFieldList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, opmExcursionDto);
                }
            }

            return rejection;
        }

        private List<string> GetStringsTooLongImportFieldList(OpmExcursionDTO opmExcursionDto)
        {
            var validator = new OpmExcursionValidator(opmExcursionDto);
            validator.Validate();
            return validator.StringFieldTooLongList;
        }

        private bool FunctionalLocationNotFound(string functionalLocation, out long? flocId)
        {
            flocId = null;
            var floc = functionalLocationDao.QueryByFullHierarchyIncludeDeletedToTestExistence(functionalLocation);
            if (floc == null) return true;

            flocId = floc.Id;
            return floc.Id.HasValue == false;
        }

        private List<string> GetMissingImportFieldList(OpmExcursionDTO opmExcursionDto)
        {
            var validator = new OpmExcursionValidator(opmExcursionDto);
            validator.Validate();
            return validator.MissingImportFieldList;
        }

        private static OpmExcursionImportRejection BuildRejection(string reason, OpmExcursionDTO opmExcursionDto)
        {
            return new OpmExcursionImportRejection(
                reason, opmExcursionDto.FunctionalLocation, opmExcursionDto.ToeName, opmExcursionDto.ToeType.Name,
                string.Format("{0}", opmExcursionDto.ToeVersion),
                opmExcursionDto.Status.Name, opmExcursionDto.StartDateTime.ToShortDateAndTimeString(),
                opmExcursionDto.EndDateTime.ToShortDateAndTimeStringOrEmptyString(), opmExcursionDto.UnitOfMeasure,
                string.Format("{0}", opmExcursionDto.Peak), string.Format("{0}", opmExcursionDto.Average),
                string.Format("{0}", opmExcursionDto.Duration), string.Format("{0}", opmExcursionDto.IlpNumber),
                opmExcursionDto.EngineerComments, null, opmExcursionDto.ReasonCode,
                string.Format("{0}", opmExcursionDto.ToeLimitValue),
                opmExcursionDto.OpmTrendUrl, opmExcursionDto.HistorianTag);
        }
    }
}