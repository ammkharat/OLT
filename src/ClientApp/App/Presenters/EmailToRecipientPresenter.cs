using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EmailToRecipientPresenter
    {
        private readonly IEmailToRecipientForm view;

        public EmailToRecipientPresenter(IEmailToRecipientForm view)
        {
            this.view = view;           
        }

        public void Load(object sender, EventArgs e)
        {      
            //ReloadGrid();
            //view.SelectFirstRow();
        }

        //private void ReloadGrid()
        //{
        //    List<EmailToRecipient> emailToRecipients =
        //        emailToService.QueryByActionItemDefinitionId(view.SelectedItem.IdValue);
            
        //  //  view.EmailToRecipients = emailToRecipients;            
        //}

        public static string CreateLockIdentifier(long actionitemdefId)
        {
            return string.Format("Email To Receipient Form, action item def. Id: " + actionitemdefId);
        }

        //public void AddButton_Click(object sender, EventArgs e)
        //{
        //    view.LaunchEditEmailToReceipientForm(null);
        //    ReloadGrid();
        //    view.SelectFirstRow();
        //}

        public void SaveButton_Click(object sender, EventArgs e)
        {
            List<string> emails = new List<string>();
            emails = view.GetEmailsFromListView();
            view.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        public void AddEmailButton_Click(object sender, EventArgs e)
        {
            view.AddEmailToListView(view.GetValFromEmailTextBox());
        }


        public void RemoveButton_Click(object sender, EventArgs e)
        {
            var selected = view.SelectedItem();
            if (selected != null)
            {
                if (view.UserIsSure())
                {
                    view.RemoveEmailFromListView();
                }
            }
        }

        public void CloseButton_Clicked(object sender, EventArgs e)
        {
           // view.RemoveEmailFromListView();  //email issue Aarti
            view.Close();
        }
    }
}
