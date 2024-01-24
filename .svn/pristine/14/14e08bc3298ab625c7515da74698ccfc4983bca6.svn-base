using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogCopyFormView : IBaseForm
    {
        List<FunctionalLocation> FunctionalLocations { get; set; }
        string Comments { get; set; }
        bool CreateALogForEachFunctionalLocation { get; set; }
        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);
    }
}
