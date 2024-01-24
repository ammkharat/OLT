using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TagSearchFormPresenterTest
    {
        private TagSearchFormPresenter presenter;
        private ITagSearchFormView mockView;
        private ITagService mockService;
        private Mockery mock = new Mockery();
        private IPlantHistorianService mockPlantHistorianService;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockService = (ITagService) mock.NewMock(typeof(ITagService));
            mockPlantHistorianService = (IPlantHistorianService) mock.NewMock(typeof(IPlantHistorianService));
            mockView = (ITagSearchFormView) mock.NewMock(typeof(ITagSearchFormView));
            
            presenter = new TagSearchFormPresenter(mockView, true, false, mockService, mockPlantHistorianService);

            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void ShouldLoadView()
        {
            Expect.Once.On(mockView).SetProperty("SearchCriteria").To(IsList.Equal(SearchField.GetAllTagFields()));
            AssertControlEnabling(null, false);
            presenter.HandleFormLoad(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableSelectButtonAndCheckTagAbilityToReadWriteFromPlantHistorianWhenItemSelected()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();

            bool canRead = true;
            bool canWrite = true;
            Expect.Once.On(mockPlantHistorianService).Method("CanReadTagValue").With(tag).Will(Return.Value(canRead));
            Expect.Once.On(mockPlantHistorianService).Method("CanWriteTagValue").With(tag).Will(Return.Value(canWrite));
            Expect.Once.On(mockView).SetProperty("SelectedTagReadStatus").To(canRead);
            Expect.Once.On(mockView).SetProperty("SelectedTagWriteStatus").To(canRead);
            
            AssertControlEnabling(tag, true);
            presenter.SelectedItemChangedEvent(null, new DomainEventArgs<TagInfo>(tag));
            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldSetDialogResultAndCloseFormOnSelectButtonClick()
        {
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            Expect.Once.On(mockView).Method("CloseForm");
            presenter.SelectButtonClickEvent(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldSetDialogResultAndCloseFormOnRowDoubleClick()
        {
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            Expect.Once.On(mockView).Method("CloseForm");
            presenter.DoubleClickSelectedEvent(null, new DomainEventArgs<TagInfo>(null));
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCancelForm()
        {
            Expect.Once.On(mockView).Method("CloseForm");
            presenter.CancelButtonClickEvent(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertControlEnabling(TagInfo tag, bool enabled)
        {
            Expect.Once.On(mockView).GetProperty("SelectedTag").Will(Return.Value(tag));
            if (! enabled)
            {
                Expect.Once.On(mockView).Method("ResetTagStatusImages");
            }
            Expect.Once.On(mockView).SetProperty("SelectButtonEnabled").To(enabled);
        }
        
        [Test]
        public void ShouldSuccessfullySearchForTags()
        {
            Expect.Once.On(mockView).Method("ClearErrorProviders");
         
            Expect.Once.On(mockView).GetProperty("CriteriaField").Will(Return.Value(GetTagNameField()));
            Expect.Exactly(2).On(mockView).GetProperty("CriteriaValue").Will(Return.Value("tagName"));
            
            List<TagInfo> tagList = TagInfoFixture.CreateTagListForSarnia();
            Expect.Once.On(mockService).Method("QueryTagInfoByFilter").WithAnyArguments().Will(Return.Value(tagList));
            Expect.Once.On(mockView).SetProperty("ListData").To(tagList);

            AssertControlEnabling(null, false);
            
            presenter.SearchButtonClickEvent(null, EventArgs.Empty);
        }
        
        [Test]
        public void ShouldFailToSearchIfCriteriaValueIsEmpty()
        {
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Once.On(mockView).GetProperty("CriteriaValue").Will(Return.Value(string.Empty));
            Expect.Once.On(mockView).Method("ShowInvalidCriteriaValueError");
            
            presenter.SearchButtonClickEvent(null, EventArgs.Empty);
        }

        public static SearchField GetTagNameField()
        {
            return new SearchField("Tag Name", "Name", FieldType.Text);
        }

        
    }
}