using System;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public interface IReportsPage
    {
        event EventHandler Load;
        event EventHandler RunReportClicked;
        
        string Title { get; set;}
        XtraReport Report { set;}
        IReportParametersControl ParametersControl { set;}
        
        void DisplayErrorMessage(string message);
    }
}