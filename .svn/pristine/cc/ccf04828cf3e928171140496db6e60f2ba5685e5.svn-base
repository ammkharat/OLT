using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitRequestEdmontonFixture
    {
        public static PermitRequestEdmonton GetPermitRequest(User user)
        {            
            DateTime currentTimeAtSite = new DateTime(2012, 1, 18);
            WorkPermitEdmontonType permitType = WorkPermitEdmontonType.COLD_WORK;

            DateTime startDateTime = new DateTime(2012, 1, 18, 13, 0, 0);
            Date endDate = new Date(2012, 1, 18);

            string workOrderNumber = "1234-5";
            string operationNumber = "42";
            string subOperationNumber = "123";

            string description = "Description";
            string sapDescription = "SAP Description";
            string company = "Company";
            
            DataSource dataSource = DataSource.SAP;
            User lastImportedByUser = user;
            DateTime? lastImportedDateTime = currentTimeAtSite;
            User lastSubmittedByUser = null;
            DateTime? lastSubmittedDateTime = null;
            User createdBy = user;
            DateTime createdDateTime = currentTimeAtSite;
            User lastModifiedBy = user;
            DateTime lastModifiedDateTime = currentTimeAtSite;

            PermitRequestEdmonton request = new PermitRequestEdmonton(
                null,
                endDate,               
                description,
                sapDescription,
                company,
                dataSource,
                lastImportedByUser,
                lastImportedDateTime,
                lastSubmittedByUser,
                lastSubmittedDateTime,
                createdBy,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime);

            request.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);
            request.WorkPermitType = permitType;
            request.RequestedStartTimeDay = new Time(startDateTime);
            request.RequestedStartDate = new Date(startDateTime);            

            return request;
        }
        
        public static PermitRequestEdmonton GetEmptyPermitRequest()
        {
            PermitRequestEdmonton request = new PermitRequestEdmonton(
                null, null, null, null, null, null, null, null, null, null, null, DateTime.Now, null, DateTime.Now);

            return request;
        }

        public static PermitRequestEdmonton CreateForInsert(DataSource dataSource, FunctionalLocation floc, WorkPermitEdmontonGroup group)
        {
            return CreateForInsert(dataSource, floc, group, true);
        }

        public static PermitRequestEdmonton CreateForInsert(DataSource dataSource, FunctionalLocation floc, WorkPermitEdmontonGroup group, bool includeAWorkOrderSource)
        {
            PermitRequestEdmonton permit = new PermitRequestEdmonton(
                null,                               
                new Date(2012, 1, 2),                                                    
                "permit request description",
                "permit request description (SAP)",
                "Black & McDonald",
                dataSource,
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite(),
                new DateTime(2001, 10, 11),
                UserFixture.CreateAdmin(),
                new DateTime(2001, 12, 13),
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2002, 6, 7),
                UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                new DateTime(2002, 8, 9));

            //permit.AddWorkOrderSource("WO#12345", "020", "0110");
            if (includeAWorkOrderSource)
            {
                permit.AddWorkOrderSource("WOnumber", "OPNU", "SUBO");
            }

            permit.SAPWorkCentre = "SAPWRKCENT";

            permit.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permit.Priority = Priority.Normal;
            
            permit.WorkPermitType = WorkPermitEdmontonType.COLD_WORK;
            permit.FunctionalLocation = floc;
            permit.AreaLabel = AreaLabelFixture.CreateWithExistingId();

            permit.RequestedStartDate = new Date(2012, 1, 2);
            permit.RequestedStartTimeDay = new Time(1, 2, 3);
            permit.RequestedStartTimeNight = new Time(4, 5, 6);

            permit.IssuedToSuncor = true;
            permit.Company = "company";
            permit.Occupation = "occupation";
            permit.NumberOfWorkers = 42;
            permit.Group = group;
            permit.Location = "location";
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());

            permit.OtherAreasAndOrUnitsAffectedArea = "area";
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = "person";

            permit.AlkylationEntryClassOfClothing = "Class of Clothing";
            permit.FlarePitEntryType = "A";
            permit.ConfinedSpaceCardNumber = "CardNum";
            permit.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
            permit.SpecialWorkFormNumber = "SWFN";
            permit.SpecialWorkType = EdmontonPermitSpecialWorkType.HotTapping;
            permit.SpecialWorkName = "Hot Tapping";

            permit.VehicleEntryTotal = 43;
            permit.VehicleEntryType = "VET";
            permit.RescuePlanFormNumber = "RPFN";

            permit.AlkylationEntry = true;
            permit.FlarePitEntry = true;
            permit.ConfinedSpace = true;
            permit.SpecialWork = true;
            permit.VehicleEntry = true;
            permit.RescuePlan = true;

            permit.GN6 = true;
            permit.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            permit.GN7 = true;
            permit.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            permit.GN59 = true;
            permit.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            permit.GN24 = true;
            permit.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            permit.GN75A = false; 
            permit.FormGN75A = null;
            permit.GN11 = WorkPermitSafetyFormState.NotApplicable;
            permit.GN24_Deprecated = WorkPermitSafetyFormState.Required;
            permit.GN27 = WorkPermitSafetyFormState.Approved;
            permit.GN75_Deprecated = WorkPermitSafetyFormState.Required;
            
            permit.HazardsAndOrRequirements = "HazardsAndOrReq";
            
            permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
            permit.FaceShield = true;
            permit.Goggles = true;
            permit.RubberBoots = true;
            permit.RubberGloves = true;
            permit.RubberSuit = true;
            permit.SafetyHarnessLifeline = true;
            permit.HighVoltagePPE = true;
            permit.Other1 = "other1value";
            permit.EquipmentGrounded = true;
            permit.FireBlanket = true;
            permit.FireExtinguisher = true;
            permit.FireMonitorManned = true;
            permit.FireWatch = true;
            permit.SewersDrainsCovered = true;
            permit.SteamHose = true;
            permit.Other2 = "other2value";
            permit.AirPurifyingRespirator = true;
            permit.BreathingAirApparatus = true;
            permit.DustMask = true;
            permit.LifeSupportSystem = true;
            permit.SafetyWatch = true;
            permit.ContinuousGasMonitor = true;            
            permit.WorkersMonitorNumber = "WM1234";
            permit.BumpTestMonitorPriorToUse = true;
            permit.Other3 = "other3value";
            permit.AirMover = true;
            permit.BarriersSigns = true;            
            permit.RadioChannelNumber = "54.123";
            permit.AirHorn = true;
            permit.MechVentilationComfortOnly = true;
            permit.AsbestosMMCPrecautions = true;
            permit.Other4 = "Other4value";

            permit.DoNotMerge = true;
        
            return permit;
        }

        public static PermitRequestEdmonton CreateValidCompletePermitRequest()
        {
            return CreateValidCompletePermitRequest(DataSource.SAP);
        }

        public static PermitRequestEdmonton CreateValidCompletePermitRequest(DataSource dataSource)
        {
            WorkPermitEdmontonGroup workPermitEdmontonGroup = new WorkPermitEdmontonGroup(1, "Some Group", new List<long> { 1 }, 2, true);

            PermitRequestEdmonton permitRequest = CreateForInsert(dataSource, FunctionalLocationFixture.GetReal_ED1_A001_U007(), workPermitEdmontonGroup);
            permitRequest.GN6_Deprecated = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.GN24_Deprecated = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.FormGN24.MarkAsApproved(Clock.Now);
            permitRequest.FormGN59.MarkAsApproved(Clock.Now);
            permitRequest.FormGN6.MarkAsApproved(Clock.Now);
            permitRequest.FormGN7.MarkAsApproved(Clock.Now);

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
            validator.Validate();

            if (!PermitRequestCompletionStatus.Complete.Equals(validator.CompletionStatus))
            {
                throw new Exception("This fixture should create a complete Edmonton Permit Request for unit tests, but validation failed.");
            }

            return permitRequest;
        }

        public static WorkPermitEdmontonGroup GetP4Group()
        {
            return new WorkPermitEdmontonGroup(1, "Outage", new List<long> { 4 }, 4, false);
        }
    }
}