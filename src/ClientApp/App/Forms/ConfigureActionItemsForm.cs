using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureActionItemsForm : BaseForm, IConfigureActionItemsForm
    {
        public ConfigureActionItemsForm()
        {
            InitializeComponent();           
            ConfigureActionItemsFormPresenter presenter = new ConfigureActionItemsFormPresenter(this);
            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }   

        public string SiteName
        {
            set { siteNameDataLabel.Text = value; }
        }

        public bool AutoApproveWorkOrderActionItemDefinition
        {
            get { return workOrdersCheckBox.Checked; }
            set { workOrdersCheckBox.Checked = value; }
        }

        public bool AutoApproveSAPAMActionItemDefinition
        {
            get { return sapAMCheckBox.Checked; }
            set { sapAMCheckBox.Checked = value; }
        }

        public bool AutoApproveSAPMCActionItemDefinition
        {
            get { return sapMCCheckBox.Checked; }
            set { sapMCCheckBox.Checked = value; }
        }

        public bool LogRequiredForActionItemResponse
        {
            get { return logRequiredForActionItemResponseCheckBox.Checked; }
            set { logRequiredForActionItemResponseCheckBox.Checked = value; }
        }

        public bool RequiresApprovalDefaultValue
        {
            get { return requiresApprovalDefaultCheckbox.Checked; }
            set { requiresApprovalDefaultCheckbox.Checked = value; }
        }

        public bool RequiresResponseDefaultValue
        {
            get { return requiresResponseDefaultCheckbox.Checked; }
            set { requiresResponseDefaultCheckbox.Checked = value; }
        }
    }
}