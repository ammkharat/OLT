namespace Com.Suncor.Olt.Client.Controls.Template
{
    public class BooleanControlUserMode : IBooleanControlMode
    {
        private readonly ITriStateControl control;

        public BooleanControlUserMode(ITriStateControl control)
        {
            this.control = control;
            control.ShowTemplateIcon(false);
        }

        public Visible<bool> Value
        {
            get
            {
                if (control.Visible == false)
                {
                    return new Visible<bool>(VisibleState.Invisible, false);
                }
                return new Visible<bool>(VisibleState.Visible, control.Checked);
            }
            set
            {
                if (value.VisibleState == VisibleState.Invisible)
                {
                    control.Visible = false;
                    control.Checked = false;
                }
                else if (value.VisibleState == VisibleState.Visible)
                {
                    control.Visible = true;
                    control.Checked = value.Value;
                }
            }
        }

        public void VisibleClick()
        {
            return;
        }
    }
}