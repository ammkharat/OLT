using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class DropdownValueService : IDropdownValueService
    {
        private readonly IDropdownValueDao dropdownValueDao;

        public DropdownValueService()
        {
            dropdownValueDao = DaoRegistry.GetDao<IDropdownValueDao>();
        }

        public List<DropdownValue> QueryAll(long siteId)
        {
            return dropdownValueDao.QueryAll(siteId);
        }

        public List<DropdownValue> QueryByKey(long siteId, string key)
        {
            return dropdownValueDao.QueryByKey(siteId, key);
        }

        public void UpdateValues(List<DropdownValue> values, List<DropdownValue> deletedValues)
        {
            foreach (DropdownValue value in deletedValues)
            {
                dropdownValueDao.Remove(value);
            }

            List<DropdownValue> newValues = values.FindAll(obj => !obj.IsInDatabase());
            List<DropdownValue> possiblyChangedValues = values.FindAll(obj => obj.IsInDatabase());

            foreach (DropdownValue value in possiblyChangedValues)
            {
                dropdownValueDao.Update(value);
            }

            foreach (DropdownValue value in newValues)
            {
                dropdownValueDao.Insert(value);
            }

        }

    }
}