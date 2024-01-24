using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AssociateBusinessCategoriesPopupForm : BaseForm, IAssociateBusinessCategoriesPopupView
    {        
        private readonly DomainSummaryGrid<BusinessCategoryFLOCAssociation> associatedBusinessCategoryGrid;
        private readonly DomainSummaryGrid<BusinessCategory> businessCategoryGrid;

        public AssociateBusinessCategoriesPopupForm(
            FunctionalLocation functionalLocation, 
            List<BusinessCategory> businessCategories)
        {
            InitializeComponent();
            InitializePresenter(functionalLocation, businessCategories);

            Text = string.Format(StringResources.EditBusinessCategoryAssociations, functionalLocation);

            associatedBusinessCategoryGrid = new DomainSummaryGrid<BusinessCategoryFLOCAssociation>(
                    new BusinessCategoryFLOCAssociationGridRenderer(), OltGridAppearance.MULTI_SELECT, string.Empty);
            InitializeAssociatedBusinessCategoryGrid(associatedBusinessCategoryGrid);

            businessCategoryGrid = new DomainSummaryGrid<BusinessCategory>(
                    new BusinessCategoryGridRenderer(BusinessCategoryGridRenderer.Layout.NameOnlyLayout), OltGridAppearance.MULTI_SELECT, string.Empty);
            InitializeBusinessCategoryGrid(businessCategoryGrid);                        
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void InitializeAssociatedBusinessCategoryGrid(DomainSummaryGrid<BusinessCategoryFLOCAssociation> grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            associationPanel.Controls.Add(grid);
        }

        private void InitializeBusinessCategoryGrid(DomainSummaryGrid<BusinessCategory> grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            businessCategoryPanel.Controls.Add(grid);
        }        

        private void InitializePresenter(FunctionalLocation functionalLocation, List<BusinessCategory> businessCategories)
        {
            AssociateBusinessCategoriesPopupPresenter presenter =
                new AssociateBusinessCategoriesPopupPresenter(this, functionalLocation, businessCategories);

            Load += presenter.HandleLoad;            

            addAssociationButton.Click += presenter.AddAssociationButton_Clicked;
            removeAssociationButton.Click += presenter.RemoveAssociationButton_Clicked;
            
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Clicked;
            cancelButton.Click += presenter.CancelButton_Clicked;
        }

        public List<BusinessCategoryFLOCAssociation> AssociationList
        {
            set { associatedBusinessCategoryGrid.Items = value; }
        }

        public List<BusinessCategory> BusinessCategoryList
        {
            set { businessCategoryGrid.Items = value; }
        }

        public List<BusinessCategory> SelectedBusinessCategories
        {
            get { return businessCategoryGrid.SelectedItems; }
        }

        public List<BusinessCategoryFLOCAssociation> SelectedAssociations
        {
            get { return associatedBusinessCategoryGrid.SelectedItems; }
            set { associatedBusinessCategoryGrid.SelectItemsByReference(value); }
        }

        public BusinessCategoryFLOCAssociation SelectedAssociation
        {            
            set { associatedBusinessCategoryGrid.SelectItemByReference(value); }
        }

        public void ShowNoAssociationsSelectedMessageBox()
        {
            OltMessageBox.ShowError(StringResources.NoBusinessCategoryAssociationSelectedWarningText,
                StringResources.NoBusinessCategoryAssociationSelectedWarningCaption);
        }       
    }
}
