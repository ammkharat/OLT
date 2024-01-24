using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter
    {
        private readonly ProcedureDeviationFormAttendee attendee;

        public ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter(ProcedureDeviationFormAttendee attendee)
        {
            this.attendee = attendee;
        }

        public bool? DisableEdit
        {
            get { return attendee.DisableEdit; }
        }

        public string AttendeeType
        {
            get { return attendee.AttendeeType.GetName(); }
            set
            {
                var attendeeType = ProcedureDeviationAttendeeType.GetByName(value);

                attendee.AttendeeType = attendeeType ?? ProcedureDeviationAttendeeType.OperationsSME;
            }
        }

        public string AttendeeName
        {
            get { return attendee.AttendeeName; }
            set { attendee.AttendeeName = value; }
        }

        public ProcedureDeviationFormAttendee GetAttendee()
        {
            return attendee;
        }
    }
}