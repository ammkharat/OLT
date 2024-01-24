using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetSummaryView
    {
        event EventHandler LoadView;
        string SummaryLabel { set; }
        string NameLabel { set; }
        string TargetName { set; }
        string CategoryName { set; }
        string Author { set; }
        string FunctionalLocationName { set; }
        string FunctionalLocationDescription { set; }
        string Description { set; }
        string MeasurementTagName { set; }
        string MeasurementTagUnits { set; }
        // Threshold values:
        decimal? NeverToExceedMaximum { set; }
        decimal? MaxValue { set; }
        decimal? MinValue { set; }
        decimal? NeverToExceedMinimum { set; }
        string TargetValue { set; }
    }
}