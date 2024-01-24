using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    /// <summary>
    /// Renders WorkPermit Properties to a ListViewItem
    /// </summary>
    public class WorkPermitListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<WorkPermit>
    {
        public ListViewItem RenderItem(WorkPermit workPermit)
        {
            var lvi = new DomainListViewItem<WorkPermit>(workPermit) {Text = workPermit.PermitNumber};

            WorkPermitSpecifics specifics = workPermit.Specifics;
            lvi.SubItems.Add(specifics.WorkOrderNumber);
            lvi.SubItems.Add(specifics.FunctionalLocation.FullHierarchy);
            lvi.SubItems.Add(specifics.StartDateTime.ToLongDateAndTimeString());
            lvi.SubItems.Add(specifics.WorkOrderDescription);
            lvi.SubItems.Add(specifics.CraftOrTrade.Name);

            return lvi;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn permitNumberColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                              {
                                                                  Name = "PermitNumber",
                                                                  Text = RendererStringResources.PermitNumber
                                                              };

                DomainListViewColumn workOrderColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                           {
                                                               Name = "WorkOrderNumber",
                                                               Text = RendererStringResources.WorkOrderNumber
                                                           };

                DomainListViewColumn flocColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                      {
                                                          Name = "FunctionalLocationName",
                                                          Text = RendererStringResources.Floc
                                                      };

                DomainListViewColumn startDateColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                           {
                                                               Name = "StartDateTime",
                                                               Text = RendererStringResources.StartDate
                                                           };

                var descriptionColumn = new DomainListViewColumn.ManualColumn
                                            {
                                                Name = "WorkOrderDescription",
                                                Text = RendererStringResources.Description,
                                                Width = 200
                                            };

                DomainListViewColumn tradeColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                       {
                                                           Name = "CraftOrTradeName",
                                                           Text = RendererStringResources.Trade
                                                       };

                return new DomainListViewColumnCollection(
                    permitNumberColumn,
                    workOrderColumn,
                    flocColumn,
                    startDateColumn,
                    descriptionColumn,
                    tradeColumn);
            }
        }
    }
}
