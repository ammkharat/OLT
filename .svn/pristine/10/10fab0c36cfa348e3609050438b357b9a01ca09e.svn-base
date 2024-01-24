using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public class StringControlTemplateMode : IStringControlMode
    {
        private readonly ITriStateTextControl control;

        private bool isVisible = true;

        public StringControlTemplateMode(ITriStateTextControl control)
        {
            this.control = control;
            control.ShowTemplateIcon(true);
        }

        public void VisibleClick()
        {
            Value = isVisible
                        ? new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null))
                        : new Visible<TernaryString>(VisibleState.Visible, new TernaryString(false, null));
        }

        public Visible<TernaryString> Value
        {
            get
            {
                if (!isVisible)
                {
                    return new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null));
                }
                return new Visible<TernaryString>(VisibleState.Visible,
                                                  new TernaryString(control.Checked, control.Text));
            }
            set
            {
                if (value.VisibleState == VisibleState.Invisible)
                {
                    isVisible = false;
                    control.TemplateIcon = ResourceUtils.EYE_CLOSED;
                    control.Checked = false;
                    control.ClearText();
                    control.EnableControl = false;
                }
                else if (value.VisibleState == VisibleState.Visible)
                {
                    isVisible = true;
                    control.TemplateIcon = ResourceUtils.EYE_OPENED;
                    control.Checked = value.Value.StateAsBool;
                    control.Text = value.Value.Text;
                    control.EnableControl = true;
                }
            }

        }
    }
}