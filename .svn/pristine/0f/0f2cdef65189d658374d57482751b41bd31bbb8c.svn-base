using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Utility;

namespace TestTool
{
    public partial class PermitRequestControl : UserControl
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        delegate void BackgroundCallback(string text);

        private string localIpAddress;

        public PermitRequestControl()
        {
            InitializeComponent();

            localIpAddress = NetworkUtilities.GetLocalIpAddress();
            SetURITextBox(localIpAddress);

            backgroundWorker.DoWork += Listen;
            backgroundWorker.RunWorkerCompleted += WorkDone;

            ipAddressRadioButton.CheckedChanged += HandleIPAddressRadioButtonCheckChanged;
            localhostRadioButton.CheckedChanged += HandleLocalhostRadioButtonCheckChanged;
        }

        private void HandleIPAddressRadioButtonCheckChanged(object sender, EventArgs e)
        {
            if (ipAddressRadioButton.Checked)
            {
                SetURITextBox(localIpAddress);
            }
        }

        private void HandleLocalhostRadioButtonCheckChanged(object sender, EventArgs e)
        {
            if (localhostRadioButton.Checked)
            {
                SetURITextBox("localhost");
            }
        }

        private void SetURITextBox(string hostname)
        {
            serverURITextBox.Text = string.Format("http://{0}:8889/", hostname);
        }

        private void Listen(object sender, DoWorkEventArgs e)
        {
            try
            {
                HttpListener listener = new HttpListener();

                listener.Prefixes.Add(serverURITextBox.Text);

                listener.Start();

                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                Stream body = request.InputStream;
                Encoding encoding = request.ContentEncoding;
                StreamReader reader = new StreamReader(body, encoding);

                string requestStringText = reader.ReadToEnd();
                reader.Close();
                body.Close();

                if (requestTextBox.InvokeRequired)
                {
                    requestTextBox.Invoke((BackgroundCallback) SetRequestText, requestStringText);
                }
                else
                {
                    requestTextBox.Text = requestStringText;
                }

                HttpListenerResponse response = context.Response;
                response.AddHeader("Content-Type", "text/xml; charset=utf-8");
                string responseString = responseTextBox.Text;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                string error = ex.Message + Environment.NewLine + ex.StackTrace;
                OltMessageBox.Show(error);
            }
        }

        private void SetRequestText(string text)
        {
            requestTextBox.Text = text;
        }

        private void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            listenButton.Enabled = true;
        }

        private void listenButton_Click(object sender, EventArgs e)
        {            
            if(responseTextBox.Text == null || responseTextBox.Text.Trim() == string.Empty)
            {
                responseTextBox.Text = "<HTML><BODY> Hello world!</BODY></HTML>";
            }

            listenButton.Enabled = false;            

            if (!HttpListener.IsSupported)
            {
                OltMessageBox.Show("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            if (serverURITextBox.Text == null || responseTextBox.Text.Trim() == string.Empty)
            {
                OltMessageBox.Show("Please enter a server URI.");
                return;
            }

            requestTextBox.Text = string.Empty;

            backgroundWorker.RunWorkerAsync();
        }
    }
}
