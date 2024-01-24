using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditTrainingBlockView : IBaseForm
    {
        event Action FormLoad;
        event Action SaveButtonClick;

        string TrainingBlockName { get; set; }
        string TrainingCode { get; set; }
        string FormTitle { set; }
        IList<FunctionalLocation> FunctionalLocations { set; get; }
        void ShowNameMustBeUniqueError();
        void ShowAtLeastOneFunctionalLocationIsNecessaryError();
        void ShowNameMustNotBeEmptyError();
    }
}
