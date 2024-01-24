using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditDocmentLinkRootView : IDocmentLinkRootValidationAction, IBaseForm
    {
        string PathName { get; set; }
        string UncPath { get; set; }
        IList<FunctionalLocation> FunctionalLocations { get; set; }
        void SetDialogResultOK();
    }
}