namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IAdministratorValidationAction
    {
        void ClearAllErrors();
        void SetErrorNoSite();
        void SetErrorNoGroup();
        void SetErrorNoSiteRepresentative();
        void SetErrorNoSiteAdmin();
        void SetErrorNoBEA();
    }
}