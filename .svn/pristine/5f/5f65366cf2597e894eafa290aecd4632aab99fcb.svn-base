using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class NetDataContractOperationBehavior : DataContractSerializerOperationBehavior
    {
        public NetDataContractOperationBehavior(OperationDescription operation)
            : base(operation)
        {
        }

        public NetDataContractOperationBehavior(OperationDescription operation,
            DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }

        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns,
            IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name,
            XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }

        public static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
        {
            var dcsOperationBehavior =
                description.Behaviors.Find<DataContractSerializerOperationBehavior>();

            if (dcsOperationBehavior != null)
            {
                description.Behaviors.Remove(dcsOperationBehavior);
            }
            description.Behaviors.Add(new NetDataContractOperationBehavior(description));
        }
    }
}