using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Resources;

namespace Com.Suncor.Olt.Client.Forms
{
    internal class ErrorProviderHandler
    {
        private readonly BaseForm form;
        private readonly List<ErrorProvider> providers;

        public ErrorProviderHandler(BaseForm form)
        {
            this.form = form;
            providers = new List<ErrorProvider>();
        }

        public void SetError(string controlName, string error)
        {
            Control controlForError = form.FindControlByName(controlName);
            if (controlForError != null) //RITM0264488 Sarnia unchecking the work permit default N/A flag investigation
            SetError(controlForError, error);
        }

        public void SetError(Control controlForError, string error)
        {
            var provider = new ErrorProvider();
            provider.SetError(controlForError, error);
            providers.Add(provider);
        }

        public void SetRequiredForApproval(string controlName, string message)
        {
            SetRequiredForApproval(form.FindControlByName(controlName), message);
        }

        public void SetRequiredForApproval(Control control, string message)
        {
            var provider = new ErrorProvider();
            var icon = ResourceUtils.NEEDS_APPROVAL;
            provider.Icon = icon;
            provider.SetError(control, message);
            providers.Add(provider);
        }

        public void SetWarning(string controlName, string message)
        {
            SetWarning(form.FindControlByName(controlName), message);
        }

        public void SetWarning(Control control, string message)
        {
            var provider = new ErrorProvider();
            SetWarningOnControl(control, provider, message);
            providers.Add(provider);
        }

        public static void SetWarningOnControl(Control control, ErrorProvider provider, string message)
        {
            Bitmap warning = ResourceUtils.WARNING;
            IntPtr hicon = warning.GetHicon();
            Icon icon = Icon.FromHandle(hicon);
            provider.Icon = icon;
            provider.SetError(control, message);
        }

        public void Clear()
        {
            providers.ForEach(
                p =>
                    {
                        p.Clear();
                        p.ContainerControl = null;
                    }
                );
            providers.Clear();
        }

    }
}