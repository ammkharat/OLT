using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public interface ICokerCardReportFormView
    {
        void CloseForm();

        Date StartDate { get; set; }
        Date EndDate { get; set; }
        string SelectedCokerCardConfiguration { get; }
        List<string> CokerCardConfigurations { set; }

        void ClearErrors();
        void SetErrorForStartDate(string errorMessage);
        void SetErrorForEndDate(string errorMessage);        
    }
}
