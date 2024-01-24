using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectFormGN75BTemplatePresenter : SelectEIPTemplatePresenter<FormEdmontonGN75BDTO, FormGN75B, FormEdmontonGN75BDetails, FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails>>
    {
         public SelectFormGN75BTemplatePresenter(FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails> formPage) : base(EdmontonFormType.GN75BTemplate, formPage, default(Range<Date>))
        {
        }

        protected override bool IsItemInDateRange(FormGN75B item, Range<Date> range)
        {
            return true;
        }

        protected override string GetPageTitleOverride()
        {
            return StringResources.FormGn75B_Select_Grid_Filter;
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return null;
        }

        // This shouldn't matter, because we don't save the layout for these, but it's good to have a separate identifier in case someone saves a generic one and it tries to apply it here.
        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN75BSelector; }
        }
    }
}
