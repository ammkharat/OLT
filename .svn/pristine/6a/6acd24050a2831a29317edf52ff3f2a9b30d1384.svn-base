using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureLinkRootsView 
    {
        List<DocumentRootUncPath> Items { set; }
        string SiteName { set; }
        DocumentRootUncPath SelectedItem { get; }
        bool CreateNewUncRoot();
        bool EditUncRoot(DocumentRootUncPath selectedItem);
    }
}