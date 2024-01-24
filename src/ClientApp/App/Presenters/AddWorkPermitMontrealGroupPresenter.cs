using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddWorkPermitMontrealGroupPresenter : BaseWorkPermitMontrealGroupPresenter
    {        
        private WorkPermitMontrealGroup newGroup;

        public AddWorkPermitMontrealGroupPresenter(IAddEditWorkPermitMontrealGroupView view, List<WorkPermitMontrealGroup> allGroups) : base(view, allGroups)
        {                        
            view.OkButtonClicked += HandleOkButtonClicked;
            view.CancelButtonClicked += CloseButton_Clicked;          
        }

        private void HandleOkButtonClicked()
        {
            view.ClearErrors();

            if (IsValid())
            {
                newGroup = new WorkPermitMontrealGroup(view.GroupName, 100);
                view.Close();           
            }
        }

        public WorkPermitMontrealGroup NewGroup
        {
            get { return newGroup; }
        }
    }
}
