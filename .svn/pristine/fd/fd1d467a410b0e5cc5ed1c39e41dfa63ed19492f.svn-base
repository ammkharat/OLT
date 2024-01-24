using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public class StringControlUserMode : IStringControlMode
    {
        private readonly ITriStateTextControl control;

        public StringControlUserMode(ITriStateTextControl control)
        {
            this.control = control;
            control.ShowTemplateIcon(false);
        }

        public void VisibleClick()
        {
            return;
        }

        public Visible<TernaryString> Value
        {
            get
            {
                if (control.Visible == false)
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
                    control.Visible = false;
                    control.Checked = false;
                    control.ClearText();
                }
                else if (value.VisibleState == VisibleState.Visible)
                {
                    control.Visible = true;
                    TernaryString ternaryString = value.Value;
                    control.Checked = ternaryString.StateAsBool;
                    if (ternaryString.HasValue)
                    {
                        control.Text = ternaryString.Text;
                    }
                    else
                    {
                        control.ClearText();
                    }
                }
            }
        }
    }
}