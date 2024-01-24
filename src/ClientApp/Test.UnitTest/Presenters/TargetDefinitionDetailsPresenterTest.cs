using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetDefinitionDetailsPresenterTest
    {
        [Test][Ignore]
        public void ShouldLoadViewWithDetails()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateATargetWithRecurringWeeklySchedule();
            targetDefinition.RequiresResponseWhenAlerted = true;
            targetDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));

            MockTargetDefinitionDetails view = new MockTargetDefinitionDetails();
            TargetDefinitionDetailsPresenter presenter = new TargetDefinitionDetailsPresenter(view, targetDefinition);

            List<DomainObjectChangeSet> changeSets = new List<DomainObjectChangeSet>
                                                         {new DomainObjectChangeSet(new DateTime(), "Test Name")};

            // Execute:
            presenter.LoadView();
            
            Assert.AreEqual(targetDefinition.RequiresApproval, view.RequiredApproval);
            Assert.AreEqual(targetDefinition.IsAlertRequired, view.RequiredAlert);
            Assert.AreEqual(targetDefinition.RequiresResponseWhenAlerted, view.RequiresResponseWhenAlerted);
            Assert.AreEqual(targetDefinition.IsActive, view.Active);
            Assert.AreEqual(targetDefinition.Name, view.TargetName);
            Assert.AreEqual(targetDefinition.FunctionalLocation.FullHierarchyWithDescription, view.FunctionalLocation);
            Assert.AreEqual(targetDefinition.Description, view.Description);
            Assert.AreEqual(string.Format("{0} ({1})", targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description), view.Tag);
            Assert.IsTrue(view.IsOperationalModeSet);
            Assert.AreEqual(targetDefinition.Category.Name, view.Category);

            AssertNullableDecimalAsString(targetDefinition.NeverToExceedMaximum, view.NeverToExceedMaxValue);
            AssertNullableDecimalAsString(targetDefinition.MaxValue, view.MaxValue);
            AssertNullableDecimalAsString(targetDefinition.NeverToExceedMinimum, view.NeverToExceedMinValue);
            AssertNullableDecimalAsString(targetDefinition.MinValue, view.MinValue);
            Assert.AreEqual(targetDefinition.TargetValue.Title, view.TargetValue);            

            Assert.AreEqual(targetDefinition.Schedule, view.Schedule);
            Assert.AreEqual(targetDefinition.Comments, view.Comments);
            Assert.AreEqual(targetDefinition.AssociatedTargetDTOs, view.TargetDefinitions);
            
            Assert.AreEqual(targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction, view.MaxReadWriteDirection);
            Assert.AreEqual(targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction, view.MinReadWriteDirection);
            Assert.AreEqual(targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction, view.TargetReadWriteDirection);
            Assert.AreEqual(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction, view.GapUnitReadWriteDirection);
            
            Assert.AreEqual(targetDefinition.DocumentLinks, view.DocumentLinks);
        }

        private void AssertNullableDecimalAsString(decimal? expected, string actual)
        {
            Assert.AreEqual(expected.HasValue ? expected.Value.ToString() : string.Empty, actual);
        }

        private class MockTargetDefinitionDetails : ITargetDefinitionDetails
        {
            public event EventHandler Delete { add {} remove {} }
            public event EventHandler Approve { add { } remove { } }
            public event EventHandler Reject { add { } remove { } }
            public event EventHandler Edit { add { } remove { } }
            public event EventHandler Comment { add { } remove { } }
            public event EventHandler ViewEditHistory { add { } remove { } }
            public event Action ToggleShow { add { } remove { } }
            public event Action SaveGridLayout;

            private string editedBy;
            private bool requiredApproval;
            private bool requiredAlert;
            private bool requiresResponseWhenAlerted;
            private bool active;
            private bool generateActionItem;
            private string targetName;
            private string functionalLocation;
            private string description;
            private string tag;
            private string category;
            private string neverToExceedMaxValue;
            private string maxValue;
            private string neverToExceedMinValue;
            private string minValue;
            private string targetValue;
            private string gapUnitValue;
            private string gapUnitValueUnits;
            private ISchedule schedule;
            private List<Comment> comments;
            private List<TargetDefinitionDTO> targetDefinitions;
            private bool approveEnabled;
            private bool deleteEnabled;
            private bool rejectEnabled;
            private bool editEnabled;
            private bool commentEnabled;
            private bool exportAllEnabled;
            private bool enabled;
            public bool IsOperationalModeSet = false;
            private bool viewEditHistoryEnabled;
            private TagDirection gapUnitReadWriteDirection;
            private TagDirection targetReadWriteDirection;
            private TagDirection minReadWriteDirection;
            private TagDirection maxReadWriteDirection;
            private string priority;
            private List<DocumentLink> documentsControl;
            private string preApprovedMaxValue;
            private string preApprovedMinValue;
            private string preApprovedNeverToExceedMaxValue;
            private string preApprovedNeverToExceedMinValue;
            private string workAssignment;

            public bool EnableLayoutIsActiveIndicator
            {
                set { ; }
            }

            public ToolStripButton SaveGridLayoutButton
            {
                get { return null; }
            }

            public string EditedBy
            {
                set { editedBy = value; }
            }

            public bool RequiredApproval
            {
                get { return requiredApproval; }
                set { requiredApproval = value; }
            }

            public bool RequiredAlert
            {
                get { return requiredAlert; }
                set { requiredAlert = value; }
            }

            public bool RequiresResponseWhenAlerted
            {
                get { return requiresResponseWhenAlerted; }
                set { requiresResponseWhenAlerted = value; }
            }

            public bool Active
            {
                get { return active; }
                set { active = value; }
            }

            public bool GenerateActionItem
            {
                set { generateActionItem = value; }
            }

            public string TargetName
            {
                get { return targetName; }
                set { targetName = value; }
            }

            public string FunctionalLocation
            {
                get { return functionalLocation; }
                set { functionalLocation = value; }
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public string Tag
            {
                get { return tag; }
                set { tag = value; }
            }

            public string Category
            {
                get { return category; }
                set { category = value; }
            }

            public string Priority
            {
                set { priority = value; }
            }

            public string WorkAssignment
            {
                set { workAssignment = value; }
            }

            public string NeverToExceedMaxValue
            {
                get { return neverToExceedMaxValue; }
                set { neverToExceedMaxValue = value; }
            }

            public string MaxValue
            {
                get { return maxValue; }
                set { maxValue = value; }
            }

            public string NeverToExceedMinValue
            {
                get { return neverToExceedMinValue; }
                set { neverToExceedMinValue = value; }
            }

            public string MinValue
            {
                get { return minValue; }
                set { minValue = value; }
            }

            public string TargetValue
            {
                get { return targetValue; }
                set { targetValue = value; }
            }

            public string GapUnitValue
            {
                get { return gapUnitValue; }
                set { gapUnitValue = value; }
            }

            public string GapUnitValueUnits
            {
                set { gapUnitValueUnits = value; }
            }

            public string NeverToExceedMaxFrequency
            {
                set {  }
            }

            public string NeverToExceedMinFrequency
            {
                set { }
            }

            public string MaxValueFrequency
            {
                set { }
            }

            public string MinValueFrequency
            {
                set { }
            }

            public string PreApprovedNeverToExceedMinValue
            {
                get { return preApprovedNeverToExceedMinValue; }
                set { preApprovedNeverToExceedMinValue = value; }
            }

            public string PreApprovedNeverToExceedMaxValue
            {
                get { return preApprovedNeverToExceedMaxValue; }
                set { preApprovedNeverToExceedMaxValue = value; }
            }

            public string PreApprovedMinValue
            {
                get { return preApprovedMinValue; }
                set { preApprovedMinValue = value; }
            }

            public string PreApprovedMaxValue
            {
                get { return preApprovedMaxValue; }
                set { preApprovedMaxValue = value; }
            }

            public TagDirection MaxReadWriteDirection
            {
                get { return maxReadWriteDirection; }
                set { maxReadWriteDirection = value; }
            }

            public TagDirection MinReadWriteDirection
            {
                get { return minReadWriteDirection;  }
                set { minReadWriteDirection = value; }
            }

            public TagDirection TargetReadWriteDirection
            {
                get { return targetReadWriteDirection; }
                set { targetReadWriteDirection = value; }
            }

            public TagDirection GapUnitReadWriteDirection
            {
                get { return gapUnitReadWriteDirection; }
                set { gapUnitReadWriteDirection = value; }
            }

            public ISchedule Schedule
            {
                get { return schedule; }
                set { schedule = value; }
            }

            public List<Comment> Comments
            {
                get { return comments; }
                set { comments = value; }
            }

            public List<TargetDefinitionDTO> TargetDefinitions
            {
                get { return targetDefinitions; }
                set { targetDefinitions = value; }
            }

            public bool ApproveEnabled
            {
                set { approveEnabled = value; }
            }

            public bool DeleteEnabled
            {
                set { deleteEnabled = value; }
            }

            public bool RejectEnabled
            {
                set { rejectEnabled = value; }
            }

            public bool EditEnabled
            {
                set { editEnabled = value; }
            }

            public bool CommentEnabled
            {
                set { commentEnabled = value; }
            }

            public bool ViewEditHistoryEnabled
            {
                set { viewEditHistoryEnabled = value; }
            }

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            public void CallDefaultButton()
            {                
            }

            public void Show(){}
            public void Hide() { }

            #region IDetails Members

            public event EventHandler ExportAll { add { } remove { } }

            public DockStyle Dock
            {
                get
                {
                    return DockStyle.Fill;
                 }
                set
                {
                 }
            }

            public WidgetAppearance ShowButtonAppearance
            {
                get { return null; }
                set { ; }
            }

            #endregion

            #region ITargetDefinitionDetails Members


            public string OperationalMode
            {
                set { IsOperationalModeSet = true; }
            }

            public List<DocumentLink> DocumentLinks
            {
                set { documentsControl = value; }
                get { return documentsControl; }
            }

            #endregion
        }
    }
}

