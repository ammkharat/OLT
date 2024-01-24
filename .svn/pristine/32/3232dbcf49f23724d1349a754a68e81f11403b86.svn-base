using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TagInfoGroupFormPresenterTest
    {
        private Mockery mocks;
        private ITagInfoGroupFormView mockView;
        private ITagInfoGroupService mockTagInfoGroupService;
        private IPlantHistorianService mockPlantHistorianService;
        private TagInfoGroupFormPresenter presenter;
        private TagInfoGroup tagInfoGroupToBeEdited;
        private User currentUser;
        
        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            mocks = new Mockery();
            mockView = mocks.NewMock<ITagInfoGroupFormView>();
            mockTagInfoGroupService = mocks.NewMock<ITagInfoGroupService>();
            mockPlantHistorianService = mocks.NewMock<IPlantHistorianService>();
            currentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            ClientSession.GetUserContext().User = currentUser;
            tagInfoGroupToBeEdited = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, tagInfoGroupToBeEdited, mockTagInfoGroupService, mockPlantHistorianService);

            Stub.On(mockView).Method("ShowWaitScreenAndDisableForm");
            Stub.On(mockView).Method("CloseWaitScreenAndEnableForm");
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void ShouldSetDataOnLoadHandle()
        {
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).SetProperty("TagInfoGroupName").To(tagInfoGroupToBeEdited.Name);
            Expect.Once.On(mockView).SetProperty("TagInfoList").To(IsList.Equal((AdaptToError(tagInfoGroupToBeEdited.TagInfoList, false))));
            Expect.Once.On(mockView).Method("UpdateTitleAsCreateOrEdit").With(tagInfoGroupToBeEdited.Id.HasValue);
            
            AssertEnablingOfButtons(null, false, true);
            
            presenter.HandleLoad(null, EventArgs.Empty);
        }

        private void AssertEnablingOfButtons(TagInfo info, bool removeEnabled,bool clearEnabled)
        {
            Expect.Once.On(mockView).Method("GetTagInfoToBeRemoved").Will(Return.Value(ConvertOne(info, false)));
            Expect.Once.On(mockView).SetProperty("RemoveButtonEnabled").To(removeEnabled);
            Expect.Once.On(mockView).SetProperty("ClearButtonEnabled").To(clearEnabled);
        }

        [Test]
        public void ShouldAddNewTagInfoOnlyWhenSelectedTagInfoIsValid()
        {
            TagInfo newTagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            HandleAddTagInfoTest(newTagInfo);
        }

        [Test]
        public void ShouldNotAddWhenSelectedTagInfoIsNull()
        {
            const TagInfo tagInfoToBeAdded = null;
            HandleAddTagInfoTest(tagInfoToBeAdded);
        }

        [Test]
        public void ShouldNotAddTheSameTagInfoToTheListTwice()
        {
            TagInfo tagInfoToBeAdded = tagInfoGroupToBeEdited.TagInfoList[0];
            HandleAddTagInfoTest(tagInfoToBeAdded);
        }

        private void HandleAddTagInfoTest(TagInfo tagInfoToBeAdded)
        {
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).Method("GetTagInfoToBeAdded").Will(Return.Value(tagInfoToBeAdded));
            if (tagInfoToBeAdded != null && tagInfoGroupToBeEdited.TagInfoList.Contains(tagInfoToBeAdded) == false)
            {
                var expectedTagInfoList = new List<TagInfo>(tagInfoGroupToBeEdited.TagInfoList)
                                              {tagInfoToBeAdded};
                Expect.Once.On(mockView).SetProperty("TagInfoList").To(IsList.Equal(AdaptToError(expectedTagInfoList, false)));
                AssertEnablingOfButtons(tagInfoToBeAdded, true, true);
            }
            presenter.HandleAddTagInfo(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldRemoveSelectedItemOnHandleRemoveTagInfo()
        {
            HandleRemoveTagInfoTest(tagInfoGroupToBeEdited.TagInfoList[0]);
        }

        private void HandleRemoveTagInfoTest(TagInfo tagInfoToBeRemoved)
        {
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).Method("GetTagInfoToBeRemoved").Will(Return.Value(ConvertOne(tagInfoToBeRemoved, false)));
            var expectedTagInfoList = new List<TagInfo>(tagInfoGroupToBeEdited.TagInfoList);
            expectedTagInfoList.Remove(tagInfoToBeRemoved);
            Expect.Once.On(mockView).SetProperty("TagInfoList").To(IsList.Equal((AdaptToError(expectedTagInfoList, false))));
            AssertEnablingOfButtons(tagInfoToBeRemoved, true, true);
            presenter.HandleRemoveTagInfo(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldClearTagInfoListOnHandleClearTagInfoList()
        {
            var emptyList = new List<TagInfo>();
            Expect.Once.On(mockView).SetProperty("TagInfoList").To(IsList.Equal(AdaptToError(emptyList, false)));
            AssertEnablingOfButtons(null, false, false);
            presenter.HandleClearTagInfoList(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldBeAbleToSaveNewTagInfoGroup()
        {
            TagInfoGroup newTagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, newTagInfoGroup, mockTagInfoGroupService, mockPlantHistorianService); 

            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(newTagInfoGroup.Name));
            const bool isNameUnique = true;
            SetExpectationsForValidate(isNameUnique, newTagInfoGroup);
            Expect.Once.On(mockTagInfoGroupService).Method("Insert").With(newTagInfoGroup);
            Expect.Once.On(mockView).Method("Close");
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayErrorMessageIfNameIsNotUniqueWhenAddingNewTagInfoGroup()
        {
            TagInfoGroup newTagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, newTagInfoGroup, mockTagInfoGroupService, mockPlantHistorianService);
            const bool isNameUnique = false;
            SetExpectationsForValidate(isNameUnique, newTagInfoGroup);
            Expect.Once.On(mockView).Method("ShowTagInfoGroupNameIsDuplicateError");
            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetExpectationsForValidate(bool isNameUnique, TagInfoGroup tagInfoGroup)
        {
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Once.On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(tagInfoGroup.Name));
            Expect.Once.On(mockTagInfoGroupService).Method("IsNameUniqueToSite")
                    .With(tagInfoGroup.Name, currentUser.AvailableSites[0])
                    .Will(Return.Value(isNameUnique));
        }

        [Test]
        public void ShouldBeAbleToSaveExistingTagInfoGroup()
        {
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, existingTagInfoGroup, mockTagInfoGroupService, mockPlantHistorianService);
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Exactly(2).On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(existingTagInfoGroup.Name));
            Expect.Once.On(mockTagInfoGroupService).Method("Update").With(existingTagInfoGroup);
            Expect.Once.On(mockView).Method("Close");
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSaveExistingTagInfoWhenNameHasChangedToValidName()
        {
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, existingTagInfoGroup, mockTagInfoGroupService, mockPlantHistorianService);
            string newName = existingTagInfoGroup.Name + "xxx";
            
            Stub.On(mockPlantHistorianService).Method("CanReadTagValue").WithAnyArguments().Will(Return.Value(true));
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Exactly(2).On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(newName));
            Expect.Once.On(mockTagInfoGroupService).Method("IsNameUniqueToSite")
                    .With(newName, currentUser.AvailableSites[0])
                    .Will(Return.Value(true));
            existingTagInfoGroup.Name = newName;
            Expect.Once.On(mockTagInfoGroupService).Method("Update").With(existingTagInfoGroup);
            Expect.Once.On(mockView).Method("Close");
            Expect.Once.On(mockView).Method("SetDialogResultOK");
            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayErrorMessageIfNameIsNotValidWhenUpdatingExistingTagInfoGroup()
        {
            const bool isUniqueName = false;
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            presenter = new TagInfoGroupFormPresenter(mockView, existingTagInfoGroup, mockTagInfoGroupService, mockPlantHistorianService);
            string newName = existingTagInfoGroup.Name + "xxx";
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Once.On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(newName));
            Expect.Once.On(mockTagInfoGroupService).Method("IsNameUniqueToSite")
                    .With(newName, currentUser.AvailableSites[0])
                    .Will(Return.Value(isUniqueName));
            Expect.Once.On(mockView).Method("ShowTagInfoGroupNameIsDuplicateError");
            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateThatTagNameIsEmptyAndSetErrorOnView()
        {
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            Expect.Once.On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(string.Empty));
            Expect.Once.On(mockView).Method("ShowTagInfoGroupNameIsEmptyError");
            Stub.On(mockTagInfoGroupService).Method("IsNameUniqueToSite").Will(Return.Value(true));
            Expect.Never.On(mockView).Method("ShowTagInfoGroupNameIsDuplicateError");
            Assert.IsTrue(presenter.ValidateViewHasError());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateThatTagNameIsDuplicateAndSetErrorOnView()
        {
            Expect.Once.On(mockView).Method("ClearErrorProviders");
            const string duplicateName = "Duplicate";
            const bool isUniqueName = false;
            Expect.Once.On(mockView).GetProperty("TagInfoGroupName").Will(Return.Value(duplicateName));
            Expect.Once.On(mockTagInfoGroupService).Method("IsNameUniqueToSite")
                    .With(duplicateName, currentUser.AvailableSites[0])
                    .Will(Return.Value(isUniqueName));
            Expect.Once.On(mockView).Method("ShowTagInfoGroupNameIsDuplicateError");
            Expect.Never.On(mockView).Method("ShowTagInfoGroupNameIsEmptyError");
            Assert.IsTrue(presenter.ValidateViewHasError());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDoNothingOnCancel()
        {
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleCancelTagInfoGroupEditing(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisableRemoveButtonWhenSelectedItemForRemovalIsNull()
        {
            AssertEnablingOfButtons(null, false, true);
            presenter.HandleTagInfoListSelectedItemChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEnableRemoveButtonWhenSelectedItemForRemovalIsNotNull()
        {
            AssertEnablingOfButtons(TagInfoFixture.CreateTagInfoWithId2FromDB(), true, true);
            presenter.HandleTagInfoListSelectedItemChanged(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static List<TagInfoWithError> AdaptToError(List<TagInfo> list, bool hasError)
        {
            return list.ConvertAll(
                tagInfo => ConvertOne(tagInfo, hasError));
        }

        private static TagInfoWithError ConvertOne(TagInfo tagInfo, bool hasError)
        {
            return tagInfo == null ? null : new TagInfoWithError(tagInfo, hasError);
        }
    }
}