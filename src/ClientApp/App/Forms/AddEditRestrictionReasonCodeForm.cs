using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditRestrictionReasonCodeForm : BaseForm
    {
        private readonly bool isAddMode;
        private bool cancelClicked;
        private RestrictionReasonCode restrictionReasonCode;
        private readonly List<RestrictionReasonCode> masterReasonCodeList;

        public AddEditRestrictionReasonCodeForm(RestrictionReasonCode restrictionReasonCode, 
            List<RestrictionReasonCode> masterReasonCodeList)
        {
            InitializeComponent();

            this.restrictionReasonCode = restrictionReasonCode;
            this.masterReasonCodeList = masterReasonCodeList;

            isAddMode = restrictionReasonCode == null;
            SetUpControlsForAddOrEditMode();

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            if(!DataIsValid())
            {
                return;
            }

            if(isAddMode)
            {
                restrictionReasonCode =
                    new RestrictionReasonCode(ReasonCodeFromTextBox, ClientSession.GetUserContext().User, Clock.Now, ClientSession.GetUserContext().SiteId);   //ayman restriction reason codes
            }
            else
            {
                if (!UserAcceptsChangingReasonCodeWarning())
                {
                    return;
                }

                restrictionReasonCode.Name = ReasonCodeFromTextBox;
            }

            Close();
        }

        private static bool UserAcceptsChangingReasonCodeWarning()
        {
            DialogResult result = 
                MessageBox.Show(StringResources.ChangingReasonCodeWarning, StringResources.ChangingReasonCodeWarningCaption, 
                    MessageBoxButtons.YesNo);

            return DialogResult.Yes == result;
        }

        private string ReasonCodeFromTextBox
        {
            get { return reasonCodeTextBox.Text.TrimOrNull(); }
        }

        private bool DataIsValid()
        {
            reasonCodeErrorProvider.SetError(reasonCodeTextBox, "");
           
            if (ReasonCodeFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                reasonCodeErrorProvider.SetError(reasonCodeTextBox, StringResources.InvalidReasonCodeError);
                return false;
            }

            if (masterReasonCodeList.Exists(code => code != restrictionReasonCode && ReasonCodeFromTextBox.Equals(code.Name)))
            {
                reasonCodeErrorProvider.SetError(reasonCodeTextBox, StringResources.ReasonCodeAlreadyExistsError);
                return false;
            }
            
            return true;
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        public RestrictionReasonCode ShowDialogAndReturnRestrictionReasonCode(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : restrictionReasonCode;                      
        }

        public RestrictionReasonCode RestrictionReasonCode
        {
            get { return restrictionReasonCode; }
        }

        public bool IsAddMode
        {
            get { return isAddMode; }
        }

        private void SetUpControlsForAddOrEditMode()
        {
            submitButton.Text = isAddMode ? StringResources.AddButtonLabelNoAmpersand : StringResources.OKButtonLabel;
            Text = isAddMode ? StringResources.AddReasonCode : StringResources.EditReasonCode;

            if (!IsAddMode)
            {
                reasonCodeTextBox.Text = restrictionReasonCode.Name;
            }
        }
    }
}
