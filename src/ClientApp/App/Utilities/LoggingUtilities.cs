using System;
using System.Diagnostics;
using log4net;
using log4net.Appender;
using log4net.Repository;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class LoggingUtilities
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoggingUtilities));

        public static void OpenLogFile()
        {
            try
            {
                string logFile = GetLogFileNameWithFullPath();
                if (!string.IsNullOrEmpty(logFile))
                {
                    Process.Start(logFile);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error opening log file: " + e);
            }
        }

        public static void EmailLogFile()
        {
            try
            {
                string logFile = GetLogFileNameWithFullPath();
                if (!string.IsNullOrEmpty(logFile))
                {
                    // This is not translated because the email is meant for an English speaking support person.
                    const string subject = "OLT Support Log File"; 
                    string body = UserLoginLogEntry.CreateLogMessage() + Environment.NewLine;

                    EmailClient emailClient = new EmailClient();
                    emailClient.SendEmail(subject, body, logFile, false);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error emailing log file: " + e);
            }
        }

        private static string GetLogFileNameWithFullPath()
        {
            foreach (ILoggerRepository repository in LogManager.GetAllRepositories())
            {
                foreach (IAppender appender in repository.GetAppenders())
                {
                    if (appender is RollingFileAppender)
                    {
                        RollingFileAppender fileAppender = (RollingFileAppender) appender;
                        return fileAppender.File;
                    }
                }
            }
            return null;
        }

    }
}
