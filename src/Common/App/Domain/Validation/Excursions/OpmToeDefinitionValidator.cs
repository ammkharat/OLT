using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Validation.Excursions
{
    public class OpmToeDefinitionValidator
    {
        private const int MaxCharLengthSmallText = 255;
        private const int MaxCharLengthMediumText = 400;
        private const int MaxCharLengthLargeText = 2000;

        private readonly List<string> missingFields;

        private readonly OpmToeDefinitionDTO opmToeDefinition;
        private readonly List<string> stringFieldsTooLong;
        private bool hasErrors;
        private bool hasWarnings;
        private bool validateHasRun;

        public OpmToeDefinitionValidator(OpmToeDefinitionDTO opmToeDefinition)
        {
            this.opmToeDefinition = opmToeDefinition;
            missingFields = new List<string>();
            stringFieldsTooLong = new List<string>();
        }

        public bool HasErrors
        {
            get
            {
                if (!validateHasRun)
                {
                    throw new InvalidOperationException("Validation has not been executed.");
                }

                return hasErrors;
            }
        }

        public bool HasWarnings
        {
            get
            {
                if (!validateHasRun)
                {
                    throw new InvalidOperationException("Validation has not been executed.");
                }

                return hasWarnings;
            }
        }

        public List<string> MissingImportFieldList
        {
            get { return missingFields; }
        }

        public List<string> StringFieldTooLongList
        {
            get { return stringFieldsTooLong; }
        }

        private void ClearErrors()
        {
            hasWarnings = false;
            hasErrors = false;
            missingFields.Clear();
            stringFieldsTooLong.Clear();
        }

        private void SetHasWarning()
        {
            hasWarnings = true;
        }

        private void SetHasError()
        {
            hasErrors = true;
        }

        private void ValidatePublishDate()
        {
            if (opmToeDefinition.ToeVersionPublishDate == DateTime.MinValue)
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_ToeVersionPublishDate);
                SetHasError();
            }
        }

        public void Validate()
        {
            validateHasRun = true;

            ClearErrors();

            // TODO: enable validations after correct data is being returned by the OPM service

            ValidateHasFunctionalLocation();
            ValidateHasToeName();
            ValidateHasToeVersion();
            ValidatePublishDate();
            ValidateHasToeType();
            ValidateHasHistorianTag();
            ValidateHasLimit();
            ValidateHasUnitOfMeasure();
            ValidateHasToeHistoryUrl();
            ValidateHasCausesDescription();
            ValidateHasConsequencesDescription();
            ValidateHasCorrectiveActionDescription();
            ValidateHasReferenceDocuments();
        }

        private void ValidateHasToeHistoryUrl()
        {
//            if (opmToeDefinition.OpmToeHistoryUrl.IsNullOrEmptyOrWhitespace())
//            {
//                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_OpmToeHistoryUrl);
//                SetHasError();
//            }

            if (opmToeDefinition.OpmToeHistoryUrl.Exceeds(MaxCharLengthMediumText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_OpmToeHistoryUrl);
                SetHasError();
            }
        }

        private void ValidateHasLimit()
        {
//            if (opmToeDefinition.LimitValue.IsNullOrEmptyOrWhitespace())
//            {
//                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_ToeLimitValue);
//                SetHasError();
//            }
//            if (opmToeDefinition.LimitValue.Exceeds(MaxCharLengthTinyText))
//            {
//                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_ToeLimitValue);
//                SetHasError();
//            }
        }

        private void ValidateHasUnitOfMeasure()
        {
            if (opmToeDefinition.UnitOfMeasure.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_UnitOfMeasure);
                SetHasError();
            }
        }

        private void ValidateHasHistorianTag()
        {
            if (opmToeDefinition.HistorianTag.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_HistorianTag);
                SetHasError();
            }
            else if (opmToeDefinition.HistorianTag.Exceeds(MaxCharLengthSmallText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_HistorianTag);
                SetHasError();
            }
        }

        private void ValidateHasToeType()
        {
            if (opmToeDefinition.ToeType.Name.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_ToeType);
                SetHasError();
            }
        }

        private void ValidateHasToeVersion()
        {
            if (opmToeDefinition.ToeVersion < 0)
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_ToeVersion);
                SetHasError();
            }
        }

        private void ValidateHasToeName()
        {
            if (opmToeDefinition.ToeName.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_ToeName);
                SetHasError();
            }
            else if (opmToeDefinition.ToeName.Exceeds(MaxCharLengthSmallText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_ToeName);
                SetHasError();
            }
        }

        private void ValidateHasFunctionalLocation()
        {
            if (opmToeDefinition.FunctionalLocation.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmToeDefinitionImportFieldName_FunctionalLocation);
                SetHasError();
            }
            else if (opmToeDefinition.FunctionalLocation.Exceeds(MaxCharLengthSmallText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_FunctionalLocation);
                SetHasError();
            }
        }

        private void ValidateHasReferenceDocuments()
        {
            if (opmToeDefinition.ReferencesDocuments.Exceeds(MaxCharLengthMediumText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_ReferenceDocuments);
                SetHasError();
            }
        }

        private void ValidateHasCausesDescription()
        {
            if (opmToeDefinition.CausesDescription.Exceeds(MaxCharLengthLargeText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_CausesDescription);
                SetHasError();
            }
        }
        
        private void ValidateHasConsequencesDescription()
        {
            if (opmToeDefinition.ConsequencesDescription.Exceeds(MaxCharLengthLargeText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_ConsequencesDescription);
                SetHasError();
            }
        }

        private void ValidateHasCorrectiveActionDescription()
        {
            if (opmToeDefinition.CorrectiveActionDescription.Exceeds(MaxCharLengthLargeText))
            {
                stringFieldsTooLong.Add(StringResources.OpmToeDefinitionImportFieldName_CorrectiveActionDescription);
                SetHasError();
            }
        }
    }
}