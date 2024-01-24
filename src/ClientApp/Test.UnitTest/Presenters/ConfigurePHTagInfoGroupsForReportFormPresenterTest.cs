using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigurePHTagInfoGroupsForReportFormPresenterTest
    {
        private Mockery mocks;
        private IConfigurePHTagInfoGroupsForReportFormView mockView;
        private ITagInfoGroupService mockTagInfoGroupService;

        private ConfigurePHTagInfoGroupsForReportFormPresenter presenter;
        private User currentUser;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IConfigurePHTagInfoGroupsForReportFormView>();
            mockTagInfoGroupService = mocks.NewMock<ITagInfoGroupService>();

            currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            ClientSession.GetUserContext().User = currentUser;

            presenter = new ConfigurePHTagInfoGroupsForReportFormPresenter(mockView, mockTagInfoGroupService);
        }

        [Test]
        public void ShouldLoadExistingTagInfoGroupOnHandleLoad()
        {
            List<TagInfoGroup> existingTagInfoGroupList
                    = TagInfoGroupFixture.CreateSampleExistingTagInfoGroupList(ClientSession.GetUserContext().Site, ClientSession.GetUserContext().Site.IdValue);
            Expect.Once.On(mockTagInfoGroupService).Method("QueryTagInfoGroupListBySite")
                    .With(ClientSession.GetUserContext().Site)
                    .Will(Return.Value(existingTagInfoGroupList));
            Expect.Once.On(mockView).SetProperty("SiteName").To(ClientSession.GetUserContext().Site.Name);
            Expect.Once.On(mockView).SetProperty("TagInfoGroupList").To(existingTagInfoGroupList);
            AssertControlEnablementOfButtons(null, false, false);
            
            presenter.HandleLoad(null, EventArgs.Empty);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldUpdateTagInfoGroupListIfUserCreateNewTagInfoGroupOnHandleNewButtonClick()
        {
            TagInfoGroup newTagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();

            Expect.Once.On(mockView).Method("AddNewTagInfoGroup").Will(Return.Value(DialogResult.OK));
            List<TagInfoGroup> existingTagInfoGroupList = TagInfoGroupFixture.CreateSampleExistingTagInfoGroupList(ClientSession.GetUserContext().Site, ClientSession.GetUserContext().Site.IdValue);
            existingTagInfoGroupList.Add(newTagInfoGroup);
            Expect.Once.On(mockTagInfoGroupService).Method("QueryTagInfoGroupListBySite").With(ClientSession.GetUserContext().Site).Will(Return.Value(existingTagInfoGroupList));
            Expect.Once.On(mockView).SetProperty("TagInfoGroupList").To(existingTagInfoGroupList);
            AssertControlEnablementOfButtons(null, false, false);
            presenter.HandleNewButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldBeAbleToHandleWhenUserAbortsAddingNewTagInfoGroup()
        {
            Expect.Once.On(mockView).Method("AddNewTagInfoGroup").Will(Return.Value(DialogResult.Cancel));
            Expect.Never.On(mockTagInfoGroupService).Method("QueryTagInfoGroupListBySite");
            Expect.Never.On(mockView).SetProperty("TagInfoGroupList");

            presenter.HandleNewButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldUpdateTagInfoGroupListAfterEditingTagInfoGroup()
        {
            List<TagInfoGroup> existingTagInfoGroupList = TagInfoGroupFixture.CreateSampleExistingTagInfoGroupList(ClientSession.GetUserContext().Site, ClientSession.GetUserContext().Site.IdValue);
            int selectedIndex = 0;
            TagInfoGroup selectedTagInfoGroup = existingTagInfoGroupList[selectedIndex];

            string newTagInfoGroupName = "New Name";
            List<TagInfo> newTagInfoList = new List<TagInfo>();
            TagInfoGroup tagInfoGroupAfterEdit = new TagInfoGroup(selectedTagInfoGroup.Id,
                                                                   newTagInfoGroupName,
                                                                   selectedTagInfoGroup.Site)
                                                     {TagInfoList = newTagInfoList};

            Expect.Once.On(mockView).GetProperty("TagInfoGroupList").Will(Return.Value(existingTagInfoGroupList));
            Expect.Once.On(mockView).Method("GetSelectedTagInfoGroup").Will(Return.Value(selectedTagInfoGroup));
            Expect.Once.On(mockView).Method("ShowTagInfoGroupForm").WithAnyArguments()
                .Will(Return.Value(tagInfoGroupAfterEdit));

            List<TagInfoGroup> expectedGroupList = new List<TagInfoGroup>(existingTagInfoGroupList);
            expectedGroupList.Remove(selectedTagInfoGroup);
            expectedGroupList.Insert(selectedIndex, tagInfoGroupAfterEdit);
            Expect.Once.On(mockView).SetProperty("TagInfoGroupList").To(IsList.Equal(expectedGroupList));

            presenter.HandleEditButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void HandleTagInfoGroupListSelectedItemChangedTest(TagInfoGroup selectedTagInfoGroup, bool expectedDeleteButtonEnabled,  bool expectedEditButtonEnabled)
        {
            Expect.Once.On(mockView).Method("GetSelectedTagInfoGroup").Will(Return.Value(selectedTagInfoGroup));
            Expect.Once.On(mockView).SetProperty("DeleteButtonEnabled").To(expectedDeleteButtonEnabled);
            Expect.Once.On(mockView).SetProperty("EditButtonEnabled").To(expectedEditButtonEnabled);
            presenter.HandleSelectedItemChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableEditAndDeleteOnlyWhenSelectedItemIsNotNull()
        {
            TagInfoGroup selectedTagInfoGroup = null;
            bool expectedDeleteButtonEnabled = false;
            bool expectedEditButtonEnabled = false;

            HandleTagInfoGroupListSelectedItemChangedTest(selectedTagInfoGroup, expectedDeleteButtonEnabled, expectedEditButtonEnabled);
        }
        
        [Test]
        public void ShouldProceedWithDeletionWhenDeletionIsConfirmed()
        {
            bool confirmDeletion = true;
            HandleDeleteButtonClickTest(confirmDeletion);
        }

        [Test]
        public void ShouldNotDeleteIfDeletionIsNotConfirmed()
        {
            bool confirmDeletion = false;
            HandleDeleteButtonClickTest(confirmDeletion);
        }

        private void HandleDeleteButtonClickTest(bool confirmDeletion)
        {
            List<TagInfoGroup> existingTagInfoGroupList = TagInfoGroupFixture.CreateSampleExistingTagInfoGroupList(ClientSession.GetUserContext().Site, ClientSession.GetUserContext().Site.IdValue);
            TagInfoGroup selectedTagInfoGroup = existingTagInfoGroupList[0];

            Expect.Once.On(mockView).Method("GetSelectedTagInfoGroup").Will(Return.Value(selectedTagInfoGroup));
            Expect.Once.On(mockView).Method("ConfirmTagInfoGroupDeletion").Will(Return.Value(confirmDeletion));
            if (confirmDeletion)
            {
                Expect.Once.On(mockView).GetProperty("TagInfoGroupList").Will(Return.Value(existingTagInfoGroupList));
                Expect.Once.On(mockTagInfoGroupService).Method("Remove").With(selectedTagInfoGroup);
                existingTagInfoGroupList.Remove(selectedTagInfoGroup);
                Expect.Once.On(mockView).SetProperty("TagInfoGroupList").To(existingTagInfoGroupList);
                AssertControlEnablementOfButtons(null, false, false);
            }
            presenter.HandleDeleteButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertControlEnablementOfButtons(TagInfoGroup selectedTagInfoGroup, bool deleteEnabled, bool editEnabled)
        {
            Expect.Once.On(mockView).Method("GetSelectedTagInfoGroup").Will(Return.Value(selectedTagInfoGroup));
            Expect.Once.On(mockView).SetProperty("DeleteButtonEnabled").To(deleteEnabled);
            Expect.Once.On(mockView).SetProperty("EditButtonEnabled").To(editEnabled);
        }

        [Test]
        public void ShouldCloseTheViewOnHandleCloseButtonClick()
        {
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleCloseButtonClick(null, EventArgs.Empty);
        }
    }
}
