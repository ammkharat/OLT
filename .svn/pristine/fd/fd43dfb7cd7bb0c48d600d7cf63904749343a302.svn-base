using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IOnPremisePersonnelService
    {
        [OperationContract(IsOneWay = true)]
        void UpdateOnPremisePersonnel(OvertimeForm oldVersion, OvertimeForm newVersion);

        [OperationContract(IsOneWay = true)]
        void InsertOnPremisePersonnel(OvertimeForm overtimeForm);

        [OperationContract(IsOneWay = true)]
        void RemoveOnPremisePersonnel(OvertimeForm overtimeForm);
    }
}