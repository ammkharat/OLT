using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILabAlertDefinitionFormView: IBaseForm
    {
        string Name { get;set; }
        string Description { get; set;}
        FunctionalLocation FunctionalLocation { get; set; }
        TagInfo TagInfo { get; set; }
        int MinimumNumberOfSamples { get; set; }
        LabAlertTagQueryRange LabAlertTagQueryRange { get; set; }
        ISchedule Schedule { get; set; }
        bool IsActive { get; set; }
        User Author { set; }
        DateTime CreateDateTime { set; }

        bool ViewEditHistoryEnabled { set; }

        void ClearErrorProviders();
        bool HasScheduleError { get; }
        void ShowNameIsEmptyError();
        void ShowDescriptionIsEmptyError();
        void ShowNoFunctionalLocationsSelectedError();
        void ShowNoTagInfoSelectedError();
        void ShowNameError(string message);

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector();
        DialogResultAndOutput<TagInfo> ShowTagSelector();

        void SetDialogResultOK();
    }
}
