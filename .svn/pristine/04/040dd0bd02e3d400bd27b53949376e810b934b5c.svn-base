using System;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICokerCardFormView: IBaseForm
    {
        string Shift { set; }
        User Author { set; }
        DateTime CreateDateTime { set; }

        CokerCardDisplayAdapter DisplayAdapter { get; set; }

        bool ViewEditHistoryEnabled { set; }

        void ShowErrors();

        string ConfigurationName { set; }
    }
}
