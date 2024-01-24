using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationFormAttendee : DomainObject, IHasDisplayOrder
    {
        private int displayOrder;

        public ProcedureDeviationFormAttendee(long? formId,
            ProcedureDeviationAttendeeType attendeeType, string attendeeName, int displayOrder, bool? disableEdit)
        {
            FormId = formId;
            AttendeeType = attendeeType;
            AttendeeName = attendeeName;
            DisplayOrder = displayOrder;
            DisableEdit = disableEdit;
        }

        public long? FormId { get; private set; }

        public ProcedureDeviationAttendeeType AttendeeType { get; set; }

        public string AttendeeName { get; set; }

        public bool? DisableEdit { get; set; }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }
    }
}