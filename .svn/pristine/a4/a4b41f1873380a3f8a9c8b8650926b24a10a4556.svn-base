using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public abstract class BaseFormHistory : DomainObjectHistorySnapshot
    {
        protected BaseFormHistory(long id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
            FormStatus = formStatus;
            ValidFromDateTime = validFromDateTime;
            ValidToDateTime = validToDateTime;
        }

        public FormStatus FormStatus { get; set; }
        public DateTime ValidFromDateTime { get; set; }
        public DateTime ValidToDateTime { get; set; }
    }
}