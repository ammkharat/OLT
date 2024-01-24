using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IRespondableDetails : IDetails
    {
        event EventHandler Respond;
        event EventHandler GoToDefinition;

        bool GoToDefinitionEnabled { set; }
        bool RespondEnabled { set; }

         //DMND0010124 mangesh
        event EventHandler CopyLastResponse;
        bool CopyLastResponseEnabled { set; }
    }
}
