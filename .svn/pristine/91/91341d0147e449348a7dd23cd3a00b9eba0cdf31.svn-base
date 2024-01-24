using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TagSearchFormPresenter
    {
        private readonly ITagSearchFormView view;
        private readonly bool showReadWriteStatus;
        private readonly bool warnOnSelectedNotWritable;
        
        private readonly ITagService tagService;
        private readonly IPlantHistorianService plantHistorianService;

        public TagSearchFormPresenter(ITagSearchFormView view, bool showReadWriteStatus, bool warnOnSelectedNotWritable) : this(
            view,
            showReadWriteStatus, warnOnSelectedNotWritable,
            ClientServiceRegistry.Instance.GetService<ITagService>(),
            ClientServiceRegistry.Instance.GetService<IPlantHistorianService>())
        {
        }

        public TagSearchFormPresenter(
            ITagSearchFormView view, 
            bool showReadWriteStatus, bool warnOnSelectedNotWritable,
            ITagService tagService,
            IPlantHistorianService plantHistorianService)
        {
            this.view = view;
            this.showReadWriteStatus = showReadWriteStatus;
            this.warnOnSelectedNotWritable = warnOnSelectedNotWritable;
            this.tagService = tagService;
            this.plantHistorianService = plantHistorianService;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.SearchCriteria = SearchField.GetAllTagFields();
            ControlEnabling(view.SelectedTag);
        }

        public void SelectedItemChangedEvent(object sender, DomainEventArgs<TagInfo> e)
        {
            TagInfo selected = view.SelectedTag;
            if(selected != null && showReadWriteStatus)
            {
                view.SelectedTagReadStatus = plantHistorianService.CanReadTagValue(selected);
                view.SelectedTagWriteStatus = plantHistorianService.CanWriteTagValue(selected);
            }
            ControlEnabling(selected);
        }

        public void DoubleClickSelectedEvent(object sender, DomainEventArgs<TagInfo> e)
        {
            SelectTagItem();
        }

        public void SelectButtonClickEvent(object sender, EventArgs eventArgs)
        {
            SelectTagItem();
        }

        private void SelectTagItem()
        {
            if (warnOnSelectedNotWritable && view.SelectedTagWriteStatus == false)
            {
                view.ShowMustSelectWritableTag();
                view.SetDialogResultNone();
            }
            else
            {
                view.SetDialogResultOK();
                view.CloseForm();
            }
        }

        public void CancelButtonClickEvent(object sender, EventArgs eventArgs)
        {
            view.CloseForm();
        }

        public void SearchButtonClickEvent(object sender, EventArgs eventArgs)
        {
            SearchForItems();
        }

        private void ControlEnabling(TagInfo selected)
        {
            bool isSelectedItem = selected != null;
            if (! isSelectedItem)
            {
                view.ResetTagStatusImages();
            }
            view.SelectButtonEnabled = isSelectedItem;
        }

        private void SearchForItems()
        {
            view.ClearErrorProviders();
            
            if(IsSearchCriteriaValid())
            {
                var queryTagInfoByFilter = tagService.QueryTagInfoByFilter(ClientSession.GetUserContext().Site, CreateUserCriteria());

                view.ListData = queryTagInfoByFilter;
                ControlEnabling(view.SelectedTag);
            }
        }

        private bool IsSearchCriteriaValid()
        {
            if (view.CriteriaValue.IsNullOrEmptyOrWhitespace())
            {
                view.ShowInvalidCriteriaValueError();
                return false;
            }
            return true;
        }

        private SearchCriteria CreateUserCriteria()
        {
            var userCriteria = new SearchCriteria
                                   {
                                       Field = view.CriteriaField,
                                       Value = view.CriteriaValue
                                   };
            return userCriteria;
        }
   }
}