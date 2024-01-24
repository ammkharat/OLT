using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class PriorityPageEdmontonGenericTemplateFormContext : GenericTemplateFormContext
    {
        private readonly GridAndDetailsForm gridAndDetailsForm;
        private readonly FormGenericTemplate form;
        private long formtypeid;
        private long plantid;
        public PriorityPageEdmontonGenericTemplateFormContext(GridAndDetailsForm gridAndDetailsForm, FormGenericTemplate form, IFormEdmontonService formService,
                                                   AbstractMultiGridPage page, long formtypeid, long plantID)
            : base(formService, page, formtypeid)
        {
            this.gridAndDetailsForm = gridAndDetailsForm;
            this.form = form;
            this.formtypeid = formtypeid;
            this.plantid = plantID;
        }

        protected override IList<FormGenericTemplateDTO> GetData(DtoFilters filters)
        {
            return new List<FormGenericTemplateDTO> { (FormGenericTemplateDTO)form.CreateDTO() };
        }

        public override FormGenericTemplate QueryById(long id)
            {
                return form;
            }

        protected override bool HandleClose()
        {   
            FormGenericTemplate latestVersionOfForm = formService.QueryFormGenericTemplateByIdAndSiteId(form.IdValue,//TODO
                form.SiteId, formtypeid, plantid); // INC0251500 - mangesh

            if (latestVersionOfForm.FormStatus == FormStatus.Closed)
            {
                OltMessageBox.Show(page.ParentForm, StringResources.FormAlreadyClosedMessage, StringResources.FormAlreadyClosedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool okSelected = base.HandleClose();
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