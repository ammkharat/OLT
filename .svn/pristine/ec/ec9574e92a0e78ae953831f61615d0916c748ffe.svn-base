using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsTradeChecklistRenderer : BaseListViewRenderer, IDomainListViewRenderer<TradeChecklist>
    {
        private bool isCseLevel3;

        public ListViewItem RenderItem(TradeChecklist item)
        {
            DomainListViewItem<TradeChecklist> listViewItem = new DomainListViewItem<TradeChecklist>(item) {Text = item.TradeChecklistDisplayNumber};
            listViewItem.SubItems.Add(item.Trade);
            listViewItem.SubItems.Add(item.LastModifiedDateTime.ToLongDateAndTimeString());
            
            if (isCseLevel3)
            {
                listViewItem.SubItems.Add(string.Empty);
                listViewItem.SubItems.Add(string.Empty);
                listViewItem.SubItems.Add(string.Empty);
            }
            else
            {
                listViewItem.SubItems.Add(item.ConstFieldMaintCoordApproval ? StringResources.Approved : StringResources.NotApproved);
                listViewItem.SubItems.Add(item.OpsCoordApproval ? StringResources.Approved : StringResources.NotApproved);
                listViewItem.SubItems.Add(item.AreaManagerApproval ? StringResources.Approved : StringResources.NotApproved);
            }
            return listViewItem;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn formNumberColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn tradeColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn lastModifiedDateTimeColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn constFieldMaintCoordApprovalColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn opsCoordApprovalColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn areaManagerApprovalColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();

                formNumberColumn.Name = "TradeChecklistDisplayNumber";
                tradeColumn.Name = "Trade";
                lastModifiedDateTimeColumn.Name = "LastModifiedDateTime";
                constFieldMaintCoordApprovalColumn.Name = "ConstFieldMaintCoordApproval";
                opsCoordApprovalColumn.Name = "OpsCoordApproval";
                areaManagerApprovalColumn.Name = "AreaManagerApproval";

                formNumberColumn.Text = RendererStringResources.FormNumber;
                tradeColumn.Text = RendererStringResources.Trade;
                lastModifiedDateTimeColumn.Text = RendererStringResources.LastModified;
                constFieldMaintCoordApprovalColumn.Text = FormGN1.ConstFieldMaintCoordApprovalName;
                opsCoordApprovalColumn.Text = FormGN1.OpsCoordApprovalName;
                areaManagerApprovalColumn.Text = FormGN1.AreaManagerApprovalName;

                return new DomainListViewColumnCollection(formNumberColumn, tradeColumn, lastModifiedDateTimeColumn, constFieldMaintCoordApprovalColumn, opsCoordApprovalColumn, areaManagerApprovalColumn);
            }
        }

        public string CseLevel
        {
            set { isCseLevel3 = WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(value); }
        }
    }
}