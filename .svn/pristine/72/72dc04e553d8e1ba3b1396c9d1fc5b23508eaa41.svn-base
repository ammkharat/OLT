using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SpecialWorkService : ISpecialWorkService
    {
        private readonly ISpecialWorkDao contractorDao;

        public SpecialWorkService()
            : this(DaoRegistry.GetDao<ISpecialWorkDao>())
        {
        }

        public SpecialWorkService(ISpecialWorkDao contractorDao)
        {
            this.contractorDao = contractorDao;
        }

        public List<SpecialWork> QueryBySite(Site site)
        {
            return contractorDao.QueryBySite(site.IdValue);
        }

        public void UpdateContractors(Site site, IList<SpecialWork> newContractorList)
        {
            List<SpecialWork> existingContractorList = QueryBySite(site);

            Dictionary<long, SpecialWork> existingContractors = GetContractorsWithId(existingContractorList);

            foreach (SpecialWork newContractor in newContractorList)
            {
                if (newContractor.IsInDatabase())
                {
                    if (newContractor.Equals(existingContractors[newContractor.IdValue]) == false)
                    {
                        contractorDao.Update(newContractor);
                    }
                }
                else
                {
                    contractorDao.Insert(newContractor);
                }
            }

            Dictionary<long, SpecialWork> newContractors = GetContractorsWithId(newContractorList);

            foreach (SpecialWork existingContractor in existingContractorList)
            {
                if (newContractors.ContainsKey(existingContractor.IdValue) == false)
                {
                    contractorDao.Remove(existingContractor);
                }
            }
        }

        private static Dictionary<long, SpecialWork> GetContractorsWithId(ICollection<SpecialWork> contractorList)
        {
            Dictionary<long, SpecialWork> contractors = new Dictionary<long, SpecialWork>(contractorList.Count);

            foreach (SpecialWork contractor in contractorList)
            {
                if (contractor.IsInDatabase())
                {
                    contractors[contractor.IdValue] = contractor;
                }
            }

            return contractors;
        }
    }
}
