using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    public class FormGN75BTemplatePattern : DomainObject, ICacheBySiteId
    {
            public FormGN75BTemplatePattern(long id,FormStatus formstatus,string functionallocation,Time startTime, string location,string equipmenttype,long siteid)

        {
                Id = id;
                FormStatus = formstatus;
                StartTime = startTime;
                FunctionalLocation = functionallocation;
                Location = location;
                EquipmentType = equipmenttype;
                SiteId = siteid;
        }

        public FormStatus FormStatus { get; private set; }
        public Time StartTime { get; private set; }
        public string FunctionalLocation { get; private set; }
        public string Location { get; private set; }
        public string EquipmentType { get; private set; }
        public long SiteId { get; private set; }

        private static string GetDisplayName(string name, Time start, Time end)
        {
            return String.Format("{0} - {1} to {2}", name, start, end);
        }

    }
}
