using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ServiceBindingFactory
    {
        public static Binding CreateClientServerBinding()
        {
            var clientServerBindingType = WcfConfiguration.Instance.ClientServerBindingType;
            return CreateClientServerBinding(clientServerBindingType);
        }

        public static Binding CreateClientServerBinding(BindingType clientServerBindingType)
        {
            switch (clientServerBindingType)
            {
                case BindingType.HttpBinding:
                    return CreateTextHttpBinding();
                case BindingType.HttpBinaryEncoded:
                    return CreateBinaryHttpBinding();
                case BindingType.HttpBinaryStreamedEncoded:
                    return CreateBinaryHttpBindingWithStreamingResponse();
                case BindingType.TcpBinding:
                    return CreateTcpBinding();
                case BindingType.HttpBinaryStreamedRequestEncoding:
                    return CreateStreamingBinaryHttpBinding();
                default:
                    return CreateTextHttpBinding();
            }
        }

        public static Binding CreateOneWayTcpBinding()
        {
            var netTcpBinding = CreateTcpBinding();
            Binding binding = WrapWithOneWayBinding(netTcpBinding);
            return binding;
        }

        private static CustomBinding WrapWithOneWayBinding(NetTcpBinding baseTcpBinding)
        {
            var oldBindingElements = baseTcpBinding.CreateBindingElements();
            var bindingElements = new BindingElementCollection {new OneWayBindingElement()};
            foreach (var bindingElement in oldBindingElements)
            {
                bindingElements.Add(bindingElement);
            }

            var binding = new CustomBinding(bindingElements)
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0)
            };

            return binding;
        }

        private static NetTcpBinding CreateTcpBinding()
        {
            var binding = new NetTcpBinding
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0),
                ListenBacklog = WcfConfiguration.Instance.MaxConnections,
                MaxConnections = WcfConfiguration.Instance.MaxConnections,
                MaxBufferPoolSize = WcfConfiguration.Instance.MaxBufferPoolSize,
                MaxReceivedMessageSize = WcfConfiguration.Instance.MaxReceivedMessageSize,
                MaxBufferSize = WcfConfiguration.Instance.MaxBufferSize,
                ReaderQuotas =
                {
                    MaxStringContentLength = WcfConfiguration.Instance.ReaderQuotasMaxStringContentLength,
                    MaxArrayLength = WcfConfiguration.Instance.ReaderQuotasMaxArrayLength
                }
            };

            binding.Security.Mode = SecurityMode.None;

            return binding;
        }

        public static Binding CreateStreamingBinaryHttpBinding()
        {
            var binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
            binaryMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength =
                WcfConfiguration.Instance.ReaderQuotasMaxStringContentLength;

            var httpTransportBindingElement = new HttpTransportBindingElement
            {
                MaxBufferPoolSize = WcfConfiguration.Instance.MaxBufferPoolSize,
                MaxReceivedMessageSize = WcfConfiguration.Instance.MaxReceivedMessageSize,
                MaxBufferSize = WcfConfiguration.Instance.MaxBufferSize,
                KeepAliveEnabled = false,
                TransferMode = TransferMode.StreamedRequest
            };

            var binding = new CustomBinding(binaryMessageEncodingBindingElement, httpTransportBindingElement)
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0)
            };

            return binding;
        }

        public static Binding CreateBinaryHttpBindingWithStreamingResponse()
        {
            var binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
            binaryMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength =
                WcfConfiguration.Instance.ReaderQuotasMaxStringContentLength;

            var httpTransportBindingElement = new HttpTransportBindingElement
            {
                MaxBufferPoolSize = WcfConfiguration.Instance.MaxBufferPoolSize,
                MaxReceivedMessageSize = WcfConfiguration.Instance.MaxReceivedMessageSize,
                MaxBufferSize = WcfConfiguration.Instance.MaxBufferSize,
                KeepAliveEnabled = false,
                TransferMode = TransferMode.StreamedResponse
            };

            var binding = new CustomBinding(binaryMessageEncodingBindingElement, httpTransportBindingElement)
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0)
            };

            return binding;
        }

        private static Binding CreateBinaryHttpBinding()
        {
            var binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
            binaryMessageEncodingBindingElement.ReaderQuotas.MaxStringContentLength =
                WcfConfiguration.Instance.ReaderQuotasMaxStringContentLength;
            binaryMessageEncodingBindingElement.ReaderQuotas.MaxArrayLength =
                WcfConfiguration.Instance.ReaderQuotasMaxArrayLength;

            var httpTransportBindingElement = new HttpTransportBindingElement
            {
                MaxBufferPoolSize = WcfConfiguration.Instance.MaxBufferPoolSize,
                MaxReceivedMessageSize = WcfConfiguration.Instance.MaxReceivedMessageSize,
                MaxBufferSize = WcfConfiguration.Instance.MaxBufferSize,
                KeepAliveEnabled = false
            };

            var binding = new CustomBinding(binaryMessageEncodingBindingElement, httpTransportBindingElement)
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0)
            };

            return binding;
        }

        private static Binding CreateTextHttpBinding()
        {
            var binding = new WSHttpBinding
            {
                OpenTimeout = new TimeSpan(0, WcfConfiguration.Instance.OpenTimeout, 0),
                ReceiveTimeout = new TimeSpan(0, WcfConfiguration.Instance.ReceiveTimeout, 0),
                SendTimeout = new TimeSpan(0, WcfConfiguration.Instance.SendTimeout, 0),
                CloseTimeout = new TimeSpan(0, WcfConfiguration.Instance.CloseTimeout, 0),
                MaxBufferPoolSize = WcfConfiguration.Instance.MaxBufferPoolSize,
                MaxReceivedMessageSize = WcfConfiguration.Instance.MaxReceivedMessageSize,
                MessageEncoding = WSMessageEncoding.Text
            };

            binding.Security.Mode = SecurityMode.None;

            binding.ReaderQuotas.MaxStringContentLength = WcfConfiguration.Instance.ReaderQuotasMaxStringContentLength;
            binding.ReaderQuotas.MaxArrayLength = WcfConfiguration.Instance.ReaderQuotasMaxArrayLength;

            var customBinding = new CustomBinding(binding);
            var httpTransportBindingElement = customBinding.Elements.Find<HttpTransportBindingElement>();
            httpTransportBindingElement.KeepAliveEnabled = false;
            return customBinding;
        }
    }
}