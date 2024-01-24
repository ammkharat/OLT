using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class BaseWorkPermitMontrealGroupPresenter : BaseFormPresenter<IAddEditWorkPermitMontrealGroupView>
    {
        protected readonly List<WorkPermitMontrealGroup> allGroupsInUI;

        public BaseWorkPermitMontrealGroupPresenter(IAddEditWorkPermitMontrealGroupView view, List<WorkPermitMontrealGroup> allGroups) : base(view)
        {
            allGroupsInUI = allGroups;
        }

        protected bool IsValid()
        {
            if (string.IsNullOrEmpty(view.GroupName))
            {
                view.SetErrorForMissingName();
                return false;
            }

            if (GroupAlreadyExists())
            {
                view.SetErrorForDuplicateName();
                return false;
            }

            return true;
        }

        protected virtual bool GroupAlreadyExists()
        {
            return allGroupsInUI.Find(g => g.Name.Equals(view.GroupName)) != null;
        }
    }
}
