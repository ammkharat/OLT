using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddWorkPermitMudsGroupPresenter : BaseWorkPermitMudsGroupPresenter
    {        
        private WorkPermitMudsGroup newGroup;

        public AddWorkPermitMudsGroupPresenter(IAddEditWorkPermitMudsGroupView view, List<WorkPermitMudsGroup> allGroups) : base(view, allGroups)
        {                        
            view.OkButtonClicked += HandleOkButtonClicked;
            view.CancelButtonClicked += CloseButton_Clicked;          
        }

        private void HandleOkButtonClicked()
        {
            view.ClearErrors();

            if (IsValid())
            {
                newGroup = new WorkPermitMudsGroup(view.GroupName, 100);
                view.Close();           
            }
        }

        public WorkPermitMudsGroup NewGroup
        {
            get { return newGroup; }
        }
    }
}
