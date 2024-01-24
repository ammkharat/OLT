using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class FormPage<TDto, TDetails> : AbstractPage<TDto, TDetails>
        where TDto : DomainObject, IFormEdmontonDTO
        where TDetails : IFormEdmontonDetails
    {
        public FormPage(TDetails details, Range<Date> dateRangeOfPermitRequest) : this(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, new FormEdmontonGridRenderer(dateRangeOfPermitRequest), details)
        {

        }

        public FormPage(TDetails details, Range<Date> dateRangeOfPermitRequest, bool useValidFromWordingForDateColumns, bool showTradesColumn) : 
            this(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, new FormEdmontonGridRenderer(dateRangeOfPermitRequest, useValidFromWordingForDateColumns, showTradesColumn), details)
        {

        }

        public FormPage(TDetails details, Range<DateTime> datetimeRangeOfWorkPermit) : this(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, new FormEdmontonGridRenderer(datetimeRangeOfWorkPermit), details)
        {
            
        }

        public FormPage(TDetails details, Range<DateTime> datetimeRangeOfWorkPermit, bool useValidFromWordingForDateColumns, bool showTradesColumn) : 
            this(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, new FormEdmontonGridRenderer(datetimeRangeOfWorkPermit, useValidFromWordingForDateColumns,showTradesColumn), details)
        {
            
        }

        public FormPage(IGridRenderer formGridRenderer, TDetails details) : this(OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, formGridRenderer, details)
        {            
        }

        public FormPage(OltGridAppearance appearance, IGridRenderer formGridRenderer, TDetails details)
            : base(new DomainSummaryGrid<TDto>(formGridRenderer, appearance, "formGrid"), details)
        {
        }

        protected override bool IsCreatedByCurrentUser(TDto dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(TDto dto)
        {
            return (dto != null && dto.LastModifiedByUserId == ClientSession.GetUserContext().User.Id);
        }

        public override PageKey PageKey
        {
            get { return PageKey.FORM_PAGE; }
        }

        public void CloseSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.CloseSuccessfulMessage,
                               StringResources.CloseSuccessfulTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }
    }
}