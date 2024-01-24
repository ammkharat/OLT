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
    public class ContractorService : IContractorService
    {
        private readonly IContractorDao contractorDao;

        public ContractorService()
            : this(DaoRegistry.GetDao<IContractorDao>())
        {
        }

        public ContractorService(IContractorDao contractorDao)
        {
            this.contractorDao = contractorDao;
        }

        public List<Contractor> QueryBySite(Site site)
        {
            return contractorDao.QueryBySite(site.IdValue);
        }

        public void UpdateContractors(Site site, IList<Contractor> newContractorList)
        {
            List<Contractor> existingContractorList = QueryBySite(site);

            Dictionary<long, Contractor> existingContractors = GetContractorsWithId(existingContractorList);

            foreach (Contractor newContractor in newContractorList)
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

            Dictionary<long, Contractor> newContractors = GetContractorsWithId(newContractorList);

            foreach (Contractor existingContractor in existingContractorList)
            {
                if (newContractors.ContainsKey(existingContractor.IdValue) == false)
                {
                    contractorDao.Remove(existingContractor);
                }
            }
        }

        private static Dictionary<long, Contractor> GetContractorsWithId(ICollection<Contractor> contractorList)
        {
            Dictionary<long, Contractor> contractors = new Dictionary<long, Contractor>(contractorList.Count);
            
            foreach (Contractor contractor in contractorList)
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
