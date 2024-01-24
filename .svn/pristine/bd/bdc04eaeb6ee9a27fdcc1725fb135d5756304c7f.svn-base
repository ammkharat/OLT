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
    public partial class OpmExcursionPullControl : UserControl
    {
        public OpmExcursionPullControl()
        {
            InitializeComponent();

            excursionCountLabel.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            excursionCountLabel.Text = string.Empty;
            responseTextBox.Text = string.Empty;
            responseTextBox.Text = "Requesting...";

            Refresh();
            Thread.Sleep(300);

            var dateTime = dateTimePicker.Value;
            var serverUri = serverURITextBox.Text;
            var domain = domainTextBox.Text;
            var userName = userNameTextBox.Text;
            var password = passwordTextBox.Text;
            OpmXhqServiceSettings settings = new UserProvidedOpmXhqServiceSettings(serverUri, domain, userName, password);

            try
            {
                var excursionImporter = new OpmXhqImporter(settings);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var excursions = excursionImporter.GetOpmExcursions(dateTime);

                stopwatch.Stop();

                if (excursions != null)
                {
                    var serializer = new XmlSerializer(typeof (OPMExcursion[]));
                    var buffer = string.Empty;

                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, excursions.ToArray());
                        buffer += writer.ToString() + '\n';
                    }

                    responseTextBox.Text = buffer;
                    excursionCountLabel.Text = string.Format("{0} excursions imported in {1} ms", excursions.Count,
                        stopwatch.ElapsedMilliseconds);
                }
                else
                {
                    responseTextBox.Text = "No data returned";
                    excursionCountLabel.Text = "No data returned";
                }
            }
            catch (Exception exception)
            {
                responseTextBox.Text = string.Format("Error: {0}\r\n\r\n{1}\r\n{2}", exception.Message, exception.StackTrace, exception.InnerException);
            }
        }
    }
}