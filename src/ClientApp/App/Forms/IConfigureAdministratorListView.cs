using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureAdministratorListView 
    {
        List<AdministratorList> Items { set; }
        string SiteName { set; }
        AdministratorList SelectedItem { get; }
        bool CreateNewAdministrator();
        bool EditAdministrator(AdministratorList selectedItem);
    }
}