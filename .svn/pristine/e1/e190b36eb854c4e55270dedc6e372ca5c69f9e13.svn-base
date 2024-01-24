using System.Collections.Generic;
using System.ServiceModel.Channels;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services; 

namespace Com.Suncor.Olt.Client.Presenters.Page                                                                                
{
    public class MultiGridSarniaFormPagePresenter : AbstractMultiGridPagePresenter
    {
        private static EdmontonFormType initialDropdownSelection = EdmontonFormType.GN75BSarniaEIP;    //ayman Sarnia eip DMND0008992
        //private List<IMultiGridContext> mycontexts = new List<IMultiGridContext>();                             //ayman Sarnia eip DMND0008992

        protected MultiGridSarniaFormPagePresenter(MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page,
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IUserService>())
        
        
        {
            page.LoadContexts(contexts);
        }
      
        public static MultiGridSarniaFormPagePresenter Create()
        {
            // ayman Sarnia form name
            EdmontonFormTypeName.EdmontonFormTypeSite = ClientSession.GetUserContext().SiteId;

            MultiGridFormPage page = new MultiGridFormPage();                     

            IFormEdmontonService formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            Authorized authorized = new Authorized();
            List<IMultiGridContext> mycontexts = new List<IMultiGridContext>{};

            if ((authorized.ToCreateEipIssue(ClientSession.GetUserContext().UserRoleElements) || authorized.ToEditEipIssue(ClientSession.GetUserContext().UserRoleElements)) ) //ayman Sarnia eip DMND0008992
            {
                List<IMultiGridContext> contexts = new List<IMultiGridContext>
                {
                    new EdmontonOP14FormContext(formService, page),
                    new EdmontonGN75BSarniaEIPContext(formService, page),
                    new EdmontonGN75BTemplateContext(formService, page) //ayman Sarnia eip DMND0008992
                };
                mycontexts = contexts;
            }
            else
            {
                List<IMultiGridContext> contexts = new List<IMultiGridContext>
                {
                    new EdmontonOP14FormContext(formService, page),
                //    new EdmontonGN75BTemplateContext(formService, page) //ayman Sarnia eip DMND0008992
                };
                mycontexts = contexts;
            }


            //ayman Sarnia eip DMND0008992
            //if (!mycontexts.Contains(initialDropdownSelection))
            initialDropdownSelection = (EdmontonFormType)mycontexts[0].Key; 

            mycontexts.Sort((a, b) => a.Key.SortOrder.CompareTo(b.Key.SortOrder));

            mycontexts.ForEach(c => page.AddNodeToSelectionList(c.Key));
            page.SetSelectedGridSelectionListNode(initialDropdownSelection);


            return new MultiGridSarniaFormPagePresenter(page, mycontexts);
        }

        protected override IMultiGridContext ChangeContext(IMultiGridContextSelection gridContextSelection)
        {
            IMultiGridContext context = page.GetContext(gridContextSelection);
            page.SetGridAndDetails(context.Grid, context.Details);
            return context;
        }
        
        protected override IMultiGridContext GetInitialGridContext()
        {
            return page.GetContext(initialDropdownSelection);
        }

        public IMultiGridContextSelection CurrentGridContext
        {
            get { return page.CurrentGridContext.Key; }
        }
    }
}