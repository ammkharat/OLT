namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IConfinedSpaceValidationAction
    {
        void SetErrorForNoFunctionalLocation();
        void SetErrorForStartDateTimeAfterEndDateTime();
        void SetErrorForEndDateMustBeonOrAfterTodayError();

        void SetErrorForCorrosif();
        void SetErrorForAromatique();
        void SetErrorForAutresSubstances();
        void SetErrorForDessinsRequis();
        void SetErrorForAutreConditions();
    }
}