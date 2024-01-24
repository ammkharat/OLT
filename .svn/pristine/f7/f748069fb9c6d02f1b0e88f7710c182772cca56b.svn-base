using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ChangeActiveWorkPermitFunctionalLocationPresenter : MultiSelectFunctionalLocationSelectionFormPresenter, IChangeActiveFunctionalLocationPresenter
    {
        private readonly IChangeActiveFunctionalLocationView view;
        private readonly IFunctionalLocationService flocService;
        private readonly WorkAssignment assignment;

        public ChangeActiveWorkPermitFunctionalLocationPresenter(IChangeActiveFunctionalLocationView view)
            : base(view, ClientSession.GetUserContext().RootFlocSetForWorkPermits.FunctionalLocations)
        {
            this.view = view;
            flocService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            assignment = ClientSession.GetUserContext().Assignment;
        }
       
        public override void Form_Load(object sender, EventArgs e)
        {
            base.Form_Load(sender, e);

            if (assignment == null)
            {
                view.Assignment = StringResources.NullWorkAssignment;
                view.LoadDefaultAssignmentFlocsButtonEnabled = false;
            }
            else
            {
                view.Assignment = assignment.Name;
                view.LoadDefaultAssignmentFlocsButtonEnabled = true;
            }            

            view.UserSelectedFunctionalLocations = ClientSession.GetUserContext().RootFlocSetForWorkPermits.FunctionalLocations;
        }
        
        public void HandleLoadDefaultAssignmentFlocsButtonClick(object sender, EventArgs e)
        {
            if (assignment != null)
            {
                List<FunctionalLocation> flocsForAssignment = flocService.QueryByWorkAssignmentIdForWorkPermits(assignment.IdValue);
                view.UserSelectedFunctionalLocations = flocsForAssignment;
            }
        }
    }
}
