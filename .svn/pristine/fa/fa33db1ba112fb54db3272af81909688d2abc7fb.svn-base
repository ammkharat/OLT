using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITrainingBlockDao : IDao
    {
        [CachedQueryById]
        TrainingBlock QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Insert(TrainingBlock trainingBlock);
        [CachedInsertOrUpdate(false, false)]
        void Update(TrainingBlock trainingBlock);
        [CachedRemove(false, false)]
        void Remove(TrainingBlock trainingBlock);

        List<TrainingBlock> QueryByFunctionalLocations(IFlocSet flocSet);
        List<TrainingBlock> QueryAll(long Siteid);         //ayman training block
        int CountOfTrainingBlocksWithName(string trainingBlockName, long? trainingBlockId, long Siteid);         //ayman training block
    }
}
