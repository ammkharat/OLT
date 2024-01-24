using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltLabelReadWriteDirection : Label
    {
        public OltLabelReadWriteDirection()
        {
            base.AutoSize = false;
            base.ForeColor = Color.Blue;
        }

        public TagDirection Direction
        {
            set { Text = GetText(value); }
        }

        private string GetText(TagDirection value)
        {
            if(TagDirection.Read == value)
            {
                return StringResources.TagDirectionLabelRead;
            }
            if(TagDirection.Write == value)
            {
                return StringResources.TagDirectionLabelWrite;
            }
            return string.Empty;
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT_BOLD; }
        }


    }
}