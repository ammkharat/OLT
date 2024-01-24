using System;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GenericTemplateApproval : DomainObject 
        //, ICacheBySiteId //commented ICache- as it conclict between e-forms dropdown name/list and approver name/list
    {
        //public static readonly SpecialWork EMPTY = new SpecialWork(string.Empty, null);

        public static readonly GenericTemplateApproval EMPTY =
            new GenericTemplateApproval(new long?(), string.Empty, null,0,0);

        public static GenericTemplateApproval NULL = new GenericTemplateApproval(0, string.Empty, null,0,0);

        public GenericTemplateApproval()
        {
        }
        public GenericTemplateApproval(string companyName, Site site, long formTypeId, long plantId)
            : this(null, companyName, site,  formTypeId,  plantId)
        {
        }

        public GenericTemplateApproval(long? id, string companyName, Site site, long formTypeId, long plantId)
        {
            this.id = id;
            CompanyName = companyName;
            Site = site;
            FormTypeId = formTypeId;
            PlantId = plantId;
        }

        public long FormTypeId { get; set; }
        public long PlantId { get; set; }
        
        public string CompanyName { get; set; }


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