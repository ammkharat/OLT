using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class MultiGridEdmontonFormPagePresenter : AbstractMultiGridPagePresenter
    {
        private static readonly EdmontonFormType initialDropdownSelection = EdmontonFormType.GN1;

        protected MultiGridEdmontonFormPagePresenter(MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page,
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            page.LoadContexts(contexts);
        }
      
        public static MultiGridEdmontonFormPagePresenter Create()
        {
            MultiGridFormPage page = new MultiGridFormPage();                     

            IFormEdmontonService formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            
            List<long> PlantIds = ClientSession.GetUserContext().PlantIds;


            List<IMultiGridContext> contexts = new List<IMultiGridContext>
                {
                    new EdmontonGN1FormContext(formService, workPermitEdmontonService, page),
                    new EdmontonGN7FormContext(formService, workPermitEdmontonService, page),
                    new EdmontonGN59FormContext(formService, workPermitEdmontonService, page),
                    new EdmontonOP14FormContext(formService, page),
                    new EdmontonGN24FormContext(formService, workPermitEdmontonService, page),
                    new EdmontonGN6FormContext(formService, workPermitEdmontonService, page),
                    new EdmontonGN75AFormContext(formService, workPermitEdmontonService, page),
                    new EdmontonGN75BFormContext(formService, page)
                    //new GenericTemplateFormContext(formService, page, 1001),
                    //new GenericTemplateFormContext(formService, page, 1002),
                    //new GenericTemplateFormContext(formService, page, 1003),
                    //new GenericTemplateFormContext(formService, page, 1004),
                    //new GenericTemplateFormContext(formService, page, 1005),
                    //new GenericTemplateFormContext(formService, page, 1006)
                };

            //TODO to update code and test by passing parameter FormEdmontonType instead of its value
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements,null,
                    EdmontonFormType.OdourNoiseComplaint, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1001));

            }
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.Deviation, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1002));

            }
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.RoadClosure, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1003));

            }
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.GN11GroundDisturbance, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1004));

            }
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.GN27FreezePlug, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1005));

            }
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.HazardAssessment, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1006));

            }

            //TASK0593631 - mangesh
            if (new Authorized().ToViewFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, null,
                    EdmontonFormType.NonEmergencyWaterSystemApproval, ClientSession.GetUserContext().Site))
            {
                contexts.Add(new GenericTemplateFormContext(formService, page, 1009));

            }


            if (new Authorized().ToViewOvertimeForm(ClientSession.GetUserContext().UserRoleElements))
            {
                contexts.Add(new EdmontonOvertimeFormContext(formService, page));
                
            }

            contexts.Sort((a,b) => a.Key.SortOrder.CompareTo(b.Key.SortOrder));

            contexts.ForEach(c => page.AddNodeToSelectionList(c.Key));
            page.SetSelectedGridSelectionListNode(initialDropdownSelection);

            return new MultiGridEdmontonFormPagePresenter(page, contexts);
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