using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public static class PageHelper
    {
        public static bool ShowOKCancelDialog(string dialogText, string title)
        {
            DialogResult result = OltMessageBox.Show(
                Form.ActiveForm,
                dialogText,
                title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            return result == DialogResult.OK;
        }

        public static void DeleteSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.DeleteSuccessfulMessage, StringResources.DeleteSuccessfulTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static GridLayoutAction ShowGridLayoutConfirmationDialog(IPage page)
        {
            GridLayoutActionSelectionForm form = new GridLayoutActionSelectionForm();
            form.ShowDialog((IWin32Window) page);
            GridLayoutAction gridLayoutAction = form.GetGridLayoutAction();
            form.Dispose();

            return gridLayoutAction;
        }

        public static string GetGridLayoutXml(IDomainSummaryGrid grid)
        {
            Stream stream = new MemoryStream();
            grid.DisplayLayout.SaveAsXml(stream);

            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            string xml = streamReader.ReadToEnd();
            return xml;
        }

        public static void LoadGridLayout(string xml, IDomainSummaryGrid grid)
        {
            if (!xml.IsNullOrEmptyOrWhitespace())
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter streamWriter = new StreamWriter(stream);
                streamWriter.Write(xml);
                streamWriter.Flush();

                stream.Position = 0;
                grid.DisplayLayout.LoadFromXml(stream);
            }
        }

        public static void LaunchLockDeniedMessage(Form owner, string nameOfUserWithCurrentLock, LockType lockType)
        {
            LockMessage lockMessage = LockMessage.CreateEditLockMessage(lockType, nameOfUserWithCurrentLock);

            OltMessageBox.Show(owner,
                               lockMessage.Message,
                               lockMessage.Title,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }

        public static DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog(Form parentForm)
        {
            DateRangeSelectorForm dateRangeForm = new DateRangeSelectorForm();
            return dateRangeForm.DisplayFormAsDialog(parentForm);
        }
    }
}