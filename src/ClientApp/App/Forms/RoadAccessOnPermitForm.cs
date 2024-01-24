using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RoadAccessOnPermitForm : BaseForm, ICraftOrTradeView
    {
        public RoadAccessOnPermitForm()
        {
            InitializeComponent();
            RoadAccessOnPermitFormPresenter presenter = new RoadAccessOnPermitFormPresenter(this);
            RegisterEventHandlersOnPresenter(presenter);
        }

        public RoadAccessOnPermitForm(CraftOrTrade craftOrTrade)
        {
            InitializeComponent();
            RoadAccessOnPermitFormPresenter presenter = new RoadAccessOnPermitFormPresenter(this, craftOrTrade);
            RegisterEventHandlersOnPresenter(presenter);
        }

        private void RegisterEventHandlersOnPresenter(RoadAccessOnPermitFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }

        public string CraftOrTradeName
        {
            get { return nameTextBox.Text.TrimOrNull(); }
            set { nameTextBox.Text = value; }
        }

        public string WorkCentre
        {
            get { return workCentreTextBox.Text.TrimOrNull(); }
            set { workCentreTextBox.Text = value; }
        }

        public string CraftOrTradeSite
        {
            set { siteNameLabel.Text = value; }
        }

        public string ViewTitle
        {
            set { Text = value; }
        }

        public void ShowNameIsEmptyError()
        {
            nameErrorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void ShowDuplicateCraftOrTradeError()
        {
            duplicateErrorProvider.SetError(nameTextBox, StringResources.DuplicateRoadAccessOnPermitForSite);
        }
        
        public void ClearErrorProviders()
        {
            nameErrorProvider.Clear();
            duplicateErrorProvider.Clear();
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public override void SaveSucceededMessage()
        {
            // Do not display confirmation.
        }
    }
}