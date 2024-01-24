using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Com.Suncor.Olt.Remote.Clients;
using Com.Suncor.Olt.Remote.Integration;

namespace TestTool
{
    public partial class OpmTagValuePullControl : UserControl
    {
        public OpmTagValuePullControl()
        {
            InitializeComponent();

            elapsedTimeLabel.Text = string.Empty;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            elapsedTimeLabel.Text = string.Empty;
            responseTextBox.Text = string.Empty;
            responseTextBox.Text = "Requesting...";

            Refresh();
            Thread.Sleep(300);

            var serverUri = serverURITextBox.Text;
            var historianTag = historianTagTextBox.Text;
            var domain = domainTextBox.Text;
            var userName = userNameTextBox.Text;
            var password = passwordTextBox.Text;
            OpmXhqServiceSettings settings = new UserProvidedOpmXhqServiceSettings(serverUri, domain, userName, password);

            try
            {
                var excursionImporter = new OpmXhqImporter(settings);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var currentTagValue = excursionImporter.GetCurrentTagValue(historianTag);

                stopwatch.Stop();

                if (currentTagValue != null)
                {
                    var serializer = new XmlSerializer(typeof (OPMTagValue));
                    var buffer = string.Empty;

                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, currentTagValue);
                        buffer += writer.ToString() + '\n';
                    }


                    responseTextBox.Text = buffer;
                    elapsedTimeLabel.Text = string.Format("Elapsed time {0} ms", stopwatch.ElapsedMilliseconds);
                }
                else
                {
                    responseTextBox.Text = "No data returned";
                    elapsedTimeLabel.Text = "No data returned";
                }
            }
            catch (Exception exception)
            {
                responseTextBox.Text = string.Format("Error: {0}\r\n\r\n{1}\r\n{2}", exception.Message, exception.StackTrace,
                    exception.InnerException);
            }
        }
    }
}