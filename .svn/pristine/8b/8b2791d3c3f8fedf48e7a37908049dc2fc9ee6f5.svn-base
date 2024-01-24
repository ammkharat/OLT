using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditRestrictionReasonCodesForm : BaseForm, IEditRestrictionReasonCodesView
    {        
        private readonly DomainSummaryGrid<RestrictionReasonCode> grid;

        public EditRestrictionReasonCodesForm()
        {
            InitializeComponent(); 
            InitializePresenter();
            
            grid = new DomainSummaryGrid<RestrictionReasonCode>(
                new RestrictionReasonCodeGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;  
            reasonCodePanel.Controls.Add(grid);
        }

        private void InitializePresenter()
        {
            EditRestrictionReasonCodesPresenter presenter = new EditRestrictionReasonCodesPresenter(this);
            Load += presenter.HandleLoad;

            addButton.Click += presenter.HandleAddButtonClicked;
            editButton.Click += presenter.HandleEditButtonClicked;
            deleteButton.Click += presenter.HandleDeleteButtonClicked;

            saveButton.Click += presenter.HandleSaveButtonClicked;
            cancelButton.Click += presenter.HandleCancelButtonClicked;
        }
 
        public List<RestrictionReasonCode> Items
        {
            set { grid.Items = value; }
        }

        public RestrictionReasonCode SelectedReasonCode
        {
            get { return grid.SelectedItem;  }
        }

        public void SelectReasonCode(RestrictionReasonCode reasonCodeToSelect)
        {
            grid.SelectItemByReference(reasonCodeToSelect);            
        }

        public void RebindGrid()
        {
            grid.ResetBindings();
        }
    }
}
