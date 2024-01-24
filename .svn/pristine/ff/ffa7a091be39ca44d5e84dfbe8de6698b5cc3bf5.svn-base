using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetDefinitionReadWriteTagConfigurationPresenterTest
    {
        private const string MAX_THRESHOLD_DIRECTION = "MaxThresholdDirection";
        private const string MIN_THRESHOLD_DIRECTION = "MinThresholdDirection";
        private const string TARGET_THRESHOLD_DIRECTION = "TargetThresholdDirection";
        private const string GAP_UNIT_VALUE_DIRECTION = "GapUnitDirection";
        private const string MAX_THRESHOLD_TAG = "MaxThresholdTag";
        private const string MIN_THRESHOLD_TAG = "MinThresholdTag";
        private const string TARGET_THRESHOLD_TAG = "TargetThresholdTag";
        private const string GAP_UNIT_VALUE_TAG = "GapUnitValueTag";
        
        private TargetDefinition targetDefinition;
        private Mockery mocks;
        private ITargetDefinitionReadWriteTagConfigurationView mockView;
        private ITargetDefinitionService mockService;
        private TargetDefinitionReadWriteTagConfigurationPresenter presenter;
        private IPlantHistorianService mockPlantHistorianService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock <ITargetDefinitionReadWriteTagConfigurationView>();
            mockService = mocks.NewMock <ITargetDefinitionService>();
            mockPlantHistorianService = mocks.NewMock<IPlantHistorianService>();
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            
            presenter = new TargetDefinitionReadWriteTagConfigurationPresenter(mockView, targetDefinition, mockService, mockPlantHistorianService);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldSetTargetDefinitionNameDisableTagTextboxesAndInitializeDropDownListsOnLoad()
        {
            Expect.Once.On(mockView).SetProperty("TargetDefinitionName").To(targetDefinition.Name);
            Expect.Once.On(mockView).SetProperty("TargetDefinitionNameEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("MaxThresholdTagEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("MinThresholdTagEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("TargetThresholdEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("GapUnitValueEnabled").To(false);
            List<TagDirection> tagDirections = new List <TagDirection>(TagDirection.All);
            Expect.Once.On(mockView).SetProperty("MaxThresholdDirectionList").To(IsList.Equal(tagDirections));
            Expect.Once.On(mockView).SetProperty("MinThresholdDirectionList").To(IsList.Equal(tagDirections));
            Expect.Once.On(mockView).SetProperty("TargetThresholdDirectionList").To(IsList.Equal(tagDirections));
            Expect.Once.On(mockView).SetProperty("GapUnitValueDirectionList").To(IsList.Equal(tagDirections));
            Expect.Once.On(mockView).SetProperty(MAX_THRESHOLD_DIRECTION).To(targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction);
            Expect.Once.On(mockView).SetProperty(MIN_THRESHOLD_DIRECTION).To(targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction);
            Expect.Once.On(mockView).SetProperty(TARGET_THRESHOLD_DIRECTION).To(targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction);
            Expect.Once.On(mockView).SetProperty(GAP_UNIT_VALUE_DIRECTION).To(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction);
            Expect.Once.On(mockView).SetProperty(MAX_THRESHOLD_TAG).To(Is.EqualTo(targetDefinition.ReadWriteTagsConfiguration.MaxValue.Tag));
            Expect.Once.On(mockView).SetProperty(MIN_THRESHOLD_TAG).To(Is.EqualTo(targetDefinition.ReadWriteTagsConfiguration.MinValue.Tag));
            Expect.Once.On(mockView).SetProperty(TARGET_THRESHOLD_TAG).To(Is.EqualTo(targetDefinition.ReadWriteTagsConfiguration.TargetValue.Tag));
            Expect.Once.On(mockView).SetProperty(GAP_UNIT_VALUE_TAG).To(Is.EqualTo(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Tag));
            presenter.Load();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnTagNameToMaxThresholdTextBoxWhenValidTagReturnedFromSearch()
        {
            AssertFoundTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnEmptyTagToMaxThresholdTextBoxWhenNullTagReturnedFromSearch()
        {
            AssertNullTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndDoNothingToMaxThresholdTextBoxWhenTagSearchCancelled()
        {
            AssertCancelledTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnTagNameToMinThresholdTextBoxWhenValidTagReturnedFromSearch()
        {
            AssertFoundTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnEmptyTagToMinThresholdTextBoxWhenNullTagReturnedFromSearch()
        {
            AssertNullTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD);
        }
        
        [Test]
        public void ShouldOpenTagSearchFormAndDoNothingToMinThresholdTextBoxWhenTagSearchCancelled()
        {
            AssertCancelledTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnTagNameToTargetThresholdTextBoxWhenValidTagReturnedFromSearch()
        {
            AssertFoundTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnEmptyTagToTargetThresholdTextBoxWhenNullTagReturnedFromSearch()
        {
            AssertNullTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD);
        }
        
        [Test]
        public void ShouldOpenTagSearchFormAndDoNothingToTargetThresholdTextBoxWhenTagSearchCancelled()
        {
            AssertCancelledTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnTagNameToGapUnitValueTextBoxWhenValidTagReturnedFromSearch()
        {
            AssertFoundTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE);
        }

        [Test]
        public void ShouldOpenTagSearchFormAndReturnEmptyTagToGapUnitValueTextBoxWhenNullTagReturnedFromSearch()
        {
            AssertNullTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE);
        }
 
        [Test]
        public void ShouldOpenTagSearchFormAndDoNothingToGapUnitValueTextBoxWhenTagSearchCancelled()
        {
            AssertCancelledTagSearch(TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE);
        }

        private void AssertFoundTagSearch(string propertyName)
        {
            TagInfo tagInfo = TagInfoFixture.CreateTagInfoWithoutId();
            ITagSearchFormView mockTagSearchFormView = mocks.NewMock <ITagSearchFormView>();
            Expect.Once.On(mockView).Method("DisplayTagSearchForm").Will(Return.Value(mockTagSearchFormView));

            Expect.Once.On(mockTagSearchFormView).Method("ShowDialog").Will(Return.Value(DialogResult.OK));
            Expect.Once.On(mockTagSearchFormView).GetProperty("SelectedTag").Will(Return.Value(tagInfo));
            Expect.Once.On(mockView).SetProperty(propertyName + "Tag").To(tagInfo);
            presenter.TagSearch(propertyName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertNullTagSearch(string propertyName)
        {
            const TagInfo tagInfo = null;
            ITagSearchFormView mockTagSearchFormView = mocks.NewMock<ITagSearchFormView>();
            Expect.Once.On(mockView).Method("DisplayTagSearchForm").Will(Return.Value(mockTagSearchFormView));

            Stub.On(mockTagSearchFormView).Method("ShowDialog").Will(Return.Value(DialogResult.OK));
            Expect.Once.On(mockTagSearchFormView).GetProperty("SelectedTag").Will(Return.Value(tagInfo));
            Expect.Once.On(mockView).SetProperty(propertyName + "Tag").To(TagInfo.CreateEmpty());
            presenter.TagSearch(propertyName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertCancelledTagSearch(string propertyName)
        {
            ITagSearchFormView mockTagSearchFormView = mocks.NewMock <ITagSearchFormView>();
            //Stub.On(mockService).Method("DoesOtherTargetDefinitionWriteToTag").Will(Return.Value(false));                        
            Expect.Once.On(mockView).Method("DisplayTagSearchForm").Will(Return.Value(mockTagSearchFormView));
            Expect.Once.On(mockTagSearchFormView).Method("ShowDialog").Will(Return.Value(DialogResult.Cancel));
            presenter.TagSearch(propertyName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetTagsToNullTagWhenDirectionsAreSetToNone()
        {
            AssertTagSetToNullWhenDirectionIsChangedToNone(TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD, MAX_THRESHOLD_DIRECTION, MAX_THRESHOLD_TAG);
            AssertTagSetToNullWhenDirectionIsChangedToNone(TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD, MIN_THRESHOLD_DIRECTION, MIN_THRESHOLD_TAG);
            AssertTagSetToNullWhenDirectionIsChangedToNone(TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD, TARGET_THRESHOLD_DIRECTION, TARGET_THRESHOLD_TAG);
            AssertTagSetToNullWhenDirectionIsChangedToNone(TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE, GAP_UNIT_VALUE_DIRECTION, GAP_UNIT_VALUE_TAG);
        }

        private void AssertTagSetToNullWhenDirectionIsChangedToNone(string propertyName, string direction, string tag)
        {
            Expect.Once.On(mockView).GetProperty(direction).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).SetProperty(tag).To(TagInfo.CreateEmpty());
            presenter.DirectionChanged(propertyName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        private void AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection tagdirection, string propertyName, string direction)
        {
            Expect.Once.On(mockView).GetProperty(direction).Will(Return.Value(tagdirection));
            presenter.DirectionChanged(propertyName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDoNothingToTagsWhenDirectionsChangedToReadOrWrite()
        {
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Read, TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD, MAX_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Read, TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD, MIN_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Read, TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD, TARGET_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Read, TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE, GAP_UNIT_VALUE_DIRECTION);
           
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Write, TargetDefinitionReadWriteTagConfigurationPresenter.MAX_THRESHOLD, MAX_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Write, TargetDefinitionReadWriteTagConfigurationPresenter.MIN_THRESHOLD, MIN_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Write, TargetDefinitionReadWriteTagConfigurationPresenter.TARGET_THRESHOLD, TARGET_THRESHOLD_DIRECTION);
            AssertNothingHappensWhenDirectionIsNotChangedNone(TagDirection.Write, TargetDefinitionReadWriteTagConfigurationPresenter.GAP_UNIT_VALUE, GAP_UNIT_VALUE_DIRECTION);
        }
    
        [Test]
        public void ShouldSetAllListsToNoneAndClearTextBoxesOnClear()
        {
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).SetProperty(MAX_THRESHOLD_DIRECTION).To(TagDirection.None);
            Expect.Once.On(mockView).SetProperty(MIN_THRESHOLD_DIRECTION).To(TagDirection.None);
            Expect.Once.On(mockView).SetProperty(TARGET_THRESHOLD_DIRECTION).To(TagDirection.None);
            Expect.Once.On(mockView).SetProperty(GAP_UNIT_VALUE_DIRECTION).To(TagDirection.None);
            Expect.Once.On(mockView).SetProperty(MAX_THRESHOLD_TAG).To(Is.EqualTo(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).SetProperty(MIN_THRESHOLD_TAG).To(Is.EqualTo(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).SetProperty(TARGET_THRESHOLD_TAG).To(Is.EqualTo(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).SetProperty(GAP_UNIT_VALUE_TAG).To(Is.EqualTo(TagInfo.CreateEmpty()));
            presenter.Clear();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCloseWithoutRememberingSetValuesWhenCancelled()
        {            
            Stub.On(mockService);
            Expect.Once.On(mockView).Method("CloseView");
            presenter.Cancel();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotRememberSetValuesOnTargetDefinitionWhenAcceptFailsValidation()
        {
            // Having multiple values writing to the same tag will cause validation error:
            Expect.AtLeastOnce.On(mockView).
                Method(TestUtil.IsGetter & TestUtil.IsMethodEndingWith("Tag")).
                Will(Return.Value(TagInfoFixture.CreateMockTagForSarnia(-99, "TT")));
            Expect.AtLeastOnce.On(mockView).
                Method(TestUtil.IsGetter & TestUtil.IsMethodEndingWith("Direction")).
                Will(Return.Value(TagDirection.Write));

            OltStub.On(mockView);

            presenter.Accept();

            TargetDefinitionReadWriteTagConfiguration config = targetDefinition.ReadWriteTagsConfiguration;
            Assert.AreNotEqual(-99, config.MaxValue.Tag.Id);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMaxThresholdTagSetButNoDirection()
        {            
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfoFixture.CreateTagInfoWithoutId()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidMaxThresholdDirectionError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMaxThresholdDirectionSetButNoTag()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidMaxThresholdTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMinThresholdTagSetButNoDirection()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfoFixture.CreateTagInfoWithoutId()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidMinThresholdDirectionError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMinThresholdDirectionSetButNoTag()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidMinThresholdTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenTargetThresholdTagSetButNoDirection()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfoFixture.CreateTagInfoWithoutId()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidTargetThresholdDirectionError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenTargetThresholdDirectionSetButNoTag()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidTargetThresholdTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenGapUnitValueTagSetButNoDirection()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfoFixture.CreateTagInfoWithoutId()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidGapUnitValueDirectionError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenGapUnitValueDirectionSetButNoTag()
        {
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowInvalidGapUnitValueTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMaxAndMinHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxAndMinSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMaxAndTargetHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxAndTargetSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMaxAndGapUnitValueHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxAndGapUnitValueSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMinAndTargetHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMinAndTargetSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenMinAndGapUnitValueHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMinAndGapUnitValueSameTagError");
            
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenTargetAndGapUnitValueHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.None));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(TagInfo.CreateEmpty()));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowTargetAndGapUnitValueSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenAllAreWriteValueHaveSameTag()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").Will(Return.Value(true));
            Stub.On(mockPlantHistorianService).Method("CanWriteTagValue").Will(Return.Value(true));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tag));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxAndMinSameTagError");
            Expect.Once.On(mockView).Method("ShowMaxAndTargetSameTagError");
            Expect.Once.On(mockView).Method("ShowMaxAndGapUnitValueSameTagError");
            Expect.Once.On(mockView).Method("ShowMinAndTargetSameTagError");
            Expect.Once.On(mockView).Method("ShowMinAndGapUnitValueSameTagError");
            Expect.Once.On(mockView).Method("ShowTargetAndGapUnitValueSameTagError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenAnotherTargetDefinitionAlreadyWritesToTags()
        {
            List <TagInfo> tags = TagInfoFixture.CreateTagInfoList(SiteFixture.Sarnia(),1);
            
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").Will(Return.Value(true));
            Stub.On(mockPlantHistorianService).Method("CanWriteTagValue").Will(Return.Value(true));
            
            Expect.Exactly(4).On(mockService).Method("IsValidWriteTag").Will(Return.Value(new Error("DontcareError")));            
            
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tags[0]));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tags[1]));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tags[2]));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tags[3]));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxTagAssociatedToOtherTargetDefinitionError").WithAnyArguments();
            Expect.Once.On(mockView).Method("ShowMinTagAssociatedToOtherTargetDefinitionError");
            Expect.Once.On(mockView).Method("ShowTargetTagAssociatedToOtherTargetDefinitionError");
            Expect.Once.On(mockView).Method("ShowGapUnitValueTagAssociatedToOtherTargetDefinitionError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenATagCannotBeReadFrom()
        {
            List<TagInfo> tags = TagInfoFixture.CreateTagInfoList(SiteFixture.Sarnia(),1);

            Expect.Exactly(4).On(mockPlantHistorianService).Method("CanReadTagValue").Will(Return.Value(false));

            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tags[0]));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tags[1]));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tags[2]));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tags[3]));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxTagInvalidReadError");
            Expect.Once.On(mockView).Method("ShowMinTagInvalidReadError");
            Expect.Once.On(mockView).Method("ShowTargetTagInvalidReadError");
            Expect.Once.On(mockView).Method("ShowGapUnitValueTagInvalidReadError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldFailToAcceptAndSetErrorMessageWhenATagCannotBeWrittenTo()
        {
            List<TagInfo> tags = TagInfoFixture.CreateTagInfoList(SiteFixture.Sarnia(),1);

            Expect.Exactly(4).On(mockPlantHistorianService).Method("CanWriteTagValue").Will(Return.Value(false));

            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tags[0]));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tags[1]));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tags[2]));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tags[3]));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("ShowMaxTagInvalidWriteError");
            Expect.Once.On(mockView).Method("ShowMinTagInvalidWriteError");
            Expect.Once.On(mockView).Method("ShowTargetTagInvalidWriteError");
            Expect.Once.On(mockView).Method("ShowGapUnitValueTagInvalidWriteError");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldValidateSuccessfullyAndCloseView()
        {
            List <TagInfo> tags = TagInfoFixture.CreateTagInfoList(SiteFixture.Sarnia(),1);

            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").Will(Return.Value(true));
            Stub.On(mockPlantHistorianService).Method("CanWriteTagValue").Will(Return.Value(true));
            Expect.AtLeastOnce.On(mockService).Method("IsValidWriteTag").Will(Return.Value(Error.HasNoError));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(MAX_THRESHOLD_TAG).Will(Return.Value(tags[0]));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Write));
            Expect.Once.On(mockView).GetProperty(MIN_THRESHOLD_TAG).Will(Return.Value(tags[1]));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(TARGET_THRESHOLD_TAG).Will(Return.Value(tags[2]));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_DIRECTION).Will(Return.Value(TagDirection.Read));
            Expect.Once.On(mockView).GetProperty(GAP_UNIT_VALUE_TAG).Will(Return.Value(tags[3]));
            Expect.Once.On(mockView).Method("ClearErrors");
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            Expect.Once.On(mockView).Method("CloseView");
            presenter.Accept();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

      
    }
}