using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class FileUtility
    {
        public static void OpenFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                string message = string.Format(StringResources.UriOpen_ErrorMessage, fileName);
                OltMessageBox.Show(Form.ActiveForm, message);
            }
            else
            {
                try
                {
                    Process.Start(fileName);
                }
                catch (Exception)
                {
                    string message = string.Format(StringResources.UriOpen_ErrorMessage, fileName);
                    OltMessageBox.Show(Form.ActiveForm, message);
                }
            }
        }

        public static void OpenFileOrDirectoryOrWebsite(string path)
        {
            OpenFile(path);
        }

    }
}