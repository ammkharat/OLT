using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITrainingBlockService
    {
        [OperationContract]
        List<TrainingBlock> QueryByFunctionalLocations(IFlocSet flocSet);

        [OperationContract]
        List<TrainingBlock> QueryAll(long Siteid);             //ayman training block

        [OperationContract]
        long Insert(TrainingBlock trainingBlock);

        [OperationContract]
        int CountOfTrainingBlocksWithName(string trainingBlockName, long? trainingBlockId, long Siteide);    //ayman training block

        [OperationContract]
        void Update(TrainingBlock trainingBlock);

        [OperationContract]
        void Remove(TrainingBlock trainingBlock);
    }
}