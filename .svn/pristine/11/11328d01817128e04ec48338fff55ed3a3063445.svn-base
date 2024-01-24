using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFormOvertimeOnPremiseContractorsRenderer : BaseListViewRenderer, IDomainListViewRenderer<OnPremiseContractor>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn personnelNameColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("PersonnelName", "Personnel Name");
                DomainListViewColumn primaryLocationColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("PrimaryLocation", "Primary Location");
                DomainListViewColumn startColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("StartDateTime", "Start");
                DomainListViewColumn endColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("EndDateTime", "End");
                DomainListViewColumn shiftsColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("Shifts", "Shifts");
                DomainListViewColumn phoneNumberColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("PhoneNumber", "Phone");
                DomainListViewColumn radioColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("Radio", "Radio");
                DomainListViewColumn descriptionColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("Description", "Description");
                DomainListViewColumn contractorColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("Company", "Company");
                DomainListViewColumn workOrderNumberColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("WorkOrderNumber", "WO#/PO#");
                DomainListViewColumn expectedHours = new DomainListViewColumn.ResizeToHeaderSizeColumn("ExpectedHours", "OT Hrs");
                return new DomainListViewColumnCollection(personnelNameColumn, primaryLocationColumn, startColumn, endColumn, shiftsColumn, 
                    phoneNumberColumn, radioColumn, descriptionColumn, contractorColumn, 
                    workOrderNumberColumn, expectedHours);
            }
        }

        public ListViewItem RenderItem(OnPremiseContractor item)
        {
            DomainListViewItem<OnPremiseContractor> listViewItem = new DomainListViewItem<OnPremiseContractor>(item) {Text = item.PersonnelName};
            listViewItem.SubItems.Add(item.PrimaryLocation);
            listViewItem.SubItems.Add(item.StartDateTime.ToLongDateAndTimeString());
            listViewItem.SubItems.Add(item.EndDateTime.ToLongDateAndTimeString());
            listViewItem.SubItems.Add(item.Shifts);
            listViewItem.SubItems.Add(item.PhoneNumber);
            listViewItem.SubItems.Add(item.Radio);
            listViewItem.SubItems.Add(item.Description);
            listViewItem.SubItems.Add(item.Company);
            listViewItem.SubItems.Add(item.WorkOrderNumber);
            listViewItem.SubItems.Add(item.ExpectedHours.Format());

            return listViewItem;

        }
    }
}