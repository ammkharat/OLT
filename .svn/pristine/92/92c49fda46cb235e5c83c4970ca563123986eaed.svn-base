
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;


namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitFortHillsBusinessLogic
    {
        private readonly IWorkPermitFortHillsView view;
        
        public WorkPermitFortHillsBusinessLogic(IWorkPermitFortHillsView view)
        {
            this.view = view;
        }

        public void ForceExecutionOfBusinessLogic()
        {
            HandleLockBoxRequiredCheckChange();

        }


        public void HandleLockBoxRequiredCheckChange()
        {
            view.IsFieldTourRequired = view.LockBoxnumberChecked;
            view.IsFieldTourRequiredEnabled = view.LockBoxnumberChecked;
            view.PartEWorkSectionNotApplicableToJob = !view.LockBoxnumberChecked;
            view.PartEWorkSectionNotApplicableToJobEnabled = !view.LockBoxnumberChecked;
        }

        //public void HandleConfinedSpaceClassChanged()
        //{
           
        //}

        public void HandlePermitTypeSelectedValueChanged()
        {
            if (view.WorkPermitType == WorkPermitFortHillsType.SPECIFIC_HOT)
            {
                view.PartGWorkSectionNotApplicableToJob = false;
                view.PartGWorkSectionNotApplicableToJobEnabled = false;
            }
        }

        //public void HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged()
        //{
           
        //}
    }
}
