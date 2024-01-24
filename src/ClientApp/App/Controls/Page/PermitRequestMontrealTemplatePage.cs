using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestMontrealTemplatePage : AbstractPage<PermitRequestMontrealDTO, IPermitRequestMontrealDetails>, IPermitRequestMontrealPage
    {
        public PermitRequestMontrealTemplatePage()
            : base(
            new DomainSummaryGrid<PermitRequestMontrealDTO>(
                new PermitRequestMontrealMarkedTemplateGridRenderer(),
                OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                "permitRequestMarkedTemplateMontrealGrid"),
            new PermitRequestMontrealDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.MontrealPermitTemplate; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestMontrealDTO dto)
        {
            return false; //(dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestMontrealDTO dto)
        {
            return false; //(dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

    }
}
