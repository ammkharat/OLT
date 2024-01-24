using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility.Cache;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TrainingBlockService : ITrainingBlockService
    {
        private ITrainingBlockDao dao;

        public TrainingBlockService()
        {
            dao = DaoRegistry.GetDao<ITrainingBlockDao>();
        }

        public List<TrainingBlock> QueryByFunctionalLocations(IFlocSet flocSet)
        {
            return dao.QueryByFunctionalLocations(flocSet);
        }

        public List<TrainingBlock> QueryAll(long Siteid)
        {
            return dao.QueryAll(Siteid);
        }

        public long Insert(TrainingBlock trainingBlock)
        {
            dao.Insert(trainingBlock);
            return trainingBlock.IdValue;
        }

        public void Update(TrainingBlock trainingBlock)
        {
            dao.Update(trainingBlock);
        }

        public void Remove(TrainingBlock trainingBlock)
        {
            dao.Remove(trainingBlock);
        }

        public int CountOfTrainingBlocksWithName(string trainingBlockName, long? trainingBlockId, long Siteid)              //ayman training block
        {
            return dao.CountOfTrainingBlocksWithName(trainingBlockName, trainingBlockId,Siteid);
        }
    }
}
