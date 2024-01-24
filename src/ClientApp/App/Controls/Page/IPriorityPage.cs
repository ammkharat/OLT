using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IPriorityPage : IPage
    {
        event Action<PriorityPageDataNode> NodeClicked;
        event Action PageLoad;
        event Action<PriorityPageSectionKey> SectionConfigurationButtonClicked;

        BindingList<PriorityPageNode> Data { set; }

        void CollapseConfiguredSectionNodes();
        void MarkSectionAsHavingConfiguration(PriorityPageSectionKey sectionKey);
        void ExpandSectionAndMarkAsNotHavingConfiguration(PriorityPageSectionKey sectionKey);
        PriorityPageSectionNode GetSectionConfigurationByKey(PriorityPageSectionKey key);        

        IMainForm MainParentForm { get; }
        bool ViewEnabled { set; }
        void Refocus();

        List<SiteCommunicationDTO> SiteCommunications { set; }        
    }
}
