using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.SupportDialogs.ConditionalFormatting;
using Com.Suncor.Olt.Common.Extension;


namespace Com.Suncor.Olt.Client.Forms
{
    public partial class GenericTemplateEmailApprovalConfigurationForm : BaseForm,IGenericTemplateEmailConfigurationview
    {
        public event EventHandler ContractorInformationChanged;
        public event EventHandler Add;
        public event EventHandler UpdateEmail;
        public event EventHandler Delete;
        public event EventHandler Clear;
        public event EventHandler ContractorSelected;
        public event EventHandler Save;
        public event EventHandler EFormTypeChanged;
        public event EventHandler EFormRoleChanged;
        public event FormClosingEventHandler ViewClosing;

        private readonly DomainSummaryGrid<GenericTemplateEmailApprovalConfiguration> contractorGrid;
       // private static EdmontonFormType initialDropdownSelection = EdmontonFormType.OP14; 

        public GenericTemplateEmailApprovalConfigurationForm()
        {
            InitializeComponent();
           // InitializeComponent();

            contractorGrid = new DomainSummaryGrid<GenericTemplateEmailApprovalConfiguration>(new GenericTemplateEmailApprovalGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            contractorGrid.DisplayLayout.GroupByBox.Hidden = true;
            contractorGrid.TabIndex = 0;
            contractorsGroupBox.Controls.Add(contractorGrid);
            contractorGrid.Dock = DockStyle.Fill;
            contractorGrid.SelectedItemChanged += OnContractorSelected;
            eFormComboBox.SelectedValueChanged += OnEFormTypeChanged;
            drpApproverrole.SelectedValueChanged += OnEFormRoleChanged;
            btnAdd.Click += OnAdd;
            btnUpdate.Click += OnUpdate;
            new GenericTemplateEmailApprovalPresenter(this).RegisterToViewEvents();
        }
        private void OnEFormTypeChanged(object sender, EventArgs e)
        {
            if (EFormTypeChanged != null) { EFormTypeChanged(sender, e); }
        }

        private void OnEFormRoleChanged(object sender, EventArgs e)
        {
            if (EFormRoleChanged != null)
            {
                EFormRoleChanged(sender, e);
            }
        }
        private void OnContractorSelected(object sender, DomainEventArgs<GenericTemplateEmailApprovalConfiguration> e)
        {
            if (ContractorSelected != null && SelectedContractor!=null) { ContractorSelected(sender, e); }
        }

        private void OnContractorInformationChanged(object sender, EventArgs e)
        {
            if (ContractorInformationChanged != null) { ContractorInformationChanged(sender, e); }
        }

        public List<GenericTemplateEmailApprovalConfiguration> AllEFormType
        {
            set
            {
                eFormComboBox.DataSource = value;
                eFormComboBox.DisplayMember = "Name";

            }
            get { return (List<GenericTemplateEmailApprovalConfiguration>)eFormComboBox.DataSource; }
        }

        public GenericTemplateEmailApprovalConfiguration eFormType
        {
            get { return eFormComboBox.SelectedItem as GenericTemplateEmailApprovalConfiguration; }
            set
            {
                eFormComboBox.SelectedItem = value;
            }
        }

        public string eRoleType
        {
            get { return Convert.ToString(drpApproverrole.SelectedItem); }
        }

        public GenericTemplateEmailApprovalConfiguration SelectedContractor
        {
            get { return contractorGrid.SelectedItem; }
            set { SelectedContractor = value; }
        }

        public Site ContractorSite
        {
            set { siteNameLabel.Text = value.Name; }
        }

        public IList<GenericTemplateEmailApprovalConfiguration> Contractors
        {
            // The grid has a Readonly list
           get { return new List<GenericTemplateEmailApprovalConfiguration>(contractorGrid.Items); }
            set { contractorGrid.Items = value; }
        }

        public bool AddEnabled
        {
            set { btnAdd.Enabled =value; }
        }

        public bool UpdateEnabled
        {
            set { btnUpdate.Enabled = value; }
        }

        public bool ClearEnabled
        {
            set { clearButton.Enabled = value; }
        }

        public string AddText
        {
            get { return btnAdd.Text; }
        }
        public string UpdateText
        {
            get { return btnUpdate.Text; }
        }

        public string ContractorName
        {
            get { return Convert.ToString( drpApproverrole.SelectedItem); }
            
        }

        public bool cmbApproverEnabled
        {

            set { drpApproverrole.Enabled = value; }
        }

        public string EmailList
        {
            get { return oltEmailTextBox.Text; }
            set { oltEmailTextBox.Text = value; }


        }

        public string ContractorID
        {

            get { return lblRoleID.Text; }
            set { lblRoleID.Text = value; }
        }

        public void ClearSelectedContractor()
        {
            contractorGrid.ClearSelections();
        }

        public void ShowWarningMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OnAdd(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }
            if (Add != null) { Add(sender, e); }
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }
            if (Add != null) { UpdateEmail(sender, e); }
        }
        private void OnDelete(object sender, EventArgs e)
        {
            if (Delete != null) { Delete(sender, e); }
        }

        private void OnClear(object sender, EventArgs e)
        {
            if (Clear != null) { Clear(sender, e); }
        }

       

        private void OnSave(object sender, EventArgs e)
        {
            if (Save != null) { Save(sender, e); }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();  // Treat clicking the cancel button as the same as closing the form.
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ViewClosing != null) { ViewClosing(sender, e); }
        }

        //DMND0009363-#950321920-Mukesh
        public bool ShowneverEnd
        {
            set
            {
                ShowNeverendCheckbox.Checked = value;
            }
            get
            {
                return ShowNeverendCheckbox.Checked;
            }
        }

        public bool groupBoxenabled
        {
            set { contractorsGroupBox.Enabled = value; }
        }

        public bool lblApprovertextvisibe
        {
            get { return lblApproverText.Visible; }
            set { lblApproverText.Visible = value; }
        }

        public string lblApproveText 
        {
            get { return lblApproverrole.Text; }
            set { lblApproverrole.Text = value; }

        }

        public string lblApprovelongtext
        {
            get { return lblApproverText.Text; }
            set { lblApproverText.Text = value; }
        }
        private bool DataIsValid()
        {
            errorProvider.Clear();

            bool hasError = false;

            if (oltEmailTextBox.Text.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(oltEmailTextBox, StringResources.FieldCannotBeEmpty);
                hasError = true;
            }
            //Added by ppanigrahi
            //Commented because Email is not mandory
            //if (String.IsNullOrEmpty(EmailAddressTextBox.Text))
            //{
            //    errorProvider.SetError(EmailAddressTextBox, StringResources.FieldCannotBeEmpty);
            //    hasError = true;
            //}
            //Validation to check valid mail or not.Added by ppanigrahi
            else
            {
                string strEmail = oltEmailTextBox.Text;
                if (strEmail.Length > 0)
                {
                    string[] eid = strEmail.Split(';');
                    for (int i = 0; i < eid.Length; i++)
                    {
                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3}[ ]*)$";
                        Regex re = new Regex(strRegex);
                        if (!(re.IsMatch(eid[i].ToString())))
                        {
                            errorProvider.SetError(oltEmailTextBox, StringResources.EmailErrorTitle);
                            hasError = true;
                            break;
                        }
                        else
                        {
                            hasError = false;
                        }
                    }

                }

            }


            return !hasError;

        }

        private void contractorsGroupBox_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
