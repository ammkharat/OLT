namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IWorkPermitMudsValidationAction
    {
        void SetErrorForNoPermitType();
        void SetErrorForNoDescription();
        void SetErrorForNoTrade();
        void SetErrorForNoFunctionalLocation();
        void SetErrorForStartDateTimeAfterEndDateTime();
        void SetErrorForNoTemplateName();
        void SetErrorForNoSelectedTemplate();
        void SetErrorForTimeSpanTooLongForVehicleEntryType();
        void SetErrorForTimeSpanTooLongForDurationType();
        void SetErrorForTimeSpanTooLong();
        void SetErrorForEndDateMustBeonOrAfterTodayError();

        void SetErrorForAutresTravexElev();
        void SetErrorForAutresTravexMod();
        void SetErrorForRemplir();
        void SetErrorForRemplirForNumeric();
        void SetErrorForProcedureEnt();
        void SetErrorForAutresCondition();
        void SetErrorForFco();
        void SetErrorForEtiquette();
        void SetErrorForAutresAppVehicleComb();
        void SetErrorForElectricVolt();
        void SetErrorForAutresRisque();
        void SetErrorForAppreilResp();
        void SetErrorForGants();
        void SetErrorForEpiAnti();
        void SetErrorForHabitP();
        void SetErrorForAlrmeDcs();
        void SetErrorForOutilManuel();
        void SetErrorForPerimetereSecurities();
        void SetErrorForAutresDePrevention();

       
    }
}
