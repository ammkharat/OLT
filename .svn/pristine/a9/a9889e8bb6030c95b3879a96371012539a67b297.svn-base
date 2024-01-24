using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Com.Suncor.Olt.Remote.Wcf
{
    public class ServerOperationBehavior : IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new ServerOperationInvoker(dispatchOperation.Invoker, operationDescription.SyncMethod);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
