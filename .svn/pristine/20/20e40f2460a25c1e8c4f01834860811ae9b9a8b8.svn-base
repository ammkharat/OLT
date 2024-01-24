using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureRoleForm : BaseForm, IConfigureRoleView
    {
        public event EventHandler ContractorInformationChanged;
        public event EventHandler AddOrUpdate;
        public event EventHandler Delete;
        public event EventHandler Clear;
        public event EventHandler ContractorSelected;
        public event FormClosingEventHandler ViewClosing;
        private ErrorProvider nameErrorProvider;
        private ErrorProvider ActivedirectoryErrorProvider;
        private ErrorProvider aliasErrorProvider;

        private readonly DomainSummaryGrid<Role> contractorGrid;

        public ConfigureRoleForm()
        {
            InitializeComponent();

            nameErrorProvider = new ErrorProvider();
            ActivedirectoryErrorProvider = new ErrorProvider();
            aliasErrorProvider = new ErrorProvider();
            contractorGrid = new DomainSummaryGrid<Role>(new ConfigureRoleGridRender(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            contractorGrid.DisplayLayout.GroupByBox.Hidden = true;
            contractorGrid.TabIndex = 0;
            contractorsGroupBox.Controls.Add(contractorGrid);
            contractorGrid.Dock = DockStyle.Fill;
            contractorGrid.SelectedItemChanged += OnContractorSelected;

            new ConfigureRolePresenter(this).RegisterToViewEvents();
        }

        public Site roleSite
        {
   
            set { siteNameLabel.Text = value.Name; }
        }

        public IList<Role> roles
        {
            // The grid has a Readonly list
            get { return new List<Role>(contractorGrid.Items); }
            set { contractorGrid.Items = value; }
        }

        public bool AddOrUpdateEnabled
        {
            set { addOrUpdateButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool ClearEnabled
        {
            set { clearButton.Enabled = value; }
        }

        public string AddUpdateText
        {
            set { addOrUpdateButton.Text = value; }
        }
        
        public string RoleName
        {
            get { return RoleNameTextBox.Text; }
            set { RoleNameTextBox.Text = value; }
        }
        CheckBox chk=new CheckBox();
        public string activedirectorykey { get{return ActiveDirectoryTextBox.Text.ToString();} set {ActiveDirectoryTextBox.Text=value;} }

        public bool isadministratorrole { get { return chk.Checked; } set { chk.Checked = false; } }

        public bool isreadonlyrole { get { return chk.Checked; } set { chk.Checked = false; } }

        public bool isdefaultreadonlyroleforsite { get { return chk.Checked; } set { chk.Checked = false; } }

        public bool isworkpermitnonoperationsrole { get { return chk.Checked; } set { chk.Checked = false; } }

        public bool warnifworkassignmentnotselected { get { return chk.Checked; } set { chk.Checked = false; } }

        public string alias { get { return AliasTextBox.Text.ToString(); } set { AliasTextBox.Text = value; } }

              

        public Role SelectedRole
        {
            get { return contractorGrid.SelectedItem; }
        }

        public void ClearSelectedContractor()
        {
            contractorGrid.ClearSelections();
        }

        public void ShowWarningMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OnContractorInformationChanged(object sender, EventArgs e)
        {
            if (ContractorInformationChanged != null) { ContractorInformationChanged(sender, e);  }
        }

        private void OnAddOrUpdate(object sender, EventArgs e)
        {
            if (AddOrUpdate != null) { AddOrUpdate(sender, e); }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (Delete != null) {

                if (OltMessageBox.ShowCustomYesNo("Do you want to delete?", "Confirm delete")== DialogResult.Yes)
                                     
                {
                    Delete(sender, e);
                }
                
                
               }
        }

        private void OnClear(object sender, EventArgs e)
        {
            if (Clear != null) { Clear(sender, e); }
        }

        private void OnContractorSelected(object sender, DomainEventArgs<Role> e)
        {
            if (ContractorSelected != null) { ContractorSelected(sender, e); }
        }

        

        private void OnCancel(object sender, EventArgs e)
        {
            Close();  // Treat clicking the cancel button as the same as closing the form.
            
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ViewClosing != null) { ViewClosing(sender, e); }
        }


        public void ShowNameIsEmptyError()
        {
          
            nameErrorProvider.SetError(RoleNameTextBox, StringResources.RoleNameEmptyError);
        }


        public void ShowAliasIsEmptyError()
        {
           
            aliasErrorProvider.SetError(AliasTextBox, StringResources.RoleNameAliasEmptyError);
        }


        public void ShowActiveDirectoryKeyIsEmptyError()
        {
          
            ActivedirectoryErrorProvider.SetError(ActiveDirectoryTextBox, StringResources.RoleNameDirectorykeyEmptyError);
        }

        public void ClearErrorProviders()
        {
            nameErrorProvider.Clear();
            ActivedirectoryErrorProvider.Clear();
            aliasErrorProvider.Clear();
            
        }
    }
}