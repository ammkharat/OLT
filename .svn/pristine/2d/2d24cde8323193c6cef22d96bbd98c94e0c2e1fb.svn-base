using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class NetDataContractSerializerAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description,
            ClientOperation proxy)
        {
            NetDataContractOperationBehavior.ReplaceDataContractSerializerOperationBehavior(description);
        }

        public void ApplyDispatchBehavior(OperationDescription description,
            DispatchOperation dispatch)
        {
            NetDataContractOperationBehavior.ReplaceDataContractSerializerOperationBehavior(description);
        }

        public void Validate(OperationDescription description)
        {
        }
    }
}