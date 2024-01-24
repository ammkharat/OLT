using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class WorkPermitLubesPage : AbstractPage<WorkPermitLubesDTO, IWorkPermitLubesDetails>, IWorkPermitLubesPage
    {
        public WorkPermitLubesPage(OltGridAppearance appearance)
            : base(
                new DomainSummaryGrid<WorkPermitLubesDTO>(new WorkPermitLubesGridRenderer(), appearance, "workPermitLubesGrid"),
                new WorkPermitLubesDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(WorkPermitLubesDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(WorkPermitLubesDTO dto)
        {
            return (dto != null && dto.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }

        public override PageKey PageKey
        {
            get { return PageKey.WORK_PERMIT_PAGE; }
        }

        public void ShowAssociatedLogForm(List<LogDTO> associatedLogDtos)
        {
            ReferencedLogForm form = new ReferencedLogForm(associatedLogDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }

        public void ShowCannotPrintMessage()
        {
            OltMessageBox.Show(ParentForm, StringResources.WorkPermitLubes_CannotPrint, StringResources.WorkPermitLubes_CannotPrintTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
