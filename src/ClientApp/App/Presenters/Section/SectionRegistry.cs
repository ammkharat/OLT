using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class SectionRegistry : ISectionRegistry
    {
        private readonly object sectionCacheLockObject = new object();

        private readonly Dictionary<SectionKey, ISectionPresenter> sectionCache;
        private readonly IDictionary<SectionKey, Type> sectionTypes;

        public SectionRegistry()
        {
            sectionCache = new Dictionary<SectionKey, ISectionPresenter>();
            sectionTypes = new Dictionary<SectionKey, Type>
                               {
                                   {SectionKey.PrioritiesSection, typeof (PrioritiesSectionPresenter)},
                                   {SectionKey.ActionItemSection, typeof (ActionItemSectionPresenter)},
                                   {SectionKey.EventSection, typeof (EventSectionPresenter)},
                                   {SectionKey.LabAlertSection, typeof (LabAlertSectionPresenter)},
                                   {SectionKey.LogSection, typeof (LogSectionPresenter)},
                                   {SectionKey.RestrictionSection, typeof (RestrictionSectionPresenter)},
                                   {SectionKey.ShiftHandoverSection, typeof (ShiftHandoverSectionPresenter)},
                                   {SectionKey.TargetSection, typeof (TargetSectionPresenter)},
                                   {SectionKey.WorkPermitSection, typeof (WorkPermitSectionPresenter)},
                                   {SectionKey.FormSection, typeof (FormSectionPresenter)},
                                   {SectionKey.DirectiveSection, typeof (DirectiveSectionPresenter)},
                                   {SectionKey.OnPremisePersonnelSection, typeof(OnPremiseSectionPresenter)},
                                   {SectionKey.LubesCsdSectionKey, typeof(PriorityPageLubesCsdSectionPresenter)},
                                   {SectionKey.MontrealCsdSectionKey, typeof(PriorityPageMontrealCsdSectionPresenter)},
                                   {SectionKey.MudsTemporaryInstallationsSectionKey, typeof(PriorityPageMudsTemporaryInstallationsSectionPresenter)}, //RITM0268131 - mangesh
                                   {SectionKey.ReadingSection, typeof (ReadingSectionPresenter)}           //ayman action item reading
                               };
        }

        public void Clear()
        {
            lock (sectionCacheLockObject)
            {
                foreach (ISectionPresenter presenter in sectionCache.Values)
                {
                    presenter.Dispose();
                }
                sectionCache.Clear();
            }
        }

        public ISection GetSection(SectionKey key)
        {
            lock (sectionCacheLockObject)
            {
                if (!sectionCache.ContainsKey(key))
                {                      
                    ISectionPresenter presenter = (ISectionPresenter)Activator.CreateInstance((sectionTypes[key]));                    
                    sectionCache.Add(key, presenter);
                }
                return sectionCache[key].Section;
            }
        }

        public bool IsPageVisible(SectionKey sectionKey, PageKey pageKey)
        {
            ISection section = GetSection(sectionKey);
            if (section != null)
            {
                return section.IsPageVisible(pageKey);
            }
            return false;
        }

    }

}