using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditWorkPermitMudsGroupPresenter : BaseWorkPermitMudsGroupPresenter
    {
        private readonly WorkPermitMudsGroup editObject;
                       
        public EditWorkPermitMudsGroupPresenter(IAddEditWorkPermitMudsGroupView view, WorkPermitMudsGroup group, List<WorkPermitMudsGroup> allGroupsInUI) : base(view, allGroupsInUI)
        {            
            editObject = group;            

            view.OkButtonClicked += HandleOkButtonClicked;
            view.CancelButtonClicked += CloseButton_Clicked;
            view.Load += HandleLoad;
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            view.GroupName = editObject.Name;            
        }

        private void HandleOkButtonClicked()
        {
            view.ClearErrors();

            if(IsValid())
            {
                editObject.Name = view.GroupName;
                view.Close();           
            }
        }

        protected override bool GroupAlreadyExists()
        {
            return allGroupsInUI.Find(g => g.Name.Equals(view.GroupName) && !ReferenceEquals(g, editObject)) != null;
        }
    }
}
