using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TagInfoGroupFormPresenter : AbstractFormPresenter<ITagInfoGroupFormView, TagInfoGroup>
    {
        private readonly IPlantHistorianService plantHistorianService;
        private readonly ITagInfoGroupService tagInfoGroupService;

        public TagInfoGroupFormPresenter(ITagInfoGroupFormView view)
            : this(view, new TagInfoGroup(null, string.Empty, ClientSession.GetUserContext().Site))
        {
        }

        public TagInfoGroupFormPresenter(ITagInfoGroupFormView view, TagInfoGroup tagInfoGroup) : this(
            view,
            tagInfoGroup,
            ClientServiceRegistry.Instance.GetService<ITagInfoGroupService>(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>())
        {
        }

        public TagInfoGroupFormPresenter(
            ITagInfoGroupFormView view,
            TagInfoGroup tagInfoGroup,
            ITagInfoGroupService tagInfoGroupService,
            IPlantHistorianService plantHistorianService) : base(view, new TagInfoGroup(tagInfoGroup))
        {
            this.tagInfoGroupService = tagInfoGroupService;
            this.plantHistorianService = plantHistorianService;
        }

        public TagInfoGroup TagInfoGroup
        {
            get { return editObject; }
        }

        public void HandleLoad(object sender, EventArgs args)
        {
            UpdateViewFromEditObject();
        }

        private void UpdateViewFromEditObject()
        {
            view.TagInfoGroupName = editObject.Name;
            view.TagInfoList = AdaptToError(editObject.TagInfoList);
            view.UpdateTitleAsCreateOrEdit(editObject.Id.HasValue);
            ControlEnablementOfButtons();
        }

        public void HandleAddTagInfo(object sender, EventArgs args)
        {
            var tagInfoToBeAdded = view.GetTagInfoToBeAdded();
            if (tagInfoToBeAdded != null && editObject.TagInfoList.Contains(tagInfoToBeAdded) == false)
            {
                editObject.TagInfoList.Add(tagInfoToBeAdded);
                view.TagInfoList = AdaptToError(editObject.TagInfoList);
                ControlEnablementOfButtons();
            }
        }

        public void HandleRemoveTagInfo(object sender, EventArgs args)
        {
            var tagInfoToBeRemoved = AdaptFromError(view.GetTagInfoToBeRemoved());
            editObject.TagInfoList.Remove(tagInfoToBeRemoved);
            view.TagInfoList = AdaptToError(editObject.TagInfoList);
            ControlEnablementOfButtons();
        }

        public void HandleClearTagInfoList(object sender, EventArgs args)
        {
            editObject.TagInfoList.Clear();
            view.TagInfoList = AdaptToError(editObject.TagInfoList);
            ControlEnablementOfButtons();
        }

        private List<TagInfoWithError> AdaptToError(List<TagInfo> list)
        {
            return list.ConvertAll(tagInfo =>
            {
                var hasError =
                    ! plantHistorianService
                        .
                        CanReadTagValue
                        (tagInfo);
                return
                    new TagInfoWithError
                        (tagInfo,
                            hasError);
            });
        }

        private static TagInfo AdaptFromError(TagInfo tagInfoWithError)
        {
            return tagInfoWithError == null
                ? null
                : new TagInfo(tagInfoWithError.Id,
                    tagInfoWithError.SiteId,
                    tagInfoWithError.Name,
                    tagInfoWithError.Description,
                    tagInfoWithError.Units,
                    tagInfoWithError.Deleted, tagInfoWithError.ScadaConnectionInfoId);
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs args)
        {
            SaveOrUpdate(true);
        }

        protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            if (saveOrUpdateSucceeded)
            {
                view.SetDialogResultOK();
            }
        }

        public override void Insert(SaveUpdateDomainObjectContainer<TagInfoGroup> container)
        {
            editObject = tagInfoGroupService.Insert(container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<TagInfoGroup> container)
        {
            tagInfoGroupService.Update(container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<TagInfoGroup> GetNewObjectToInsert()
        {
            editObject.Name = view.TagInfoGroupName;
            return new SaveUpdateDomainObjectContainer<TagInfoGroup>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<TagInfoGroup> GetPopulatedEditObjectToUpdate()
        {
            editObject.Name = view.TagInfoGroupName;
            return new SaveUpdateDomainObjectContainer<TagInfoGroup>(editObject);
        }

        public void HandleCancelTagInfoGroupEditing(object sender, EventArgs e)
        {
            view.Close();
        }

        public void HandleTagInfoListSelectedItemChanged(object sender, EventArgs empty)
        {
            ControlEnablementOfButtons();
        }

        private void ControlEnablementOfButtons()
        {
            view.RemoveButtonEnabled = view.GetTagInfoToBeRemoved() != null;
            view.ClearButtonEnabled = editObject.TagInfoList.Count > 0;
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            var hasError = false;
            var name = view.TagInfoGroupName;
            if (name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowTagInfoGroupNameIsEmptyError();
                hasError = true;
            }
            var checkForNameUniqueness = true;
            if (editObject.Id.HasValue)
            {
                checkForNameUniqueness = editObject.Name != name;
            }
            if (checkForNameUniqueness)
            {
                var isNameUnique = tagInfoGroupService.IsNameUniqueToSite(name, userContext.Site);
                if (!isNameUnique)
                {
                    view.ShowTagInfoGroupNameIsDuplicateError();
                    hasError = true;
                }
            }
            if (! hasError)
            {
                if (CheckIfUserWantsToContinueSavingWithTagReadErrors() == false)
                {
                    hasError = true;
                }
            }

            return hasError;
        }

        private bool CheckIfUserWantsToContinueSavingWithTagReadErrors()
        {
            var list = AdaptToError(editObject.TagInfoList);
            var isValid = list.TrueForAll(tag => tag.HasError == false);
            return isValid || view.ShowTagReadWarningMessage() == DialogResult.Yes;
        }
    }


    public class TagInfoWithError : TagInfo
    {
        public TagInfoWithError(TagInfo info, bool hasError)
            : base(info.Id, info.SiteId, info.Name, info.Description, info.Units, info.Deleted,info.ScadaConnectionInfoId)
        {
            HasError = hasError;
        }

        public bool HasError { get; set; }
    }
}