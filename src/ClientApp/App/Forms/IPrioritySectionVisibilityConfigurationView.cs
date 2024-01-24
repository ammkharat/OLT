using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPrioritySectionVisibilityConfigurationView : IBaseForm
    {
        event Action FormLoad;
        event Action SaveButtonClick;

        string SiteName { set; }
        bool UseNewPrioritiesPage { get; set; }
    }
}