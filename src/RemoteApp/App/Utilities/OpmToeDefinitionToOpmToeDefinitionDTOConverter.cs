using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Validation.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using OpmToeDefinitionRemote = Com.Suncor.Olt.Remote.Integration;
using OpmToeDefinitionDomain = Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class OpmToeDefinitionToOpmToeDefinitionDTOConverter
    {
        private readonly IFunctionalLocationDao functionalLocationDao;

        public OpmToeDefinitionToOpmToeDefinitionDTOConverter(IFunctionalLocationDao functionalLocationDao)
        {
            this.functionalLocationDao = functionalLocationDao;
        }

        public OpmToeDefinitionDTO ConvertToOpmToeDefinitionDTO(string historianTag, long? versionId,
            OpmToeDefinitionRemote.OpmToeDefinition toeDefinition,
            out OpmToeDefinitionDomain.OpmToeDefinitionImportRejection rejection)
        {
            var toeDefinitionDto = BuildOpmToeDefinitionDTO(historianTag, versionId, toeDefinition, out rejection);

            return toeDefinitionDto;
        }

        public OpmToeDefinitionDomain.OpmToeDefinition ConvertToOpmToeDefinition(OpmToeDefinitionDTO toeDefinitionDto)
        {
            if (toeDefinitionDto == null) return null;

            var toeDefinition = new OpmToeDefinitionDomain.OpmToeDefinition(toeDefinitionDto.IdValue,
                toeDefinitionDto.ToeVersion,
                toeDefinitionDto.HistorianTag, toeDefinitionDto.ToeVersionPublishDate, toeDefinitionDto.ToeName,
                toeDefinitionDto.FunctionalLocation, toeDefinitionDto.FunctionalLocationId, toeDefinitionDto.ToeType,
                toeDefinitionDto.LimitValue,
                toeDefinitionDto.CausesDescription, toeDefinitionDto.ConsequencesDescription,
                toeDefinitionDto.CorrectiveActionDescription, toeDefinitionDto.ReferencesDocuments,
                toeDefinitionDto.UnitOfMeasure, toeDefinitionDto.OpmToeHistoryUrl);

            return toeDefinition;
        }

        private OpmToeDefinitionDTO BuildOpmToeDefinitionDTO(string historianTag, long? versionId,
            OpmToeDefinitionRemote.OpmToeDefinition toeDefinition,
            out OpmToeDefinitionDomain.OpmToeDefinitionImportRejection rejection)
        {
            if (toeDefinition == null)
            {
                rejection =
                    new OpmToeDefinitionDomain.OpmToeDefinitionImportRejection(
                        string.Format(
                            "No data returned by OPM TOE definition web service for (Historian Tag: {0} Version: {1})",
                            historianTag, versionId));
                return null;
            }

            long toeId = 0;
            var toeType = OpmXhqImporterDataConversionUtility.GetToeType(toeDefinition.ToeType);
            var toeVersionPublishDate =
                OpmXhqImporterDataConversionUtility.ConvertNullableDateTimeToDateTimeValue(
                    toeDefinition.ToeVersionPublishDate);
            var toeLimitValue =
                OpmXhqImporterDataConversionUtility.ConvertNullableDecimalToDecimalValue(toeDefinition.ToeLimitValue);

            var toeDefinitionDto = new OpmToeDefinitionDTO(toeId, toeDefinition.ToeVersion, toeDefinition.HistorianTag,
                toeVersionPublishDate, toeDefinition.ToeName, toeDefinition.FunctionalLocation, -1, toeType,
                toeLimitValue, toeDefinition.CauseDescription, toeDefinition.ConsequenceDescription,
                toeDefinition.CorrectiveActionDescription, null, toeDefinition.UnitOfMeasure,
                toeDefinition.OPMPubHistoryURLLink);

            rejection = Validate(toeDefinitionDto);

            if (rejection == null)
            {
                return toeDefinitionDto;
            }

            return null;
        }

        private OpmToeDefinitionDomain.OpmToeDefinitionImportRejection Validate(OpmToeDefinitionDTO opmToeDefinitionDTO)
        {
            OpmToeDefinitionDomain.OpmToeDefinitionImportRejection rejection = null;

            long? flocId = null;

            if (opmToeDefinitionDTO.ToeType == OpmToeDefinitionDomain.ToeType.InvalidToeType)
            {
                var message =
                    string.Format(StringResources.OpmToeDefinitionImportValidationError_InvalidToeType,
                        opmToeDefinitionDTO.ToeType.TagValue);

                rejection = BuildRejection(message, opmToeDefinitionDTO);
                return rejection;
            }

            if (!string.IsNullOrEmpty(opmToeDefinitionDTO.FunctionalLocation) &&
                FunctionalLocationNotFound(opmToeDefinitionDTO.FunctionalLocation, out flocId))
            {
                var message =
                    string.Format(StringResources.OpmToeDefinitionImportValidationError_FunctionalLocationNotFound,
                        opmToeDefinitionDTO.FunctionalLocation);

                rejection = BuildRejection(message, opmToeDefinitionDTO);
                return rejection;
            }

            opmToeDefinitionDTO.FunctionalLocationId = flocId.Value;

            {
                var stringFieldsTooLongList = GetStringsTooLongImportFieldList(opmToeDefinitionDTO);

                if (stringFieldsTooLongList.Count > 0)
                {
                    var errorMessage =
                        string.Format(StringResources.OpmToeDefinitionImportValidationError_StringFieldTooLong,
                            stringFieldsTooLongList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, opmToeDefinitionDTO);
                    return rejection;
                }
            }

            {
                var missingFieldList = GetMissingImportFieldList(opmToeDefinitionDTO);

                if (missingFieldList.Count > 0)
                {
                    var errorMessage = string.Format(StringResources.OpmToeDefinitionImportValidationError_FieldMissing,
                        missingFieldList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, opmToeDefinitionDTO);
                }
            }

            return rejection;
        }

        private List<string> GetStringsTooLongImportFieldList(OpmToeDefinitionDTO opmToeDefinitionDTO)
        {
            var validator = new OpmToeDefinitionValidator(opmToeDefinitionDTO);
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

        private List<string> GetMissingImportFieldList(OpmToeDefinitionDTO opmToeDefinitionDTO)
        {
            var validator = new OpmToeDefinitionValidator(opmToeDefinitionDTO);
            validator.Validate();
            return validator.MissingImportFieldList;
        }

        private static OpmToeDefinitionDomain.OpmToeDefinitionImportRejection BuildRejection(string reason,
            OpmToeDefinitionDTO opmToeDefinitionDTO)
        {
            return new OpmToeDefinitionDomain.OpmToeDefinitionImportRejection(
                reason, opmToeDefinitionDTO.FunctionalLocation, opmToeDefinitionDTO.ToeName,
                opmToeDefinitionDTO.ToeType.Name,
                string.Format("{0}", opmToeDefinitionDTO.ToeVersion),
                opmToeDefinitionDTO.ToeVersionPublishDate.ToShortDateAndTimeString(),
                opmToeDefinitionDTO.UnitOfMeasure,
                string.Format("{0}", opmToeDefinitionDTO.LimitValue),
                opmToeDefinitionDTO.OpmToeHistoryUrl,
                opmToeDefinitionDTO.HistorianTag,
                opmToeDefinitionDTO.CausesDescription,
                opmToeDefinitionDTO.ConsequencesDescription,
                opmToeDefinitionDTO.CorrectiveActionDescription,
                opmToeDefinitionDTO.ReferencesDocuments);
        }
    }
}