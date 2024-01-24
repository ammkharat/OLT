using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class PriorityPageGenericCsdFormContext : GenericCsdFormContext
    {
        private readonly GenericCsd form;
        private readonly GridAndDetailsForm gridAndDetailsForm;

        public PriorityPageGenericCsdFormContext(GridAndDetailsForm gridAndDetailsForm, GenericCsd form,
            IFormEdmontonService formService,
            AbstractMultiGridPage page)
            : base(formService, page)
        {
            this.gridAndDetailsForm = gridAndDetailsForm;
            this.form = form;
        }

        protected override IList<GenericCsdDTO> GetData(DtoFilters filters)
        {
            return new List<GenericCsdDTO> { (GenericCsdDTO)form.CreateDTO() };
        }

        public override GenericCsd QueryById(long id)
        {
            return form;
        }

        protected override bool HandleClose()
        {
            var latestVersionOfForm = formService.QueryMontrealCsdById(form.IdValue);

            if (latestVersionOfForm.FormStatus == FormStatus.Closed)
            {
                OltMessageBox.Show(page.ParentForm, StringResources.FormAlreadyClosedMessage,
                    StringResources.FormAlreadyClosedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var okSelected = base.HandleClose();
                if (!okSelected)
                {
                    // don't close the form
                    return false;
                }
            }

            gridAndDetailsForm.Close();
            return true;
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            // This override is necessary to prevent exceptions. The base class's method subscribes to repeater_Updated which invokes a method
            // on 'page', but we never show 'page' from this presenter so it never gets a window handle and therefore an exception
            // occurs on invoke.
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            // Overridden on purpose. Do not delete.
        }
    }
}