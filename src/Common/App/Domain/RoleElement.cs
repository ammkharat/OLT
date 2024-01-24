using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class RoleElement : DomainObject
    {
        // action items
        public static RoleElement VIEW_ACTIONITEM_NAVIGATION = new RoleElement(210, "View Navigation - Action Items");
        public static RoleElement VIEW_ACTIONITEM_PRIORITIES = new RoleElement(218, "View Priorities - Action Items");
        public static RoleElement VIEW_ACTIONITEMDEFINITION = new RoleElement(1, "View Action Item Definition");
        public static RoleElement VIEW_FUTUREACTIONITEMS = new RoleElement(273, "View Future Action Items");
        public static RoleElement VIEW_ACTIONITEM = new RoleElement(39, "View Action Item");
        public static RoleElement APPROVE_ACTIONITEMDEFINITION = new RoleElement(2, "Approve Action Item Definition");
        public static RoleElement REJECT_ACTIONITEMDEFINITION = new RoleElement(3, "Reject Action Item Definition");
        public static RoleElement CREATE_ACTIONITEMDEFINITION = new RoleElement(4, "Create Action Item Definition");
        public static RoleElement EDIT_ACTIONITEMDEFINITION = new RoleElement(6, "Edit Action Item Definition");
        public static RoleElement DELETE_ACTIONITEMDEFINITION = new RoleElement(8, "Delete Action Item Definition");
        public static RoleElement COMMENT_ACTIONITEMDEFINITION = new RoleElement(10, "Comment Action Item Definition");
        public static RoleElement SET_OPERATIONAL_MODES = new RoleElement(272, "Set Operational Modes");
        public static RoleElement CONFIGURE_RESTRICTION_FLOCS_FOR_WORK_ASSIGNMENTS = new RoleElement(274, "Configure Restriction FLOCs for Work Assignments");

        public static RoleElement TOGGLE_ACTIONITEMDEFINITION_APPROVAL_REQUIRED = new RoleElement(11,
            "Toggle Approval Required for Action Item Definition");

        public static RoleElement RESPOND_ACTIONITEM = new RoleElement(40, "Respond to Action Item");

        // coker cards
        public static RoleElement VIEW_COKER_CARD = new RoleElement(149, "View Coker Card");
        public static RoleElement CREATE_COKER_CARD = new RoleElement(150, "Create Coker Card");
        public static RoleElement EDIT_COKER_CARD = new RoleElement(151, "Edit Coker Card");
        public static RoleElement DELETE_COKER_CARD = new RoleElement(152, "Delete Coker Card");

        // lab alerts
        public static RoleElement VIEW_LAB_ALERT_NAVIGATION = new RoleElement(215, "View Navigation - Lab Alerts");

        public static RoleElement VIEW_LAB_ALERT_DEFINITIONS_AND_LAB_ALERTS = new RoleElement(130,
            "View Lab Alert Definitions and Lab Alerts");

        public static RoleElement CREATE_LAB_ALERT_DEFINITION = new RoleElement(131, "Create Lab Alert Definition");
        public static RoleElement EDIT_LAB_ALERT_DEFINITION = new RoleElement(132, "Edit Lab Alert Definition");
        public static RoleElement DELETE_LAB_ALERT_DEFINITION = new RoleElement(133, "Delete Lab Alert Definition");
        public static RoleElement RESPOND_TO_LAB_ALERT = new RoleElement(134, "Respond To Lab Alert");

        // logs
        public static RoleElement VIEW_LOG_NAVIGATION = new RoleElement(212, "View Navigation - Logs");
        public static RoleElement VIEW_LOG = new RoleElement(33, "View Log");
        public static RoleElement VIEW_LOG_DEFINITION = new RoleElement(54, "View Log Definitions");
        public static RoleElement CREATE_LOG = new RoleElement(32, "Create Log");
        public static RoleElement EDIT_LOG = new RoleElement(34, "Edit Log");
        public static RoleElement DELETE_LOG = new RoleElement(35, "Delete Log");
        public static RoleElement REPLY_TO_LOG = new RoleElement(51, "Reply To Log");

        public static RoleElement EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG = new RoleElement(63,
            "Edit Log Flagged as Operating Engineer Log");

        public static RoleElement DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG = new RoleElement(64,
            "Delete Log Flagged as Operating Engineer Log");

        public static RoleElement CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG = new RoleElement(65,
            "Cancel Log Flagged as Operating Engineer Log");

        public static RoleElement CANCEL_LOG = new RoleElement(176, "Cancel Log");
        public static RoleElement CREATE_LOG_DEFINITION = new RoleElement(187, "Create Log Definition");
        public static RoleElement EDIT_LOG_DEFINITION = new RoleElement(188, "Edit Log Definition");
        public static RoleElement COPY_LOG = new RoleElement(235, "Copy Log");
        public static RoleElement ADD_SHIFT_INFORMATION = new RoleElement(236, "Add Shift Information");

        // logs - directives
        public static RoleElement VIEW_LOG_BASED_DIRECTIVES_PRIORITIES = new RoleElement(220, "View Priorities - Log Based Directives");
        public static RoleElement VIEW_LOG_BASED_DIRECTIVES = new RoleElement(96, "View Log Based Directives");
        public static RoleElement CREATE_LOG_BASED_DIRECTIVES = new RoleElement(97, "Create Log Based Directives");
        public static RoleElement EDIT_LOG_BASED_DIRECTIVES = new RoleElement(98, "Edit Log Based Directives");
        public static RoleElement DELETE_LOG_BASED_DIRECTIVES = new RoleElement(99, "Delete Log Based Directives");

        public static RoleElement VIEW_STANDING_ORDERS = new RoleElement(178, "View Standing Orders");
        public static RoleElement CANCEL_STANDING_ORDERS = new RoleElement(177, "Cancel Standing Orders");

        // "new" directives
        public static RoleElement VIEW_DIRECTIVE_NAVIGATION = new RoleElement(231, "View Navigation - Directives");
        public static RoleElement VIEW_DIRECTIVES_FUTURE = new RoleElement(232, "View Directives - Future");

        public static RoleElement VIEW_NEW_DIRECTIVES_PRIORITIES = new RoleElement(267, "View Priorities - Directives");
        public static RoleElement VIEW_NEW_DIRECTIVES = new RoleElement(268, "View Directives");
        public static RoleElement CREATE_NEW_DIRECTIVES = new RoleElement(269, "Create Directives");
        public static RoleElement EDIT_NEW_DIRECTIVES = new RoleElement(270, "Edit Directives");
        public static RoleElement DELETE_NEW_DIRECTIVES = new RoleElement(271, "Delete Directives");

        // logs - notification
        public static RoleElement VIEW_SAP_NOTIFICATIONS = new RoleElement(47, "View SAP Notifications");
        public static RoleElement PROCESS_SAP_NOTIFICATIONS = new RoleElement(48, "Process SAP Notifications");

        // logs - summary logs
        public static RoleElement VIEW_SUMMARY_LOG = new RoleElement(88, "View Summary Logs");
        public static RoleElement CREATE_SUMMARY_LOG = new RoleElement(89, "Create Summary Logs");
        public static RoleElement EDIT_SUMMARY_LOG = new RoleElement(92, "Edit Summary Logs");
        public static RoleElement DELETE_SUMMARY_LOG = new RoleElement(95, "Delete Summary Logs");
        public static RoleElement EDIT_DOR_COMMENTS = new RoleElement(126, "Edit DOR Comments");

        // restriction reporting
        public static RoleElement VIEW_RESTRICTION_NAVIGATION = new RoleElement(216, "View Navigation - Restrictions");
        public static RoleElement VIEW_RESTRICTION_REPORTING = new RoleElement(100, "View Restriction Reporting");
        public static RoleElement CREATE_RESTRICTION_DEFINITION = new RoleElement(101, "Create Restriction Definition");
        public static RoleElement DELETE_RESTRICTION_DEFINITION = new RoleElement(102, "Delete Restriction Definition");
        public static RoleElement EDIT_RESTRICTION_DEFINITION = new RoleElement(103, "Edit Restriction Definition");
        public static RoleElement RESPOND_TO_DEVIATION_IN_SHIFT = new RoleElement(104, "Respond to Deviation In Shift");

        public static RoleElement RESPOND_TO_DEVIATION_OUT_OF_SHIFT = new RoleElement(110,
            "Respond to Deviation Out of Shift");

        public static RoleElement EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT = new RoleElement(105,
            "Edit Deviation Response For Alert In Shift");

        public static RoleElement EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT = new RoleElement(106,
            "Edit Deviation Response For Alert Out of Shift");

        public static RoleElement EDIT_DEVIATION_ALERT_COMMENT = new RoleElement(128, "Edit Deviation Alert Comment");

        // shift handovers
        public static RoleElement VIEW_SHIFT_HANDOVER_NAVIGATION = new RoleElement(214,
            "View Navigation - Shift Handovers");

        public static RoleElement VIEW_SHIFT_HANDOVER_PRIORITIES = new RoleElement(223,
            "View Priorities - Shift Handovers");

        public static RoleElement VIEW_SHIFT_HANDOVER = new RoleElement(114, "View Shift Handover");

        public static RoleElement CREATE_SHIFT_HANDOVER_QUESTIONNAIRE = new RoleElement(115,
            "Create Shift Handover Questionnaire");

        public static RoleElement EDIT_SHIFT_HANDOVER_QUESTIONNAIRE = new RoleElement(116,
            "Edit Shift Handover Questionnaire");

        public static RoleElement DELETE_SHIFT_HANDOVER_QUESTIONNAIRE = new RoleElement(117,
            "Delete Shift Handover Questionnaire");

        // targets
        public static RoleElement VIEW_TARGET_NAVIGATION = new RoleElement(211, "View Navigation - Targets");
        public static RoleElement VIEW_TARGET_PRIORITIES = new RoleElement(219, "View Priorities - Targets");
        public static RoleElement VIEW_TARGETDEFINITION = new RoleElement(12, "View Target Definition");
        public static RoleElement VIEW_TARGET_ALERTS = new RoleElement(41, "View Target Alerts");
        public static RoleElement APPROVE_TARGETDEFINITION = new RoleElement(13, "Approve Target Definition");
        public static RoleElement REJECT_TARGETDEFINITION = new RoleElement(14, "Reject Target Definition");
        public static RoleElement CREATE_TARGETDEFINITION = new RoleElement(15, "Create Target Definition");
        public static RoleElement EDIT_TARGETDEFINITION = new RoleElement(17, "Edit Target Definition");
        public static RoleElement DELETE_TARGETDEFINITION = new RoleElement(19, "Delete Target Definition");
        public static RoleElement REVIEW_TARGETDEFINITION = new RoleElement(21, "Comment on Target Definition");

        public static RoleElement TOGGLE_TARGETDEFINITION_APPROVAL_REQUIRED = new RoleElement(22,
            "Toggle Approval Required for Target Definition");

        public static RoleElement RESPOND_TO_TARGET_ALERTS = new RoleElement(42, "Respond to Target Alerts");

        public static RoleElement CONFIGURE_PREAPPROVED_TARGET_RANGES = new RoleElement(83,
            "Configure Pre-Approved Target Ranges");

        // work permits
        public static RoleElement VIEW_PERMIT_NAVIGATION = new RoleElement(213, "View Navigation - Work Permits");
        public static RoleElement VIEW_PERMIT_PRIORITIES = new RoleElement(224, "View Navigation - Work Permits");
        public static RoleElement VIEW_PERMIT = new RoleElement(24, "View Permit");
        public static RoleElement CREATE_PERMIT = new RoleElement(23, "Create Permit");
        public static RoleElement APPROVE_PERMIT = new RoleElement(25, "Approve Permit");
        public static RoleElement REJECT_PERMIT = new RoleElement(26, "Reject Permit");
        public static RoleElement DELETE_PERMIT = new RoleElement(27, "Delete Permit");

        public static RoleElement UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING = new RoleElement(28,
            "Update Permit with Restrictions");

        public static RoleElement UPDATE_PERMIT_NO_RESTRICTIONS = new RoleElement(29, "Update Permit at any time");
        public static RoleElement PRINT_PERMIT = new RoleElement(31, "Print Permit");

        public static RoleElement CLONE_PERMIT_WITH_SOME_RESTRICTIONS = new RoleElement(45,
            "Clone work permit with some restrictions");

        public static RoleElement CLONE_PERMIT_WITH_NO_RESTRICTION = new RoleElement(46,
            "Clone work permit with no restriction");

        public static RoleElement COPY_PERMIT_WITH_SOME_RESTRICTIONS = new RoleElement(49,
            "Copy work permit with some restrictions");

        public static RoleElement COPY_PERMIT_WITH_NO_RESTRICTION = new RoleElement(50,
            "Copy work permit with no restriction");

        public static RoleElement CLOSE_PERMIT = new RoleElement(52, "Close Permit");
        public static RoleElement APPROVE_NON_OPERATIONS_PERMIT = new RoleElement(57, "Approve Non-Operations Permit");
        public static RoleElement REJECT_NON_OPERATIONS_PERMIT = new RoleElement(58, "Reject Non-Operations Permit");
        public static RoleElement DELETE_NON_OPERATIONS_PERMIT = new RoleElement(59, "Delete Non-Operations Permit");
        public static RoleElement EDIT_NON_OPERATIONS_PERMIT = new RoleElement(60, "Update Non-Operations Permit");
        public static RoleElement CLOSE_NON_OPERATIONS_PERMIT = new RoleElement(61, "Close Non-Operations Permit");
        public static RoleElement PRINT_NON_OPERATIONS_PERMIT = new RoleElement(62, "Print Non-Operations Permit");
        public static RoleElement COMMENT_WORK_PERMIT = new RoleElement(86, "Comment WorkPermit");

        // work permit confined space documents
        public static RoleElement CREATE_CONFINED_SPACE = new RoleElement(189, "Create Confined Space Documents");
        public static RoleElement EDIT_CONFINED_SPACE = new RoleElement(190, "Create Confined Space Documents");
        public static RoleElement PRINT_CONFINED_SPACE = new RoleElement(191, "Create Confined Space Documents");
        public static RoleElement VIEW_CONFINED_SPACE = new RoleElement(192, "Create Confined Space Documents");
        public static RoleElement DELETE_CONFINED_SPACE = new RoleElement(193, "Delete Confined Space Documents");

        // work permit requests
        public static RoleElement VIEW_PERMIT_REQUESTS = new RoleElement(181, "View Permit Requests");
        public static RoleElement CREATE_PERMIT_REQUEST = new RoleElement(182, "Create Permit Request");
        public static RoleElement EDIT_PERMIT_REQUEST = new RoleElement(183, "Edit Permit Request");
        public static RoleElement DELETE_PERMIT_REQUEST = new RoleElement(184, "Delete Permit Request");
        public static RoleElement SUBMIT_PERMIT_REQUEST = new RoleElement(185, "Submit Permit Request");
        public static RoleElement IMPORT_PERMIT_REQUESTS = new RoleElement(186, "Import Permit Requests");
        public static RoleElement CLONE_PERMIT_REQUEST = new RoleElement(197, "Clone Permit Requests");

        // forms
        public static RoleElement VIEW_FORM_NAVIGATION = new RoleElement(217, "View Navigation - Forms");
        public static RoleElement VIEW_FORM_PRIORITIES = new RoleElement(221, "View Priorities - Forms");
        public static RoleElement VIEW_FORMOP14_PRIORITIES = new RoleElement(222, "View Priorities - Form OP-14s");
        public static RoleElement VIEW_LUBESCSD_PRIORITIES = new RoleElement(248, "View Priorities - Lubes CSD");
        public static RoleElement VIEW_MONTREALCSD_PRIORITIES = new RoleElement(252, "View Priorities - Montreal CSD");
        public static RoleElement VIEW_FORM = new RoleElement(207, "View Form");
        public static RoleElement CREATE_FORM = new RoleElement(196, "Create Form");

        //ayman Reports
        public static RoleElement VIEW_FORM_REPORT = new RoleElement(290,"View Form Report (In General)");
        public static RoleElement VIEW_TRAINING_FORM_EXCEL = new RoleElement(291,"View Training Form Excel");
        public static RoleElement VIEW_TRAINING_FORM_REPORT = new RoleElement(292,"View Training Form Report");
        public static RoleElement VIEW_SWP_ASSESSMENT_REPORT = new RoleElement(293,"View SWP Assessment Report");


        //ayman training
        public static RoleElement CREATE_FORM_TRAINING = new RoleElement(285,"Create Form - Training");
        public static RoleElement VIEW_FORM_TRAINING = new RoleElement(286,"View Form - Training");
        public static RoleElement EDIT_FORM_TRAINING = new RoleElement(287, "Edit Form - Training");
        public static RoleElement CLOSE_FORM_TRAINING = new RoleElement(288, "Close Form - Training");
        public static RoleElement DELETE_FORM_TRAINING = new RoleElement(289, "Delete Form - Training");

        public static RoleElement DELETE_FORM = new RoleElement(198, "Delete Form");
        public static RoleElement EDIT_FORM = new RoleElement(199, "Edit Form");
        public static RoleElement APPROVE_OILSANDS_TRAINING_FORM = new RoleElement(208, "Approve Oilsands Training Form");
        public static RoleElement CREATE_OILSANDS_SWP_FORM = new RoleElement(259, "Create Form - SWP Audit");
        public static RoleElement EDIT_OILSANDS_SWP_FORM = new RoleElement(260, "EDIT Form - SWP Audit");
        public static RoleElement CANCEL_DURING_SHIFT_OILSANDS_SWP_FORM = new RoleElement(261, "Cancel Form During Shift - SWP Audit");
        public static RoleElement CANCEL_ANYTIME_OILSANDS_SWP_FORM = new RoleElement(262, "Cancel Form Anytime - SWP Audit");

        public static RoleElement CHANGE_FORMGN59_END_DATE_WITH_NO_REAPPROVAL_REQUIRED = new RoleElement(226,
            "No approval required for GN-59 End Date Change");

        public static RoleElement CHANGE_FORMGN24_END_DATE_WITH_NO_REAPPROVAL_REQUIRED = new RoleElement(229,
            "No approval required for GN-24 End Date Change");

        public static RoleElement CHANGE_FORMGN6_END_DATE_WITH_NO_REAPPROVAL_REQUIRED = new RoleElement(230,
            "No approval required for GN-6 End Date Change");

        public static RoleElement CHANGE_FORMGN75A_END_DATE_WITH_NO_REAPPROVAL_REQUIRED = new RoleElement(233,
            "No approval required for GN-75A End Date Change");

        public static RoleElement CHANGE_FORMGN1_END_DATE_WITH_NO_REAPPROVAL_REQUIRED = new RoleElement(234,
            "No approval required for GN-1 End Date Change");

        public static RoleElement APPROVE_FORM_OVERTIME_REQUEST = new RoleElement(239, "Approve Form - Overtime Request");
        public static RoleElement VIEW_FORM_OVERTIME_REQUEST = new RoleElement(238, "View Form - Overtime Request");

        public static RoleElement CLOSE_LUBES_CSD_FORM = new RoleElement(247, "Close Form - Lubes CSD");
        public static RoleElement CREATE_LUBES_CSD_FORM = new RoleElement(241, "Create Form - Lubes CSD");
        public static RoleElement EDIT_LUBES_CSD_FORM = new RoleElement(242, "Edit Form - Lubes CSD");
        public static RoleElement APPROVE_LUBES_CSD_FORM_PROCESS_ENGINEER = new RoleElement(243, "Approve Form - Lubes CSD - Process Engineer");
        public static RoleElement APPROVE_LUBES_CSD_FORM_LEAD_TECH = new RoleElement(244, "Approve Form - Lubes CSD - Lead Tech");
        public static RoleElement APPROVE_LUBES_CSD_FORM_AREA_TEAM_LEAD = new RoleElement(245, "Approve Form - Lubes CSD - Area Team Lead");
        public static RoleElement APPROVE_LUBES_CSD_FORM_DIRECTOR_OF_PRODUCTION = new RoleElement(246, "Approve Form - Lubes CSD - Director of Production");
        public static RoleElement APPROVE_LUBES_CSD_FORM_CHANGE_END_DATE_WITHOUT_REAPPROVAL = new RoleElement(249, "No approval require for Lubes CSD End Date Change");
        public static RoleElement DELETE_LUBES_CSD_FORM = new RoleElement(250, "Delete Form - Lubes CSD");

        // Document Suggestion Forms
        public static RoleElement VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM = new RoleElement(275, "View Priorities - Document Suggestion");
        public static RoleElement CREATE_DOCUMENT_SUGGESTION_FORM = new RoleElement(276, "Create Form - Document Suggestion");
        public static RoleElement EDIT_DOCUMENT_SUGGESTION_FORM = new RoleElement(277, "Edit Form - Document Suggestion");
        public static RoleElement APPROVE_DOCUMENT_SUGGESTION_FORM = new RoleElement(278, "Approve Form - Document Suggestion");
        public static RoleElement DELETE_DOCUMENT_SUGGESTION_FORM = new RoleElement(279, "Delete Form - Document Suggestion");
        
        // Procedure Deviation Forms
        public static RoleElement VIEW_PRIORITIES_PROCEDURE_DEVIATION_FORM = new RoleElement(280, "View Priorities - Procedure Deviation");
        public static RoleElement CREATE_PROCEDURE_DEVIATION_FORM = new RoleElement(281, "Create Form - Procedure Deviation");
        public static RoleElement EDIT_PROCEDURE_DEVIATION_FORM = new RoleElement(282, "Edit Form - Procedure Deviation");
        public static RoleElement APPROVE_PROCEDURE_DEVIATION_FORM = new RoleElement(283, "Approve Form - Procedure Deviation");
        public static RoleElement DELETE_PROCEDURE_DEVIATION_FORM = new RoleElement(284, "Delete Form - Procedure Deviation");
        
        public static RoleElement EDIT_MONTREAL_CSD_FORM = new RoleElement(199, "Edit Form");

        // Lubes Temporary Alarm Disable
        public static RoleElement CLOSE_LUBES_ALARM_DISABLE_FORM = new RoleElement(257, "Close Form - Lubes Temporary Alarm Disable");
        public static RoleElement CREATE_LUBES_ALARM_DISABLE_FORM = new RoleElement(253, "Create Form - Lubes Alarm Temporary Disable");
        public static RoleElement EDIT_LUBES_ALARM_DISABLE_FORM = new RoleElement(254, "Edit Form - Lubes Alarm Temporary Disable");
        public static RoleElement DELETE_LUBES_ALARM_DISABLE_FORM = new RoleElement(255, "Delete Form - Lubes Alarm Temporary Disable");

        public static RoleElement APPROVE_LUBES_ALARM_DISABLE_FORM_LEAD_TECH = new RoleElement(256, "Approve Form - Lubes Temporary Alarm Disable");
        public static RoleElement APPROVE_LUBES_ALARM_DISABLE_FORM_SUPERVISOR = new RoleElement(256, "Approve Form - Lubes Temporary Alarm Disable");

        public static RoleElement APPROVE_LUBES_ALARM_DISABLE_FORM_CHANGE_END_DATE_WITHOUT_REAPPROVAL = new RoleElement(258, "No approval require for Lubes Temporary Alarm Disable End Date Change");

        // Excursion Events
        public static RoleElement VIEW_EVENTS_NAVIGATION = new RoleElement(264, "View Navigation - Events");
        public static RoleElement VIEW_EVENTS_PRIORITIES = new RoleElement(265, "View Priorities - Events");
        public static RoleElement RESPOND_TO_EXCURSION = new RoleElement(266, "Respond to Excursion");

        // admin action items
        public static RoleElement CONFIGURE_AUTO_APPROVE_SAP_AID = new RoleElement(77,
            "Configure Auto Approve SAP Action Item Definition");

        public static RoleElement CONFIGURE_BUSINESS_CATEGORIES = new RoleElement(111, "Configure Business Categories");

        public static RoleElement CONFIGURE_BUSINESS_CATEGORY_FLOC_ASSOCIATION = new RoleElement(112,
            "Associate Business Categories To Functional Locations");

        // admin action items and targets
        public static RoleElement MANAGE_OPERATIONAL_MODES = new RoleElement(73, "Manage Operational Modes");

        public static RoleElement CONFIGURE_AUTO_RE_APPROVAL_BY_FIELD = new RoleElement(84,
            "Configure Automatic Re-Approval by Field");

        // admin coker cards
        public static RoleElement CONFIGURE_COKER_CARDS = new RoleElement(154, "Configure Coker Cards");

        // admin lab alerts
        public static RoleElement CONFIGURE_LAB_ALERT = new RoleElement(135, "Configure Lab Alert");

        // admin - logs
        public static RoleElement CONFIGURE_LOG_GUIDELINE = new RoleElement(113, "Configure Log Guidelines");

        public static RoleElement CONFIGURE_SUMMARY_LOG_CUSTOM_FIELDS = new RoleElement(122,
            "Configure Summary Log Custom Fields");

        public static RoleElement CONFIGURE_LOG_TEMPLATES = new RoleElement(129, "Edit Log Templates");

        // admin reports
        public static RoleElement CONFIGURE_PLANT_HISTORIAN_TAG_LIST = new RoleElement(80,
            "Configure Plant Historian Tag List");

        // admin restriction reporting
        public static RoleElement CONFIGURE_RESTRICTION_REASON_CODE = new RoleElement(107,
            "Configure Restriction Reason Code");

        public static RoleElement CONFIGURE_DEVIATION_RESPONSE_TIME_LIMIT = new RoleElement(109,
            "Configure Time Limit for Deviation Response");

        public static RoleElement CONFIGURE_DOR_CUTOFF_TIME = new RoleElement(127, "Configure DOR Cutoff Time");

        // admin shift handover
        public static RoleElement EDIT_SHIFT_HANDOVER_CONFIGURATIONS = new RoleElement(120,
            "Edit Shift Handover Configurations");

        public static RoleElement EDIT_SHIFT_HANDOVER_EMAIL_CONFIGURATIONS = new RoleElement(206,
            "Edit Shift Handover E-mail Configurations");

        // admin site configuration
        public static RoleElement CONFIGURE_DISPLAY_LIMITS = new RoleElement(76, "Configure Display Limits");
        public static RoleElement CONFIGURE_WORK_ASSIGNMENTS = new RoleElement(82, "Configure Work Assignments");

        public static RoleElement CONFIGURE_DEFAULT_FLOCS_FOR_ASSIGNMENTS = new RoleElement(85,
            "Configure Default FLOCs for Assignments");

        public static RoleElement CONFIGURE_DEFAULT_TABS = new RoleElement(136, "Configure Default Tabs");

        public static RoleElement CONFIGURE_WORK_ASSIGNMENT_NOT_SELECTED_WARNING = new RoleElement(141,
            "Configure Work Assignment Not Selected Warning");

        public static RoleElement CONFIGURE_LINKS = new RoleElement(142, "Configure Unc Paths for Links");
        public static RoleElement CONFIGURE_AREA_LABELS = new RoleElement(204, "Configure Area Labels");
        public static RoleElement CONFIGURE_SITE_COMMUNICATIONS = new RoleElement(225, "Configure Site Communications");
        public static RoleElement CONFIGURE_FUNCTIONAL_LOCATIONS = new RoleElement(237, "Configure Functional Locations");

        // admin work permits
        public static RoleElement CONFIGURE_GAS_TEST_LIMITS = new RoleElement(72, "Configure Gas Test Limits");

        public static RoleElement CONFIGURE_WORK_PERMIT_ARCHIVAL_PROCESS = new RoleElement(75,
            "Configure Work Permit Archival Process");

        public static RoleElement CONFIGURE_WORK_PERMIT_CONTRACTOR = new RoleElement(78,
            "Configure Work Permit Contractor");

        public static RoleElement CONFIGURE_CRAFT_OR_TRADE = new RoleElement(81, "Configure Craft Or Trade");
        public static RoleElement ADMIN_FORM_SWP = new RoleElement(263, "Admin Form - SWP Audit");

        public static RoleElement CONFIGURE_FLOC_ASSIGNMENT_CONFIG_FOR_WORK_PERMIT_AUTO_ASSIGNMENT = new RoleElement(
            153, "Configure Work Assignments for Work Permit Auto-Assignment");

        public static RoleElement CONFIGURE_ASSIGNMENTS_FOR_WORK_PERMITS = new RoleElement(201,
            "Configure Work Assignments for Work Permits");

        public static RoleElement CONFIGURE_WORK_PERMIT_TEMPLATES = new RoleElement(180,
            "Configure Work Permit Templates");

        public static RoleElement CONFIGURE_WORK_PERMIT_DROPDOWNS = new RoleElement(194,
            "Configure Work Permit Dropdowns");

        public static RoleElement CONFIGURE_CONFIGURED_DOCUMENT_LINKS = new RoleElement(195,
            "Configure Configured Document Links");

        public static RoleElement CONFIGURE_WORK_PERMIT_GROUPS = new RoleElement(228, "Configure Work Permit Groups");

        // admin Priorities
        public static RoleElement CONFIGURE_PRIORITIES_PAGE = new RoleElement(179, "Configure the Priorities Page");

        // admin forms
        public static RoleElement CONFIGURE_FORM_TEMPLATES = new RoleElement(200, "Configure Form Templates");
        public static RoleElement CONFIGURE_TRAINING_BLOCKS = new RoleElement(209, "Configure Training Blocks");
        public static RoleElement CONFIGURE_EFORM_TEMPLATES_APPROVAL = new RoleElement(328, "Configure E-Form Templates Approval");//generic template - mangesh
        public static RoleElement CONFIGURE_OLT_COMMUNITY = new RoleElement(329, "Configure OLT Community");//OLT admin list - mangesh

        public static RoleElement CONFIGURE_IS_FLEXIBLE_SHIFT = new RoleElement(330, "Create Flexible Shift Handover Questionnaire");//amit is flexi

        // technical admin
        public static RoleElement PERFORM_TECH_ADMIN_TASKS = new RoleElement(202, "Perform Tech Admin Tasks");

        public static RoleElement VIEW_ON_PREMISE_PERSONNEL_NAVIGATION = new RoleElement(240,
            "View Navigation - On Premise Personnel");

        public static RoleElement CONFIGURE_FORM_DROPDOWNS = new RoleElement(251,
            "Configure Form Dropdowns");
  //RITM0268131 - mangesh
        public static RoleElement VIEW_TemporaryInstallations = new RoleElement(331, "View Temporary Installations - MUDS");
        public static RoleElement APPROVECLOSE_TemporaryInstallations = new RoleElement(332, "Approve / Close Temporary Installations - MUDS");
        public static RoleElement CREATE_TemporaryInstallations = new RoleElement(333, "Create Temporary Installations - MUDS");
        public static RoleElement EDIT_TemporaryInstallations = new RoleElement(334, "Edit Temporary Installations - MUDS");
        public static RoleElement DELETE_TemporaryInstallations = new RoleElement(335, "Delete Temporary Installations - MUDS");

        //TASK0593631 - mangesh
        public static RoleElement VIEW_NonEmergencyWaterSystemApproval = new RoleElement(406, "View Non-Emergency Water System Approval");
        public static RoleElement APPROVE_NonEmergencyWaterSystemApproval = new RoleElement(407, "Approve Non-Emergency Water System Approval");
        public static RoleElement CREATE_NonEmergencyWaterSystemApproval = new RoleElement(408, "Create Non-Emergency Water System Approval");
        public static RoleElement EDIT_NonEmergencyWaterSystemApproval = new RoleElement(409, "Edit Non-Emergency Water System Approval");
        public static RoleElement DELETE_NonEmergencyWaterSystemApproval = new RoleElement(410, "Delete Non-Emergency Water System Approval");

        //generic template - mangesh
        public static RoleElement VIEW_ODOURNOISE = new RoleElement(298, "View Odour - Noise complaint");
        public static RoleElement APPROVE_ODOURNOISE = new RoleElement(299, "Approve Odour - Noise complaint");
        public static RoleElement CREATE_ODOURNOISE = new RoleElement(300, "Create Odour - Noise complaint");
        public static RoleElement EDIT_ODOURNOISE = new RoleElement(301, "Edit Odour - Noise complaint");
        public static RoleElement DELETE_ODOURNOISE = new RoleElement(302, "Delete Odour - Noise complaint");

        //RITM0195885 mangesh
        public static RoleElement VIEW_DEVIATION = new RoleElement(303, "View Letter of Exception");
        public static RoleElement APPROVE_DEVIATION = new RoleElement(304, "Approve Letter of Exception");
        public static RoleElement CREATE_DEVIATION = new RoleElement(305, "Create Letter of Exception");
        public static RoleElement EDIT_DEVIATION = new RoleElement(306, "Edit Letter of Exception");
        public static RoleElement DELETE_DEVIATION = new RoleElement(307, "Delete Letter of Exception");

        public static RoleElement VIEW_ROADCLOSURE = new RoleElement(308, "View Road closure");
        public static RoleElement APPROVE_ROADCLOSURE = new RoleElement(309, "Approve Road closure");
        public static RoleElement CREATE_ROADCLOSURE = new RoleElement(310, "Create Road closure");
        public static RoleElement EDIT_ROADCLOSURE = new RoleElement(311, "Edit Road closure");
        public static RoleElement DELETE_ROADCLOSURE = new RoleElement(312, "Delete Road closure");

        public static RoleElement VIEW_GN11GROUNDDISTURBANCE = new RoleElement(313, "View GN11 Ground Disturbance");
        public static RoleElement APPROVE_GN11GROUNDDISTURBANCE = new RoleElement(314, "Approve GN11 Ground Disturbance");
        public static RoleElement CREATE_GN11GROUNDDISTURBANCE = new RoleElement(315, "Create GN11 Ground Disturbance");
        public static RoleElement EDIT_GN11GROUNDDISTURBANCE = new RoleElement(316, "Edit GN11 Ground Disturbance");
        public static RoleElement DELETE_GN11GROUNDDISTURBANCE = new RoleElement(317, "Delete GN11 Ground Disturbance");

        public static RoleElement VIEW_GN27FREEZEPLUG = new RoleElement(318, "View GN27 Freeze Plug");
        public static RoleElement APPROVE_GN27FREEZEPLUG = new RoleElement(319, "Approve GN27 Freeze Plug");
        public static RoleElement CREATE_GN27FREEZEPLUG = new RoleElement(320, "Create GN27 Freeze Plug");
        public static RoleElement EDIT_GN27FREEZEPLUG = new RoleElement(321, "Edit GN27 Freeze Plug");
        public static RoleElement DELETE_GN27FREEZEPLUG = new RoleElement(322, "Delete GN27 Freeze Plug");

        // RITM0195190 - mangesh
        public static RoleElement VIEW_HAZARDASSESSMENT = new RoleElement(323, "View HO68 Plant 12 Minor HF Leak");
        public static RoleElement APPROVE_HAZARDASSESSMENT = new RoleElement(324, "Approve HO68 Plant 12 Minor HF Leak");
        public static RoleElement CREATE_HAZARDASSESSMENT = new RoleElement(325, "Create HO68 Plant 12 Minor HF Leak");
        public static RoleElement EDIT_HAZARDASSESSMENT = new RoleElement(326, "Edit HO68 Plant 12 Minor HF Leak");
        public static RoleElement DELETE_HAZARDASSESSMENT = new RoleElement(327, "Delete HO68 Plant 12 Minor HF Leak");


        // ayman Sarnia eip DMND0008992
        public static RoleElement CREATE_EIP_ISSUE = new RoleElement(336, "Create Sarnia Eip Issue/Template");
        public static RoleElement EDIT_EIP_ISSUE = new RoleElement(337, "Edit Sarnia Eip Issue/Template");
        public static RoleElement VIEW_EIP_ISSUE = new RoleElement(338, "View Sarnia Eip Issue/Template");
        public static RoleElement Approve_EIP_ISSUE = new RoleElement(339, "Approve Sarnia Eip Issue/Template");

        /*RITM0265746 - Sarnia CSD marked as read start*/
        public static RoleElement MARKASREAD_CSDFORMS = new RoleElement(340, "Mark As Read CSD Forms");/*RITM0265746*/

        //RITM0341710 -mangesh
        public static RoleElement VIEW_OILSAMPLE = new RoleElement(341, "View 980E- AT 250HR Oil Sample/ inspection");
        public static RoleElement APPROVE_OILSAMPLE = new RoleElement(342, "Approve 980E- AT 250HR Oil Sample/ inspection");
        public static RoleElement CREATE_OILSAMPLE = new RoleElement(343, "Create 980E- AT 250HR Oil Sample/ inspection");
        public static RoleElement EDIT_OILSAMPLE = new RoleElement(344, "Edit 980E- AT 250HR Oil Sample/ inspection");
        public static RoleElement DELETE_OILSAMPLE = new RoleElement(345, "Delete 980E- AT 250HR Oil Sample/ inspection");

        public static RoleElement VIEW_DAILYINSPECTION = new RoleElement(346, "View 980E- AT Daily Inspection");
        public static RoleElement APPROVE_DAILYINSPECTION = new RoleElement(347, "Approve 980E- AT Daily Inspection");
        public static RoleElement CREATE_DAILYINSPECTION = new RoleElement(348, "Create 980E- AT Daily Inspection");
        public static RoleElement EDIT_DAILYINSPECTION = new RoleElement(349, "Edit 980E- AT Daily Inspection");
        public static RoleElement DELETE_DAILYINSPECTION = new RoleElement(350, "Delete 980E- AT Daily Inspection");


        //Reading roles         ayman action tiem reading
        public static RoleElement VIEW_READING = new RoleElement(400, "View Reading");
        public static RoleElement VIEW_READING_PRIORITIES = new RoleElement(401, "View Priorities - Reading");
        public static RoleElement VIEW_READING_NAVIGATION = new RoleElement(402, "View Navigation - Reading");

        //Mukesh for Selc CSD Approval
        public static RoleElement Pipeline_CSD_APPROVAL = new RoleElement(404, "Approved CSD(SELC)");

        // DMND0010609-OLT - Edmonton Work permit Scan
        public static RoleElement WORKPERMIT_SCAN = new RoleElement(405, "Scan Work Permit");

        public static RoleElement WORKPERMIT_MARKED_TEMPLATE = new RoleElement(411, "Create Global Template"); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

        public static RoleElement CSD_LOG = new RoleElement(412, "Create CSD Log");

        // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions
        public static RoleElement CLONE_ACTIONITEM = new RoleElement(413, "Clone Action Item Definition");

        // this list is meant to contain all role elements that work with our role permissions sytem. It is used in the tech admin form.
        public static List<RoleElement> APPLICABLE_TO_ROLE_PERMISSIONS = new List<RoleElement>
        {
            EDIT_LOG,
            DELETE_LOG,
            EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG,
            DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG,
            CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG,
            CANCEL_LOG,
            EDIT_LOG_DEFINITION,
            EDIT_LOG_BASED_DIRECTIVES,
            DELETE_LOG_BASED_DIRECTIVES,
            CANCEL_STANDING_ORDERS,
            EDIT_NEW_DIRECTIVES,
            DELETE_NEW_DIRECTIVES,
            EDIT_SUMMARY_LOG,
            DELETE_SUMMARY_LOG,
            EDIT_PERMIT_REQUEST,
            DELETE_PERMIT_REQUEST, // these permit request ones are currently Lubes-only

            EDIT_FORM // this form one is currently Oilsands-only
            ,VIEW_SHIFT_HANDOVER
        };

        private readonly string name;
        private string functionalArea;

        public RoleElement()
        {
        }

        public RoleElement(string name)
        {
            this.name = name;
        }

        public RoleElement(long? id, string name)
        {
            this.name = name;
            this.id = id;
        }

        public string Name
        {
            get { return name; }
        }

        public string FunctionalArea
        {
            get { return functionalArea; }
            set { functionalArea = value; }
        }

       public bool Equals(RoleElement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id == id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RoleElement);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return id.GetHashCode();
            }
        }
    }
}