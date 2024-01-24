using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{

    public class PriorityPageActionItemDetailsPresenter : PriorityPageDetailsPresenter<IActionItemDetails>
    {
        private readonly IAuthorized authorized;
        private readonly IActionItemService actionItemService;
        private readonly IFormEdmontonService formEdmontonService;
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        
        private readonly ActionItem actionItem;
        private readonly IFormEdmontonService formService;
        private readonly IReportPrintManager<FormGN75B> reportPrintManagerForGn75B;


        public PriorityPageActionItemDetailsPresenter(long id, IAuthorized authorized, IActionItemService service, IFormEdmontonService formService)
            : base(
                StringResources.DomainObjectName_ActionItem,
                new ActionItemDetails())
        {
            var clientServiceRegistry = Com.Suncor.Olt.Client.Services.ClientServiceRegistry.Instance;
            authorized = new Authorized();
            
            actionItemService = clientServiceRegistry.GetService<IActionItemService>();
            formEdmontonService = clientServiceRegistry.GetService<IFormEdmontonService>();
            actionItemDefinitionService = clientServiceRegistry.GetService<IActionItemDefinitionService>();

            this.formService = formService;

            actionItem = service.QueryById(id);
            details.actionItemImage = actionItem.Imagelist;  //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            details.SetDetails(actionItem, userContext.IsEdmontonSite,true);

            details.MakeAllButtonsInvisible();
            details.RespondVisible = true;

            details.RespondEnabled = authorized.ToRespondActionItem(userContext.UserRoleElements,
                                                                    new ActionItemDTO(actionItem));
            details.Respond += Details_Respond;
            details.ViewAssociatedGN75B += ViewAssociatedGn75B;

            //Added GoToDefinition button for Edmonton site.
            details.GoToDefinitionVisible = false;
            //details.GoToDefinitionVisible = userContext.IsEdmontonSite ? true : false;
            //details.GoToDefinitionEnabled = authorized.ToRespondActionItem(userContext.UserRoleElements,
            //                                                        new ActionItemDTO(actionItem));
            //details.GoToDefinition += Details_GoToDefinition;
       
            
            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions = new EdmontonGN75BFormPrintActions(formService);
            reportPrintManagerForGn75B = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);

            //mangesh- DMND0005327- Requet 15
            details.ViewAssociatedGN75B1 += ViewAssociatedGn75B1;
            details.ViewAssociatedGN75B2+= ViewAssociatedGn75B2;
            details.EditAssociatedGN75B += EditAssociatedGn75B;
            details.EditAssociatedGN75B1 += EditAssociatedGn75B1;
            details.EditAssociatedGN75B2 += EditAssociatedGn75B2;
        }

        protected override void UnsubscribeToEvents()
        {
            details.Respond -= Details_Respond;
            details.ViewAssociatedGN75B -= ViewAssociatedGn75B;

            details.GoToDefinition -= Details_GoToDefinition;

            //mangesh- DMND0005327- Requet 15
            details.ViewAssociatedGN75B1 -= ViewAssociatedGn75B1;
            details.ViewAssociatedGN75B2 -= ViewAssociatedGn75B2;
            details.EditAssociatedGN75B -= EditAssociatedGn75B;
            details.EditAssociatedGN75B1 -= EditAssociatedGn75B1;
            details.EditAssociatedGN75B2 -= EditAssociatedGn75B2;
        }

        private void ViewAssociatedGn75B()
        {
            long? associatedGn75BFormNumber = details.AssociatedGn75BFormNumber;
            if (!associatedGn75BFormNumber.HasValue)
                return;

            FormGN75B formGn75B = formService.QueryFormGN75BById(associatedGn75BFormNumber.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B);
        }
        //mangesh- DMND0005327- Requet 15
        private void ViewAssociatedGn75B1()
        {
            long? associatedGn75BFormNumber1 = details.AssociatedGn75BFormNumber1;
            if (!associatedGn75BFormNumber1.HasValue)
                return;

            FormGN75B formGn75B1 = formService.QueryFormGN75BById(associatedGn75BFormNumber1.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B1);
        }
        //mangesh- DMND0005327- Requet 15
        private void ViewAssociatedGn75B2()
        {
            long? associatedGn75BFormNumber2 = details.AssociatedGn75BFormNumber2;
            if (!associatedGn75BFormNumber2.HasValue)
                return;

            FormGN75B formGn75B2 = formService.QueryFormGN75BById(associatedGn75BFormNumber2.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B2);
        }

        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B()
        {
            long? associatedGn75BFormNumber = details.AssociatedGn75BFormNumber;
            if (!associatedGn75BFormNumber.HasValue)
                return;

            FormGN75B formGn75B = formService.QueryFormGN75BById(associatedGn75BFormNumber.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B);
            presenter.Run(null); 
        }
        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B1()
        {
            long? associatedGn75BFormNumber1 = details.AssociatedGn75BFormNumber1;
            if (!associatedGn75BFormNumber1.HasValue)
                return;

            FormGN75B formGn75B1 = formService.QueryFormGN75BById(associatedGn75BFormNumber1.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B1);
            presenter.Run(null); 
        }
        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B2()
        {
            long? associatedGn75BFormNumber2 = details.AssociatedGn75BFormNumber2;
            if (!associatedGn75BFormNumber2.HasValue)
                return;

            FormGN75B formGn75B2 = formService.QueryFormGN75BById(associatedGn75BFormNumber2.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B2);
            presenter.Run(null);
        }

        private void Details_Respond(object sender, EventArgs e)
        {
            LockResult<DialogResult> lockResult = LockDatabaseObjectWhileInUse<ActionItem, DialogResult>(Respond, actionItem);

            if (lockResult.LockAquired && lockResult.ActionResult == DialogResult.OK)
            {
                view.Close();
            }
        }

        private DialogResult Respond(ActionItem item)
        {
            ActionItemResponseForm form = new ActionItemResponseForm(item, ActionItemStatus.AvailableForCurrentView, ActionItemStatus.Complete);
            DialogResult dialogResult = form.ShowDialog(view);
            form.Dispose();

            return dialogResult;
        }

        void Details_GoToDefinition(object sender, EventArgs e)
        {
            //var page = new ActionItemDefinitionPagePresenter();
            var presenter =
                    new PriorityPageActionItemDefinitionDetailsPresenter(actionItem.DefinitionId, 
                        actionItemDefinitionService);
            presenter.Run(null);
            
        }
       
    }

}