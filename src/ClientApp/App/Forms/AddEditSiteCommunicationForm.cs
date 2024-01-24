using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraRichEdit.Model.History;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditSiteCommunicationForm : BaseForm
    {
        private readonly SiteCommunication editObject;
        private readonly ISiteCommunicationService siteCommunicationService;

        private List<SiteCommunication> editObjects;                //ayman site communication

        public AddEditSiteCommunicationForm() : this(CreateDefaultSiteCommunication())
        {
        }

        public AddEditSiteCommunicationForm(List<SiteCommunication> editObjects)         //ayman site communication
        {
            InitializeComponent();
            
            //ayman site communication
            Authorized authorized = new Authorized();
            chkAllSites.Visible = false;
            if (ClientSession.GetUserContext().UserRoleElements.Role.Name == "Technical Administrator")
            //if (authorized.ToConfigureSiteCommunications(ClientSession.GetUserContext().UserRoleElements))
            {
                chkAllSites.Visible = true;
            }

            this.siteCommunicationService = ClientServiceRegistry.Instance.GetService<ISiteCommunicationService>();
            this.editObjects = editObjects;            //ayman site communication
            this.editObject = editObjects[0];           //ayman site communication
            saveButton.Click += HandleSaveButtonClick;
        }

        private static List<SiteCommunication> CreateDefaultSiteCommunication()         //ayman site communication
        {
            UserContext userContext = ClientSession.GetUserContext();
            SiteCommunication sitecomm = new SiteCommunication(null, userContext.SiteId,null, null, Clock.Now, Clock.Now.AddHours(1), userContext.User, Clock.Now);      //ayman site communication
            List<SiteCommunication> siteCommunications = new List<SiteCommunication>();
            siteCommunications.Add(sitecomm);
            return siteCommunications;
        }

        private bool IsValid()
        {
            bool hasErrors = false;

            if (Message == null)
            {
                errorProvider.SetError(messageTextBox, StringResources.SiteCommunicationMessageEmptyError);
                hasErrors = true;
            }

            if (StartDateTime >= EndDateTime)
            {
                errorProvider.SetError(startTimePicker, StringResources.EndDateBeforeStartDate);
                hasErrors = true;
            }

            return !hasErrors;
        }

        private string Message
        {
            get { return messageTextBox.Text.EmptyToNull(); }
        }

        private DateTime StartDateTime
        {
            get
            {
                return startDatePicker.Value.CreateDateTime(startTimePicker.Value); 
            }
        }

        private DateTime EndDateTime
        {
            get
            {
                return endDatePicker.Value.CreateDateTime(endTimePicker.Value);
            }
        }

        public List<SiteCommunication> SiteCommunication             //ayman site communication
        {
            get { return editObjects; }             
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }

            editObject.Message = Message;
            editObject.StartDateTime = StartDateTime;
            editObject.EndDateTime = EndDateTime;

            if (editObject.IsInDatabase())
            {
                editObject.LastModifiedBy = ClientSession.GetUserContext().User;
                editObject.LastModifiedDateTime = Clock.Now;

                siteCommunicationService.Update(editObject);
            }
            else
            {
                //ayman site communication
                if (chkAllSites.Checked)
                {
                    List<SiteCommunication> insertedCommunication = siteCommunicationService.InsertAllSites(editObject);
                    if (insertedCommunication.Count > 0)
                    {
                        editObjects = insertedCommunication;
                    }
                }
                else
                {
                    SiteCommunication insertedCommunication = siteCommunicationService.Insert(editObject);
                    editObject.Id = insertedCommunication.Id;
                }
            }

            SaveSucceededMessage();
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            messageTextBox.Text = editObject.Message;
            startDatePicker.Value = editObject.StartDateTime.ToDate();
            startTimePicker.Value = editObject.StartDateTime.ToTime();
            endDatePicker.Value = editObject.EndDateTime.ToDate();
            endTimePicker.Value = editObject.EndDateTime.ToTime();
        }
    }
}
