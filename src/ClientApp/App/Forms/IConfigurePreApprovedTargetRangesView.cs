using System;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigurePreApprovedTargetRangesView
    {
        bool WritableMode { set; }
        string TargetDefinitionName { set; }
        
        bool NeverToExceedMinEnabled { set; }
        bool NeverToExceedMaxEnabled { set; }
        bool MinEnabled { set; }
        bool MaxEnabled { set; }

        decimal? PreApprovedNeverToExceedMin { get; set; }
        decimal? PreApprovedNeverToExceedMax { get; set; }
        decimal? PreApprovedMin { get; set; }
        decimal? PreApprovedMax { get; set; }

        string TagUnit { set; }

        TargetDefinition TargetDefinition { get; }
        
        void Close();

        event EventHandler FormLoad;
        event EventHandler Save;
        event EventHandler Cancel;
    }
}