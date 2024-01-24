namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IDocmentLinkRootValidationAction
    {
        void ClearAllErrors();
        void SetErrorNoFunctionalLocations();
        void SetErrorNoPathName();
        void SetErrorNoUncPath();
        void SetErrorIsNotUncPath();
        void SetErrorIsNotExistingUncPath();
    }
}