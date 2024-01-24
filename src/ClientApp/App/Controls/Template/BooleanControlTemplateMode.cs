using Com.Suncor.Olt.Client.Resources;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public class BooleanControlTemplateMode : IBooleanControlMode
    {
        private readonly ITriStateControl control;

        private bool isVisible = true;

        public BooleanControlTemplateMode(ITriStateControl control)
        {
            this.control = control;
            control.ShowTemplateIcon(true);
        }

        public Visible<bool> Value
        {
            get
            {
                if (!isVisible)
                {
                    return new Visible<bool>(VisibleState.Invisible, false);
                }
                if (control.Checked)
                {
                    return new Visible<bool>(VisibleState.Visible, true);
                }
                return new Visible<bool>(VisibleState.Visible, false);
            }
            set
            {
                if (value.VisibleState == VisibleState.Invisible)
                {
                    isVisible = false;
                    control.TemplateIcon = ResourceUtils.EYE_CLOSED;
                    control.Checked = false;
                    control.EnableControl = false;
                }
                else if (value.VisibleState == VisibleState.Visible)
                {
                    isVisible = true;
                    control.TemplateIcon = ResourceUtils.EYE_OPENED;
                    control.Checked = value.Value;
                    control.EnableControl = true;
                }
            }
        }

        public void VisibleClick()
        {
            Value = isVisible
                        ? new Visible<bool>(VisibleState.Invisible, false)
                        : new Visible<bool>(VisibleState.Visible, false);
        }
    }
}