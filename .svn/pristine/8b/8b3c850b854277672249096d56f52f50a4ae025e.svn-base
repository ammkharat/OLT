using System.Drawing;
using DevExpress.XtraPrinting.Native;

namespace Com.Suncor.Olt.Common.Utility
{
    public class DevExpressMeasurementUtility
    {
        public static bool StringWillFitIntoField(LabelAttributes labelAttributes, string stringToPutInControl)
        {
            var font = labelAttributes.Font;
            var width = labelAttributes.Width;
            var height = labelAttributes.Height;

            var result = Measurement.MeasureString(stringToPutInControl,
                font, width,
                StringFormat.GenericDefault,
                GraphicsUnit.Pixel);
            return result.Height <= height;
        }
    }
}