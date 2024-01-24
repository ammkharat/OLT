using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditTradeChecklistForm : BaseForm, IAddEditTradeChecklistView
    {
        public event Action FormLoad;
        public event Action SaveAndCloseButtonClick;
        public event Action ViewHistoryButtonClick;

        public AddEditTradeChecklistForm()
        {
            InitializeComponent();
            
            okButton.Click += HandleSaveButtonClick;
            viewHistoryButton.Click += HandleViewHistoryButtonClick;
        }

        private void HandleViewHistoryButtonClick(object sender, EventArgs e)
        {
            ViewHistoryButtonClick();
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            SaveAndCloseButtonClick();            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        public string Trade
        {
            get { return tradeComboBox.Text; }
            set { tradeComboBox.Text = value; }
        }

        public List<string> TradeList
        {
            set
            {
                tradeComboBox.Items.Clear();
                value.ForEach(t => tradeComboBox.Items.Add(t));               
            }
        }

        public string TradeChecklistInformation
        {
            set { tradeChecklistInformationTextbox.Text = value; }
        }

        public string Content
        {
            get { return contentRichTextEditor.Text; }
            set { contentRichTextEditor.Text = value; }
        }

        public string PlainTextContent
        {
            get { return contentRichTextEditor.PlainText; }
        }

        public User LastModifiedUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public void ShowMustSelectATradeError()
        {
            errorProvider.SetError(tradeComboBox, StringResources.WorkPermitLubes_TradeEmpty);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }       
    }
}
