using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SectionKey
    {
        public static SectionKey PrioritiesSection = new SectionKey(1, StringResources.PrioritiesSectionNavigationText);
        public static SectionKey ActionItemSection = new SectionKey(2, StringResources.ActionItemSectionNavigationText);
        public static SectionKey EventSection = new SectionKey(3, StringResources.EventSectionNavigationText);
        public static SectionKey LabAlertSection = new SectionKey(4, StringResources.LabAlertSectionNavigationText);
        public static SectionKey LogSection = new SectionKey(5, StringResources.LogSectionNavigationText);
        public static SectionKey LogSection_ConstSite = new SectionKey(5, StringResources.LogSectionNavigationTextForConstructionSite); //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public static SectionKey RestrictionSection = new SectionKey(6, StringResources.RestrictionSectionNavigationText);

        public static SectionKey ShiftHandoverSection = new SectionKey(7,StringResources.ShiftHandoverSectionNavigationText);

        public static SectionKey TargetSection = new SectionKey(8, StringResources.TargetSectionNavigationText);
        public static SectionKey WorkPermitSection = new SectionKey(9, StringResources.WorkPermitSectionNavigationText);
        public static SectionKey FormSection = new SectionKey(10, StringResources.FormSectionNavigationText);
        public static SectionKey DirectiveSection = new SectionKey(11, StringResources.DirectiveSectionNavigationText);

        public static SectionKey OnPremisePersonnelSection = new SectionKey(12, StringResources.OnPremisePersonnelSectionNavigationText);
  
        public static SectionKey LubesCsdSectionKey = new SectionKey(13, StringResources.LubesCsdSectionNavigationText);
        public static SectionKey MontrealCsdSectionKey = new SectionKey(14, StringResources.MontrealCsdSectionNavigationText);
        public static SectionKey FutureActionItemSection = new SectionKey(15, StringResources.FutureActionItemSectionNavigationText);

        public static SectionKey MudsTemporaryInstallationsSectionKey = new SectionKey(16, StringResources.MudsTemporaryInstallationsSectionNavigationText);//RITM0268131 - mangesh
        public static SectionKey ReadingSection = new SectionKey(17, StringResources.ReadingSectionNavigationText);                //ayman action item reading

        /* RITM0265746 - Sarnia CSD marked as read **** Add tab to all and make it visibale or hidden from role matrix*/
        public static SectionKey CSDFormSection = new SectionKey(17, StringResources.CSDFormSectionNavigationText);

        public static readonly List<SectionKey> All = new List<SectionKey>
        {
            PrioritiesSection,
            ActionItemSection,
            EventSection,
            LabAlertSection,
            LogSection,
            RestrictionSection,
            ShiftHandoverSection,
            FormSection,
            TargetSection,
            WorkPermitSection,
            DirectiveSection,
            OnPremisePersonnelSection,
            LubesCsdSectionKey,
            MontrealCsdSectionKey,
            FutureActionItemSection,
            MudsTemporaryInstallationsSectionKey,  //RITM0268131 - mangesh
            ReadingSection
        };

        private readonly int id;
        //private readonly string name;
        private string name; //RITM0443261 : Added by Vibhor : REMOVED READONLY 

        public SectionKey(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
           
            get { return name; }
            set { name = value; } //RITM0443261 : Added by Vibhor : ADDED SET 
        }

        public bool Equals(SectionKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id == id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SectionKey)) return false;
            return Equals((SectionKey) obj);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public static SectionKey GetById(int id)
        {
            return All.Find(obj => obj.Id == id);
        }
    }
}