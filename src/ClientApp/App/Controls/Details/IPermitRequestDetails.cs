using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IPermitRequestDetails : IDeletableDetails
    {
        event EventHandler Submit;
        event EventHandler Import;

        bool SubmitEnabled { set; }
        bool ImportEnabled { set; }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        event EventHandler MarkAsTemplate;
        
        bool MarkTemplateEnabled { set; }

        bool DeleteVisible { set; }
        bool editVisible { set; }
        

        bool editHistoryButtonVisible { set; }
        bool submitButtonVisible { set; }

        event EventHandler RefreshAll;

        bool editTemplateVisible { set; }
        event EventHandler EditTemplate;

        
        
        
        
    }
}