using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RestrictionLocationItemReasonCodeForm : BaseForm, IRestrictionLocationItemReasonCodeForm
    {        
        private readonly SummaryGrid<RestrictionLocationItemReasonCodeAssociation> associatedReasonCodeGrid;
        private readonly SummaryGrid<RestrictionReasonCode> reasonCodeGrid;

        private const string TitleTextFormat = "Edit Reason Code Associations - {0}";

        public RestrictionLocationItemReasonCodeForm(RestrictionLocationItem restrictionLocationItem, List<RestrictionReasonCode> restrictionReasonCodes)
        {
            InitializeComponent();

            RestrictionLocationItemReasonCodePresenter presenter =
                new RestrictionLocationItemReasonCodePresenter(this, restrictionLocationItem, restrictionReasonCodes);

            RegisterEventHandlers(presenter);

            Text = string.Format(TitleTextFormat, restrictionLocationItem.Name);

            associatedReasonCodeGrid = new SummaryGrid<RestrictionLocationItemReasonCodeAssociation>(
                new RestrictionReasonCodeAssociationGridRenderer(), OltGridAppearance.MULTI_SELECT) {Dock = DockStyle.Fill};
            associatedReasonCodeGrid.DisplayLayout.GroupByBox.Hidden = true;
            associationPanel.Controls.Add(associatedReasonCodeGrid);


            reasonCodeGrid = new SummaryGrid<RestrictionReasonCode>(
                    new RestrictionReasonCodeGridRenderer(), OltGridAppearance.MULTI_SELECT) {Dock = DockStyle.Fill};
            reasonCodeGrid.DisplayLayout.GroupByBox.Hidden = true;
            reasonPanel.Controls.Add(reasonCodeGrid);
        }

        private void RegisterEventHandlers(RestrictionLocationItemReasonCodePresenter presenter)
        {
            Load += presenter.HandleLoad;

            addAssociationButton.Click += presenter.AddAssociationButton_Clicked;
            removeAssociationButton.Click += presenter.RemoveAssociationButton_Clicked;

            editLimitButton.Click += presenter.EditLimitButton_Clicked;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public List<RestrictionLocationItemReasonCodeAssociation> AssociationList
        {
            set { associatedReasonCodeGrid.Items = value; }
            get { return new List<RestrictionLocationItemReasonCodeAssociation>(associatedReasonCodeGrid.Items); }
        }

        public List<RestrictionReasonCode> ReasonCodeList
        {
            set { reasonCodeGrid.Items = value; }
            get { return new List<RestrictionReasonCode>(reasonCodeGrid.Items); }
        }

        public List<RestrictionReasonCode> SelectedRestrictionReasonCodes
        {
            get { return reasonCodeGrid.SelectedItems; }
        }

        public List<RestrictionLocationItemReasonCodeAssociation> SelectedAssociations
        {
            get { return associatedReasonCodeGrid.SelectedItems; }
            set { associatedReasonCodeGrid.SelectItemsByReference(value); }
        }

        public RestrictionLocationItemReasonCodeAssociation SelectedAssociation
        {            
            set { associatedReasonCodeGrid.SelectItemByReference(value); }
        }

        public void ShowNoAssociationsSelectedMessageBox()
        {
            OltMessageBox.ShowError(StringResources.NoRestrictionReasonCodeAssociationSelectedWarningText, StringResources.NoRestrictionReasonCodeAssociationSelectedWarningCaption);
        }

        public void DisplayEditLimitsForm(List<RestrictionLocationItemReasonCodeAssociation> selectedAssociations)
        {
            EditRestrictionReasonCodeLimitForm form = new EditRestrictionReasonCodeLimitForm(selectedAssociations);
            form.ShowDialog(this);
        }
    }
}
