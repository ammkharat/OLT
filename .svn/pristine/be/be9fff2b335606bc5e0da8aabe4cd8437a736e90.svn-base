using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftFormSelectionPresenter
    {
        private readonly IShiftSelectionForm form;
        private readonly List<ShiftPattern> shiftPatterns;
        private ShiftPattern selectedItem;

        public ShiftFormSelectionPresenter(
            IShiftSelectionForm form,
            List<ShiftPattern> shiftPatterns)
        {
            this.form = form;
            this.shiftPatterns = shiftPatterns;
        }

        public void HandleAcceptButtonClick(object sender, EventArgs e)
        {
            if (form.ShiftWasSelected())
            {
                try
                {
                    ResetUserContextShift();
                    form.CloseForm();
                }
                catch (ShiftOutOfBoundsException)
                {
                    form.SetSelectedShiftWasOutsideOfAllowedTimeRangeError = true;
                }

            }
            else
            {
                form.SetNoShiftSelectedError = true;
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            form.ShiftPatternToAddToListView = shiftPatterns;
        }

        public void HandleSelectedItemChanged(object sender, DomainEventArgs<ShiftPattern> args)
        {
            selectedItem = args.SelectedItem;
        }

        public void HandleOnDoubleClick(object sender, DomainEventArgs<ShiftPattern> e)
        {
            HandleAcceptButtonClick(this, EventArgs.Empty);
        }


        private void ResetUserContextShift()
        {
            ClientSession.GetUserContext().UserShift = new UserShift(selectedItem, Clock.Now);
        }
    }
}
