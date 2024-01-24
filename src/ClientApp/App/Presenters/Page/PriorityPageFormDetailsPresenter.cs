using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageFormDetailsPresenter : MultiGridEdmontonFormPagePresenter
    {
        private readonly IGridAndDetailsView view;

        private readonly IMultiGridContext defaultContext;

        public PriorityPageFormDetailsPresenter(BaseEdmontonForm form, MultiGridFormPage page, IMultiGridContext context)
            : base(page, new List<IMultiGridContext> { context })
        {
            defaultContext = context;
            view = new GridAndDetailsForm {Title = form.FormType.GetName()};
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

        protected override IMultiGridContext GetInitialGridContext()
        {
            return defaultContext;
        }
    }
}

