using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class GenericTemplateFormApprovalService : IGenericTemplateService
    {
        private readonly IGenericTemplateApprovalDao contractorDao;

        public GenericTemplateFormApprovalService()
            : this(DaoRegistry.GetDao<IGenericTemplateApprovalDao>())
        {
        }

        public GenericTemplateFormApprovalService(IGenericTemplateApprovalDao contractorDao)
        {
            this.contractorDao = contractorDao;
        }

        public List<GenericTemplateApproval> QueryForEGenericForms(Site site, long plantId)
        {
            return contractorDao.QueryForEGenericForms(site.IdValue, plantId);
        }
        //Added by ppanigrahi
        public List<GenericTemplateEmailApprovalConfiguration> QueryByEmailSite(Site site, long formTypeId)
        {
            return contractorDao.QueryByEmailSite(site.IdValue, formTypeId);
        }
        //Added by ppanigrahi
        public string QueryEmailListApproverBySite(Site site, long formTypeId, string Name)
        {
            return contractorDao.QueryEmailListApproverBySite(site.IdValue, formTypeId, Name);
        }
        public List<GenericTemplateApproval> QueryBySite(Site site, long plantId, long formTypeId)
        {
            return contractorDao.QueryBySite(site.IdValue, plantId, formTypeId);
        }
        //Added by ppanigrahi
        public List<GenericTemplateEmailApprovalConfiguration> QueryFormGenericTemplateEmailEFormsBySite(Site site)
        {
            return contractorDao.QueryFormGenericTemplateEmailEFormsBySite(site.IdValue);
        }

        //INC0251500 - mangesh
        public void DeleteFormApprover(GenericTemplateApproval contractor)
        {
            contractorDao.Remove(contractor);
        }
        //Added by ppanigrahi
        public void DeleteFormApproverEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {
            contractorDao.RemoveEmail(contractor);

        }

        public void UpdateContractors(Site site, IList<GenericTemplateApproval> newContractorList, long plantId, long formTypeId)
        {
            List<GenericTemplateApproval> existingContractorList = QueryBySite(site, plantId, formTypeId);

            Dictionary<long, GenericTemplateApproval> existingContractors = GetContractorsWithId(existingContractorList);

            foreach (GenericTemplateApproval newContractor in newContractorList)
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

            //Dictionary<long, GenericTemplateApproval> newContractors = GetContractorsWithId(newContractorList);

            //foreach (GenericTemplateApproval existingContractor in existingContractorList)
            //{
            //    if (newContractors.ContainsKey(existingContractor.IdValue) == false)
            //    {
            //        contractorDao.Remove(existingContractor);
            //    }
            //}
        }
        //Added by ppanigrahi
        public void UpdateContractorsEmail(Site site, IList<GenericTemplateEmailApprovalConfiguration> newContractorList, long plantId, long formTypeId)
        {
            List<GenericTemplateEmailApprovalConfiguration> existingContractorList = QueryByEmailSite(site, formTypeId);

            Dictionary<long, GenericTemplateEmailApprovalConfiguration> existingContractors = GetContractorsWithId(existingContractorList);

            foreach (GenericTemplateEmailApprovalConfiguration newContractor in newContractorList)
            {
                if (newContractor.IsInDatabase())
                {
                    if (newContractor.Equals(existingContractors[newContractor.IdValue]) == false)
                    {
                        contractorDao.UpdateEmail(newContractor);
                    }
                }
                else
                {
                    contractorDao.InsertEmail(newContractor);
                }


            }

            //Dictionary<long, GenericTemplateApproval> newContractors = GetContractorsWithId(newContractorList);

            //foreach (GenericTemplateApproval existingContractor in existingContractorList)
            //{
            //    if (newContractors.ContainsKey(existingContractor.IdValue) == false)
            //    {
            //        contractorDao.Remove(existingContractor);
            //    }
            //}
        }
        //Added by ppanigrahi
        public void UpdateEmailApprover(GenericTemplateEmailApprovalConfiguration selectedContractor)
        {

            contractorDao.UpdateEmail(selectedContractor);
        }


        private static Dictionary<long, GenericTemplateApproval> GetContractorsWithId(ICollection<GenericTemplateApproval> contractorList)
        {
            Dictionary<long, GenericTemplateApproval> contractors = new Dictionary<long, GenericTemplateApproval>(contractorList.Count);

            foreach (GenericTemplateApproval contractor in contractorList)
            {
                if (contractor.IsInDatabase())
                {
                    contractors[contractor.IdValue] = contractor;
                }
            }

            return contractors;
        }
        //Added by ppanigrahi
        private static Dictionary<long, GenericTemplateEmailApprovalConfiguration> GetContractorsWithId(ICollection<GenericTemplateEmailApprovalConfiguration> contractorList)
        {
            Dictionary<long, GenericTemplateEmailApprovalConfiguration> contractors = new Dictionary<long, GenericTemplateEmailApprovalConfiguration>(contractorList.Count);

            foreach (GenericTemplateEmailApprovalConfiguration contractor in contractorList)
            {
                if (contractor.IsInDatabase())
                {
                    contractors[contractor.IdValue] = contractor;
                }
            }

            return contractors;
        }
        //Added by ppanigrahi


        private static Dictionary<long, GenericTemplateEmailApprovalConfiguration> GetContractorsEmailWithId(ICollection<GenericTemplateEmailApprovalConfiguration> contractorList)
        {
            Dictionary<long, GenericTemplateEmailApprovalConfiguration> contractors = new Dictionary<long, GenericTemplateEmailApprovalConfiguration>(contractorList.Count);

            foreach (GenericTemplateEmailApprovalConfiguration contractor in contractorList)
            {
                if (contractor.IsInDatabase())
                {
                    contractors[contractor.IdValue] = contractor;
                }
            }

            return contractors;
        }

        //DMND0009363-#950321920-Mukesh
        public void UpdateTemplateHeader(GenericTemplateApproval contractor)
        {

            contractorDao.UpdateTemplateHeader(contractor);
        }
        //Added by ppanigrahi

        public void UpdateTemplateHeaderEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {

            contractorDao.UpdateTemplateHeaderEmail(contractor);
        }
    }
}
