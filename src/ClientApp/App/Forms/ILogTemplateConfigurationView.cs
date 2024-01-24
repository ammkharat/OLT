using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogTemplateConfigurationView : IBaseForm
    {
        LogTemplate ShowAddEditForm(LogTemplate editObject, List<LogTemplate> logTemplatesForSite);        
        List<LogTemplate> LogTemplateList { set; }
        LogTemplate SelectedLogTemplate { get; }
        void SelectFirstLogTemplate();
        bool UserReallyWantsToDeleteLogTemplate();
    }
}
