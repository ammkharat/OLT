using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class MarkAsTemplateNameForm : BaseForm, IMarkAsTemplateNameForm
    {
        private MarkAsTemplateNameFormPresenter presenter;
        private IList<WorkAssignment> allAssignments;
        private readonly List<WorkAssignment> assignments;
        

        public MarkAsTemplateNameForm(bool isWorkPermit)
        {
            InitializeComponent();
            InitializePresenter();
            if (ClientSession.GetUserContext().Site.Id == Common.Domain.Site.MontrealSulphur_ID ||
                ClientSession.GetUserContext().Site.Id == Common.Domain.Site.MONTREAL_ID)
            {
                this.Text = "Sauvergarde de modèle";
            }
            else
            {
                this.Text = "TemplateSaveAs";
            }
            
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
            
            //if (!ClientSession.GetUserContext().UserRoleElements.Role.IsAdministratorRole)
            if (!ClientSession.GetUserContext().UserRoleElements.AuthorizedTo(RoleElement.WORKPERMIT_MARKED_TEMPLATE))
            {
                GlobalCheckBox.Checked = false;
                GlobalCheckBox.Enabled = false;
                IndividualCheckbox.Checked = true;
                IndividualCheckbox.Enabled = false;
            }
            else
            {
                GlobalCheckBox.Enabled = true;
                IndividualCheckbox.Enabled = true; 
            }
            var workPermitCategory = AssignmentAndFunctionalLocationsSelectionFormPresenter.Cat_allAssignments;
            var permitRequestCategory = AssignmentAndFunctionalLocationsSelectionFormPresenter.Cat_allAssignments_PermitRequest;

            if (isWorkPermit && (workPermitCategory != null || permitRequestCategory != null))
            {
                Categories = GetCategories(workPermitCategory);
            }
            else
            {
                Categories = GetCategories(permitRequestCategory);
            }
            //categoryComboBox.SelectedIndex = 0;
            ClearError();
        }

        private void InitializePresenter()
        {
            presenter = new MarkAsTemplateNameFormPresenter(this);
            saveButton.Click += presenter.HandleSelectButtonClicked;
            CancelButton.Click += presenter.HandleCancelButtonClicked;
            
        }

        public string WorkPermitTemplateName
        {
            get { return TemplateName.Text; }
            set { TemplateName.Text = value; }
        }

        public bool Global
        {
            get { return GlobalCheckBox.Checked; }
            set { GlobalCheckBox.Checked = value; }
        }
        public bool Individual
        {
            get { return IndividualCheckbox.Checked; }
            set { IndividualCheckbox.Checked = value; }
        }

        public string Category
        {
            get { return categoryComboBox.Text.TrimOrNull(); }
            set { categoryComboBox.Text = value; }
        }

        public List<string> Categories
        {
            set
            {
                categoryComboBox.Items.Clear();
                categoryComboBox.Items.AddRange(value.ToArray());
            }
        }

        private static List<string> GetCategories(IEnumerable<WorkAssignment> assignments)
        {
            List<string> categories = new List<string>();
            foreach (WorkAssignment assignment in assignments)
            {
                if (!String.IsNullOrEmpty(assignment.Category) &&
                    !categories.Contains(assignment.Category))
                {
                    categories.Add(assignment.Category);
                }
            }
            return categories;
        }

        //private void CancelButton_Click(object sender, EventArgs e)
        //{
        //    MarkAsTemplateNameForm form = new MarkAsTemplateNameForm(true);
        //    Cancel = true;
        //    Save = false;
        //    form.Close();
        //}
        public void SetErrorForTemplateName()
        {
            OlterrorProvider.SetError(TemplateName, "This Field cannot be Empty");
        }
        public void SetErrorForCategories()
        {
            OlterrorProvider.SetError(categoryComboBox, "This Field cannot be Empty");
        }
        public void SetErrorForGlobal()
        {
            OlterrorProvider.SetError(GlobalCheckBox, "This Field cannot be Empty");
        }
        public void SetErrorForIndividual()
        {
            OlterrorProvider.SetError(IndividualCheckbox, "This Field cannot be Empty");
        }
        public void ClearError()
        {
            OlterrorProvider.Clear();
        }

        private void GlobalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (GlobalCheckBox.Checked)
            //{
                
            //    IndividualCheckbox.Enabled = false;
            //}
            //else
            //{
                
            //    IndividualCheckbox.Enabled = true;
            //}
            
            
        }

        private void IndividualCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //if (IndividualCheckbox.Checked)
            //{
                
            //    GlobalCheckBox.Enabled = false;
            //}
            //else
            //{
                
            //    GlobalCheckBox.Enabled = true;
            //}
        }

        public bool Save { get; set; }
        public bool Cancel { get; set; }

        public bool Error { get; set; }

        

        
    }
}
