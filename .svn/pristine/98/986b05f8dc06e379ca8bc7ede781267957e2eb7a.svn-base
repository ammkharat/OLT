using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using System.Data;



namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class TrackerReport : DomainObject, IHasDisplayOrder
    {
        private decimal? numericFieldEntry;

        public TrackerReport(long id, string actionitemDefName, string customfieldName,string listval,string listtime)
        {
            Id = id;
            ActionItemDefinitionName = actionitemDefName;
            CustomFieldName = customfieldName;
            ListValue = listval;
            ListTime = listtime;
        }

        public long Id { get; set; }
        public string ActionItemDefinitionName { get; set; }
        public string CustomFieldName { get; set; }
        public string ListValue { get; set; }                 //ayman action item reading
        public string ListTime { get; set; }                  //ayman action item reading
        public int DisplayOrder { get; set; }
        public DataTable dt;
        public object GraphType { get; set; }
      
    }
}