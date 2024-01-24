using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitMontrealTemplateConfigurationView : IBaseForm
    {
        List<WorkPermitMontrealTemplate> WorkPermitMontrealTemplateList { set; }
        WorkPermitMontrealTemplate SelectedWorkPermitMontrealTemplate { get; set; }
        void SelectFirstWorkPermitMontrealTemplate();
        bool UserReallyWantsToDeleteWorkPermitMontrealTemplate();
    }
}
