using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Excel
{
    public class ExcelExporter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ExcelExporter));

        public void Export(Stream stream)
        {
            SaveFileDialog dialog = CreateSaveAsDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                try
                {
                    using (Stream file = File.OpenWrite(fileName))
                    {
                        CopyStream(stream, file);
                    }
                    OpenFileInExcel(fileName);
                }
                catch (IOException ioEx)
                {
                    logger.Error(ioEx);
                    OltMessageBox.Show(Form.ActiveForm, StringResources.ExcelExporter_ExportError);
                }
            }
        }

        private static void OpenFileInExcel(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch (Exception)
            {
                string message = string.Format(StringResources.ExcelExporter_ErrorOpeningExcel, fileName);
                OltMessageBox.Show(Form.ActiveForm, message);
            }
        }

        private static SaveFileDialog CreateSaveAsDialog()
        {
           
            var dialog = new SaveFileDialog
            {
                AddExtension = true,
                Filter = StringResources.ExcelExporter_FileFilterDescription + "|*.xls",
                FilterIndex = 2,
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                RestoreDirectory = true
            };
            return dialog;
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

    }

}
