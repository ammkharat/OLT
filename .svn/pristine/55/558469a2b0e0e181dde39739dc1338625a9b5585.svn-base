using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SingleSelectShiftForm : BaseForm, IShiftSelectionForm
    {
        private readonly ShiftFormSelectionPresenter presenter;
        private ShiftPattern selectedShift;
        private DomainListView<ShiftPattern> listView;

        public SingleSelectShiftForm(List<ShiftPattern> shiftFlocLists)
        {
            Initialize();
            presenter = new ShiftFormSelectionPresenter(this, shiftFlocLists);
            RegisterEventHandlersOnPresenter();       
        }

        private void Initialize()
        {
            InitializeComponent();
            AcceptButton = acceptButton;
            StartPosition = FormStartPosition.CenterParent;

            listView = new DomainListView<ShiftPattern>(new ShiftSelectorListViewRenderer(), false);
            listView.Dock = DockStyle.Fill;
            shiftFlocPanel.Controls.Add(listView);
        }

        private void RegisterEventHandlersOnPresenter()
        {
            Load += presenter.HandleFormLoad;
            acceptButton.Click += presenter.HandleAcceptButtonClick;
            listView.SelectedItemChanged += presenter.HandleSelectedItemChanged;
            listView.DoubleClickSelected += presenter.HandleOnDoubleClick;            
        }


        public ShiftPattern SelectedShiftPattern
        {
            set { selectedShift = value; }
            get { return selectedShift; }
        }

        public void CloseForm()
        {
            Close();
        }

        public DomainListView<ShiftPattern> ShiftPatternListView
        {
            get { return listView; }
        }

        public void SelectItem(DomainObject selected)
        {
            foreach (DomainListViewItem<ShiftPattern> lvi in listView.Items)
            {
                if (lvi.Item.Equals(selected))
                {
                    lvi.Selected = true;
                    listView.Select();
                    break;
                }
            }
        }

        public int ListViewItemCount
        {
            get { return listView.Items.Count; }
        }

        public List<ShiftPattern> ShiftPatternToAddToListView
        {
            set { listView.ItemList = value; }
            get { return listView.ItemList; }
        }

        public bool ShiftWasSelected()
        {
            return listView.SelectedItems != null;
        }

        public bool SetNoShiftSelectedError
        {
            set
            {
                noShiftSelectedErrorProvider.SetError(acceptButton,
                                                      value ? StringResources.NoShiftSelectedError : string.Empty);
            }
        }

        public bool SetSelectedShiftWasOutsideOfAllowedTimeRangeError
        {
            set
            {
                noShiftSelectedErrorProvider.SetError(
                    acceptButton, value ? StringResources.AfterAllowedShiftSelectionWindowError : String.Empty);
            }
        }

    }
}
