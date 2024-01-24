
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class PriorityPageSectionNode : PriorityPageGroupNode
    {
        private readonly PriorityPageTree tree;
        private readonly List<PriorityPageSubSectionNode> subSections = new List<PriorityPageSubSectionNode>();
        private readonly PriorityPageSectionKey sectionKey;
        private PriorityPageSectionConfiguration sectionConfiguration;

        public PriorityPageSectionNode(PriorityPageTree tree, long nodeId, string name, PriorityPageSectionKey sectionKey, PriorityPageSectionConfiguration sectionConfiguration)
            : base(nodeId, null, name)
        {
            this.tree = tree;
            this.sectionKey = sectionKey;
            this.sectionConfiguration = sectionConfiguration;
        }

        public PriorityPageSubSectionNode AddSubSection(string description)
        {
            PriorityPageSubSectionNode subSection = tree.CreateSubSectionNode(this, description);
            subSections.Add(subSection);
            return subSection;
        }

        public PriorityPageSectionKey SectionKey
        {
            get { return sectionKey; }
        }

        public bool DoesConfigurationExistForSection
        {
            get { return sectionConfiguration != null; }
        }

        public PriorityPageSectionConfiguration SectionConfiguration
        {
            get { return sectionConfiguration; }
            set { sectionConfiguration = value; }
        }

        public bool ExpandSectionByDefault
        {
            get
            {
                if (sectionConfiguration != null)
                {
                    return sectionConfiguration.SectionExpandedByDefault;
                }

                return true;
            }
        }
    }
}
