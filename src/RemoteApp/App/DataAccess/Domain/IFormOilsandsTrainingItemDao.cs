using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // caching, because this is only called by the Training Dao, it's safe to cache the Training Domain Object
    public interface IFormOilsandsTrainingItemDao : IDao
    {
        void Insert(FormOilsandsTrainingItem trainingItem);
        List<FormOilsandsTrainingItem> QueryByFormOilsandsTrainingId(long formOilsandsTrainingId);
        void RemoveAllThatAreNotInThisList(long formOilsandsTrainingId, List<FormOilsandsTrainingItem> items);
        void Update(FormOilsandsTrainingItem trainingItem);
    }
}
