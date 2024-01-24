using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class AdministratorFormValidator
    {
        private readonly IAdministratorValidationAction action;
        private bool hasErrors;

        public AdministratorFormValidator(IAdministratorValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateAndSetErrors(AdministratorList editObject)
        {
            action.ClearAllErrors();
            ValidateSiteName(editObject);
            //ValidateGroup(editObject);
            //ValidateSiteRepresentative(editObject);
            //ValidateSiteAdmin(editObject);
            //ValidateBEA(editObject);
        }


        private void ValidateSiteName(AdministratorList editObject)
        {
            if (editObject.SiteName.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoSite();
                hasErrors = true;
            }
        }

        private void ValidateGroup(AdministratorList editObject)
        {
            if (editObject.Group.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoGroup();
                hasErrors = true;
            }
        }

        private void ValidateSiteRepresentative(AdministratorList editObject)
        {
            // no validation for site representative

            //if (editObject.SiteRepresentative.IsNullOrEmptyOrWhitespace())
            //{
            //    action.SetErrorNoSiteRepresentative();
            //    hasErrors = true;
            //}
        }

        private void ValidateSiteAdmin(AdministratorList editObject)
        {
            if (editObject.SiteAdmin.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoSiteAdmin();
                hasErrors = true;
            }
        }

        private void ValidateBEA(AdministratorList editObject)
        {
            if (editObject.BEA.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoBEA();
                hasErrors = true;
            }
        }

       
    }
}