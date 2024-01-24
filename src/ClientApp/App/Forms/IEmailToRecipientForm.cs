using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEmailToRecipientForm : IBaseForm
    {

        //  List<EmailToRecipient> EmailToRecipients { set; }
        object SelectedItem();
        List<string> AssociatedEmailToRecipients { get; set; }
        List<string> GetEmailsFromListView();
        void SetExistingEmails(List<string> emails);
        void AddEmailToListView(string email);
        void RemoveEmailFromListView();
        string GetValFromEmailTextBox();
     //   List<string> GetEnteredEmail { get; }
      //  void LaunchEditEmailToReceipientForm(EmailToRecipient selected);
      //  void SelectFirstRow();
        bool UserIsSure();
        
    }
}