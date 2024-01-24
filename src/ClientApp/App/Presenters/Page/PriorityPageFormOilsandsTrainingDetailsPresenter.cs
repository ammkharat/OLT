using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageFormOilsandsTrainingDetailsPresenter : MultiGridFormPagePresenter
    {
        private readonly FormOilsandsTraining form;
        private readonly IGridAndDetailsView view;

        public PriorityPageFormOilsandsTrainingDetailsPresenter(FormOilsandsTraining form, MultiGridFormPage page, List<IMultiGridContext> contexts) : base(page, contexts)
        {
            this.form = form;
            view = new GridAndDetailsForm();
            view.Title = StringResources.DomainObjectName_FormOilsandsTraining;
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.Details = page.CurrentGridContext.Details;            
            page.CurrentGridContext.MakeAllDetailsButtonsInvisible();
            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }
    }
}