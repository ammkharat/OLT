using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITechnicalSiteConfigurationView : IBaseForm
    {
        event Action Save;

        SiteConfiguration SiteConfiguration { get; set; }
    }
}
