using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class PriorityPageSectionKey
    {
        public static PriorityPageSectionKey FormOP14 = new PriorityPageSectionKey(0, false,
            StringResources.FormOP14SectionNavigationText);

        public static PriorityPageSectionKey FormOP14_SarniaSection = new PriorityPageSectionKey(22, false,
            StringResources.FormOP14SectionNavigationText_SarniaSite); //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}

        public static PriorityPageSectionKey FormOilsands = new PriorityPageSectionKey(1, false,
            StringResources.FormSectionNavigationText);

        public static PriorityPageSectionKey WorkPermitMontreal = new PriorityPageSectionKey(2, false,
            StringResources.WorkPermitTabText);

        public static PriorityPageSectionKey WorkPermitLubes = new PriorityPageSectionKey(3, false,
            StringResources.WorkPermitTabText);

        public static PriorityPageSectionKey EdmontonForm = new PriorityPageSectionKey(4, false,
            StringResources.FormSectionNavigationText);

        public static PriorityPageSectionKey WorkPermitEdmonton = new PriorityPageSectionKey(5, false,
            StringResources.WorkPermitTabText);

        public static PriorityPageSectionKey ShiftHandover = new PriorityPageSectionKey(6, true,
            StringResources.ShiftHandoverQuestionnaireTabText);

        public static PriorityPageSectionKey Directive = new PriorityPageSectionKey(7, false, StringResources.Directives);

        public static PriorityPageSectionKey DirectiveLog = new PriorityPageSectionKey(8, false,
            StringResources.DailyDirectiveTabText);

        public static PriorityPageSectionKey TargetAlert = new PriorityPageSectionKey(9, false,
            StringResources.PriorityPage_TargetAlertsLabel);

        public static PriorityPageSectionKey ActionItem = new PriorityPageSectionKey(10, true,
            StringResources.ActionItemTabText);

        public static PriorityPageSectionKey LubesCsd = new PriorityPageSectionKey(11, false,
            StringResources.LubesCsdSectionNavigationText);

        public static PriorityPageSectionKey MontrealCsd = new PriorityPageSectionKey(12, false,
            StringResources.MontrealCsdSectionNavigationText);

        public static PriorityPageSectionKey MontrealForm = new PriorityPageSectionKey(13, false,
            StringResources.FormSectionNavigationText);

        public static PriorityPageSectionKey LubesForm = new PriorityPageSectionKey(14, false,
            StringResources.FormSectionNavigationText);

        public static PriorityPageSectionKey ExcursionEvent = new PriorityPageSectionKey(15, false,
            StringResources.ExcursionEventSectionNavigationText);

        public static PriorityPageSectionKey DocumentSuggestion = new PriorityPageSectionKey(16, false,
            StringResources.DocumentSuggestionSectionNavigationText);

        public static PriorityPageSectionKey ProcedureDeviation = new PriorityPageSectionKey(17, false,
            StringResources.ProcedureDeviationSectionNavigationText);

        public static PriorityPageSectionKey MudsTemporaryInstallations = new PriorityPageSectionKey(18, false,
            StringResources.MudsTemporaryInstallationsSectionNavigationText); //RITM0268131 - mangesh

 public static PriorityPageSectionKey Reading = new PriorityPageSectionKey(19, false,
            StringResources.ReadingSectionNavigationText);                                       //ayman action item reading
    public static PriorityPageSectionKey WorkPermitMuds = new PriorityPageSectionKey(20, false,
            StringResources.WorkPermitTabText); //RITM0301321 - mangesh
        public static PriorityPageSectionKey WorkPermitFortHills = new PriorityPageSectionKey(20, false,
            StringResources.WorkPermitTabText);

        //DMND0011225 OLT - CSD for WBR
        public static PriorityPageSectionKey GenericCsd = new PriorityPageSectionKey(21, false,
            StringResources.MontrealCsdSectionNavigationText);

        public static readonly List<PriorityPageSectionKey> All = new List<PriorityPageSectionKey>
        {
            FormOP14,
            FormOilsands,
            WorkPermitMontreal,
            WorkPermitLubes,
            EdmontonForm,
            WorkPermitEdmonton,
            ShiftHandover,
            Directive,
            DirectiveLog,
            TargetAlert,
            ActionItem,
            MontrealForm,
            MontrealCsd,
            LubesCsd,
            LubesForm,
            ExcursionEvent,
            DocumentSuggestion,
            ProcedureDeviation,
            GenericCsd
        };

        public PriorityPageSectionKey(int id, bool enableFilteringByWorkAssignment, string sectionName)
        {
            Id = id;
            SectionName = sectionName;
            EnableFilteringByWorkAssignment = enableFilteringByWorkAssignment;
        }

        public int Id { get; private set; }

        public bool EnableFilteringByWorkAssignment { get; private set; }

        public string SectionName { get;  set; }

        protected bool Equals(PriorityPageSectionKey other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PriorityPageSectionKey) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static PriorityPageSectionKey GetById(int sectionKeyId)
        {
            return All.Find(sk => sk.Id == sectionKeyId);
        }
    }
}