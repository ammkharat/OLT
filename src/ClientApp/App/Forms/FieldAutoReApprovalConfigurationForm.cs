using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FieldAutoReApprovalConfigurationForm : BaseForm, IFieldAutoReApprovalConfigurationFormView
    {
        public FieldAutoReApprovalConfigurationForm()
        {
            InitializeComponent();
            
            FieldAutoReApprovalConfigurationFormPresenter presenter = new FieldAutoReApprovalConfigurationFormPresenter(this);
            Load += presenter.HandleLoad;
            saveButton.Click += presenter.HandleSave;
            cancelButton.Click += presenter.HandleCancel;
            targetDefinitionAutoReApprovalConfigurationControl.SelectAllButtonClick +=
                presenter.HandleTargetDefinitionConfigSelectAll;
            targetDefinitionAutoReApprovalConfigurationControl.ClearAllButtonClick +=
                presenter.HandleTargetDefinitionConfigClearAll;
            actionItemDefinitionAutoReApprovalConfigurationControl.SelectAllButtonClick +=
                presenter.HandleActionItemDefinitionConfigSelectAll;
            actionItemDefinitionAutoReApprovalConfigurationControl.ClearAllButtonClick +=
                presenter.HandleActionItemDefinitionConfigClearAll;
        }     

        #region IFieldAutoReApprovalConfigurationFormView Members

        public string SiteName
        {
            set { siteLabelData.Text = value; }
        }

        public ITargetDefinitionAutoReApprovalConfigurationView TargetDefAutoReApprovalConfigView
        {
            get
            {
                return targetDefinitionAutoReApprovalConfigurationControl;
            }
        }

        public IActionItemDefinitionAutoReApprovalConfigurationView AIDAutoReApprovalConfigView
        {
            get
            {
                return actionItemDefinitionAutoReApprovalConfigurationControl;
            }
        }

        #endregion
    }
}