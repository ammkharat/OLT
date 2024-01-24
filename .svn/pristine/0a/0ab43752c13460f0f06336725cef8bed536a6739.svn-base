using System;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    [TestFixture]
    public class DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidatorTest
    {
        [SetUp]
        public void SetUp()
        {                   
        }
        
        [Test]
        public void ShouldValidateDateAndShiftOrder_EndDateBeforeStartDate()
        {            
            ShiftPattern availableShift1 = ShiftPatternFixture.CreateDayShift();
            ShiftPattern availableShift2 = ShiftPatternFixture.CreateNightShift();

            List<ShiftPattern> availableShiftPatterns = new List<ShiftPattern> { availableShift1, availableShift2 };

            Date tuesday = new Date(2010, 12, 7);
            Date wednesday = new Date(2010, 12, 8);

            // Shift same, start before end (valid case)
            {

                IDateRangeShiftRoleAndWorkAssignmentReportParametersControl fakeTestControl =
                    new FakeTestControl(availableShiftPatterns, availableShift1, availableShift2, tuesday, wednesday);

                DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                    new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);

                Assert.IsTrue(validator.IsValid);
                Assert.IsNullOrEmpty(validator.ErrorMessage);
            }


            // Shift same, end before start
            {                      
                IDateRangeShiftRoleAndWorkAssignmentReportParametersControl fakeTestControl =
                    new FakeTestControl(availableShiftPatterns, availableShift1, availableShift2, wednesday, tuesday);

                DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator = 
                        new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);    

                Assert.IsFalse(validator.IsValid);
                Assert.AreEqual(StringResources.FromShiftBeforeToShift, validator.ErrorMessage);
            }
            
        }

        [Test]
        public void ShouldValidateDateAndShiftOrder_SameDateButEndShiftBeforeStartShift()
        {
            // shift1 start 6am
            // shift1 end 6pm

            // shift2 start 6pm
            // shift2 end 6am

            ShiftPattern availableShift1 = ShiftPatternFixture.CreateDayShift();
            ShiftPattern availableShift2 = ShiftPatternFixture.CreateNightShift();
            ShiftPattern availableShift3 = ShiftPatternFixture.CreateShiftPattern(new Time(14), new Time(2));

            List<ShiftPattern> availableShiftPatterns = new List<ShiftPattern> { availableShift1, availableShift2, availableShift3 };

            Date tuesday = new Date(2010, 12, 7);           

            // date same, start shift before end shift (valid case)
            {

                IDateRangeShiftRoleAndWorkAssignmentReportParametersControl fakeTestControl =
                    new FakeTestControl(availableShiftPatterns, availableShift1, availableShift2, tuesday, tuesday);

                DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                    new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);

                Assert.IsTrue(validator.IsValid);
                Assert.IsNullOrEmpty(validator.ErrorMessage);
            }

            // date same, end shift before start shift (still valid for this case, 6pm start, 6pm end)
            {

                IDateRangeShiftRoleAndWorkAssignmentReportParametersControl fakeTestControl =
                    new FakeTestControl(availableShiftPatterns, availableShift2, availableShift1, tuesday, tuesday);

                DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                    new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);

                Assert.IsTrue(validator.IsValid);
                Assert.IsNullOrEmpty(validator.ErrorMessage);
            }

            // date same, end shift crosses midnight barrier, so ends on next day (fails)
            {

                IDateRangeShiftRoleAndWorkAssignmentReportParametersControl fakeTestControl =
                    new FakeTestControl(availableShiftPatterns, availableShift3, availableShift1, tuesday, tuesday);

                DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                    new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);

                Assert.IsTrue(validator.IsValid);
                Assert.IsNullOrEmpty(validator.ErrorMessage);
                //Assert.AreEqual(Messages.FROM_SHIFT_BEFORE_TO_SHIFT, validator.ErrorMessage);
            }            
        }

        [Test]
        public void ShouldValidateWorkAssignmentSelection()
        {
            FakeTestControl fakeTestControl = CreateValidControl();
            DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);
            Assert.IsTrue(validator.IsValid);

            fakeTestControl.SelectedWorkAssignments.Clear();
            fakeTestControl.IncludeDataWithNoWorkAssignment = false;
            Assert.IsFalse(validator.IsValid);

            fakeTestControl.SelectedWorkAssignments.Add(WorkAssignmentFixture.CreateConsoleOperator());
            fakeTestControl.IncludeDataWithNoWorkAssignment = false;
            Assert.IsTrue(validator.IsValid);

            fakeTestControl.SelectedWorkAssignments.Clear();
            fakeTestControl.IncludeDataWithNoWorkAssignment = true;
            Assert.IsTrue(validator.IsValid);
        }

        [Test]
        public void ShouldValidateFunctionalLocationSelection()
        {
            FakeTestControl fakeTestControl = CreateValidControl();
            DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator validator =
                new DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(fakeTestControl);
            Assert.IsTrue(validator.IsValid);

            fakeTestControl.SelectedFunctionalLocations.Clear();
            Assert.IsFalse(validator.IsValid);

            fakeTestControl.SelectedFunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            Assert.IsTrue(validator.IsValid);
        }

        private static FakeTestControl CreateValidControl()
        {
            FakeTestControl control = new FakeTestControl(
                new List<ShiftPattern> { ShiftPatternFixture.CreateDayShift() },
                ShiftPatternFixture.CreateDayShift(), 
                ShiftPatternFixture.CreateDayShift(),
                new Date(2010, 12, 7),
                new Date(2010, 12, 7));
            return control;
        }


        private class FakeTestControl : IDateRangeShiftRoleAndWorkAssignmentReportParametersControl
        {
            private List<ShiftPattern> availableShiftPatterns;
            private ShiftPattern selectedStartShiftPattern;
            private ShiftPattern selectedEndShiftPattern;

            private Date selectedStartDate;
            private Date selectedEndDate;

            private List<FunctionalLocation> selectedFunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

            private List<WorkAssignment> selectedWorkAssignments = new List<WorkAssignment>{WorkAssignmentFixture.CreateConsoleOperator()};
            private bool includeDataWithNoWorkAssignment;
            /**/ 
            private bool showFlexibleShiftHandoverData;

            public FakeTestControl(
                List<ShiftPattern> availableShiftPatterns, 
                ShiftPattern selectedStartShiftPattern, 
                ShiftPattern selectedEndShiftPattern, 
                Date selectedStartDate, 
                Date selectedEndDate)
            {
                this.availableShiftPatterns = availableShiftPatterns;
                this.selectedStartShiftPattern = selectedStartShiftPattern;
                this.selectedEndShiftPattern = selectedEndShiftPattern;
                this.selectedStartDate = selectedStartDate;
                this.selectedEndDate = selectedEndDate;
            }

            public List<ShiftPattern> AvailableShiftPatterns
            {
                set { availableShiftPatterns = value; }
            }

            public IList<FunctionalLocation> SelectedRootFunctionalLocations
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public List<FunctionalLocation> SelectedFunctionalLocations
            {
                get { return selectedFunctionalLocations; }
            }

            public List<WorkAssignment> SelectedWorkAssignments
            {
                get { return selectedWorkAssignments; }
            }

            public bool IncludeDataWithNoWorkAssignment
            {
                get { return includeDataWithNoWorkAssignment; }
                set { includeDataWithNoWorkAssignment = value; }
            }

            /**/
            public bool ShowFlexibleShiftHandoverData
            {
                get { return showFlexibleShiftHandoverData; }
                set { showFlexibleShiftHandoverData = value; }
            }
            /**/

            public string IncludeDataWithNoWorkAssignmentText
            {
                set { throw new NotImplementedException(); }
            }

            public void SetAvailableWorkAssignments(List<WorkAssignment> assignments)
            {
                throw new NotImplementedException();
            }

            public List<Role> SelectedRoles
            {
                get { throw new NotImplementedException(); }
            }

            public List<string> SelectedCategories
            {
                get { throw new NotImplementedException(); }
            }

            public void SelectRolesCategoriesAndWorkAssignments(
                List<long> selectedRoleIds,
                List<string> selectedCategories,
                List<long> selectedWorkAssignmentIds,
                bool includeDataWithNoWorkAssignment)
            {
                throw new NotImplementedException();
            }

            public List<AssignmentSectionUnitReportGroupBy> GroupByItems
            {
                set { throw new NotImplementedException(); }
            }

            public AssignmentSectionUnitReportGroupBy SelectedGroupBy
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public bool Enabled
            {
                set { throw new NotImplementedException(); }
            }

            public bool IsValid
            {
                get { throw new NotImplementedException(); }
            }

            public string ErrorMessage
            {
                get { throw new NotImplementedException(); }
            }

            public event EventHandler Load;

            public ShiftPattern SelectedStartShiftPattern
            {
                get { return selectedStartShiftPattern; }
                set { throw new NotImplementedException(); }
            }

            public ShiftPattern SelectedEndShiftPattern
            {
                get { return selectedEndShiftPattern; }
                set { throw new NotImplementedException(); }
            }

            public Date SelectedStartDate
            {
                get { return selectedStartDate; }
                set { throw new NotImplementedException(); }
            }

            public Date SelectedEndDate
            {
                get { return selectedEndDate; }
                set { throw new NotImplementedException(); }
            }
        }
    }
}
