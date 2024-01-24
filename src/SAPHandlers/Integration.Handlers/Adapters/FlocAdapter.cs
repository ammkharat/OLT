using System;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public class FlocAdapter
    {
        private const string ERROR_MESSAGE_START = "Floc Adapter Error: ";
        private const string FLOC_DELIMITER = "-";
        private readonly FunctionalLocationDetails functionalLocationObj;
        private readonly IFunctionalLocationOperationalModeService functionalLocationOperationalModeService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ILog logger;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ISiteService siteService;
        private readonly IUserService userService;


        public FlocAdapter(FunctionalLocationDetails flocObj, ILog logger)
            : this(
                flocObj,
                logger,
                GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
                GenericServiceRegistry.Instance.GetService<ISiteService>(),
                GenericServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
                GenericServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>(),
                GenericServiceRegistry.Instance.GetService<IUserService>())
        {
        }

        public FlocAdapter(
            FunctionalLocationDetails flocObj,
            ILog logger,
            IFunctionalLocationService functionalLocationService,
            ISiteService siteService,
            ISiteConfigurationService siteConfigurationService,
            IFunctionalLocationOperationalModeService functionalLocationOperationalModeService,
            IUserService userService)
        {
            this.logger = logger;
            functionalLocationObj = flocObj;

            this.functionalLocationService = functionalLocationService;
            this.functionalLocationOperationalModeService = functionalLocationOperationalModeService;
            this.siteService = siteService;
            this.siteConfigurationService = siteConfigurationService;
            this.userService = userService;
        }

        public void IntegrateFlocObjectToOperatorLogTool()
        {

            //ayman SAP Mapping
            if (functionalLocationObj.PlantId.Trim() == "7030" || functionalLocationObj.PlantId.Trim() == "7600")
            {
                functionalLocationObj.PlantId = "9991";
            }


            var site = siteService.QueryByPlantId(functionalLocationObj.PlantId);
            DoSiteNullCheck(site, functionalLocationObj.PlantId);

            Thread.CurrentThread.CurrentUICulture =
                LanguageCode.GetCultureInfoFromSAPALanguageCode(functionalLocationObj.LanguageCode);

            var fullHierarchy = CreateFullHierarchyIncludingSuperior(
                functionalLocationObj.FullHierarchy, functionalLocationObj.SuperiorFullHierarchy);

            var languageCode = functionalLocationObj.LanguageCode == null
                ? null
                : functionalLocationObj.LanguageCode.ToUpper();

            if (languageCode == null)
            {
                logger.Error(
                    "NULL language code received from SAP. There should be follow-up with the webMethods team to determine why. The code should be EN or FR. OLT will default to EN.");
            }

            if (languageCode != LanguageCode.English.SapCode && languageCode != LanguageCode.French.SapCode)
            {
                logger.Error("OLT received an unrecognized language code. The code received was: " + languageCode);
            }

            var culture = LanguageCode.GetCultureStringFromSAPLanguageCode(languageCode);

            var newFunctionalLocation = new FunctionalLocation(
                site,
                fullHierarchy,
                long.Parse(functionalLocationObj.PlantId), functionalLocationObj.Description, culture);

            var alreadyExistsFunctionalLocation =
                functionalLocationService.QueryByFullHierarchyIncludeDeleted(newFunctionalLocation.FullHierarchy,
                    newFunctionalLocation.Site.IdValue);
            // do not change anything if the Floc already exists in OLT, but was created in OLT.
            if (alreadyExistsFunctionalLocation != null &&
                alreadyExistsFunctionalLocation.Source == FunctionalLocationSource.OLT)
                return;

            switch (functionalLocationObj.Action)
            {
                case "Add":
                    // Add or Update because add may need to undelete an existing record.
                    UndoDeleteOfFunctionalLocation(newFunctionalLocation);
                    AddOrUpdateFunctionalLocation(newFunctionalLocation, site);
                    break;
                case "Change":
                    AddOrUpdateFunctionalLocation(newFunctionalLocation, site);
                    break;
                case "Delete":
                    DeleteFunctionalLocation(newFunctionalLocation);
                    break;
            }
        }

        // If the Functional Location already exists, then reset the delete flag to zero.
        private void UndoDeleteOfFunctionalLocation(FunctionalLocation functionalLocation)
        {
            var alreadyExistsFunctionalLocation =
                functionalLocationService.QueryByFullHierarchyIncludeDeleted(functionalLocation.FullHierarchy,
                    functionalLocation.Site.IdValue);
            if (alreadyExistsFunctionalLocation != null && alreadyExistsFunctionalLocation.Deleted)
            {
                logger.Debug(
                    string.Format("Removing the Deleted Flag to the Functional Location {0}",
                        functionalLocation.FullHierarchy));
                alreadyExistsFunctionalLocation.Deleted = false;
                functionalLocationService.UndoRemove(alreadyExistsFunctionalLocation);
            }
        }

        private void DeleteFunctionalLocation(FunctionalLocation incomingFunctionalLocation)
        {
            logger.Debug(string.Format("DELETE Functional Location: {0}.", incomingFunctionalLocation.FullHierarchy));

            var existingFloc =
                functionalLocationService.QueryByFullHierarchy(incomingFunctionalLocation.FullHierarchy,
                    incomingFunctionalLocation.Site.IdValue);

            if (existingFloc == null)
            {
                logger.Info(
                    "OLT has received a 'Delete' message for a FLOC that doesn't exist in the system. The FLOC is: " +
                    incomingFunctionalLocation.FullHierarchy);
                return;
            }

            if (string.Equals(existingFloc.Culture, incomingFunctionalLocation.Culture))
            {
                functionalLocationService.RemoveByFullHierarchy(incomingFunctionalLocation);
            }
        }

        private void Insert(FunctionalLocation functionalLocation)
        {
            logger.Debug(string.Format("ADD Functional Location: {0}.", functionalLocation.FullHierarchy));

            functionalLocation = functionalLocationService.Insert(functionalLocation);

            // If the Functional Location is at the Unit level, then insert default Operational Mode.
            if (FunctionalLocationType.Level3 == functionalLocation.Type)
            {
                var sapCreationUser = userService.GetSAPUser();

                logger.Debug(
                    string.Format("Adding default Operational Modes for the Floc {0} because it's a new Unit.",
                        functionalLocation.FullHierarchy));

                functionalLocationOperationalModeService.InsertDefault(functionalLocation, sapCreationUser);
            }
        }

        private void Update(FunctionalLocation currentFunctionalLocation, FunctionalLocation functionalLocation)
        {
            logger.Debug(
                string.Format(
                    "Updating Functional Location {0}. Old description: {1},  New description: {2}, Old Culture: {3}, New Culture: {4}",
                    currentFunctionalLocation.FullHierarchy, currentFunctionalLocation.Description,
                    functionalLocation.Description, currentFunctionalLocation.Culture, functionalLocation.Culture));

            currentFunctionalLocation.Description = functionalLocation.Description;
            currentFunctionalLocation.Culture = functionalLocation.Culture;
            functionalLocationService.Update(currentFunctionalLocation);
        }

        private void AddOrUpdateFunctionalLocation(FunctionalLocation functionalLocation, Site site)
        {
            var alreadyExistsFunctionalLocation =
                functionalLocationService.QueryByFullHierarchy(functionalLocation.FullHierarchy,
                    functionalLocation.Site.IdValue);

            if (alreadyExistsFunctionalLocation != null)
            {
                if (FunctionalLocationChanged(functionalLocation, alreadyExistsFunctionalLocation))
                {
                    if (ShouldUpdateBasedOnLanguageCode(alreadyExistsFunctionalLocation, functionalLocation, site))
                    {
                        Update(alreadyExistsFunctionalLocation, functionalLocation);
                    }
                }
            }
            else
            {
                Insert(functionalLocation);
            }
        }

        private bool ShouldUpdateBasedOnLanguageCode(FunctionalLocation existingFunctionalLocation,
            FunctionalLocation incomingFunctionalLocation, Site site)
        {
            bool shouldUpdate;

            if (incomingFunctionalLocation.Culture.Equals(existingFunctionalLocation.Culture))
            {
                shouldUpdate = true;
            }
            else
            {
                var siteConfiguration = siteConfigurationService.QueryBySiteId(site.IdValue);
                var siteCulture = siteConfiguration.Culture;

                if (siteCulture.Equals(incomingFunctionalLocation.Culture))
                {
                    shouldUpdate = true;
                }
                else
                {
                    shouldUpdate = false;
                }
            }

            return shouldUpdate;
        }


        private static bool FunctionalLocationChanged(FunctionalLocation newFloc, FunctionalLocation oldFloc)
        {
            return (!string.Equals(oldFloc.Description, newFloc.Description)) ||
                   (!string.Equals(oldFloc.Culture, newFloc.Culture));
        }

        private static void DoSiteNullCheck(Site site, string plantId)
        {
            if (site == null)
            {
                var siteErrorString =
                    string.Format("{0}. No OLT Site was found for Plant Id: {1}. ", ERROR_MESSAGE_START, plantId);
                throw new ApplicationException(siteErrorString);
            }
        }

        public static string CreateFullHierarchyIncludingSuperior(string flocId, string superiorFlocId)
        {
            // TODO: Convert to startwith and ordinalignorecase.
            if (superiorFlocId.IsNullOrEmptyOrWhitespace() ||
                flocId.StartsWith(superiorFlocId, StringComparison.OrdinalIgnoreCase))
                return flocId;

            var fullHierarchyWithSuperiorPrepended = superiorFlocId + FLOC_DELIMITER + flocId;

            return fullHierarchyWithSuperiorPrepended;
        }
    }
}