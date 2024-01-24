using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.Utils.Drawing.Helpers;
using Org.BouncyCastle.Asn1.Cmp;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PopupSarniaExtension : BaseForm, IPopupSarniaExtension
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClick;
        public event Action FormLoad;
        private WorkPermit permit;

        public PopupSarniaExtension()
        {
            InitializeComponent();
        }

        public PopupSarniaExtension(WorkPermit workpermit, bool isExtensible, IWorkPermitPage page)
        {
            InitializeComponent();
            this.saveButton.Click +=saveButton_Click;
            this.cancelButton.Click += cancelButton_Click;
            this.StartPosition = FormStartPosition.Manual;
           
         //   requestedEndTimeTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
            //extensiondatetime = ExtensionDateTime.Value;
            this.permit = workpermit;
             var presenter = new PopupSarniaExtensionPresenter(workpermit,isExtensible,this,page);
          //  var presenter = new WorkPermitFormPresenter<IPopupSarniaExtension>(this, workpermit);
            this.oltExtensionTime.Hour = 0;
            this.oltExtensionTime.Minute = 0;
        }
        public void DisplayErrorMessageDialog(string message, string title)
        {
            OltMessageBox.Show(ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

       protected override void OnLoad(EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Left, scr.WorkingArea.Top+this.Width/6);
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }

        }

        public Time ExtensionTime {get { return oltExtensionTime.Value; }}
        //public string ExtensionComment
        //{
        //    get { return extensionCommentsTextBox.Text; }
        //    set { extensionCommentsTextBox.Text = value; }
        //}

        public bool ExtensionDateEnable
        {
            get { return extensionDatePickerWP.Enabled; }
            set { extensionDatePickerWP.Enabled = value; }
        }

        public bool ExtensionTimeEnable
        {

            get { return extensionTimePickerWP.Enabled; }
            set { extensionTimePickerWP.Enabled = value; }
        }

        public DateTime ExpiryDateTime {
            get
            {
                Date date = extensionDatePickerWP.Value;
                Time time = extensionTimePickerWP.Value;
                return date.CreateDateTime(time);
           }
           set
            {
               if (value != null)
               {
                      extensionDatePickerWP.Value = new Date(Convert.ToDateTime(value));
            //        // extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                     extensionTimePickerWP.Value = new Time(Convert.ToDateTime(value));
            //        //  extensionTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
               }
                else
              {
                     extensionDatePickerWP.Value = null;
                  //extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                    extensionTimePickerWP.Value = null;
              }
            }
        }
       

       public DateTime? ExtensionDateTime
        {
            get
            {
                Date date = extensionDatePickerWP.Value;
                Time time = extensionTimePickerWP.Value;

                return date.CreateDateTime(time);
            }
           set
           {
               if (value != null)
               {
                   extensionDatePickerWP.Value = new Date(Convert.ToDateTime(value));
                   // extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                   extensionTimePickerWP.Value = new Time(Convert.ToDateTime(value));
                   //  extensionTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
               }
               else
               {
                   extensionDatePickerWP.Value = null;
                   //extensionDatePickerWP.ValueChanged -= HandleExpiredTimeChanged;
                   extensionTimePickerWP.Value = new Time(0,0,0);
               }
           }
        }
   

        //public DateTime ExpiryDateTime
        //{
        //    get
        //    {
        //        Date date = requestedEndDateDatePickerWP.Value;
        //        Time time = requestedEndTimeTimePickerWP.Value;
        //        return date.CreateDateTime(time);
        //    }
        //    set
        //    {
        //        requestedEndDateDatePickerWP.Value = new Date(value);
        //        requestedEndTimeTimePickerWP.ValueChanged -= HandleExpiredTimeChanged;
        //        requestedEndTimeTimePickerWP.Value = new Time(value);
        //        requestedEndTimeTimePickerWP.ValueChanged += HandleExpiredTimeChanged;
        //    }
        //}

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                DialogResult = DialogResult.None;
                //if (OltMessageBox.Show(
                //                    this,
                //    //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
                //    //StringResources.SitePlantRoleNotConfigured,
                //                   "Please Enter Extension Time",
                //    //Dharmesh 13-Sep-2017 end
                //                    "Aleart",
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Asterisk,
                //                    ContentAlignment.MiddleLeft)
                //                    == DialogResult.OK)

                    errorProvider.SetError(oltExtensionTime, StringResources.OvertimeForm_InvalidDate);
               // {
                    return;
               // }
            }


            
                    if (SaveButtonClicked != null)
                    {

                        SaveButtonClicked(sender, e);
           
                
                    }
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //if (CancelButtonClick != null)
            //{

            //    CancelButtonClick(sender, e);

            //}
            
        }
        private bool DataIsValid()
        {
            errorProvider.Clear();

            bool hasError = false;

            double totalMinutes = ExtensionTime.TotalMinutes;

            if (totalMinutes == 0)
            {
//errorProvider.SetError(oltExtensionTime, StringResources.OvertimeForm_InvalidDate);
                hasError = true;
            }

            return !hasError;
        }

        //public void UnlimitWork(string msg)
        //{
        //    DialogResult=DialogResult.None;
        //    if (OltMessageBox.Show(
        //                        this,
        //        //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
        //        //StringResources.SitePlantRoleNotConfigured,
        //                       "A Safe Work Permit can only be valid for upto 16hrs",
        //        //Dharmesh 13-Sep-2017 end
        //                        "Alert",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Asterisk,
        //                        ContentAlignment.MiddleLeft)
        //                        == DialogResult.OK)
        //    {
        //       return;
        //    }
        //}

        public void ExtensionWork(string msg)
        {

            DialogResult = DialogResult.None;
            if (OltMessageBox.Show(
                                this,
                //Dharmesh 13-Sep-2017 start FOR RITM0156565 - OLT User Access-Instructions link on Login page 
                //StringResources.SitePlantRoleNotConfigured,
                              msg,
                //Dharmesh 13-Sep-2017 end
                                "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                ContentAlignment.MiddleLeft)
                                == DialogResult.OK)
            {
                return;
            } 
        }

       
       
    }
}
