using System.Drawing;

namespace Com.Suncor.Olt.Client
{
    /// <summary>
    /// Holds appearance aspects of a widget. The short text and icon are always
    /// displayed. The long text is used to explain the button in more
    /// details (perhaps as a tooltip).
    /// </summary>
    public class WidgetAppearance
    {
        private readonly string shortText;
        private readonly string longText;
        private readonly Image icon;

        public WidgetAppearance(string shortText, string longText, Image icon)
        {
            this.shortText = shortText;
            this.longText = longText;
            this.icon = icon;
        }

        public string ShortText
        {
            get { return shortText; }
        }

        public string LongText
        {
            get { return longText; }
        }

        public Image Icon
        {
            get { return icon; }
        }

        public override string ToString()
        {
            return "Widget appearance: " + shortText;
        }
    }
}
