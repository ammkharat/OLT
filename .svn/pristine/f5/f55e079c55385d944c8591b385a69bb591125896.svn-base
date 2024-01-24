using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using System;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageFormGenericTemplateDetailsPresenter : MultiGridEdmontonFormPagePresenter
    {
        private readonly IGridAndDetailsView view;
        private long formtypeid;

        public PriorityPageFormGenericTemplateDetailsPresenter(GridAndDetailsForm gridAndDetailsForm, MultiGridFormPage page, List<IMultiGridContext> contexts, long formtypeid)
            : base(page, contexts)
        {
            view = gridAndDetailsForm;
            view.Title = Convert.ToString(FormGenericTemplate.getUserGridLayoutIdentifier(formtypeid)); //StringResources.DomainObjectName_FormGenericTemplate;
            this.formtypeid = formtypeid;
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.Details = page.CurrentGridContext.Details;

            FormGenericTemplateDetails details = (FormGenericTemplateDetails)page.CurrentGridContext.Details;
            view.Details = details;
            details.MakeAllButtonsInvisible();
            details.PrintButtonVisible = true;

            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            return page.GetContext(FormGenericTemplate.getEdmontonFormType(formtypeid));
        }

    }
}
