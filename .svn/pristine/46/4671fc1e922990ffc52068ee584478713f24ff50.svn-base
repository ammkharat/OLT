using System.ServiceModel.Description;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ServiceEndpointConfiguration
    {
        public static void Apply(ServiceEndpoint endpoint)
        {
            endpoint.Behaviors.Add(new MessageInspectionEndpointBehavior());

            foreach (var operationDescription in endpoint.Contract.Operations)
            {
                NetDataContractOperationBehavior.ReplaceDataContractSerializerOperationBehavior(operationDescription);

                var behaviour = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (behaviour != null)
                {
                    behaviour.MaxItemsInObjectGraph = WcfConfiguration.Instance.MaxItemsInObjectGraph;
                }
            }
        }
    }
}