using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFormOilsandsTrainingItemRenderer : BaseListViewRenderer, IDomainListViewRenderer<FormOilsandsTrainingItem>
    {
        public ListViewItem RenderItem(FormOilsandsTrainingItem item)
        {
            DomainListViewItem<FormOilsandsTrainingItem> listViewItem = new DomainListViewItem<FormOilsandsTrainingItem>(item);
            listViewItem.Text = item.TrainingBlock.Name;
            listViewItem.SubItems.Add(item.Comments);
            listViewItem.SubItems.Add(item.Supervisor);                                   //ayman training form add column
            listViewItem.SubItems.Add(item.BlockCompleted.BooleanToYesNoString());
            listViewItem.SubItems.Add(item.Hours.ToString());
            return listViewItem;
        }


        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn trainingBlockColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn commentsBlockColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn supervisorColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();               //ayman training form add column
                DomainListViewColumn blockCompletedColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn hoursColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                
                trainingBlockColumn.Name = "TrainingBlock";
                commentsBlockColumn.Name = "Comments";
                supervisorColumn.Name = "Supervisor";                   //ayman training form add column
                blockCompletedColumn.Name = "BlockCompleted";
                hoursColumn.Name = "Hours";

                trainingBlockColumn.Text = RendererStringResources.TrainingBlock;
                commentsBlockColumn.Text = RendererStringResources.Comments;
                supervisorColumn.Text = RendererStringResources.Supervisor;                    //ayman training form add column
                blockCompletedColumn.Text = RendererStringResources.BlockCompleted;
                hoursColumn.Text = RendererStringResources.Hours;

                return new DomainListViewColumnCollection(trainingBlockColumn, commentsBlockColumn,supervisorColumn, blockCompletedColumn, hoursColumn);    //ayman training form add column
            }
        }
    }
}
