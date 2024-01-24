using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NMock2;
using NUnit.Framework;
using Mockery = NMock2.Mockery;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class CustomFieldEntryValidatorTest
    {
        [Test]
        public void ShouldNotAllowNumericCustomFieldsToHaveNonNumericValues()
        {
            CustomFieldEntry customFieldEntry = new CustomFieldEntry(null, null, "field name", null, null,null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            Mockery mockery = new Mockery();
            ICustomFieldValidationAction action = (ICustomFieldValidationAction) mockery.NewMock(typeof (ICustomFieldValidationAction));
            Expect.Once.On(action).Method("GetCustomFieldEntryText").Will(Return.Value("notanumber"));
            Expect.Once.On(action).Method("SetCustomFieldMustContainANumberError").With(customFieldEntry);

            CustomFieldEntryValidator validator = new CustomFieldEntryValidator(action);
            validator.ValidateAndSetErrors(new List<CustomFieldEntry> { customFieldEntry });

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAllowNumericCustomFieldsToHaveNumericValues()
        {
            CustomFieldEntry customFieldEntry = new CustomFieldEntry(null, null, "field name", null, null,null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            Mockery mockery = new Mockery();
            ICustomFieldValidationAction action = (ICustomFieldValidationAction)mockery.NewMock(typeof(ICustomFieldValidationAction));
            Expect.Once.On(action).Method("GetCustomFieldEntryText").Will(Return.Value("-23.6"));
            Expect.Never.On(action).Method("SetCustomFieldMustContainANumberError");

            CustomFieldEntryValidator validator = new CustomFieldEntryValidator(action);
            validator.ValidateAndSetErrors(new List<CustomFieldEntry> { customFieldEntry });

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldOnlyLetNumericFieldsHaveTwelveDigitsBeforeDecimalPointAndSixDigitsAfter()
        {
            CustomFieldEntry customFieldEntry1 = new CustomFieldEntry(null, null, "field name 1", null, null,null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null); //ayman action item reading
            CustomFieldEntry customFieldEntry2 = new CustomFieldEntry(null, null, "field name 2", null, null,null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntry customFieldEntry3 = new CustomFieldEntry(null, null, "field name 3", null, null,null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            Mockery mockery = new Mockery();
            ICustomFieldValidationAction action = (ICustomFieldValidationAction)mockery.NewMock(typeof(ICustomFieldValidationAction));
            Expect.Once.On(action).Method("GetCustomFieldEntryText").With(customFieldEntry1).Will(Return.Value("-1234567890123"));
            Expect.Once.On(action).Method("GetCustomFieldEntryText").With(customFieldEntry2).Will(Return.Value("1234567890123.5"));
            Expect.Once.On(action).Method("GetCustomFieldEntryText").With(customFieldEntry3).Will(Return.Value("-3.1234567"));

            Expect.Once.On(action).Method("SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError").With(customFieldEntry1);
            Expect.Once.On(action).Method("SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError").With(customFieldEntry2);
            Expect.Once.On(action).Method("SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError").With(customFieldEntry3);

            CustomFieldEntryValidator validator = new CustomFieldEntryValidator(action);
            validator.ValidateAndSetErrors(new List<CustomFieldEntry> { customFieldEntry1, customFieldEntry2, customFieldEntry3 });

            mockery.VerifyAllExpectationsHaveBeenMet();
        }


    }
}
