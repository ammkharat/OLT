﻿using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class MultiGridWoodBuffaloRegionFormPagePresenter : AbstractMultiGridPagePresenter
    {
        private static readonly EdmontonFormType InitialForm = EdmontonFormType.DocumentSuggestion;

        protected MultiGridWoodBuffaloRegionFormPagePresenter(MultiGridFormPage page, List<IMultiGridContext> contexts)
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

        public static MultiGridWoodBuffaloRegionFormPagePresenter Create()
        {

            // ayman selc
            EdmontonFormTypeName.EdmontonFormTypeSite = ClientSession.GetUserContext().SiteId;

            var page = new MultiGridFormPage();

            var authorized = new Authorized();
            var context = ClientSession.GetUserContext();

            var canViewProcedureDeviationFormInList =
                authorized.ToViewProcedureDeviationOnPrioritiesPage(context.UserRoleElements, context.SiteId) ||
                authorized.ToCreateFormProcedureDeviation(context.UserRoleElements, context.SiteId) ||
                authorized.ToEditFormProcedureDeviation(context.UserRoleElements, context.SiteId); 

            page.AddNodeToSelectionList(EdmontonFormType.DocumentSuggestion);

            if (canViewProcedureDeviationFormInList)
            {
                page.AddNodeToSelectionList(EdmontonFormType.ProcedureDeviation);
            }

            // ayman selc
            if (authorized.ToCreateForms(context.UserRoleElements, context.Site))
            {
                page.AddNodeToSelectionList(EdmontonFormType.OP14);
            }

            page.SetSelectedGridSelectionListNode(InitialForm);

            var edmontonService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            var contexts = new List<IMultiGridContext>
            {
                new DocumentSuggestionFormContext(edmontonService, page),
                new ProcedureDeviationFormContext(edmontonService, page),
               // new EdmontonOP14FormContext(edmontonService, page)                 //ayman selc
                 new GenericCsdFormContext(edmontonService, page)

            };
            if(ClientSession.GetUserContext().IsSelcSite)
               {
                   contexts.Add(new CSDPipelineFormContext(edmontonService, page)); //DMND0010261-SELC CSD EdmontonPipeline
               }

            //Training eform for ETF  - mangesh
            var formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();
            var CanViewTrainingForm = authorized.ToViewTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToEditTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToCloseTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToCreateTrainingForm(context.UserRoleElements, context.Site);
            if (CanViewTrainingForm) 
            {
                page.AddNodeToSelectionList(OilsandsFormType.Training);
                contexts.Add(new OilsandsTrainingFormContext(formService, page));
            }
            //--

            return new MultiGridWoodBuffaloRegionFormPagePresenter(page, contexts);
        }

        protected override IMultiGridContext ChangeContext(IMultiGridContextSelection gridContextSelection)
        {
            var context = page.GetContext(gridContextSelection);
            page.SetGridAndDetails(context.Grid, context.Details);
            return context;
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            return page.GetContext(InitialForm);
        }
    }
}