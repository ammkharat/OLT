﻿using System.Collections.Generic;
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
    public class PriorityPageLubesCsdFormContext : LubesCsdFormContext
    {
        private readonly LubesCsdForm form;
        private readonly GridAndDetailsForm gridAndDetailsForm;

        public PriorityPageLubesCsdFormContext(GridAndDetailsForm gridAndDetailsForm, LubesCsdForm form,
            IFormEdmontonService formService,
            AbstractMultiGridPage page)
            : base(formService, page)
        {
            this.gridAndDetailsForm = gridAndDetailsForm;
            this.form = form;
        }

        protected override IList<LubesCsdFormDTO> GetData(DtoFilters filters)
        {
            return new List<LubesCsdFormDTO> {(LubesCsdFormDTO) form.CreateDTO()};
        }

        public override LubesCsdForm QueryById(long id)
        {
            return form;
        }

        protected override bool HandleClose()
        {
            var latestVersionOfForm = formService.QueryLubesCsdFormById(form.IdValue);

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