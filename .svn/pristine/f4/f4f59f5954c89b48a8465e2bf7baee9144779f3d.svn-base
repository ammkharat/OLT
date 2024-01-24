using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPermitAssessmentFormView : IFormView
    {
        string LocationEquipmentNumber { get; set; }
        string PermitNumber { get; set; }
        OilsandsWorkPermitType PermitType { get; set; }
        int CrewSize { get; set; }
        string JobDescription { get; set; }
        bool IssuedToSuncor { get; set; }
        bool IssuedToContractor { get; set; }
        string Contractor { get; set; }
        string Trade { get; set; }
        string JobCoordinator { get; set; }
        List<OilsandsWorkPermitType> OilsandsWorkPermitTypes { set; }
        List<Contractor> Contractors { set; }
        List<CraftOrTrade> Trades { set; }
        List<QuestionnaireConfigurationDTO> QuestionnaireConfigurations { set; }
        QuestionnaireConfigurationDTO SelectedQuestionnaireConfiguration { get; set; }
        PermitAssessment PermitAssessment { set; }
        bool? IsIlpRecommended { get; set; }
        bool EnableQuestionnaireSelection { set; }
        event Action QuestionnaireConfigurationChanged;
        event Action HistoryClicked;

        void SetErrorForValidToIsInThePast();
        void SetQuestionnaireConfigurationNotSelectedError();
        void SetPermitNumberNotSelectedError();
        void SetPermitTypeNotSelectedError();
        void SetTradeNotSelectedError();
        void SetLocationEquipmentNumberNotSetError();
        void SetCrewSizeNotSetError();
        void SetJobDescriptionNotSetError();
        void SetIssuedToNotSetError();
        void SetContractorNotSelectedError();
        void SetJobCoordinatorNotSetError();
    }
}