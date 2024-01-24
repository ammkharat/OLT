using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class MultiGridMontrealFormPagePresenter : AbstractMultiGridPagePresenter
    {
        private static readonly EdmontonFormType InitialDropdownSelection = EdmontonFormType.MontrealCsd;

        protected MultiGridMontrealFormPagePresenter(MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page,
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            page.LoadContexts(contexts);
        }

        public IMultiGridContextSelection CurrentGridContext
        {
            get { return page.CurrentGridContext.Key; }
        }

        public static MultiGridMontrealFormPagePresenter Create()
        {
            var page = new MultiGridFormPage();

            var formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            var contexts = new List<IMultiGridContext>
            {
                new MontrealCsdFormContext(formService, page),
            };
            
            contexts.Sort((a, b) => a.Key.SortOrder.CompareTo(b.Key.SortOrder));

            contexts.ForEach(c => page.AddNodeToSelectionList(c.Key));
            page.SetSelectedGridSelectionListNode(InitialDropdownSelection);

            return new MultiGridMontrealFormPagePresenter(page, contexts);
        }

        protected override IMultiGridContext ChangeContext(IMultiGridContextSelection gridContextSelection)
        {
            var context = page.GetContext(gridContextSelection);
            page.SetGridAndDetails(context.Grid, context.Details);
            return context;
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            return page.GetContext(InitialDropdownSelection);
        }
    }
}