using System;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FormOP14Read : DomainObject
    {
        private readonly long formOP14Id;
        private readonly long readByUserId;
        private readonly DateTime time;
        private readonly long shiftId;

        public FormOP14Read(long formOP14Id, long readByUserId, DateTime time)
        {
            this.formOP14Id = formOP14Id;
            this.readByUserId = readByUserId;
            this.time = time;
        }

        public FormOP14Read(FormOP14 fromOP14, User readByUser, DateTime time)
        {
            readByUserId = readByUser.Id.Value;
            formOP14Id = fromOP14.Id.Value;
            this.time = time;
        }

        public long ReadByUserId
        {
            get { return readByUserId; }
        }

        public long FormOP14Id
        {
            get { return formOP14Id; }
        }
       
        public long ShiftId
        {
            get { return shiftId; }
        }

        public DateTime Time
        {
            get { return time; }
        }
    }
}