using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ContractorFixture
    {
        public static Contractor CreateContractor(int id, string companyName)
        {
            Contractor contractor = new Contractor {Id = id, CompanyName = companyName};
            return contractor;
        }

        public static Contractor CreateContractor(string companyName, Site site)
        {
            return new Contractor(companyName, site);
        }

        public static Contractor CreateContractor(int id)
        {
            Contractor contractor = new Contractor {Id = id};
            return contractor;
        }
    }
}
