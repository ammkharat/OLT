using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CloneWorkPermitFormPresenter
    {
        private readonly ICloneWorkPermitFormView view;
        private readonly IAuthorized authorized;
        private WorkPermit cloneFrom;
        private readonly UserContext userContext;

        public CloneWorkPermitFormPresenter(ICloneWorkPermitFormView view, IAuthorized authorized)
        {
            this.view = view;
            this.authorized = authorized;
            userContext = ClientSession.GetUserContext();
        }

        public void HandleFormLoad(object sender, EventArgs args)
        {
            cloneFrom = view.OriginalWorkPermit;
            view.WorkPermitNumber = cloneFrom.PermitNumber;

            view.ShowCommunicationMethod = userContext.Site.Id == Site.SARNIA_ID;
            view.ShowAsbestos = userContext.Site.Id == Site.SARNIA_ID;
            view.ShowTools = userContext.Site.Id == Site.DENVER_ID;
            view.ShowRadiation = userContext.Site.Id == Site.DENVER_ID;

            //ayman USPipeline workpermit
            if (userContext.Site.Id == Site.USPipeline_ID)
            {
                view.ShowTools = userContext.Site.Id == Site.USPipeline_ID;
                view.ShowRadiation = userContext.Site.Id == Site.USPipeline_ID;
            }
            //mangesh uspipelinbe to selc
            if (userContext.Site.Id == Site.SELC_ID)
            {
                view.ShowTools = userContext.Site.Id == Site.SELC_ID;
                view.ShowRadiation = userContext.Site.Id == Site.SELC_ID;
            }

            PerformActionBasedOnSecurity(EnableAllowedSections);
            PerformActionBasedOnSecurity(SelectAllowedSections);
        }

        public void HandleCreateButtonClick(object sender, EventArgs args)
        {
            view.ClonedWorkPermit = CreateClone();
        }

        public WorkPermit CreateClone()
        {
            User user = userContext.User;
            UserShift currentShift = userContext.UserShift;

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            WorkPermit clone = new WorkPermit(userContext.Site);
            clone.InitializeWithSensibleDefaults(new UserSpecifiedCraftOrTrade(string.Empty),
                                                   user, !userContext.Role.IsWorkPermitNonOperationsRole, Clock.Now, siteConfiguration, currentShift, SiteSpecificHandlerFactory.GetDateTimeHandler(userContext.Site));

            if (view.ClonePermitTypeAttributes)
            {
                clone.WorkPermitType = cloneFrom.WorkPermitType;
                clone.WorkPermitTypeClassification = cloneFrom.WorkPermitTypeClassification;
                clone.Attributes = cloneFrom.Attributes.Copy();
            }

            if (view.CloneAdditionalForms)
                clone.AdditionItemsRequired = cloneFrom.AdditionItemsRequired.Copy();

            if (view.CloneLocationJobSpecifics)
                clone.Specifics = cloneFrom.Specifics.Copy(!view.ShowCommunicationMethod, clone.StartDateTime, clone.EndDateTime);

            if (view.CloneTools)
                clone.Tools = cloneFrom.Tools.Copy();

            if (view.CloneEquipmentPreparationCondition)
                clone.EquipmentPreparationCondition = cloneFrom.EquipmentPreparationCondition.Copy();

            if (view.CloneJobWorksitePreparation)
                clone.JobWorksitePreparation = cloneFrom.JobWorksitePreparation.Copy();

            if (view.CloneCommunicationMethod)
                clone.CommunicationMethod = cloneFrom.CommunicationMethod.Copy();

            if (view.CloneRadiationInformation)
                clone.RadiationInformation = cloneFrom.RadiationInformation.Copy();

            if (view.CloneAsbestos)
                clone.Asbestos = cloneFrom.Asbestos.Copy();

            if (view.CloneFireConfinedSpaceRequirements)
                clone.FireConfinedSpaceRequirements = cloneFrom.FireConfinedSpaceRequirements.Copy();

            if (view.CloneRespiratoryProtectionRequirements)
                clone.RespiratoryProtectionRequirements = cloneFrom.RespiratoryProtectionRequirements.Copy();

            if (view.CloneSpecialPPERequirements)
                clone.SpecialProtectionRequirements = cloneFrom.SpecialProtectionRequirements.Copy();

            if (view.CloneSpecialPrecautionsOrConsiderations)
                clone.SpecialPrecautionsOrConsiderations = cloneFrom.SpecialPrecautionsOrConsiderations;

            if (view.CloneGasTests)
                clone.GasTests = cloneFrom.GasTests.Copy();

            if (view.CloneNotificationAuthorization)
                cloneFrom.CopyNotificationAuthorizationTo(clone);

            if (view.CloneMiscellaneous)
                clone.DocumentLinks = cloneFrom.CloneDocumentLinksWithoutIds();

            // We have removed various fields from the Denver permits. So if someone clones an old permit that has those fields filled out, we want to remove them
            // from the new permit.
            if (userContext.IsDenverSite || userContext.IsUSPipelineSite)           //ayman USPipeline workpermit
            {
                clone.WorkPermitTypeClassification = null;                
                clone.EquipmentPreparationCondition.IsOutOfService = null;

                clone.EquipmentPreparationCondition.InServiceComments = null;
                clone.EquipmentPreparationCondition.NoElectricalTestBumpComments = null;
                clone.EquipmentPreparationCondition.StillContainsResidualComments = null;
                clone.EquipmentPreparationCondition.LeakingValvesComments = null;
                clone.JobWorksitePreparation.FlowRequiredComments = null;
                clone.JobWorksitePreparation.BondingGroundingNotRequiredComments = null;
                clone.JobWorksitePreparation.SurroundingConditionsAffectAreaComments = null;

                clone.Attributes.IsVehicleEntry = false;
            }

            return clone;
        }

        public void SelectAllSections(object sender, EventArgs e)
        {
            PerformActionBasedOnSecurity(SelectAllowedSections);
        }

        public void DeselectAllSections(object sender, EventArgs e)
        {
            SelectAllowedSections(false, false);
        }

        private void PerformActionBasedOnSecurity(WorkPermitSectionAction performAction)
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            bool cloneWithSomeRestrictions = authorized.ToCloneWorkPermitWithSomeRestrictions(userRoleElements);
            bool cloneWithNoRestriction = authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements);

            if (!cloneWithNoRestriction && !cloneWithSomeRestrictions)
            {
                throw new ApplicationException("User has no permission to clone work permits.");
            }
            if (cloneWithNoRestriction && cloneWithSomeRestrictions)
            {
                throw new ApplicationException("Cannot have both restriction and no restrictions at the same time");
            }

            performAction(true, cloneWithNoRestriction);
        }

        private void EnableAllowedSections(bool basicSectionsEnabled, bool restrictedSectionsEnabled)
        {
            view.ClonePermitTypeAttributesEnabled = basicSectionsEnabled;
            view.CloneAdditionalFormsEnabled = basicSectionsEnabled;
            view.CloneLocationJobSpecificsEnabled = basicSectionsEnabled;
            view.CloneCommunicationMethodEnabled = basicSectionsEnabled;
            view.CloneToolsEnabled = basicSectionsEnabled;
            view.CloneFireConfinedSpaceRequirementsEnabled = basicSectionsEnabled;
            view.CloneRespiratoryProtectionRequirementsEnabled = basicSectionsEnabled;
            view.CloneSpecialPPERequirementsEnabled = basicSectionsEnabled;
            view.CloneSpecialPrecautionsOrConsiderationsEnabled = basicSectionsEnabled;
            view.CloneNotificationAuthorizationEnabled = basicSectionsEnabled;
            view.CloneMiscellaneousEnabled = basicSectionsEnabled;
            view.CloneEquipmentPreparationConditionEnabled = restrictedSectionsEnabled;
            view.CloneJobWorksitePreparationEnabled = restrictedSectionsEnabled;
            view.CloneRadiationInformationEnabled = restrictedSectionsEnabled;
            view.CloneAsbestosEnabled = restrictedSectionsEnabled;
            view.CloneGasTestsEnabled = restrictedSectionsEnabled;
        }

        private void SelectAllowedSections(bool basicSectionsAllowed, bool restrictedSectionsAllowed)
        {
            view.ClonePermitTypeAttributes = basicSectionsAllowed;
            view.CloneAdditionalForms = basicSectionsAllowed;
            view.CloneLocationJobSpecifics = basicSectionsAllowed;
            view.CloneCommunicationMethod = basicSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID;

            //ayman USPipeline workpermit
            if (view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.DENVER_ID)
            view.CloneTools = basicSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.DENVER_ID;

            if (view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID)
                view.CloneTools = basicSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.USPipeline_ID;

            //mangesh uspipeline to selc
            if (view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.SELC_ID) 
                view.CloneTools = basicSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.SELC_ID;

            view.CloneFireConfinedSpaceRequirements = basicSectionsAllowed;
            view.CloneRespiratoryProtectionRequirements = basicSectionsAllowed;
            view.CloneSpecialPPERequirements = basicSectionsAllowed;
            view.CloneSpecialPrecautionsOrConsiderations = basicSectionsAllowed;
            view.CloneNotificationAuthorization = basicSectionsAllowed;
            view.CloneMiscellaneous = basicSectionsAllowed;

            view.CloneEquipmentPreparationCondition = restrictedSectionsAllowed;
            view.CloneJobWorksitePreparation = restrictedSectionsAllowed;

            if(view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.DENVER_ID)
            view.CloneRadiationInformation = restrictedSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.DENVER_ID;

            if (view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID)
                view.CloneRadiationInformation = restrictedSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.USPipeline_ID;

            //mangesh uspipeline to selc
            if (view.OriginalWorkPermit.FunctionalLocation.Site.Id == Site.SELC_ID)
                view.CloneRadiationInformation = restrictedSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.SELC_ID;

            view.CloneAsbestos = restrictedSectionsAllowed && ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID;
            view.CloneGasTests = restrictedSectionsAllowed;
        }
    }
}