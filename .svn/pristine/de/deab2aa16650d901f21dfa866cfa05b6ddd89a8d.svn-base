using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Wcf;

namespace TestTool
{
    public partial class PermitRequestPullControl : UserControl
    {
        public PermitRequestPullControl()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            responseTextBox.Text = "Requesting...";

            DateTime dateTime = dateTimePicker.Value;
            string serverUri = serverURITextBox.Text;
            string plantId = plantTextBox.Text;
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            WorkOrderImportSettings settings = new UserProvidedWorkOrderImportSettings(serverUri, userName, password);

            try
            {
                WorkOrderImporter workOrderImporter = new WorkOrderImporter(settings);
                List<WorkOrderRecordList> workOrderRecordLists = workOrderImporter.ImportWorkOrders(new Date(dateTime), long.Parse(plantId), null);

                WorkOrderOLTdata data = new WorkOrderOLTdata {WorkOrderRecordList = workOrderRecordLists.ToArray()};


                var serializer = new XmlSerializer(typeof(WorkOrderOLTdata));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, data);
                    responseTextBox.Text = writer.ToString();
                }

            }
            catch (Exception exception)
            {
                responseTextBox.Text = string.Format("Error: {0}\n\n{1}", exception.Message, exception.StackTrace);
            }
        }
    }

    public class UserProvidedWorkOrderImportSettings : WorkOrderImportSettings
    {
        private readonly string server;
        private readonly string username;
        private readonly string password;

        public UserProvidedWorkOrderImportSettings(string server, string username, string password)
        {
            this.server = server;
            this.username = username;
            this.password = password;
        }

        public override string URI
        {
            get { return server; }
        }

        public override string UserName
        {
            get { return username; }
        }

        public override string Password
        {
            get { return password; }
        }

        public override TimeSpan CloseTimeout
        {
            get { return new TimeSpan(0, 0, 1, 0); }
        }

        public override TimeSpan OpenTimeout
        {
            get { return new TimeSpan(0, 0, 1, 0);  }
        }

        public override TimeSpan ReceiveTimeout
        {
            get { return new TimeSpan(0, 0, 10, 0);  }
        }

        public override TimeSpan SendTimeout
        {
            get { return new TimeSpan(0, 0, 3, 0); }
        }

        public override int MaxBufferSize
        {
            get { return 2147483647; }
        }

        public override int MaxReceivedMessageSize
        {
            get { return 2147483647;  }
        }

        public override int MaxBufferPoolSize
        {
            get { return 524288; }
        }

        public override int ReaderQuotasMaxDepth
        {
            get { return 2147483647; }
        }

        public override int MaxStringContentLength
        {
            get { return 2147483647; }
        }

        public override int MaxArrayLength
        {
            get { return 2147483647; }
        }
    }
}
