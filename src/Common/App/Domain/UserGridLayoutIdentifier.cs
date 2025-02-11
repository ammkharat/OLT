﻿using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class UserGridLayoutIdentifier : SimpleDomainObject
    {
        public static readonly UserGridLayoutIdentifier EdmontonRunningUnitWorkPermits = new UserGridLayoutIdentifier(
            0, "Running Unit Work Permits");

        public static readonly UserGridLayoutIdentifier EdmontonTurnaroundWorkPermits = new UserGridLayoutIdentifier(1,
            "Turnaround Work Permits");
        public static readonly UserGridLayoutIdentifier EdmontonTemplateorkPermits = new UserGridLayoutIdentifier(68, "Work Permit Templates"); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades


        public static readonly UserGridLayoutIdentifier EdmontonRunningUnitPermitRequests =
            new UserGridLayoutIdentifier(2, "Running Unit Permit Requests");

        public static readonly UserGridLayoutIdentifier EdmontonTurnaroundPermitRequests =
            new UserGridLayoutIdentifier(3, "Turnaround Permit Requests");

        public static readonly UserGridLayoutIdentifier ActionItemDefinitions = new UserGridLayoutIdentifier(4,
            "Action Item Definitions");

        public static readonly UserGridLayoutIdentifier ActionItems = new UserGridLayoutIdentifier(5, "Action Items");

        public static readonly UserGridLayoutIdentifier ActionItemsByAssignment = new UserGridLayoutIdentifier(6,
            "Action Items By Assignment");

        public static readonly UserGridLayoutIdentifier Logs = new UserGridLayoutIdentifier(7, "Logs");

        public static readonly UserGridLayoutIdentifier LogsByAssignment = new UserGridLayoutIdentifier(8,
            "Logs By Assignment");

        public static readonly UserGridLayoutIdentifier SummaryLogs = new UserGridLayoutIdentifier(9, "Summary Logs");

        public static readonly UserGridLayoutIdentifier DailyDirectives = new UserGridLayoutIdentifier(10,
            "Daily Directives");

        public static readonly UserGridLayoutIdentifier LogDefinitions = new UserGridLayoutIdentifier(11,
            "Log Definitions");

        public static readonly UserGridLayoutIdentifier OperatingEngineerLogs = new UserGridLayoutIdentifier(12,
            "Operating Engineer Logs");

        public static readonly UserGridLayoutIdentifier StandingOrders = new UserGridLayoutIdentifier(13,
            "Standing Orders");

        public static readonly UserGridLayoutIdentifier ShiftHandovers = new UserGridLayoutIdentifier(14,
            "Shift Handovers");

        public static readonly UserGridLayoutIdentifier ShiftHandoversByAssignment = new UserGridLayoutIdentifier(15,
            "Shift Handovers By Assignment");

        public static readonly UserGridLayoutIdentifier Forms = new UserGridLayoutIdentifier(16, "Forms");

        public static readonly UserGridLayoutIdentifier MontrealWorkPermits = new UserGridLayoutIdentifier(17,
            "Montreal Work Permits");

        public static readonly UserGridLayoutIdentifier ConfinedSpace = new UserGridLayoutIdentifier(18,
            "Confined Space");

        public static readonly UserGridLayoutIdentifier MontrealPermitRequests = new UserGridLayoutIdentifier(19,
            "Montreal Permit Requests");

        public static readonly UserGridLayoutIdentifier RestrictionDefinitions = new UserGridLayoutIdentifier(20,
            "Restriction Definitions");

        public static readonly UserGridLayoutIdentifier DeviationAlerts = new UserGridLayoutIdentifier(21,
            "DeviationAlerts");

        public static readonly UserGridLayoutIdentifier LabAlertDefinitions = new UserGridLayoutIdentifier(22,
            "Lab Alert Definitions");

        public static readonly UserGridLayoutIdentifier LabAlerts = new UserGridLayoutIdentifier(23, "Lab Alerts");
        public static readonly UserGridLayoutIdentifier CokerCards = new UserGridLayoutIdentifier(24, "Coker Cards");

        public static readonly UserGridLayoutIdentifier SAPNotifications = new UserGridLayoutIdentifier(25,
            "SAP Notifications");

        public static readonly UserGridLayoutIdentifier TargetDefinitions = new UserGridLayoutIdentifier(26,
            "Target Definitions");

        public static readonly UserGridLayoutIdentifier TargetAlerts = new UserGridLayoutIdentifier(27, "Target Alerts");

        public static readonly UserGridLayoutIdentifier WorkPermits = new UserGridLayoutIdentifier(28, "Work Permits");
            // Shared Sarnia and Denver

        public static readonly UserGridLayoutIdentifier WorkPermitsByAssignment = new UserGridLayoutIdentifier(29,
            "Work Permits by Assignment"); // Shared Sarnia and Denver

        public static readonly UserGridLayoutIdentifier WorkPermitsForToday = new UserGridLayoutIdentifier(30,
            "Work Permits for Today"); // Shared Sarnia and Denver        

        public static readonly UserGridLayoutIdentifier WorkPermitsTemplatePage = new UserGridLayoutIdentifier(67,
           "Work Permits Templates"); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

        public static readonly UserGridLayoutIdentifier LubesWorkPermits = new UserGridLayoutIdentifier(31,
            "Lubes Work Permits");

        public static readonly UserGridLayoutIdentifier LubesPermitRequests = new UserGridLayoutIdentifier(32,
            "Lubes Permit Requests");

        public static readonly UserGridLayoutIdentifier OilsandsTrainingForms = new UserGridLayoutIdentifier(33,
            "Oilsands Training Forms");

        public static readonly UserGridLayoutIdentifier FormGN7 = new UserGridLayoutIdentifier(34, "Edmonton GN7 Form");
        public static readonly UserGridLayoutIdentifier FormGN59 = new UserGridLayoutIdentifier(35, "Edmonton GN59 Form");
        public static readonly UserGridLayoutIdentifier FormOP14 = new UserGridLayoutIdentifier(36, "Edmonton OP14 Form");
        public static readonly UserGridLayoutIdentifier FormGN24 = new UserGridLayoutIdentifier(37, "Edmonton GN24 Form");
        public static readonly UserGridLayoutIdentifier FormGN6 = new UserGridLayoutIdentifier(38, "Edmonton GN6 Form");

        public static readonly UserGridLayoutIdentifier FormGN75A = new UserGridLayoutIdentifier(39,
            "Edmonton GN75A Form");

        public static readonly UserGridLayoutIdentifier FormGN75B = new UserGridLayoutIdentifier(40,
            "Edmonton GN75B Form");

        public static readonly UserGridLayoutIdentifier Directives = new UserGridLayoutIdentifier(41, "Directives");

        public static readonly UserGridLayoutIdentifier FormGN75BSelector = new UserGridLayoutIdentifier(42,
            "FormGN75BSelector");

        public static readonly UserGridLayoutIdentifier FormGN1 = new UserGridLayoutIdentifier(43, "Edmonton GN1 Form");

        public static readonly UserGridLayoutIdentifier OvertimeForm = new UserGridLayoutIdentifier(44,
            "Edmonton Overtime Form");

        public static readonly UserGridLayoutIdentifier OnPremisePersonnelSupervisorView =
            new UserGridLayoutIdentifier(45, "Edmonton On Premise Personnel Supervisor View");

        public static readonly UserGridLayoutIdentifier OnPremisePersonnelAuditView = new UserGridLayoutIdentifier(46,
            "Edmonton On Premise Personnel Audit View");

        public static readonly UserGridLayoutIdentifier FormLubesCsd = new UserGridLayoutIdentifier(47, "Lubes CSD Form");
        public static readonly UserGridLayoutIdentifier FormMontrealCsd = new UserGridLayoutIdentifier(48, "Montreal CSD Form");

        public static readonly UserGridLayoutIdentifier FormLubesAlarmDisable = new UserGridLayoutIdentifier(49, "Lubes Temporary Alarm Disable Form");
        public static readonly UserGridLayoutIdentifier ExcursionEvents = new UserGridLayoutIdentifier(50, "Excursion Events");
        public static readonly UserGridLayoutIdentifier PermitAssessment = new UserGridLayoutIdentifier(51, "Safe Work Permit Audit Questionnaire Form");
        public static readonly UserGridLayoutIdentifier DocumentSuggestion = new UserGridLayoutIdentifier(52, "Document Suggestion Form");
        public static readonly UserGridLayoutIdentifier ProcedureDeviation = new UserGridLayoutIdentifier(53, "Operating Procedure Deviation Form");

        //generic template - mangesh
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_OdourNoiseComplaint = new UserGridLayoutIdentifier(53, "Edmonton Odour Noise Complaint Form");
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_Deviation = new UserGridLayoutIdentifier(54, "Edmonton Letter of Exception Form"); //RITM0195885 - mangesh
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_RoadClosure = new UserGridLayoutIdentifier(55, "Edmonton Road Closure Form"); 
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_GN11GroundDisturbance = new UserGridLayoutIdentifier(56, "Edmonton GN11 Ground Disturbance Form"); 
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_GN27FreezePlug = new UserGridLayoutIdentifier(57, "Edmonton GN27 Freeze Plug Form");
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_HazardAssessment = new UserGridLayoutIdentifier(58, "Edmonton HO68 Plant 12 Minor HF Leak Form"); //RITM0195190 - mangesh

        public static readonly UserGridLayoutIdentifier FormGenericTemplate_NonEmergencyWaterSystemApproval = new UserGridLayoutIdentifier(66, "Edmonton Non-Emergency Water System Approval");

        public static readonly UserGridLayoutIdentifier FormMudsTemporaryInstallation = new UserGridLayoutIdentifier(59, "MUDS Temporary Installation Form"); //RITM0268131 - mangesh

        public static readonly UserGridLayoutIdentifier MudsWorkPermits = new UserGridLayoutIdentifier(60, "Muds Work Permits"); //RITM0301321 - mangesh
        public static readonly UserGridLayoutIdentifier MudsPermitRequests = new UserGridLayoutIdentifier(63,"Muds Permit Requests");

        //RITM0341710 mangesh
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_OilSample = new UserGridLayoutIdentifier(61, "Fort Hills 980E- AT 250HR Oil Sample/ inspection Form"); //RITM0341710 : Bug fix Vibhor added Fort Hills in place of Fort Hill
        public static readonly UserGridLayoutIdentifier FormGenericTemplate_DailyInspection = new UserGridLayoutIdentifier(62, "Fort Hills- AT 980E- AT Daily Inspection Form"); //RITM0341710 : Bug fix Vibhor added Fort Hills in place of Fort Hill

        public static readonly UserGridLayoutIdentifier Readings = new UserGridLayoutIdentifier(63, "Readings");         //ayman action item reading
        public static readonly UserGridLayoutIdentifier ReadingsByAssignment = new UserGridLayoutIdentifier(64,
    "Readings By Assignment");

        public static readonly UserGridLayoutIdentifier FortHillsRunningUnitPermitRequests =new UserGridLayoutIdentifier(60, "FortHills Permit Requests");
        public static readonly UserGridLayoutIdentifier FortHillsRunningUnitWorkPermits = new UserGridLayoutIdentifier(65, "FortHills Work Permits");
        public UserGridLayoutIdentifier(long id, string gridName) : base(id)
        {
            GridName = gridName;
        }

        public string GridName { get; private set; }

        public override string GetName()
        {
            return GridName;
        }
    }
}