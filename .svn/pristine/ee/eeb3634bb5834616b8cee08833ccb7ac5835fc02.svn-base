using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class BusinessCategoryForm : BaseForm, IBusinessCategoryView
    {        
        private readonly DomainSummaryGrid<BusinessCategory> grid;

        // - adds - add the master list
        // - edits - if old, add them to update list, modify master list. 
        // - edits - if unsaved, modify master list
        // - deletes - if new objects, do nothing but remove them from master list.
        // - deletes - if old objects, add the delete list, remove them from master list

        public BusinessCategoryForm()
        {
            InitializeComponent(); 
            InitializePresenter();
            
            grid = new DomainSummaryGrid<BusinessCategory>(
                new BusinessCategoryGridRenderer(BusinessCategoryGridRenderer.Layout.AllFieldsLayout), OltGridAppearance.SINGLE_SELECT, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;  
            businessCategoryPanel.Controls.Add(grid);
        }

        private void InitializePresenter()
        {
            BusinessCategoryPresenter presenter = new BusinessCategoryPresenter(this);
            Load += presenter.HandleLoad;

            addButton.Click += presenter.HandleAddButtonClicked;
            editButton.Click += presenter.HandleEditButtonClicked;
            deleteButton.Click += presenter.HandleDeleteButtonClicked;

            saveButton.Click += presenter.HandleSaveButtonClicked;
            cancelButton.Click += presenter.HandleCancelButtonClicked;
        }
 
        public List<BusinessCategory> Items
        {
            set { grid.Items = value; }
        }

        public BusinessCategory SelectedBusinessCategory
        {
            get { return grid.SelectedItem;  }
        }

        public void SelectBusinessCategory(BusinessCategory businessCategory)
        {
            grid.SelectItemByReference(businessCategory);            
        }

        public void RebindGrid()
        {
            grid.ResetBindings();
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetGridDataError(string errorMessage)
        {
            errorProvider.SetError(businessCategoryPanel, errorMessage);
        }
    }
}
