using System;
using System.Collections.Generic;
using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.Form
{
     public class GenericTemplateEmailApprovalConfiguration:DomainObject
    {
        //public static readonly SpecialWork EMPTY = new SpecialWork(string.Empty, null);

        //public static readonly GenericTemplateEmailApprovalConfiguration EMPTY =
        //    new GenericTemplateEmailApprovalConfiguration(new long?(), string.Empty, null,0,0);

        public static GenericTemplateEmailApprovalConfiguration NULL = new GenericTemplateEmailApprovalConfiguration(0, string.Empty, null, 0, 0,null);

        public GenericTemplateEmailApprovalConfiguration()
        {
        }
        public GenericTemplateEmailApprovalConfiguration(string companyName, Site site, long formTypeId, long plantId,string emaillist)
            : this(null, companyName, site,  formTypeId,  plantId,emaillist)
        {
        }

        public GenericTemplateEmailApprovalConfiguration(long? id, string companyName, Site site, long formTypeId, long plantId,string emaillist)
        {
            this.id = id;
            CompanyName = companyName;
            Site = site;
            FormTypeId = formTypeId;
            PlantId = plantId;
            EmailList = emaillist;
        }

        public long FormTypeId { get; set; }
        public long PlantId { get; set; }
        
        public string CompanyName { get; set; }
        public string EmailList { get; set; }

        public Site Site { get; set; }

        //DMND0009363-#950321920-Mukesh
       public bool ShowneverEnd { set; get; }

        [IgnoreToString]
        public long SiteId
        {
            get { return Site.IdValue; }
        }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
