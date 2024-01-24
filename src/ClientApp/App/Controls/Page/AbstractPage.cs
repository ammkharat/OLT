using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public abstract class AbstractPage<TDto, TDetails> : BasePage, IDomainPage<TDto, TDetails>
        where TDto : DomainObject
        where TDetails : IDetails
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<AbstractPage<TDto, TDetails>>();

        protected readonly TDetails details;
        protected readonly DomainSummaryGrid<TDto> grid;

        public event EventHandler DetailsChanged;
        public event EventHandler ButtonsChanged;

        protected abstract bool IsCreatedByCurrentUser(TDto dto);
        protected abstract bool IsUpdatedByCurrentUser(TDto dto);

        public abstract PageKey PageKey { get; }

        protected AbstractPage(DomainSummaryGrid<TDto> grid, TDetails details)
        {            
            this.details = details;
            this.grid = grid;
            
            HideControlsUntilDoneInitializing();
            AddComponents(grid, details);
            ShowControlsAfterDoneInitializing();
        }

        public TDetails Details
        {
            get { return details; }
        }

        public DomainSummaryGrid<TDto> Grid
        {
            get { return grid; }
        }

        public virtual List<TDto> SelectedItems
        {
            get { return grid.SelectedItems; }
        }

        // This is to give a non-generic version in the non-generic interface for the multi-grid stuff.
        public List<DomainObject> SelectedDTOs
        {
            get { return SelectedItems.ConvertAll(i => (DomainObject)i); }
        }

        public bool EnableLayoutIsActiveIndicator
        {
            set { details.EnableLayoutIsActiveIndicator = value; }
        }

        public virtual bool CanSelectItemFromAnotherPage
        {
            get { return true; }
        }

        public bool IsItemSelected()
        {
            return grid.SelectedItem != null;
        }

        public TDto FirstSelectedItem
        {
            get { return SelectedItems.Count > 0 ? SelectedItems[0] : null; }
        }

        public void HideDetails()
        {
            details.Hide();
        }

        public bool ButtonsEnabled
        {
            set
            {
                if (MainParentForm != null)
                {
                    MainParentForm.ButtonsEnabled = value;
                }
                details.Enabled = value;
            }
        }

        public void ShowDetails()
        {
            details.Show();
        }

        private void ShowControlsAfterDoneInitializing()
        {
            grid.Visible = true;
            details.Show();
        }

        private void HideControlsUntilDoneInitializing()
        {
            grid.Visible = false;
            details.Hide();
        }

        public IMainForm MainParentForm
        {
            get { return ParentForm as MainForm; }
        }

        public void CancelSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.CancelRecurringLogSuccessfulMessage,
                               StringResources.CancelRecurringLogSuccessfulTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }

        public void DeleteSuccessfulMessage()
        {
            PageHelper.DeleteSuccessfulMessage();
        }

        public void LaunchLockDeniedMessage(string nameOfUserWithCurrentLock, LockType lockType)
        {
            PageHelper.LaunchLockDeniedMessage(Form.ActiveForm, nameOfUserWithCurrentLock, lockType);           
        }

        public bool ShowOKCancelDialog(string dialogText, string title)
        {
            return PageHelper.ShowOKCancelDialog(dialogText, title);
        }

        public void DisplayErrorMessageDialog(string message, string title)
        {
            OltMessageBox.Show(Form.ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowUnableToReturnTheAmountOfDataRequestedError(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SelectSingleItemById(long? id)
        {
            grid.ClearSelections();
            grid.SelectItemById(id);
        }

        private void SelectAdditionalItemById(long? id)
        {
            grid.SelectItemById(id);
        }

        public void ClearSelectionsAndSelectItemsById(List<long> ids)
        {
            grid.ClearSelections();
            ids.ForEach(id => SelectAdditionalItemById(id));
        }

        public bool ContainsItemById(long? id)
        {
            return grid.ContainsItem(id);
        }

        public IList<TDto> Items
        {
            get { return grid.Items; }
            set { grid.Items = value; }
        }

        private void OnButtonsChanged()
        {
            if (ButtonsChanged != null)
                ButtonsChanged(this, EventArgs.Empty);
        }

        private void OnDetailsChanged()
        {
            if (DetailsChanged != null)
                DetailsChanged(this, EventArgs.Empty);
        }

        public void AddItem(TDto dto)
        {
            if (!ItemIsInGrid(dto))
            {
                grid.AddItem(dto);

                if (IsCreatedByCurrentUser(dto))
                {
                    // only need to select the item that the user created because
                    // it's not possible to have other items selected when you just created one.
                    SelectSingleItemById(dto.Id);
                    grid.ScrollToItemById(dto.Id);
                }
            }
            else
            {
                logger.InfoFormat("{0} with id: {1} was already found in the grid. Skipping AddItem.", dto.GetType().Name, dto.Id);
            }
        }

        public bool ItemIsInGrid(TDto dto)
        {
            return grid.FindItem(dto.Id) != null;
        }

        public void UpdateItem(TDto dto)
        {
            TDto updatedVersion = dto;
            TDto oldVersion = grid.FindItem(dto.Id);
            int updateIndex = grid.Items.IndexOf(oldVersion);

            // Got an Update Event for an item not in our list. So, ignore it.
            if (updateIndex == -1)
                return;

            grid.UpdateItem(updateIndex, updatedVersion);

            // The item that was updated is the item showing in the details pane, so reselect it
            if (DetailsPaneItem != null && updatedVersion.Id == DetailsPaneItem.Id)
            {
                SelectSingleItemById(updatedVersion.Id);
                OnDetailsChanged();
            }

            if (IsUpdatedByCurrentUser(dto))
            {
                grid.ScrollToItemById(dto.Id);
            }

            OnButtonsChanged();
        }

        public void RemoveItem(TDto dto)
        {
            TDto toBeRemoved = grid.FindItem(dto.Id);

            // Somehow we got notified of an event for an item that we don't care about cause it's not in our visible list.
            if (toBeRemoved == null)
                return;

            grid.RemoveItem(toBeRemoved);
            
            if (Items.Count == 0)
            {
                // Nothing in the grid now, so make sure Buttons and Details are updated
                OnDetailsChanged();
                OnButtonsChanged();
            }
            else if (FirstSelectedItem != null && FirstSelectedItem.Id == dto.Id)
            {
                // Removing the First Item selected, so Details and Buttons should be notified.
                OnDetailsChanged();
                OnButtonsChanged();
            }
            else if (SelectedItemsContains(dto))
            {
                // Removing one of the other selected items, so update the buttons.
                OnButtonsChanged();
            }
        }

        private bool SelectedItemsContains(TDto dto)
        {
            return grid.SelectedItems.Count > 0 
                   && grid.SelectedItems.ExistsById(dto);
        }

        public void SelectSingleItemByIndex(int visibleIndex)
        {
            grid.SelectSingleItemByIndex(visibleIndex);            
        }
        
        private TDto DetailsPaneItem
        {
            get { return FirstSelectedItem; }
        }

        public virtual void ExportAll()
        {
            new OltExcelExporter().Export(grid);
        }

        public DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog()
        {
            return PageHelper.DisplayDateRangeDialog(ParentForm);
        }

        public virtual string TabText
        {
            get { return PageKey.TabText; }
        }

        public Type PageDtoType
        {
            get { return typeof (TDto); }
        }

        public void LoadGridLayout(string xml)
        {
            PageHelper.LoadGridLayout(xml, grid);
        }

        public string GetGridLayoutXml()
        {
            return PageHelper.GetGridLayoutXml(grid);
        }

        public GridLayoutAction ShowGridLayoutConfirmationDialog()
        {
            return PageHelper.ShowGridLayoutConfirmationDialog(this);
        }
    }
}