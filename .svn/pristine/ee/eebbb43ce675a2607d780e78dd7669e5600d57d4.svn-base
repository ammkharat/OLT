using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class CustomFieldEntryValidator
    {
        private readonly ICustomFieldValidationAction action;
        private bool hasErrors;

        public CustomFieldEntryValidator(ICustomFieldValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateAndSetErrors(List<CustomFieldEntry> customFieldEntries)
        {
            hasErrors = false;

            customFieldEntries.ForEach(entry =>
            {
                string fieldEntryText = action.GetCustomFieldEntryText(entry);
                if (!IsValidFieldEntry(fieldEntryText, entry))
                {
                    
                    hasErrors = true;
                }
            });
        }

        private bool IsValidFieldEntry(string fieldEntryText, CustomFieldEntry entry)
        {
            if (!entry.Type.Equals(CustomFieldType.NumericValue) || fieldEntryText.IsNullOrEmptyOrWhitespace())
            {
                return true;
            }

            decimal result;
            bool parseWasSuccessful = Decimal.TryParse(fieldEntryText, out result);
            if (!parseWasSuccessful)
            {
                action.SetCustomFieldMustContainANumberError(entry);
                return false;
            }
            else
            {
                if (HasMoreThanTwelveDigitsToLeftOfDecimalPoint(result))
                {
                    action.SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(entry);
                    return false;
                }

                if (HasMoreThanSixDigitsToRightOfDecimalPoint(result))
                {
                    action.SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(entry);
                    return false;
                }
            }

            return true;
        }

        private static bool HasMoreThanTwelveDigitsToLeftOfDecimalPoint(decimal result)
        {
            return Math.Abs(result) > new decimal(999999999999.999999);
        }

        private static bool HasMoreThanSixDigitsToRightOfDecimalPoint(decimal result)
        {
                                                                         // e.g. result is -50.1234567
            decimal decimalPart = DecimalPart(result);                   // => 0.1234567
            decimal shiftedSixDigitsToTheLeft = decimalPart * 1000000;   // => 123456.7
            decimal endResult = DecimalPart(shiftedSixDigitsToTheLeft);  // => 0.7

            return endResult != 0;
        }

        private static decimal DecimalPart(decimal num)
        {
            return num - Math.Truncate(num);
        }
    }
}
