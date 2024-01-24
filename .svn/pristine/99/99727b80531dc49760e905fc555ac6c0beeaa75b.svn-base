using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;


namespace Com.Suncor.Olt.Client.Presenters
{
   public class FormGN75BTemplateSelectionPresenter
    {
        private readonly IFormGN75BTemplateSelectionForm form;
        private readonly List<FormGN75BTemplatePattern> formPatterns;
        private FormGN75B selectedItem;

            public FormGN75BTemplateSelectionPresenter(
            IFormGN75BTemplateSelectionForm form,
            List<FormGN75BTemplatePattern> formpatterns)
        {
            this.form = form;
            this.formPatterns = formpatterns;
        }

        public void HandleAcceptButtonClick(object sender, EventArgs e)
        {
            if (form.formWasSelected())
            {
                try
                {
                    form.CloseForm();
                }
                catch (ShiftOutOfBoundsException)
                {
                    //form. SetSelectedShiftWasOutsideOfAllowedTimeRangeError = true;
                }

            }
            else
            {
                //form.SetNoShiftSelectedError = true;
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            form.FormGN75BTemplatesToAddToListView = formPatterns;
        }

        public void HandleSelectedItemChanged(object sender, DomainEventArgs<FormGN75B> args)
        {
            selectedItem = args.SelectedItem;
        }

        public void HandleOnDoubleClick(object sender, DomainEventArgs<ShiftPattern> e)
        {
            HandleAcceptButtonClick(this, EventArgs.Empty);
        }

    }
}
