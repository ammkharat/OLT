using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ConfinedSpaceMudsPagePresenter : AbstractDeletableDomainPagePresenter<ConfinedSpaceMudsDTO, ConfinedSpaceMuds, IConfinedSpaceMudsDetails, IConfinedSpaceMudsPage>
    {
        private readonly IConfinedSpaceMudsService confinedSpaceService;
        private readonly IReportPrintManager<ConfinedSpaceMuds> reportPrintManager;
        private readonly IGasTestElementInfoService gasTestElementInfoService;

        public ConfinedSpaceMudsPagePresenter() : this(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT)
        {
        }

        public ConfinedSpaceMudsPagePresenter(OltGridAppearance appearance)
            : base(
            new ConfinedSpaceMudsPage(appearance),
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            confinedSpaceService = ClientServiceRegistry.Instance.GetService<IConfinedSpaceMudsService>();
            SubscribeToEvents();

            reportPrintManager = new ReportPrintManager<ConfinedSpaceMuds, ConfinedSpaceMudsReport, ConfinedSpaceMudsReportAdapter>(
                    new ConfinedSpaceMudsPrintActions(page, confinedSpaceService));
            gasTestElementInfoService = ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>();
        }

        private void SubscribeToEvents()
        {
            page.Details.Clone += Details_Clone;
            page.Details.Print += Details_Print;
            page.Details.PrintPreview += Details_PrintPreview;
        }

        protected override void UnSubscribeFromEvents()
        {
            page.Details.Clone -= Details_Clone;
            page.Details.Print -= Details_Print;
            page.Details.PrintPreview -= Details_PrintPreview;
        }

        private void Details_Clone(object sender, EventArgs e)
        {
            ConfinedSpaceMuds item = QueryForFirstSelectedItem();
            if (item.GasTests.Elements.Count != 0)
            {
                item.GasTests.GasTestFirstResultTime = null;

                for (int i = 0; i < item.GasTests.Elements.Count; i++)
                {
                    item.GasTests.Elements[i].ConfinedSpaceTestRequired = false;
                    item.GasTests.Elements[i].ImmediateAreaTestRequired = false;
                }

            }

           
           IForm form = CreateEditForm(item.CreateCopy());

           // IForm form = CreateEditForm(item);

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_Print(object sender, EventArgs args)
        {

            if (ClientSession.GetUserContext().SiteConfiguration.EnableWorkPermitSignature)
            {
                ConfinedSpaceMudsSign confinedSpaceMudSign = new ConfinedSpaceMudsSign(page.SelectedItems[0]);
                QueryStandardGasTestElementInfoList();
                confinedSpaceMudSign.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);

                DialogResult Result = confinedSpaceMudSign.ShowDialog();
                if (Result == DialogResult.Yes)
                {
                    PrintWithDialogFocus(Print);
                }
            }
           
        }

        private void Print()
        {
                    
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
                
        }

        private void Details_PrintPreview(object sender, EventArgs args)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        protected override ConfinedSpaceMuds QueryByDto(ConfinedSpaceMudsDTO dto)
        {
            return confinedSpaceService.QueryById(dto.IdValue);
        }

        protected override IList<ConfinedSpaceMudsDTO> GetDtos(Range<Date> dateRange)
        {
            return confinedSpaceService.QueryByFlocUnitAndBelow(userContext.RootFlocSet, new DateRange(dateRange));
        }

        protected override ConfinedSpaceMudsDTO CreateDTOFromDomainObject(ConfinedSpaceMuds item)
        {
            return new ConfinedSpaceMudsDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ConfinedSpace; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerConfinedSpaceMudsCreated += repeater_Created;
            remoteEventRepeater.ServerConfinedSpaceMudsUpdated += repeater_Updated;
            remoteEventRepeater.ServerConfinedSpaceMudsRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerConfinedSpaceMudsCreated -= repeater_Created;
            remoteEventRepeater.ServerConfinedSpaceMudsUpdated -= repeater_Updated;
            remoteEventRepeater.ServerConfinedSpaceMudsRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            List<ConfinedSpaceMudsDTO> selectedDtos = page.SelectedItems;
            bool hasSingleItemSelected = selectedDtos.Count == 1;
            bool hasItemsSelected = selectedDtos.Count > 0;

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            IConfinedSpaceMudsDetails details = page.Details;
            details.PrintEnabled = hasItemsSelected && authorized.ToPrintConfinedSpace(userRoleElements);
            details.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintConfinedSpace(userRoleElements);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditConfinedSpace(userRoleElements, selectedDtos[0]);
            details.DeleteEnabled = hasItemsSelected &&
                                    authorized.ToDeleteConfinedSpace(userRoleElements, selectedDtos);
            details.CloneEnabled = hasSingleItemSelected &&
                                   authorized.ToCreateConfinedSpace(userRoleElements);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
        }

        protected override void SetDetailData(IConfinedSpaceMudsDetails details, ConfinedSpaceMuds item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(ConfinedSpaceMuds item)
        {
            return new ConfinedSpaceMudsHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(ConfinedSpaceMuds item)
        {
            ConfinedSpaceFormMudsPresenter confinedSpaceFormPresenter = new ConfinedSpaceFormMudsPresenter(item);
            return confinedSpaceFormPresenter.View;
        }

        protected override void Delete(ConfinedSpaceMuds item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(confinedSpaceService.Remove, item);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date start = now.SubtractDays(1);
            return new Range<Date>(start, null);
        }

        protected override bool IsItemInDateRange(ConfinedSpaceMuds confinedSpace, Range<Date> range)
        {
            if (confinedSpace.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            else
            {
                DateRange dateRange = new DateRange(range ?? GetDefaultDateRange());
                return dateRange.Overlaps(confinedSpace.StartDateTime, confinedSpace.EndDateTime);
            }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ConfinedSpace; }
        }
        //Added by ppanigrahi

        private void ViewGastest(object sender, EventArgs e)
        {
            QueryStandardGasTestElementInfoList();
            GasTestMudsForm gasTestMudsForm = new GasTestMudsForm();
            gasTestMudsForm.workpermitId = page.FirstSelectedItem.IdValue;
            gasTestMudsForm.permitnumber = Convert.ToString(page.FirstSelectedItem.ConfinedSpaceNumber);
          //  gasTestMudsForm.Permitstatus = page.FirstSelectedItem.Status;
            gasTestMudsForm.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);
            gasTestMudsForm.ShowDialog();
        }

        private List<GasTestElementInfo> standardGasTestElementInfoList;

        private void QueryStandardGasTestElementInfoList()
        {

            standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
        }
    }
}