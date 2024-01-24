using System;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class NonnumericCustomFieldEntryDTO
    {
        private readonly long id;

        public NonnumericCustomFieldEntryDTO(long id, string value, DateTime dateTime)
        {
            this.id = id;

            Value = value;
            DateTime = dateTime;
        }

        public DateTime DateTime { get; private set; }
        public string Value { get; private set; }

        public long GetId()
        {
            return id;
        }
    }
}