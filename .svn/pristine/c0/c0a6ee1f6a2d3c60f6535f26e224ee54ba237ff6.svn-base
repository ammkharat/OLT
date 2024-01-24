using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CopyWorkPermitFormPresenter
    {               
        private const string NO_PERMISSION = "User has no permission to copy work permits.";

        private const string CONFLICTING_PERMISSIONS =
            "Cannot have both some restrictions and no restrictions at the same time";

        private readonly ICopyWorkPermitFormView view;
        private readonly IAuthorized authorized;
        private readonly WorkPermit sourcePermit;
        private readonly IWorkPermitCopyDestinationFormView workPermitCopyDestinationFormView;

        private readonly IObjectLockingService objectLockingService;
        private readonly IWorkPermitService workPermitService;

        private UserContext userContext;

        public CopyWorkPermitFormPresenter(ICopyWorkPermitFormView view, WorkPermit sourcePermit)
            : this(view, new WorkPermitCopyDestinationForm(), new Authorized(), sourcePermit)
        {
        }

        public CopyWorkPermitFormPresenter(
            ICopyWorkPermitFormView view, 
            IWorkPermitCopyDestinationFormView workPermitCopyDestinationFormView, 
            IAuthorized authorized, 
            WorkPermit sourcePermit) :
            this(
                view, 
                workPermitCopyDestinationFormView,
                authorized, 
                sourcePermit, 
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<IWorkPermitService>())
        {                        
        }

        public CopyWorkPermitFormPresenter(
            ICopyWorkPermitFormView view, 
            IWorkPermitCopyDestinationFormView workPermitCopyDestinationFormView, 
            IAuthorized authorized, 
            WorkPermit sourcePermit,
            IObjectLockingService objectLockingService,
            IWorkPermitService workPermitService)
        {
            this.view = view;
            this.sourcePermit = sourcePermit;
            this.authorized = authorized;

            this.workPermitCopyDestinationFormView = workPermitCopyDestinationFormView;
            userContext = ClientSession.GetUserContext();

            this.objectLockingService = objectLockingService;
            this.workPermitService = workPermitService;

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.LoadView += LoadView;
            view.Copy += CopySelectedSections;
            view.Cancel += Cancel;
            view.SelectAllSections += SelectAllSections;
            view.DeselectAllSections += DeselectAllSections;
        }

        public void LoadView(object sender, EventArgs e)
        {
            view.WorkPermitNumber = sourcePermit.PermitNumber;
            view.ShowCommunicationMethod = userContext.SiteId == Site.SARNIA_ID;
            view.ShowAsbestos = userContext.SiteId == Site.SARNIA_ID;
            view.ShowTools = userContext.SiteId == Site.DENVER_ID;
            view.ShowRadiation = userContext.SiteId == Site.DENVER_ID;

            PerformActionBasedOnSecurity(EnableAllowedSections);
            PerformActionBasedOnSecurity(SelectAllowedSections);
        }

        public void Cancel(object sender, EventArgs e)
        {
            if (view.ConfirmCancelDialog())
            {
                view.CloseView();
            }
        }
        
        public void CopySelectedSections(object sender, EventArgs e)
        {
            var sectionsToCopy = new List<WorkPermitSection>();

            if (view.ToolsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.Tools);
            }
            if (view.EquipmentPreparationConditionChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.EquipmentPreparationCondition);
            }
            if (view.JobWorksitePreparationChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.JobWorksitePreparation);
            }
            if (view.CommunicationMethodChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.CommunicationMethod);
            }
            if (view.RadiationInformationChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.RadiationInformation);
            }
            if (view.AsbestosChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.Asbestos);
            }
            if (view.FireConfinedSpaceRequirementsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.FireConfinedSpaceRequirements);
            }
            if (view.RespiratoryProtectionRequirementsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.RespiratoryProtectionRequirements);
            }
            if (view.SpecialPPERequirementsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.SpecialPPERequirements);
            }
            if (view.SpecialPrecautionsOrConsiderationsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.SpecialPrecautionsOrConsiderations);
            }
            if (view.GasTestsChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.GasTests);
            }
            if (view.NotificationAuthorizationChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.NotificationAuthorization);
            }
            if (view.MiscellaneousChecked)
            {
                sectionsToCopy.Add(WorkPermitSection.Miscellaneous);
            }
            
            if (sectionsToCopy.Count == 0)
            {
                view.ShowDialog(
                    StringResources.CopyWorkPermitFormNoSectionSelectedMessageBoxText,
                    StringResources.CopyWorkPermitFormNoSectionSelectedMessageBoxCaption);
                return;
            }
              
            // Present new view for picking what work permits to copy these sections to
            new WorkPermitCopyDestinationFormPresenter(
                workPermitCopyDestinationFormView, sourcePermit, sectionsToCopy, workPermitService, objectLockingService, new Authorized());
            workPermitCopyDestinationFormView.ShowDialog(view as Form);
            
            // Close the current view:
            view.CloseView();
        }

        public void SelectAllSections(object sender, EventArgs e)
        {
            PerformActionBasedOnSecurity(SelectAllowedSections);
        }

        public void DeselectAllSections(object sender, EventArgs e)
        {
            SelectAllowedSections(false, false);
        }

        private void PerformActionBasedOnSecurity(WorkPermitSectionAction performSecurityAction)
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            bool copyWithSomeRestrictions = authorized.ToCopyWorkPermitWithSomeRestrictions(userRoleElements);
            bool copyWithNoRestrictions = authorized.ToCopyWorkPermitWithNoRestriction(userRoleElements);

            if (copyWithNoRestrictions == false && copyWithSomeRestrictions == false)
            {
                throw new OLTException(NO_PERMISSION);
            }
            if (copyWithNoRestrictions && copyWithSomeRestrictions)
            {
                throw new OLTException(CONFLICTING_PERMISSIONS);
            }

            bool authorizedForSpecialSections = copyWithNoRestrictions;
            performSecurityAction(true, authorizedForSpecialSections);
        }

        private void EnableAllowedSections(bool basicSectionsEnabled, bool restrictedSectionsEnabled)
        {
            view.ToolsEnabled = basicSectionsEnabled;
            view.FireConfinedSpaceRequirementsEnabled = basicSectionsEnabled;
            view.RespiratoryProtectionRequirementsEnabled = basicSectionsEnabled;
            view.SpecialPPERequirementsEnabled = basicSectionsEnabled;
            view.SpecialPrecautionsOrConsiderationsEnabled = basicSectionsEnabled;
            view.NotificationAuthorizationEnabled = basicSectionsEnabled;
            view.MiscellaneousEnabled = basicSectionsEnabled;
            view.CommunicationMethodEnabled = basicSectionsEnabled;

            view.EquipmentPreparationConditionEnabled = restrictedSectionsEnabled;
            view.JobWorksitePreparationEnabled = restrictedSectionsEnabled;
            view.RadiationInformationEnabled = restrictedSectionsEnabled;
            view.AsbestosEnabled = restrictedSectionsEnabled;
            view.GasTestsEnabled = restrictedSectionsEnabled;
        }

        private void SelectAllowedSections(bool basicSectionsChecked, bool restrictedSectionsChecked)
        {
            view.FireConfinedSpaceRequirementsChecked = basicSectionsChecked;
            view.RespiratoryProtectionRequirementsChecked = basicSectionsChecked;
            view.SpecialPPERequirementsChecked = basicSectionsChecked;
            view.SpecialPrecautionsOrConsiderationsChecked = basicSectionsChecked;
            view.NotificationAuthorizationChecked = basicSectionsChecked;
            view.MiscellaneousChecked = basicSectionsChecked;
            view.CommunicationMethodChecked = basicSectionsChecked && userContext.SiteId == Site.SARNIA_ID;
            view.ToolsChecked = basicSectionsChecked && userContext.SiteId == Site.DENVER_ID;

            view.EquipmentPreparationConditionChecked = restrictedSectionsChecked;
            view.JobWorksitePreparationChecked = restrictedSectionsChecked;
            view.RadiationInformationChecked = restrictedSectionsChecked && userContext.SiteId == Site.DENVER_ID;
            view.AsbestosChecked = restrictedSectionsChecked && userContext.SiteId == Site.SARNIA_ID;
            view.GasTestsChecked = restrictedSectionsChecked;
        }

       
    }
}