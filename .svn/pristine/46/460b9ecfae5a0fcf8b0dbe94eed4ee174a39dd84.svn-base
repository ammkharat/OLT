using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;

namespace TestTool
{
    public partial class WcfControl : UserControl
    {
        private readonly ConsoleClass console;


        public WcfControl()
        {
            InitializeComponent();
            console = new ConsoleClass(outputTextBox);
            submitButton.Click += SubmitButton_Click;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SendMessage();
            // SendEventsToClient(1);
        }

        private void SendMessage()
        {
            try
            {
                string baseAddress = "http://localhost/website/ISiteService.svc";
                //string baseAddress = "http://oltsbxcgy004:8090/ISecurityService.svc";

                /*
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                ChannelFactory<ISecurityService> factory = new ChannelFactory<ISecurityService>(binding, new EndpointAddress(baseAddress));

                ISecurityService proxy = factory.CreateChannel();

                Console.WriteLine(proxy.GetAssemblyVersion());

                ((IClientChannel)proxy).Close();

                factory.Close();
                 * */

                ISiteService siteService = GenericServiceRegistry.Instance.GetService<ISiteService>();
                console.WriteLine(siteService.GetAll());
//                ProxyProvider clientChannel = ProxyProviderFactory.CreateProxyProviderForSendingRequestsToServer<ISiteService>(baseAddress);
//                ISiteService proxy = (ISiteService)clientChannel.Proxy;
//                Console.WriteLine(proxy.GetAll());
//                clientChannel.Close();

            }
            catch (Exception e)
            {

                console.WriteLine(e.ToString());
            }
        }

        private void SendEventsToClient(int numRepeats)
        {
            try
            {
                List<WaitHandle> waitHandles = new List<WaitHandle>();
                for (int i = 0; i < numRepeats; i++)
                {
                    AutoResetEvent waitHandle = new AutoResetEvent(false);
                    waitHandles.Add(waitHandle);

                    ThreadPool.QueueUserWorkItem(SendIt, new object[] { waitHandle, i });
                }
                WaitHandle.WaitAll(waitHandles.ToArray());
            }
            catch (Exception e)
            {

                console.WriteLine(e.ToString());
            }
        }

        private void SendIt(object state)
        {
            object[] objects = (object[])state;
            AutoResetEvent are = (AutoResetEvent)objects[0];
            int i = (int)objects[1];

            string baseAddress = "net.tcp://10.9.43.16:9771/";
            IEventNotificationService proxy = null;
            try
            {
                console.WriteLine("Thread: " + i);

                ChannelFactory<IEventNotificationService> channelFactory =
                    ChannelFactoryCreator.CreateClientToServerChannelFactory<IEventNotificationService>(baseAddress, new List<IEndpointBehavior>(0));
                proxy = channelFactory.CreateChannel();

                console.WriteLine(i + " Before send");
                ((IClientChannel)proxy).Open();
                proxy.Notify(new DomainEventArgs<DomainObject>(ApplicationEvent.LogCreate));
                console.WriteLine(i + " After send, before close");
                console.WriteLine(i + " After close");
            }
            catch (Exception e)
            {
                console.WriteLine(e.ToString());
            }
            finally
            {
                ((IClientChannel)proxy).CloseOrAbort();
            }
            are.Set();
        }

        public class ConsoleClass
        {
            private readonly TextBox outputTextBox;

            public ConsoleClass(TextBox outputTextBox)
            {
                this.outputTextBox = outputTextBox;
            }

            public void WriteLine(object s)
            {
                outputTextBox.Text += (s ?? "<null>") + Environment.NewLine;
            }
        }
    }
}
