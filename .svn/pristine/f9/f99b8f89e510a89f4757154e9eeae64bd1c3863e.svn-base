using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureDefaultTabsFormView
    {
        string SiteName { set; }
        Dictionary<SectionKey, List<PageKey>> SectionToPageMap { set; }
        IList<RoleDisplayConfiguration> Configurations { get; set; }
        void Close();
    }
}
