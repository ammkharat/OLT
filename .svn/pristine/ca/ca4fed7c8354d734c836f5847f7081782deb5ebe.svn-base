using System;
using System.IO;
using System.Net;
using System.Text;
using log4net.Appender;
using log4net.Core;

namespace Com.Suncor.Olt.Client
{
    public class RemoteAppender : AppenderSkeleton 
    {
        private const int TIMEOUT = 5000;

        private string remoteUrl;

        // set in config file
        public string RemoteUrl
        {
            get { return remoteUrl; }
            set { remoteUrl = value; }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                string logMessage = CreateLogMessage(loggingEvent);
                Send(logMessage);
            }
            catch (Exception e)
            {
                ErrorHandler.Error("An error occurred while logging: ", e);
            }
        }

        private string CreateLogMessage(LoggingEvent loggingEvent)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(RenderLoggingEvent(loggingEvent));
            sb.AppendLine(UserLoginLogEntry.CreateLogMessage());
            
            return sb.ToString();
        }

        private void Send(string logMessage)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(logMessage);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RemoteUrl);
            request.KeepAlive = false;
            request.Timeout = TIMEOUT;
            request.ReadWriteTimeout = TIMEOUT;
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version10;
            request.ContentLength = bytes.Length;
            request.ContentType = "application/text";

            Stream stream = null;
            try
            {
                stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
