using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace TestTool
{
    public partial class OpmExcursionProxyControl : UserControl
    {
        private static readonly char[] Separator = {'\\'};

        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        private readonly string localIpAddress;
        private HttpListener listener;
        private string soapExcursionResponseFooter = @"</GetOpmExcursionsResult>
		</GetOpmExcursionsResponse>
	</s:Body>
</s:Envelope>";

        private string soapExcursionResponseHeader =
            @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
	<s:Body>
		<GetOpmExcursionsResponse xmlns=""http://tempuri.org/"">
			<GetOpmExcursionsResult xmlns:a=""http://schemas.datacontract.org/2004/07/"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">";

        public OpmExcursionProxyControl()
        {
            InitializeComponent();

            localIpAddress = NetworkUtilities.GetLocalIpAddress();
            SetURITextBox(localIpAddress);

            backgroundWorker.DoWork += Listen;
            backgroundWorker.RunWorkerCompleted += WorkDone;

            ipAddressRadioButton.CheckedChanged += HandleIPAddressRadioButtonCheckChanged;
            localhostRadioButton.CheckedChanged += HandleLocalhostRadioButtonCheckChanged;

            fileSelectButton.Click += FileSelectButtonOnClick;
            filenameTextBox.TextChanged += FilenameTextBoxOnTextChanged;

            resetButton.Click += ResetButtonOnClick;
        }

        private string DefaultOpmExcursionResponseSoapMessage
        {
            get
            {
                var soapResponse = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
	<s:Body>
		<GetOpmExcursionsResponse xmlns=""http://tempuri.org/"">
			<GetOpmExcursionsResult xmlns:a=""http://schemas.datacontract.org/2004/07/"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>312.73193</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>65552</a:ExcursionId>
					<a:FunctionalLocation>UP1-P005-FRC1-SPT</a:FunctionalLocation>
					<a:HistorianTag>5TI25</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-23T12:14:54</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>45.5</a:ToeLimitValue>
					<a:ToeName>5TI255C99 OVERHEAD SOL High</a:ToeName>
					<a:ToeType>SOL High</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>DEGF</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>312.64557</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>65561</a:ExcursionId>
					<a:FunctionalLocation>UP1-P025-DRU2-SEH-PH0024</a:FunctionalLocation>
					<a:HistorianTag>25FI510A</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-23T12:20:05</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>25</a:ToeLimitValue>
					<a:ToeName>25FI510A25F-2 PASS#8 HC FEED SOL</a:ToeName>
					<a:ToeType>SOL High</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>BPH</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>146.25917</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>67325</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-SRU3</a:FunctionalLocation>
					<a:HistorianTag>53FI3031</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-30T10:43:16</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>250</a:ToeLimitValue>
					<a:ToeName>53FI303153D300 SULFUR PIT VAPOUR</a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>MSCFD</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>146.25833</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>67327</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-SRUF-SPT-C0530</a:FunctionalLocation>
					<a:HistorianTag>53LI5009</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-30T10:43:19</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>88</a:ToeLimitValue>
					<a:ToeName>53LI500953C530 CONTACTOR SOL Hig</a:ToeName>
					<a:ToeType>SOL High</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>PCT</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>146.25833</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>67328</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-TGTU</a:FunctionalLocation>
					<a:HistorianTag>53LI6049</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-30T10:43:19</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>12</a:ToeLimitValue>
					<a:ToeName>53LI604953C602 QUENCH TOWER SOL </a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>PCT</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>146.25806</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>67329</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-SRU4</a:FunctionalLocation>
					<a:HistorianTag>53PI4004</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-30T10:43:20</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>14.9</a:ToeLimitValue>
					<a:ToeName>53PI400453F400 BLOWER DISCHARGE </a:ToeName>
					<a:ToeType>SOL High</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>PSIG</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>145.5925</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>67339</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-TGTU</a:FunctionalLocation>
					<a:HistorianTag>53AI6000A</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-30T11:23:16</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>70</a:ToeLimitValue>
					<a:ToeName>53AI6000A53F612 SWAG FLARE WEST </a:ToeName>
					<a:ToeType>SOL High</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>PCT</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>24.43952</a:Average>
					<a:Duration>0.083333336</a:Duration>
					<a:EndDateTime>2015-02-05T02:18:16</a:EndDateTime>
					<a:EngineerComments/>
					<a:ExcursionId>69090</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-TGTU</a:FunctionalLocation>
					<a:HistorianTag>53FC6024</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T02:18:16</a:LastUpdatedDateTime>
					<a:Peak>24.43952</a:Peak>
					<a:ReasonCode/>
					<a:StartDateTime>2015-02-05T02:13:16</a:StartDateTime>
					<a:Status>CLOSED</a:Status>
					<a:ToeLimitValue>25</a:ToeLimitValue>
					<a:ToeName>53FC602453G603A/B REFLUX SOL Low</a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>USGPM</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>31.333334</a:Average>
					<a:Duration>0.25</a:Duration>
					<a:EndDateTime>2015-02-05T05:08:16</a:EndDateTime>
					<a:EngineerComments/>
					<a:ExcursionId>69117</a:ExcursionId>
					<a:FunctionalLocation>UP1-P010-PRIM-SPT-C0001</a:FunctionalLocation>
					<a:HistorianTag>10TI3</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T05:08:16</a:LastUpdatedDateTime>
					<a:Peak>31.0</a:Peak>
					<a:ReasonCode/>
					<a:StartDateTime>2015-02-05T04:53:16</a:StartDateTime>
					<a:Status>CLOSED</a:Status>
					<a:ToeLimitValue>32</a:ToeLimitValue>
					<a:ToeName>10TI310E1 OVHD COND AIR TEMP SOL</a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>DEGF</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>233.95778</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>66319</a:ExcursionId>
					<a:FunctionalLocation>UP1-P008-AMN1</a:FunctionalLocation>
					<a:HistorianTag>8TI26</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-01-26T19:01:21</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>32.9</a:ToeLimitValue>
					<a:ToeName>8TI268E7 AMINE RGN OH CON AIR SO</a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>DEGF</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0</a:Average>
					<a:Duration>65.50916</a:Duration>
					<a:EndDateTime i:nil=""true""/>
					<a:EngineerComments/>
					<a:ExcursionId>68384</a:ExcursionId>
					<a:FunctionalLocation>UP2-P053-SRU3</a:FunctionalLocation>
					<a:HistorianTag>53FI3019</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T12:58:49</a:LastUpdatedDateTime>
					<a:Peak i:nil=""true""/>
					<a:ReasonCode/>
					<a:StartDateTime>2015-02-02T19:28:16</a:StartDateTime>
					<a:Status>OPEN</a:Status>
					<a:ToeLimitValue>6</a:ToeLimitValue>
					<a:ToeName>53FI301953C305 LIQUID TO 53C100 </a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>USGPM</a:UnitOfMeasure>
				</a:OPMExcursion>
				<a:OPMExcursion>
					<a:Average>0.12989786</a:Average>
					<a:Duration>14.583333</a:Duration>
					<a:EndDateTime>2015-02-05T03:04:43</a:EndDateTime>
					<a:EngineerComments/>
					<a:ExcursionId>68963</a:ExcursionId>
					<a:FunctionalLocation>MR1-P004-0400</a:FunctionalLocation>
					<a:HistorianTag>M04FIC1215.DACA.PV</a:HistorianTag>
					<a:IlpNumber>0</a:IlpNumber>
					<a:LastUpdatedDateTime>2015-02-05T03:04:43</a:LastUpdatedDateTime>
					<a:Peak>0.0</a:Peak>
					<a:ReasonCode/>
					<a:StartDateTime>2015-02-04T12:29:43</a:StartDateTime>
					<a:Status>CLOSED</a:Status>
					<a:ToeLimitValue>7.3</a:ToeLimitValue>
					<a:ToeName>M04FIC1215.DACA.PVSTM GEN BFW IN</a:ToeName>
					<a:ToeType>SOL Low</a:ToeType>
					<a:ToeVersion>0</a:ToeVersion>
					<a:UnitOfMeasure>M3/HR</a:UnitOfMeasure>
				</a:OPMExcursion>
			</GetOpmExcursionsResult>
		</GetOpmExcursionsResponse>
	</s:Body>
</s:Envelope>";

                return soapResponse;
            }
        }

        private string DefaultOpmToeDefinitionResponseSoapMessage
        {
            get
            {
                var soapResponse = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
	<s:Body>
		<GetOpmToeDefinitionResponse xmlns=""http://tempuri.org/"">
			<GetOpmToeDefinitionResult xmlns:a=""http://schemas.datacontract.org/2004/07/"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
				<a:CauseDescription/>
				<a:ConsequenceDescription/>
				<a:CorrectiveActionDescription/>
				<a:FunctionalLocation>UP1-P005-FRC1-SEH-PH4135</a:FunctionalLocation>
				<a:HistorianTag>5LIC749</a:HistorianTag>
				<a:ToeLimitValue i:nil=""true""/>
				<a:ToeName>5LIC7495C99 GASOIL DRAW SOL High</a:ToeName>
				<a:ToeType>SOL High</a:ToeType>
				<a:ToeVersion>-1</a:ToeVersion>
				<a:ToeVersionPublishDate>2015-02-05T12:58:49</a:ToeVersionPublishDate>
				<a:UnitOfMeasure>%</a:UnitOfMeasure>
			</GetOpmToeDefinitionResult>
		</GetOpmToeDefinitionResponse>
	</s:Body>
</s:Envelope>";

                return soapResponse;
            }
        }

        private string DefaultCurrentTagValueResponseSoapMessage
        {
            get
            {
                var soapResponse = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
	<s:Body>
		<GetCurrentTagValueResponse xmlns=""http://tempuri.org/"">
			<GetCurrentTagValueResult xmlns:a=""http://schemas.datacontract.org/2004/07/"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
				<a:Description>5C99 GASOIL DRAW</a:Description>
				<a:Quality>GOOD</a:Quality>
				<a:TimeStamp>2015-02-27T12:58:26-07:00</a:TimeStamp>
				<a:Units>%</a:Units>
				<a:Value>50.88337</a:Value>
			</GetCurrentTagValueResult>
		</GetCurrentTagValueResponse>
	</s:Body>
</s:Envelope>";

                return soapResponse;
            }
        }

        private void ResetButtonOnClick(object sender, EventArgs eventArgs)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            // Clear the template data group
            useTemplateDataCheckbox.Checked = false;
            filenameTextBox.Clear();
            repeatsTextBox.Text = "1";
            uniqueFieldTextBox.Clear();

            // Clear the excursion, TOE def, and tag data response fields
            excursionResponseTextBox.Clear();
            toeDefinitionResponseTextBox.Clear();
            tagValueResponseTextBox.Clear();
        }

        private void FilenameTextBoxOnTextChanged(object sender, EventArgs eventArgs)
        {
            // Read data file
            var fileName = openFileDialog.FileName;
            using (var stream = new StreamReader(fileName, Encoding.Default, true))
            {
                var textOfFile = stream.ReadToEnd();

                // Convert data to string
                excursionResponseTextBox.Text = textOfFile;
            }
        }

        private void FileSelectButtonOnClick(object sender, EventArgs eventArgs)
        {
            openFileDialog.ShowDialog();
            var splitPath = openFileDialog.FileName.Split(Separator);
            filenameTextBox.Text = splitPath[splitPath.Length - 1];
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
            serverURITextBox.Text = string.Format("http://{0}:8882/", hostname);
        }

        private void Listen(object sender, DoWorkEventArgs e)
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add(serverURITextBox.Text);
                listener.Start();

                while (true)
                {
                    var context = listener.GetContext();
                    var request = context.Request;

                    var body = request.InputStream;
                    var encoding = request.ContentEncoding;
                    var reader = new StreamReader(body, encoding);

                    var requestStringText = reader.ReadToEnd();
                    reader.Close();
                    body.Close();

                    if (requestStringText.IsNullOrEmptyOrWhitespace())
                    {
                        requestStringText = string.Format("Request received from {0} at {1}",
                            request.RemoteEndPoint.Address, DateTime.Now.ToString("G"));
                    }

                    if (requestTextBox.InvokeRequired)
                    {
                        requestTextBox.Invoke((BackgroundCallback) SetRequestText, requestStringText);
                    }
                    else
                    {
                        requestTextBox.Text = requestStringText;
                    }

                    var response = context.Response;
                    response.AddHeader("Content-Type", "text/xml; charset=utf-8");
                    var responseString = GetResponseText(requestStringText);
                    var buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();

                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                }

                listener.Stop();
            }
            catch (HttpListenerException listenerException)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message + Environment.NewLine + ex.StackTrace;
                OltMessageBox.Show(error);
            }
        }

        private string GetResponseText(string requestText)
        {
            if (requestText.Contains("<GetOpmToeDefinition"))
            {
                return toeDefinitionResponseTextBox.Text;
            }

            if (requestText.Contains("<GetCurrentTagValue"))
            {
                return tagValueResponseTextBox.Text;
            }

            return excursionResponseTextBox.Text;
        }

        private void SetRequestText(string text)
        {
            requestTextBox.Text = text;
        }

        private void WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            listenButton.Enabled = true;
            stopListeningButton.Enabled = false;
            resetButton.Enabled = true;
        }

        private bool BuildExcursionResponseIfEmpty()
        {
            // If a soap envelope has already been generated or pasted into the response, use it;
            // otherwise generate one from the template or use the default

            var responseText = excursionResponseTextBox.Text;
            if (responseText.StartsWith(soapExcursionResponseHeader)) return true;


            // If a file is selected and iteration count, generate the response and set the text;
            // otherwise, if response is empty use the default.

            if (useTemplateDataCheckbox.Checked)
            {
                var numRepeats = 1;
                if (!int.TryParse(repeatsTextBox.Text, out numRepeats))
                {
                    MessageBox.Show("Enter the number of times to generate unique excursions from the template.",
                        "Invalid Repeats Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                long uniqueField = 0;
                if (!long.TryParse(uniqueFieldTextBox.Text, out uniqueField))
                {
                    MessageBox.Show("Enter a unique [numeric] field to increment for each excursion generated.",
                        "Invalid Unique Field Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (filenameTextBox.Text.Length != 0)
                {
                    var templateMessageBuilder = new StringBuilder(soapExcursionResponseHeader);
                    var messageData = excursionResponseTextBox.Text;

                    if (ValidateExcursionTemplateData(messageData) == false)
                    {
                        MessageBox.Show(
                            "Template data must be a single soap excursion of the format <a:OPMExcursion>...</a:OPMExcursion>.",
                            "Invalid Excursion Template", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    for (var i = 0; i < numRepeats; i++)
                    {
                        if (numRepeats > 1)
                        {
                            messageData = messageData.Replace(uniqueField.ToString(), (uniqueField + 1).ToString());
                            uniqueField++;
                        }

                        templateMessageBuilder.Append(messageData);
                    }

                    templateMessageBuilder.Append(soapExcursionResponseFooter);

                    excursionResponseTextBox.Clear();
                    excursionResponseTextBox.Text = templateMessageBuilder.ToString();
                }
                else
                {
                    MessageBox.Show("Please select a data file containing a single soap excursion of the format <a:OPMExcursion>...</a:OPMExcursion> to use as a template.", "No Excursion Template File Selected", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (excursionResponseTextBox.Text == null || excursionResponseTextBox.Text.Trim() == string.Empty)
                {
                    excursionResponseTextBox.Text = DefaultOpmExcursionResponseSoapMessage;
                }
            }

            return true;
        }

        private bool ValidateExcursionTemplateData(string excursionTemplateData)
        {
            if (excursionTemplateData.IsNullOrEmptyOrWhitespace()) return false;

            return excursionTemplateData.StartsWith("<a:OPMExcursion>") &&
                   excursionTemplateData.EndsWith("</a:OPMExcursion>");
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            if (BuildExcursionResponseIfEmpty() == false) return;

            if (toeDefinitionResponseTextBox.Text == null || toeDefinitionResponseTextBox.Text.Trim() == string.Empty)
            {
                toeDefinitionResponseTextBox.Text = DefaultOpmToeDefinitionResponseSoapMessage;
            }

            if (tagValueResponseTextBox.Text == null || tagValueResponseTextBox.Text.Trim() == string.Empty)
            {
                tagValueResponseTextBox.Text = DefaultCurrentTagValueResponseSoapMessage;
            }

            listenButton.Enabled = false;
            stopListeningButton.Enabled = true;
            resetButton.Enabled = false;

            if (!HttpListener.IsSupported)
            {
                OltMessageBox.Show("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            if (serverURITextBox.Text == null || excursionResponseTextBox.Text.Trim() == string.Empty)
            {
                OltMessageBox.Show("Please enter a server URI.");
                return;
            }

            requestTextBox.Text = string.Empty;

            backgroundWorker.RunWorkerAsync();
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void stopListeningButton_Click(object sender, EventArgs e)
        {
            if (listener.IsListening)
            {
                listener.Abort();
            }

            backgroundWorker.CancelAsync();
        }

        private delegate void BackgroundCallback(string text);
    }
}