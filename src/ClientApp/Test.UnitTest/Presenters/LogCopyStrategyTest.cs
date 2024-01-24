using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class LogCopyStrategyTest
    {
        [Test]
        public void ShouldOnlyCopyFlocsThatUserHasLoggedInTo()
        {
            List<FunctionalLocation> activeFlocs = new List<FunctionalLocation>
                                                       {
                                                           FunctionalLocationFixture.CreateNew(1, "Z"),
                                                           FunctionalLocationFixture.CreateNew(2, "A-B1"),
                                                           FunctionalLocationFixture.CreateNew(3, "A-B2")
                                                       };

            ClientSession.GetUserContext().SetSelectedFunctionalLocations(
                activeFlocs,
                new List<FunctionalLocation>(), 
                new List<FunctionalLocation>());

            Log log = LogFixture.CreateLog(false);
            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "Z"));
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "A-B1"));
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(4, "A-B1-C1"));
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(5, "A-B2-C2-D3"));
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(6, "A-B3"));
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(7, "Z-1-3-3"));

            LogCopyStrategy logCopyStrategy = new LogCopyStrategy(log);
            ILogFormView testView = new TestView();
            logCopyStrategy.Copy(testView, new List<CustomField>(), null);

            Assert.AreEqual(5, ((ILogCopyFormView) testView).FunctionalLocations.Count);
            Assert.IsTrue(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 1));
            Assert.IsTrue(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 2));
            Assert.IsFalse(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 3));
            Assert.IsTrue(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 4));
            Assert.IsTrue(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 5));
            Assert.IsFalse(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 6));
            Assert.IsTrue(((ILogCopyFormView) testView).FunctionalLocations.Exists(obj => obj.Id == 7));
        }

        [Test]  // Scenario: Create a log, rename a custom field, copy that log.
        public void ShouldCopyCustomFieldsMatchingByCustomFieldOriginIdAndNotByName()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            const long customField1Id = 1;
            const long customField2Id = 2;

            CustomField customField1 = new CustomField(customField1Id, "cf1", 0, null, null, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField2 = new CustomField(customField2Id, "cf2", 1, null, null, customField2Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            CustomFieldEntry entry1 = new CustomFieldEntry(customField1);
            entry1.FieldEntry = "val1";

            CustomFieldEntry entry2 = new CustomFieldEntry(customField2);
            entry2.FieldEntry = "val2";

            Log log = LogFixture.CreateLog(false);
            log.WorkAssignment = workAssignment;
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFieldEntries.Add(entry2);
            log.CustomFields.Clear();
            log.CustomFields.Add(customField1);
            log.CustomFields.Add(customField2);

            // now let's pretend that customField1 was renamed to be cf1-renamed. This actually creates a new custom field in the db, but it is linked
            // to the original custom field by origin id.

            const long customField1RenamedId = 3;
            CustomField customField1Renamed = new CustomField(customField1RenamedId, "cf1-renamed", 0, null, null, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            List<CustomField> customFieldsOnNewLogs = new List<CustomField> {customField1Renamed, customField2};

            LogCopyStrategy logCopyStrategy = new LogCopyStrategy(log);
            TestView testView = new TestView();
            logCopyStrategy.Copy(testView, customFieldsOnNewLogs, workAssignment);

            List<CustomFieldEntry> customFieldEntries = testView.customFieldEntries;
            Assert.AreEqual(2, customFieldEntries.Count);

            CustomFieldEntry fieldEntry1 = customFieldEntries.Find(entry => entry.CustomFieldId == customField1RenamedId);
            Assert.AreEqual("cf1-renamed", fieldEntry1.CustomFieldName);
            Assert.AreEqual("val1", fieldEntry1.FieldEntry);

            CustomFieldEntry fieldEntry2 = customFieldEntries.Find(entry => entry.CustomFieldId == customField2Id);
            Assert.AreEqual("cf2", fieldEntry2.CustomFieldName);
            Assert.AreEqual("val2", fieldEntry2.FieldEntry);
        }

        [Test]  // Scenario: Rename a custom field, create a log, rename the custom field again, copy that log.
        public void ShouldCopyCustomFieldsMatchingByCustomFieldOriginIdAndNotByName_MiddleLogScenario()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            const long customField1Id = 1;
            const long customField2Id = 2;

            CustomField customField1 = new CustomField(customField1Id, "cf1", 0, null, null, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField2 = new CustomField(customField2Id, "cf2", 1, null, null, customField2Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            // now let's pretend that customField1 was renamed to be cf1-renamed. This actually creates a new custom field in the db, but it is linked
            // to the original custom field by origin id.

            const long customField1RenamedId = 3;
            CustomField customField1Renamed = new CustomField(customField1RenamedId, "cf1-renamed", 0, null, null, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            CustomFieldEntry entry1 = new CustomFieldEntry(customField1Renamed);
            entry1.FieldEntry = "val1";

            CustomFieldEntry entry2 = new CustomFieldEntry(customField2);
            entry2.FieldEntry = "val2";

            Log log = LogFixture.CreateLog(false);
            log.WorkAssignment = workAssignment;
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFieldEntries.Add(entry2);
            log.CustomFields.Clear();
            log.CustomFields.Add(customField1Renamed);
            log.CustomFields.Add(customField2);

            // now we pretend that customField1 was renamed again.

            const long customField1RenamedAgainId = 4;
            CustomField customField1RenamedAgain = new CustomField(customField1RenamedAgainId, "cf1-renamed-again", 0, null, null, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            List<CustomField> customFieldsOnNewLogs = new List<CustomField> { customField1RenamedAgain, customField2 };

            LogCopyStrategy logCopyStrategy = new LogCopyStrategy(log);
            TestView testView = new TestView();
            logCopyStrategy.Copy(testView, customFieldsOnNewLogs, workAssignment);

            List<CustomFieldEntry> customFieldEntries = testView.customFieldEntries;
            Assert.AreEqual(2, customFieldEntries.Count);

            CustomFieldEntry fieldEntry1 = customFieldEntries.Find(entry => entry.CustomFieldId == customField1RenamedAgainId);
            Assert.AreEqual("cf1-renamed-again", fieldEntry1.CustomFieldName);
            Assert.AreEqual("val1", fieldEntry1.FieldEntry);

            CustomFieldEntry fieldEntry2 = customFieldEntries.Find(entry => entry.CustomFieldId == customField2Id);
            Assert.AreEqual("cf2", fieldEntry2.CustomFieldName);
            Assert.AreEqual("val2", fieldEntry2.FieldEntry);
        }

        private class TestView : ILogFormView
        {
            //Mukesh for Log Image
             public List<LogImage> ImageLogdetails { set; get; }
            public bool setLogImage
             {

                 set{}
             }
            //end

            public event FormClosingEventHandler FormClosing { add { } remove { } }

            public int Height
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public int Width
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public Point Location
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public DialogResult DialogResult
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public DialogResult ShowDialog(IWin32Window form)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void ShowWaitScreenAndDisableForm()
            {            
            }

            public void CloseWaitScreenAndEnableForm()
            {           
            }

            public void SetFormVisibleState(bool visible)
            {                
            }

            public event EventHandler Load { add { } remove { } }
            public event EventHandler Disposed { add { } remove { } }

            public void Close() {}
            public bool ConfirmCancelDialog() { return false; }
            public void SaveFailedMessage() {}
            public void SaveSucceededMessage() {}
            public void ShowMessageBox(string title, string error) { }

            public void ClearErrorProviders() {}            
            public void SetCommentsBlankError(){}
            public void SetFunctionLocationBlankError(){}
            public bool EHSFollowUp { get {return false; } set { }}
            public bool InspectionFollowUp{ get {return false; } set { }}
            public bool OperationsFollowUp{ get {return false; } set { }}
            public bool ProcessControlFollowUp{ get {return false; } set { }}
            public bool SupervisionFollowUp{ get {return false; } set { }}
            public bool OtherFollowUp{ get {return false; } set { }}
            public bool IsOperatingEngineerLog{ get {return false; } set { }}
            public bool ViewEditHistoryEnabled{ set { }}
            public string Shift{ set { }}
            public string Author{ set { }}
            public void ClearLogValidationErrorProviders()
            {
            }

            public List<FunctionalLocation> FunctionalLocations { get; set; }
            public bool CreateALogForEachFunctionalLocation { get; set; }

            public List<CustomFieldEntry> customFieldEntries;
            public List<CustomField> customFields;

           
            public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
            {
                this.customFieldEntries = customFieldEntries;
                this.customFields = customFields;
            }

            public string Comments { get; set; }
            public string CommentsAsPlainText { get; set; }
            DialogResultAndOutput<List<string>> ILogFormView.ShowSelectLogsForSummaryForm() { return null; }
            public void AppendComments(List<string> textToAppend) { ; }           
            public FunctionalLocation SelectedFunctionalLocation { get; private set; }
            public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection, FunctionalLocationType selectionFLOCLevel) { return null; }
            public List<DocumentLink> AssociatedDocumentLinks { get; set; }
            public void SetupForEdit() {}
            public void HideLogTemplateComponent(){}
            public void ShowLogTemplateComponent(){}
            public Time ActualLoggedTime { get; private set; }
            public DateTime LogDateTime { get; set; }
            public void SetLogTimeInTheFutureError(){}
            public void SetLogDateTimeError(){}
            public void SetCustomFieldMustContainANumberError(CustomFieldEntry entry) {}
            public void SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(CustomFieldEntry entry) { }

            public bool SelectLogsForSummaryButtonEnabled { set; private get; }

            public string OperatingEngineerLogDisplayName { set; private get; }
            public void HideOperatingEngineerCheckBox(){}
            public bool RecommendForShiftSummary { get; set; }
            public bool EnableRecommendForShiftSummary { set; private get; }
            public void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions(){}
            public void SetLogTemplates(List<LogTemplateDTO> logTemplates){}
            public LogTemplateDTO SelectedLogTemplate { get; set; }
            public bool EnableSelectLogsForSummary { set{} }
            public string GetCustomFieldEntryText(CustomFieldEntry entry) { return ""; }
            public string GetCustomFieldEntryText(long customFieldId) { return ""; }

            public bool LogTimeControlEnabled { get { return false; } set {} }
            public bool MultipleFunctionalLocationOptionsEnabled { set {} }
            public bool IsCommentEmpty { get { return false; } }
            public void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText) { }
            public void ShowGuidelines(List<LogGuideline> guidelines) { }
            public void ApplyLogTemplateText(string text) { }
            public event Action HandleLogTemplateButtonClick;
            public bool ShowLogMarkedAsReadWarning() { return true; }
            public void HideFollowupFlags() { }
            public void HideMultipleFunctionalLocationOptions() { }
            public bool ExpandAdditionalDetails { set { } }

            public void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
            {
            }

            public void DisableControls() { }
            public void EnableControls() { }
            public void SetCustomFieldEntryText(CustomFieldEntry customFieldEntry, string text) { }
            public void TurnOffCustomFieldPhTagHighlights() {}
            public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries) {}

            public IntPtr Handle
            {
                get { throw new NotImplementedException(); }
            }


            public string SetShiftLogMenuItemName
            {
                set { throw new NotImplementedException(); }
            }
        }
    }
}
