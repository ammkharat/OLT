using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Validation.Excursions
{
    public class OpmExcursionValidator
    {
        private const int MaxCharLengthSmallText = 255;

        private readonly List<string> missingFields;
        private readonly OpmExcursionDTO opmExcursion;
        private readonly List<string> stringFieldsTooLong;
        private bool hasErrors;
        private bool hasWarnings;
        private bool validateHasRun;

        public OpmExcursionValidator(OpmExcursionDTO opmExcursion)
        {
            this.opmExcursion = opmExcursion;
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

        private void ValidateStartDateTimeAndDuration()
        {
            if (opmExcursion.StartDateTime == DateTime.MinValue)
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_StartDateTime);
                SetHasError();
            }

            if (opmExcursion.Duration < 0m)
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_Duration);
                SetHasError();
            }
        }

        public void Validate()
        {
            validateHasRun = true;

            ClearErrors();

            ValidateStartDateTimeAndDuration();

            ValidateHasFunctionalLocation();
            ValidateHasToeName();
            ValidateHasToeType();
            ValidateHasHistorianTag();
            ValidateHasStatus();
        }

        private void ValidateHasStatus()
        {
            if (opmExcursion.Status.Name.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_Status);
                SetHasError();
            }
        }

        private void ValidateHasHistorianTag()
        {
            if (opmExcursion.HistorianTag.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_HistorianTag);
                SetHasError();
            }
            else if (opmExcursion.HistorianTag.Exceeds(MaxCharLengthSmallText))
            {
                stringFieldsTooLong.Add(StringResources.OpmExcursionImportFieldName_HistorianTag);
                SetHasError();
            }
        }

        private void ValidateHasToeType()
        {
            if (opmExcursion.ToeType.Name.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_ToeType);
                SetHasError();
            }
        }

        private void ValidateHasToeVersion()
        {
            if (opmExcursion.ToeVersion < 0)
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_ToeVersion);
                SetHasError();
            }
        }

        private void ValidateHasToeName()
        {
            if (opmExcursion.ToeName.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_ToeName);
                SetHasError();
            }
        }

        private void ValidateHasFunctionalLocation()
        {
            if (opmExcursion.FunctionalLocation.IsNullOrEmptyOrWhitespace())
            {
                missingFields.Add(StringResources.OpmExcursionImportFieldName_FunctionalLocation);
                SetHasError();
            }
            else if (opmExcursion.FunctionalLocation.Exceeds(MaxCharLengthSmallText))
            {
                stringFieldsTooLong.Add(StringResources.OpmExcursionImportFieldName_FunctionalLocation);
                SetHasError();
            }
        }
    }
}