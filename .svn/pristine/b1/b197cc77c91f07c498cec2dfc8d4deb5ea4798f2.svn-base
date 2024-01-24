using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class DocumentRootUncPathValidator
    {
        private readonly IDocmentLinkRootValidationAction action;
        private bool hasErrors;

        public DocumentRootUncPathValidator(IDocmentLinkRootValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateAndSetErrors(DocumentRootUncPath editObject)
        {
            action.ClearAllErrors();
            ValidateFunctionalLocation(editObject);
            ValidateHasName(editObject);
            ValidateHasPath(editObject);

            if(!hasErrors && !editObject.Path.IsValidUri())
            {
                ValidatePathIsUncFolder(editObject);
                ValidatePathExists(editObject);                
            }
        }

        private void ValidatePathExists(DocumentRootUncPath editObject)
        {
            string uncPath = editObject.Path;

            if (uncPath.HasValue() && uncPath.IsValidUncPath())
            {
                if (!Directory.Exists(uncPath))
                {
                    action.SetErrorIsNotExistingUncPath();
                    hasErrors = true;
                }
            }
        }

        private void ValidatePathIsUncFolder(DocumentRootUncPath editObject)
        {
            string uncPath = editObject.Path;
            if (uncPath.HasValue() && !uncPath.IsValidUncPath())
            {
                action.SetErrorIsNotUncPath();
                hasErrors = true;
            }
        }

        private void ValidateHasPath(DocumentRootUncPath editObject)
        {
            if (editObject.Path.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoUncPath();
                hasErrors = true;
            }
        }

        private void ValidateHasName(DocumentRootUncPath editObject)
        {
            if (editObject.PathName.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorNoPathName();
                hasErrors = true;
            }
        }

        private void ValidateFunctionalLocation(DocumentRootUncPath editObject)
        {
            if (editObject.FirstLevelFunctionalLocations.Count == 0)
            {
                action.SetErrorNoFunctionalLocations();
                hasErrors = true;
            }
        }
    }
}