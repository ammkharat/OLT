using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Validation
{
    public class WorkPermitSectionsValidator : AbstractNewWorkPermitValidator
    {
        private readonly IAuthorized authorized;

        public WorkPermitSectionsValidator(WorkPermit workPermit, IAuthorized authorized)
            : base(workPermit)
        {
            this.authorized = authorized;
        }

        protected override List<IValidation<WorkPermit>> BuildValidationRules()
        {
            bool shouldFullyValidateBasedOnUser = authorized.ToFullyValidateWorkPermit(ClientSession.GetUserContext().UserRoleElements);

            return shouldFullyValidateBasedOnUser ? BuildRules() : new List<IValidation<WorkPermit>> (0);
        }

        private static List<IValidation<WorkPermit>> BuildRules()
        {
            var rules = new List<IValidation<WorkPermit>>();

            if (ClientSession.GetUserContext().SiteId == Site.DENVER_ID)
            {
                rules.AddRange(BuildDenverRules());
                rules.AddRange(BuildIsRadiationSealedRules());
            }
            else if (ClientSession.GetUserContext().SiteId == Site.SARNIA_ID)
            {
                rules.AddRange(BuildSarniaRules());
            }
            else if (ClientSession.GetUserContext().SiteId == Site.USPipeline_ID)      //ayman USPipeline workpermit
            {
                rules.AddRange(BuildUSPipelineRules());
                rules.AddRange(BuildIsRadiationSealedRules());
            }
            else if (ClientSession.GetUserContext().SiteId == Site.SELC_ID)      //mangesh uspipeline to selc
            {
                rules.AddRange(BuildUSPipelineRules());
                rules.AddRange(BuildIsRadiationSealedRules());
            }

            rules.AddRange(BuildIsHotWorkPermitRules());
            rules.AddRange(BuildIsConfinedSpaceEntryRules());
            rules.AddRange(BuildIsSystemEntryRules());
            rules.AddRange(BuildIsBreathingAirOrSCBARules());
            rules.AddRange(BuildIsCriticalLiftRules());
            rules.AddRange(BuildIsVehicleEntryRules());
            rules.AddRange(BuilIsExcavationRules());
            rules.AddRange(BuilIsHotTapRules());
            rules.AddRange(BuildIsAsbestosRules());
            rules.AddRange(BuildIsBurnOrOpenFlameRules());
            return rules;

        }

        private static IEnumerable<IValidation<WorkPermit>> BuildDenverRules()
        {            
            return new List<IValidation<WorkPermit>>
                       {
                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsVehicleEntry,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.FireConfinedSpaceRequirements,
                                                      wp => !wp.FireConfinedSpaceRequirements.IsNotApplicable,
                                                      wp => !wp.FireConfinedSpaceRequirements.HasData())
                       };
        }

        //ayman USPipeline workpermit
        private static IEnumerable<IValidation<WorkPermit>> BuildUSPipelineRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsVehicleEntry,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.FireConfinedSpaceRequirements,
                                                      wp => !wp.FireConfinedSpaceRequirements.IsNotApplicable,
                                                      wp => !wp.FireConfinedSpaceRequirements.HasData())
                       };
        }

        private static IEnumerable<IValidation<WorkPermit>> BuildSarniaRules()
        {
            return new List<IValidation<WorkPermit>>
                {
                    BuildRequiredForApprovalValidator(WorkPermitSection.FireConfinedSpaceRequirements,
                                                      wp => WorkPermitType.HOT.Equals(wp.WorkPermitType),
                                                      wp => !wp.FireConfinedSpaceRequirements.HasData())
                };
        }

        private static List<IValidation<WorkPermit>> BuildIsHotWorkPermitRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.GasTests,
                                                             wp => WorkPermitType.HOT.Equals(wp.WorkPermitType),
                                                             wp => !wp.GasTests.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsConfinedSpaceEntryRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                             wp => wp.Attributes.IsConfinedSpaceEntry,
                                                             wp => !wp.AdditionItemsRequired.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.FireConfinedSpaceRequirements,
                                                             wp => wp.Attributes.IsConfinedSpaceEntry,
                                                             wp => !wp.FireConfinedSpaceRequirements.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.GasTests,
                                                             wp => wp.Attributes.IsConfinedSpaceEntry,
                                                             wp => !wp.GasTests.HasData())
                       };
        }
        private static List<IValidation<WorkPermit>> BuildIsSystemEntryRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsSystemEntry,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildWarningValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                 wp => wp.Attributes.IsSystemEntry,
                                                 wp => !wp.RespiratoryProtectionRequirements.HasData()),
                           BuildWarningValidator(WorkPermitSection.GasTests,
                                                 wp => wp.Attributes.IsSystemEntry,
                                                 wp => !wp.GasTests.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsBreathingAirOrSCBARules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                             wp => wp.Attributes.IsBreathingAirOrSCBA,
                                                             wp => !wp.RespiratoryProtectionRequirements.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsCriticalLiftRules()
        {
            return new List<IValidation<WorkPermit>>
                       {

                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsCriticalLift,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildWarningValidator(WorkPermitSection.GasTests,
                                                 wp => wp.Attributes.IsCriticalLift,
                                                 wp => !wp.GasTests.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsVehicleEntryRules()
        {
            return new List<IValidation<WorkPermit>>
                       {

                           BuildWarningValidator(WorkPermitSection.GasTests,
                                                 wp => wp.Attributes.IsVehicleEntry,
                                                 wp => !wp.GasTests.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuilIsExcavationRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                             wp => wp.Attributes.IsExcavation,
                                                             wp => !wp.AdditionItemsRequired.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuilIsHotTapRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.AdditionalForms,
                                                             wp => wp.Attributes.IsHotTap,
                                                             wp => !wp.AdditionItemsRequired.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.GasTests,
                                                             wp => wp.Attributes.IsHotTap,
                                                             wp => !wp.GasTests.HasData())

                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsAsbestosRules()
        {
            return new List<IValidation<WorkPermit>>
                       {

                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsAsbestos,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildWarningValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                 wp => wp.Attributes.IsAsbestos,
                                                 wp => !wp.RespiratoryProtectionRequirements.HasData()),
                           BuildWarningValidator(WorkPermitSection.SpecialPPERequirements,
                                                 wp => wp.Attributes.IsAsbestos,
                                                 wp => !wp.SpecialProtectionRequirements.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsRadiationSealedRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForApprovalValidator(WorkPermitSection.RadiationInformation,
                                                             wp => wp.Attributes.IsRadiationSealed,
                                                             wp => !wp.RadiationInformation.HasData())
                       };
        }

        private static List<IValidation<WorkPermit>> BuildIsBurnOrOpenFlameRules()
        {
            return new List<IValidation<WorkPermit>>
                       {

                           BuildWarningValidator(WorkPermitSection.AdditionalForms,
                                                 wp => wp.Attributes.IsBurnOrOpenFlame,
                                                 wp => !wp.AdditionItemsRequired.HasData()),
                           BuildWarningValidator(WorkPermitSection.RespiratoryProtectionRequirements,
                                                 wp => wp.Attributes.IsBurnOrOpenFlame,
                                                 wp => !wp.RespiratoryProtectionRequirements.HasData()),
                           BuildRequiredForApprovalValidator(WorkPermitSection.GasTests,
                                                 wp => wp.Attributes.IsBurnOrOpenFlame,
                                                 wp => !wp.GasTests.HasData())
                       };
        }
    }
}