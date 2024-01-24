using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;



namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EmailToRecipientForm : BaseForm, IEmailToRecipientForm
    {
        private readonly long actionitemdefinitionId;


        public EmailToRecipientForm(List<string> emails)
        {
            InitializeComponent();
            InitializePresenter();

            emailsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            emailsListView.View = View.List;
            if(emails != null && emails.Count > 0)
            {
                SetExistingEmail(emails);
            }
        }

        private void InitializePresenter()
        {
            EmailToRecipientPresenter presenter = new EmailToRecipientPresenter(this);
            Load += presenter.Load;

            removeButton.Click += presenter.RemoveButton_Click;
            closeButton.Click += presenter.CloseButton_Clicked;
            AddEmailButton.Click += presenter.AddEmailButton_Click;
            saveButton.Click += presenter.SaveButton_Click;
        }

        public void SetExistingEmail(List<string> emails)
        {
            SetExistingEmails(emails);
        }

        public object SelectedItem()
        {
            return emailsListView.SelectedItems; 
        }

        public void RemoveItems(List<ListViewItem> itemsToDelete)
        {
            foreach(ListViewItem itm in itemsToDelete)
            {
                emailsListView.Items.Remove(itm);
            }
        }


        protected override void OnLoad(EventArgs e)
        {
        }


        public List<string> GetEmailsFromListView()
        {
            List<string> emails = new List<string>();

            foreach (ListViewItem item in emailsListView.Items)
            {
                emails.Add(item.Text);
            }
            emails.ConvertAll(itm => itm.Replace("\r\n",""));
            
            return emails;
        }

        public void RemoveEmailFromListView()
        {
            if (emailsListView.SelectedItems != null && emailsListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem itm in emailsListView.SelectedItems)
                {
                    emailsListView.Items.Remove(itm);
                }
            }
            else
            {
                foreach(ListViewItem itm in emailsListView.Items)
                {
                    emailsListView.Items.Remove(itm);
                }
            }
            emailsListView.Refresh();
        }

        public void AddEmailToListView(string email)
        {
            if (email.Length > 0)
            {
                emailsListView.Items.Add(email);
                emailTextBox.Text = "";
            }
            emailTextBox.Focus();
        }

        public string GetValFromEmailTextBox()
        {
            return emailTextBox.Text;
        }

        public List<string> AssociatedEmailToRecipients
        {
            get { return GetEmailsFromListView(); }
            set { }
        }

        public void SetExistingEmails(List<string> emails)
        {
            foreach(var itm in emails)
            {
                emailsListView.Items.Add(itm);
            }

        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool Validate(string areaLabelText, string sapPlannerGroup)
        {
            bool hasError = false;

            //if (areaLabelText == null)
            //{
            //    errorProvider.SetError(areaLabelTextBox, StringResources.EnterAValidValue);
            //    hasError = true;
            //}

            //if (sapPlannerGroup != null && existingSapPlannerGroups.Exists(groupName => groupName.ToLower() == sapPlannerGroup.ToLower()))
            //{
            //    errorProvider.SetError(sapPlannerGroupTextBox, StringResources.PlannerGroupAlreadyAssigned);
            //    hasError = true;
            //}

            return hasError;
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }
    }


}
