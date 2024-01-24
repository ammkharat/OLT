using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class BusinessCategoryFLOCAssociationForm : BaseForm, IBusinessCategoryFLOCAssociationView
    {
        private DomainSummaryGrid<FunctionalLocation> functionalLocationGrid;
        private DomainSummaryGrid<BusinessCategoryFLOCAssociation> businessCategoryGrid;

        public event BusinessCategoriesForFLOCHandler AssociationPopupFormClosedHandler;

        public BusinessCategoryFLOCAssociationForm()
        {
            InitializeComponent();
            InitalizeFunctionalLocationGrid();
            InitalizeBusinessCategoryGrid();
            InitializePresenter();            
        }

        private void InitalizeFunctionalLocationGrid()
        {
            functionalLocationGrid = new DomainSummaryGrid<FunctionalLocation>(
                new FunctionalLocationGridRenderer(FunctionalLocationGridRenderer.Layout.FullHierarchyWithDescription), OltGridAppearance.SINGLE_SELECT, string.Empty);
            
            functionalLocationGrid.Dock = DockStyle.Fill;
            functionalLocationGrid.DisplayLayout.GroupByBox.Hidden = true;
            flocPanel.Controls.Add(functionalLocationGrid);
        }

        private void InitalizeBusinessCategoryGrid()
        {
            businessCategoryGrid = new DomainSummaryGrid<BusinessCategoryFLOCAssociation>(
                new BusinessCategoryFLOCAssociationGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            businessCategoryGrid.Dock = DockStyle.Fill;
            businessCategoryGrid.DisplayLayout.GroupByBox.Hidden = true;
            businessCategoryGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            businessCategoryGrid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            businessCategoryPanel.Controls.Add(businessCategoryGrid);

        }

        private void InitializePresenter()
        {
            BusinessCategoryFLOCAssociationPresenter presenter = new BusinessCategoryFLOCAssociationPresenter(this);
            Load += presenter.Load;
          
            editAssociationsButton.Click += presenter.EditAssociationsButton_Clicked;
            cancelButton.Click += presenter.CancelButton_Clicked;

            functionalLocationGrid.SelectedItemChanged += presenter.FunctionalLocationGrid_SelectedItemChanged;

            AssociationPopupFormClosedHandler += presenter.PopupForm_Closed;
        }

        public List<FunctionalLocation> DivisionLevelFunctionalLocations
        {
            set { functionalLocationGrid.Items = value; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationGrid.SelectedItem; }
            set { functionalLocationGrid.SelectItemById(value.Id); }
        }

        public BusinessCategoryFLOCAssociation SelectedAssociation
        {
            get { return businessCategoryGrid.SelectedItem; }
            set { businessCategoryGrid.SelectItemByReference(value); }
        }

        public void ShowEditBusinessCategoryFLOCAssociationsPopupForm(
                FunctionalLocation selectedFunctionalLocation, List<BusinessCategory> masterList)
        {
            AssociateBusinessCategoriesPopupForm form = new AssociateBusinessCategoriesPopupForm(selectedFunctionalLocation, masterList);
            form.ShowDialog(this);

            if (AssociationPopupFormClosedHandler != null)
            {
                Associations = AssociationPopupFormClosedHandler(SelectedFunctionalLocation);
            }
        }

        public List<BusinessCategoryFLOCAssociation> Associations
        {
            set { businessCategoryGrid.Items = value; }
        }

        public void SelectFirstBusinessCategoryRow()
        {
            businessCategoryGrid.SelectFirstRow();
        }

        public void SelectFirstFunctionalLocation()
        {
            functionalLocationGrid.SelectFirstRow();
        }
    }
}
