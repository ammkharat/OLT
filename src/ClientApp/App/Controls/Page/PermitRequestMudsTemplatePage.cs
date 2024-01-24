using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestMudsTemplatePage : AbstractPage<PermitRequestMudsDTO, IPermitRequestMudsDetails>, IPermitRequestMudsPage
    {
        public PermitRequestMudsTemplatePage()
            : base(
            new DomainSummaryGrid<PermitRequestMudsDTO>(
                new PermitRequestMudsTemplateGridRenderer(),
                OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                "permitRequestMudsTemplateGrid"),
            new PermitRequestMudsDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.MudsPermitTemplate; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestMudsDTO dto)
        {
            //return false; 
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestMudsDTO dto)
        {
            //return false;
             return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

    }
}
