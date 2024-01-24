using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormGN75BReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        public FormGN75BReportAdapter(FormGN75B form, List<long> gn75AFormNumbers)
        {
            FormNumber = PadFormNumber(form.FormNumber);
            BlindsRequired = form.BlindsRequired.BooleanToYesNoString();
            ClosedDateTime = form.ClosedDateTime.HasValue
                ? form.ClosedDateTime.Value.ToLongDateAndTimeString()
                : string.Empty;
            CreatedBy = form.CreatedBy.FullNameWithUserName;
            CreationDateTime = form.CreatedDateTime.ToLongDateAndTimeString();
            Status = form.FormStatus.GetName();
            FunctionalLocation = form.FunctionalLocation.FullHierarchyWithDescription;
            IsolationReportAdapters = form.IsolationItems.ConvertAll(item => new IsolationReportAdapter(item));
            LockBoxLocation = form.LockBoxLocation;
            LockBoxNumber = form.LockBoxNumber;
            LastModifiedBy = form.LastModifiedBy.FullNameWithUserName;
            LastModifiedDateTime = form.LastModifiedDateTime.ToLongDateAndTimeString();

            GN75AForms = gn75AFormNumbers == null ? string.Empty : gn75AFormNumbers.ToCommaSeparatedString();


            OperatorLabel = form.OperatorText; //RITM0468037EN50 : OLT:: Edmonton:: GN75B changes Aarti 

            SchematicImage = form.SchematicImage;

            if (form.IsDeleted)
            {
                WatermarkText = StringResources.Deleted;
            }
            else if (form.FormStatus == FormStatus.Closed)
            {
                WatermarkText = form.FormStatus.Name;
            }
        }


        public string FormNumber { get; private set; }
        public string OperatorLabel { get; private set; } //RITM0468037EN50 : OLT:: Edmonton:: GN75B changes Aarti 
        public string FunctionalLocation { get; private set; }

        public string CreatedBy { get; private set; }
        public string LastModifiedBy { get; private set; }
        public string CreationDateTime { get; private set; }
        public string LastModifiedDateTime { get; private set; }
        public string ClosedDateTime { get; private set; }

        public string BlindsRequired { get; private set; }

        public string LockBoxNumber { get; private set; }
        public string LockBoxLocation { get; private set; }

        public string Status { get; private set; }

        public byte[] SchematicImage { get; private set; }

        public List<IsolationReportAdapter> IsolationReportAdapters { get; private set; }

        public string GN75AForms { get; private set; }

        public string WatermarkText { get; private set; }
    }

    public class IsolationReportAdapter
    {
        public IsolationReportAdapter(IsolationItem isolationItem)
        {
            DisplayOrder = isolationItem.DisplayOrder;
            IsolationType = isolationItem.IsolationType;
            LocationOfEnergyIsolation = isolationItem.LocationOfEnergyIsolation;
        }

        public string LocationOfEnergyIsolation { get; private set; }
        public string IsolationType { get; private set; }
        public int DisplayOrder { get; private set; }
    }


    //ayman Sarnia eip DMND0008992
    public class IsolationForSarniaReportAdapter
    {
        public IsolationForSarniaReportAdapter(IsolationItem isolationItem)
        {
            DisplayOrder = isolationItem.DisplayOrder;
            IsolationType = isolationItem.IsolationType;
            LocationOfEnergyIsolation = isolationItem.LocationOfEnergyIsolation;
            DevicePosition = isolationItem.DevicePosition;
        }

        public string LocationOfEnergyIsolation { get; private set; }
        public string IsolationType { get; private set; }
        public int DisplayOrder { get; private set; }
        public string DevicePosition { get; private set; }
    }

}