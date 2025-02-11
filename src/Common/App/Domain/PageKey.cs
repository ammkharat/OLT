﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class PageKey
    {
        public static PageKey PRIORITIES_PAGE = new PageKey(1, StringResources.PrioritiesTabText,
            SectionKey.PrioritiesSection);

        public static PageKey ACTION_ITEM_DEFINITION_PAGE = new PageKey(2, StringResources.ActionItemDefinitionTabText,
            SectionKey.ActionItemSection);

        public static PageKey ACTION_ITEM_PAGE = new PageKey(3, StringResources.ActionItemTabText,
            SectionKey.ActionItemSection);

        public static PageKey READING_PAGE = new PageKey(3, StringResources.ReadingTabText,
            SectionKey.ReadingSection);

        public static PageKey ACTION_ITEM_BY_ASSIGNMENT_PAGE = new PageKey(4,
            StringResources.ActionItemByWorkAssignmentTabText, SectionKey.ActionItemSection);

        public static PageKey LAB_ALERT_DEFINITION_PAGE = new PageKey(5, StringResources.LabAlertDefinitionTabText,
            SectionKey.LabAlertSection);

        public static PageKey LAB_ALERT_PAGE = new PageKey(6, StringResources.LabAlertTabText,
            SectionKey.LabAlertSection);

        public static PageKey LOG_PAGE = new PageKey(7, StringResources.LogTabText, SectionKey.LogSection);
        public static PageKey LOG_PAGE_DWR = new PageKey(41, StringResources.LogSectionNavigationTextForConstructionSite, SectionKey.LogSection); //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}

        public static PageKey LOG_BY_WORK_ASSIGNMENT_PAGE_ConstMgntSite = new PageKey(42, StringResources.LogByWorkAssignmentTabTextForConstructionSite,
            SectionKey.LogSection);//RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        
        public static PageKey LOG_BY_WORK_ASSIGNMENT_PAGE = new PageKey(8, StringResources.LogByWorkAssignmentTabText,
            SectionKey.LogSection);

        public static PageKey OPERATING_ENGINEER_LOG_PAGE = new PageKey(9, StringResources.OperatingEngineerLogTabText,
            SectionKey.LogSection);

        public static PageKey SUMMARY_LOG_PAGE = new PageKey(10, StringResources.SummaryLogTabText,
            SectionKey.LogSection); //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}

        public static PageKey SUMMARY_LOG_PAGE_ConstMgntSite = new PageKey(43, StringResources.SummaryLogTabTextForConstSite,
            SectionKey.LogSection);

        public static PageKey DAILY_DIRECTIVES_LOG_PAGE = new PageKey(11, StringResources.DailyDirectiveTabText,
            SectionKey.LogSection);

        public static PageKey STANDING_ORDERS_PAGE = new PageKey(12, StringResources.StandingOrderTabText,
            SectionKey.LogSection);

        public static PageKey LOG_DEFINITION_PAGE = new PageKey(13, StringResources.LogDefinitionTabText,
            SectionKey.LogSection);

        public static PageKey SAP_NOTIFICATION_PAGE = new PageKey(14, StringResources.SAPNotificationTabText,
            StringResources.SAPNotificationPageTitle, SectionKey.LogSection);

        public static PageKey RESTRICTION_DEFINITION_PAGE = new PageKey(15, StringResources.RestrictionDefinitionTabText,
            SectionKey.RestrictionSection);

        public static PageKey DEVIATION_ALERT_PAGE = new PageKey(16, StringResources.DeviationAlertTabText,
            SectionKey.RestrictionSection);

        public static PageKey SHIFT_HANDOVER_QUESTIONNAIRE_PAGE = new PageKey(17,
            StringResources.ShiftHandoverQuestionnaireTabText, SectionKey.ShiftHandoverSection);

        public static PageKey SHIFT_HANDOVER_QUESTIONNAIRE_BY_ASSIGNMENT_PAGE = new PageKey(18,
            StringResources.ShiftHandoverQuestionnaireByAssignmentTabText, SectionKey.ShiftHandoverSection);

        public static PageKey TARGET_DEFINITION_PAGE = new PageKey(19, StringResources.TargetDefinitionTabText,
            SectionKey.TargetSection);

        public static PageKey TARGET_ALERT_PAGE = new PageKey(20, StringResources.TargetAlertTabText,
            SectionKey.TargetSection);

        public static PageKey WORK_PERMIT_PAGE = new PageKey(21, StringResources.WorkPermitTabText,
            SectionKey.WorkPermitSection);

        public static PageKey WORK_PERMIT_BY_WORK_ASSIGNMENT_PAGE = new PageKey(22,
            StringResources.WorkPermitByWorkAssignmentTabText, SectionKey.WorkPermitSection);

        public static PageKey WORK_PERMIT_FOR_TODAY_PAGE = new PageKey(23, StringResources.WorkPermitForTodayTabText,
            SectionKey.WorkPermitSection);

        public static PageKey COKER_CARD_PAGE = new PageKey(24, StringResources.CokerCardTabText, SectionKey.LogSection);

        public static PageKey PERMIT_REQUEST_PAGE = new PageKey(25, StringResources.PermitRequestTabText,
            SectionKey.WorkPermitSection);

        public static PageKey CONFINED_SPACE_PAGE = new PageKey(26, StringResources.ConfinedSpaceTabText,
            SectionKey.WorkPermitSection);

        //public static PageKey FORM_PAGE = new PageKey(27, StringResources.FormTabText, SectionKey.FormSection);

        //RITM0475844 :  Changed by vibhor : changed Tab text, applicable for sarnia.
        public static PageKey FORM_PAGE = new PageKey(27, StringResources.CSDFormTabText, SectionKey.FormSection); 

        public static PageKey WORK_PERMIT_TURNAROUND_PAGE = new PageKey(28, StringResources.WorkPermitTurnaroundTabText,
            SectionKey.WorkPermitSection);

        public static PageKey WORK_PERMIT_RUNNING_UNIT_PAGE = new PageKey(29,
            StringResources.WorkPermitRunningUnitTabText, SectionKey.WorkPermitSection);

        public static PageKey PERMIT_REQUEST_TURNAROUND_PAGE = new PageKey(30,
            StringResources.PermitRequestTurnaroundTabText, SectionKey.WorkPermitSection);

        public static PageKey PERMIT_REQUEST_RUNNING_UNIT_PAGE = new PageKey(31,
            StringResources.PermitRequestRunningUnitTabText, SectionKey.WorkPermitSection);

        public static PageKey MULTIGRID_FORM_PAGE = new PageKey(32, StringResources.FormTabText, SectionKey.FormSection);

        public static PageKey DIRECTIVE_PAGE = new PageKey(33, StringResources.DirectiveTabText,
            SectionKey.DirectiveSection);

        public static PageKey ON_PREMISE_PERSONNEL_SUPERVISOR_PAGE = new PageKey(34,
            StringResources.OnPremisePersonnelSupervisorTabText, StringResources.OnPremisePersonnelSupervisorPageText,
            SectionKey.OnPremisePersonnelSection);

        public static PageKey ON_PREMISE_PERSONNEL_AUDIT_PAGE = new PageKey(35,
            StringResources.OnPremisePersonnelAuditTabText, StringResources.OnPremisePersonnelAuditPageText,
            SectionKey.OnPremisePersonnelSection);


        public static PageKey EXCURSION_RESPONSE_PAGE = new PageKey(36, StringResources.ExcursionResponseTabText,
    SectionKey.EventSection);

        public static PageKey FUTURE_ACTION_ITEM_PAGE = new PageKey(37, StringResources.FutureActionItemTabText,
    SectionKey.FutureActionItemSection);
        
        /* RITM0265746 - Sarnia CSD marked as read **** Add tab to all and make it visibale or hidden from role matrix*/
        public static PageKey MULTIGRID_CSD_FORM_PAGE = new PageKey(38, StringResources.CSDFormTabText, SectionKey.CSDFormSection);

        public static PageKey READING_DEFINITION_PAGE = new PageKey(39, StringResources.ReadingDefinitionTabText,
    SectionKey.ReadingSection);
        
        public static PageKey READING_BY_ASSIGNMENT_PAGE = new PageKey(40,
            StringResources.ReadingByWorkAssignmentTabText, SectionKey.ActionItemSection);

//Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
        public static PageKey WORK_PERMIT_Template_PAGE = new PageKey(42, StringResources.WorkPermitTemplates, SectionKey.WorkPermitSection);
        public static PageKey WORK_PERMIT_Edmonton_Template_PAGE = new PageKey(43, StringResources.WorkPermitTemplates, SectionKey.WorkPermitSection);
        public static PageKey WORK_PERMIT_Montreal_Template_PAGE = new PageKey(777, StringResources.WorkPermitTemplates, SectionKey.WorkPermitSection);
        public static PageKey WORK_PERMIT_MUDS_Template_PAGE = new PageKey(100, StringResources.WorkPermitTemplates, SectionKey.WorkPermitSection);


        public static PageKey EdmontonMarkedTemplate = new PageKey(50, StringResources.PermitRequestTemplates, SectionKey.WorkPermitSection);
        public static PageKey MontrealPermitTemplate = new PageKey(999, StringResources.PermitRequestTemplates, SectionKey.WorkPermitSection);
        public static PageKey MudsPermitTemplate = new PageKey(555, StringResources.PermitRequestTemplates, SectionKey.WorkPermitSection);

        public static readonly List<PageKey> All = new List<PageKey>
        {
            PRIORITIES_PAGE,
            ACTION_ITEM_DEFINITION_PAGE,
            ACTION_ITEM_PAGE,
            ACTION_ITEM_BY_ASSIGNMENT_PAGE,
            LAB_ALERT_DEFINITION_PAGE,
            LAB_ALERT_PAGE,
            LOG_PAGE,
            LOG_BY_WORK_ASSIGNMENT_PAGE,
            OPERATING_ENGINEER_LOG_PAGE,
            COKER_CARD_PAGE,
            SUMMARY_LOG_PAGE,
            DAILY_DIRECTIVES_LOG_PAGE,
            STANDING_ORDERS_PAGE,
            LOG_DEFINITION_PAGE,
            SAP_NOTIFICATION_PAGE,
            RESTRICTION_DEFINITION_PAGE,
            DEVIATION_ALERT_PAGE,
            SHIFT_HANDOVER_QUESTIONNAIRE_PAGE,
            SHIFT_HANDOVER_QUESTIONNAIRE_BY_ASSIGNMENT_PAGE,
            TARGET_DEFINITION_PAGE,
            TARGET_ALERT_PAGE,
            WORK_PERMIT_PAGE,
            WORK_PERMIT_BY_WORK_ASSIGNMENT_PAGE,
            WORK_PERMIT_FOR_TODAY_PAGE,
            PERMIT_REQUEST_PAGE,
            CONFINED_SPACE_PAGE,
            WORK_PERMIT_TURNAROUND_PAGE,
            WORK_PERMIT_RUNNING_UNIT_PAGE,
            PERMIT_REQUEST_TURNAROUND_PAGE,
            PERMIT_REQUEST_RUNNING_UNIT_PAGE,
            FORM_PAGE,
            MULTIGRID_FORM_PAGE,
            DIRECTIVE_PAGE,
            EXCURSION_RESPONSE_PAGE,
            FUTURE_ACTION_ITEM_PAGE,
            ON_PREMISE_PERSONNEL_SUPERVISOR_PAGE,       //Mingle Story #3556
            ON_PREMISE_PERSONNEL_AUDIT_PAGE,             //Mingle Story #3556
            READING_BY_ASSIGNMENT_PAGE   ,               //ayman action item reading
            WORK_PERMIT_Template_PAGE,                         //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            WORK_PERMIT_Edmonton_Template_PAGE,               //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            EdmontonMarkedTemplate,
            WORK_PERMIT_Montreal_Template_PAGE,
            MontrealPermitTemplate,
            WORK_PERMIT_MUDS_Template_PAGE,
            MudsPermitTemplate
        };


        private readonly int id;
        private readonly SectionKey sectionKey;
        private readonly string tabText;
        private readonly string titleText;

        private PageKey(int id, string tabText, SectionKey sectionKey)
            : this(id, tabText, tabText, sectionKey)
        {
        }

        public PageKey(int id, string tabText, string titleText, SectionKey sectionKey)
        {
            this.id = id;
            this.tabText = tabText;
            this.titleText = titleText;
            this.sectionKey = sectionKey;
        }

        public int Id
        {
            get { return id; }
        }

        public string TabText
        {
            get { return tabText; }
        }

        public string TitleText
        {
            get { return titleText; }
        }

        public SectionKey SectionKey
        {
            get { return sectionKey; }
        }

        public bool Equals(PageKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id == id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (PageKey)) return false;
            return Equals((PageKey) obj);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public static PageKey GetById(int id)
        {
            return All.Find(obj => obj.Id == id);
        }

        public override string ToString()
        {
            return tabText;
        }
    }
}