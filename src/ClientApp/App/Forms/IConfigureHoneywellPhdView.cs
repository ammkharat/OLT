using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureHoneywellPhdView : IBaseForm
    {
        event Action SaveButtonClick;
        event Action CancelButtonClick;

        bool IsSqlServer { get; set; }
        bool IsOracle { get; set; }
        
        string OracleUsername { get; set; }
        string OraclePassword { get; set; }
        string OracleHost { get; set; }
        string OracleServiceName { get; set; }

        string SqlServerUsername { get; set; }
        string SqlServerPassword { get; set; }
        string SqlServerHost { get; set; }
        string SqlServerInstance { get; set; }

        bool UseWindowsAuthentication { get; set; }
        string PhdUsername { get; set; }
        string PhdPassword { get; set; }
        string PhdServer { get; set; }
        string ApiVersion { get; set; }

        int? StartTimeOffset { get; set; }
        int? EndTimeOffset { get; set; }
        
        string DataSamplingType { get; set; }
        int? DataSamplingFrequency { get; set; }
        
        string DataReductionType { get; set; }
        int? DataReductionFrequency { get; set; }
        string DataReductionOffset { get; set; }
        int MinimimConfidence { get; set; }
        string PiPassword { get; set; }
        string PiUsername { get; set; }
        string PiServer { get; set; }
        void ShowPiElements();
        void ShowPhdElements();
    }
}