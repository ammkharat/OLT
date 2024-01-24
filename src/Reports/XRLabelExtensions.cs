using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public static class XRLabelExtensions
    {
        public static LabelAttributes CreateLabelAttributes(this XRLabel xrLabel)
        {
            var effectiveFont = xrLabel.GetEffectiveFont();
            var width = xrLabel.WidthF;

            // Sometimes the last character can get clipped off, so putting a little extra "padding" in.
            width -= 2.0f;
            var height = xrLabel.HeightF;

            var effectivePadding = xrLabel.GetEffectivePadding();
            width -= effectivePadding.Left;
            width -= effectivePadding.Right;
            height -= effectivePadding.Top;
            height -= effectivePadding.Bottom;

            var effectiveBorderWidth = xrLabel.GetEffectiveBorderWidth();
            width -= (effectiveBorderWidth*2);
            height -= (effectiveBorderWidth*2);

            return new LabelAttributes(effectiveFont, width, height);
        }
    }
}