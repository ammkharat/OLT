using System;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public interface IReportParametersControl
    {
        event EventHandler Load;

        bool Enabled { set; }
        bool IsValid { get; }
        string ErrorMessage { get;}
    }
}