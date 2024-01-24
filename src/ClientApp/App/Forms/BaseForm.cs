using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraSplashScreen;
using Infragistics.Win.UltraWinExplorerBar;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;
using CommonConstants = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Forms
{
    public class BaseForm : Form, IBaseForm
    {

        private static readonly Font FONT =
            new Font(UIConstants.FONT_FAMILY_NAME, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

        protected BaseForm()
        {
            base.Icon = ResourcesResx.OLT_Program_Icon;
            MinimizeBox = false;
        }

        public Control FindControlByName(string name)
        {
            Control[] result = Controls.Find(name, true);
            return result.Length == 0 ? null : result[0];
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new Icon Icon
        {
            set {  }
            get { return base.Icon; }
        }

        public override Font Font
        {
            get { return FONT; }
        }

        public virtual bool ConfirmCancelDialog()
        {
            return
                OltMessageBox.Show(ActiveForm, StringResources.AreYouSureCancelDialogMessage,
                                   StringResources.AreYouSureCancelDialogTitle, MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public void SaveFailedMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.SaveFailureErrorMessage, StringResources.SaveFailureErrorTitle,
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public virtual void SaveSucceededMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.SaveSuccessMessage, StringResources.SaveSuccessTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }

        public void ShowMessageBox(string title, string error)
        {
            OltMessageBox.Show(ActiveForm, error, title, MessageBoxButtons.OK);
        }

        //ayman Sarnia eip DMND0008992
        public void SetTitle(string titleText)
        {
            Text = titleText;
        }

        public void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText)
        {
            if (Text != "View Eip Template")   //ayman Sarnia eip DMND0008992
            {
                Text = string.Format(isEdit ? StringResources.FormEditTitleText : StringResources.FormCreateTitleText, titleText);
            }
        }

        protected void MakeControlsAndChildControlsReadOnly(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBoxBase)
                {
                    TextBoxBase textBoxBase = (TextBoxBase)control;
                    textBoxBase.ReadOnly = true;
                }
                else if (control is OltListBox)
                {
                    OltListBox listBox = (OltListBox) control;
                    listBox.ReadOnly = true;
                }
                else if (control is Label ||
                    control is UltraExplorerBar || 
                    control is ListBox ||
                    control is LinkLabel)
                {
                    // do nothing
                }
                else if (control is RichTextEditor)
                {
                    ((RichTextEditor) control).ReadOnly = true;
                }
                else if (
                    control is Panel ||
                    control is GroupBox ||
                    control is SplitContainer ||
                    control is UserControl)
                {
                    MakeControlsAndChildControlsReadOnly(control.Controls);
                }
                else
                {
                    control.Enabled = false;
                    MakeControlsAndChildControlsReadOnly(control.Controls);
                }                
            }
        }

        public void ShowWaitScreenAndDisableForm()
        {
            const bool fadeInOrFadeOut = false;  // turning off fade in/fade out seems to fix a bug (#3057)

            SetFormEnabledState(false);
            SplashScreenManager.ShowForm(this, typeof(WaitForm), fadeInOrFadeOut, fadeInOrFadeOut, false);
        }

        public void CloseWaitScreenAndEnableForm()
        {
            SetFormEnabledState(true);
            SplashScreenManager.CloseForm(false, 0, this, true);
            Focus();
        }

        protected void SetFormEnabledState(bool enabled)
        {
            ControlBox = enabled;
            foreach (Control control in Controls)
            {
                control.Enabled = enabled;
            }
        }

        public void SetFormVisibleState(bool visible)
        {
            foreach (Control control in Controls)
            {
                control.Visible = visible;
            }
        }        
    }
}