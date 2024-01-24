using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using log4net.Config;
using Microsoft.Win32;
using CommonConstants = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client
{
    public class Program
    {
        private const string LOGGING_FILE_NAME = "log4net.config";
        private static readonly ILog logger = LogManager.GetLogger(typeof (Program));

        [STAThread]
        public static void Main()
        {
            try
            {
                XmlConfigurator.Configure(new FileInfo(LOGGING_FILE_NAME));
                logger.Debug("Starting Operator Log Tool Smart Client");

                CurrentCulture.SetUpCulture();

                Application.EnableVisualStyles();
            
                Application.ThreadException += HandleApplicationException;
                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
                Application.ApplicationExit += Application_ThreadExit;
                SystemEvents.SessionEnding += SystemEvents_SessionEnding;
                SystemEvents.PowerModeChanged += PowerModeChanged;
                NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;

                ITimeService timeService = ClientServiceRegistry.Instance.GetService<ITimeService>();
                
                if (timeService == null)
                {
                    logger.Error("The time service is null. This means that all times will be using the system clock. This should be investigated");
                }

                Clock.UseTimeService(timeService);
                Analytics.Initialize(ClientServiceRegistry.Instance.GetService<IAnalyticsService>());
                Application.Run(new MainForm());

                if (ClientSession.GetInstance().ForceLogoff)
                {
                    logger.Debug("Forced Restart starting.");
                    Application.Restart();
                }
            }
            catch (FileNotFoundException ex)
            {
                string message = StringResources.ApplicationException_ErrorCode1002 + Environment.NewLine + ex.Message;
                DisplayandLogError(ex, message);
            }
            catch (EndpointNotFoundException ex)
            {
                string message = StringResources.ApplicationException_ErrorCode1004;
                DisplayandLogError(ex, message);
            }
            catch (Exception ex)
            {
                string message = StringResources.ApplicationException_ErrorCode1003 + Environment.NewLine + Environment.NewLine + ex;
                DisplayandLogError(ex, message);
            }
        }

        private static void DisplayandLogError(Exception ex, string message)
        {
            MessageBox.Show(message, StringResources.OLTErrorTitle,  MessageBoxButtons.OK,  MessageBoxIcon.Error);
            logger.Error("Exception in OLT CLient.", ex);
        }

        // This pre 4.0 method signature cannot be changed in order to maintain backwards compatibilty with 
        // old bootstrappers. We need to keep it as is until all old bootstrappers are gone.

        /// <summary>
        /// Static Events must be detached, otherwise they will remain attached to the vent and continue to consume memory
        /// </summary>
        private static void CleanupStaticEvents()
        {
            Application.ThreadException -= HandleApplicationException;
            AppDomain.CurrentDomain.UnhandledException -= HandleUnhandledException;
            Application.ApplicationExit -= Application_ThreadExit;
            SystemEvents.SessionEnding -= SystemEvents_SessionEnding;
            SystemEvents.PowerModeChanged -= PowerModeChanged;
            NetworkChange.NetworkAvailabilityChanged -= NetworkChange_NetworkAvailabilityChanged;
        }

        private static bool IsWindowsXPMachine()
        {
            return Environment.OSVersion.Version.Major < 6;
        }

        private static void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            bool isWindows7Machine = !IsWindowsXPMachine();

            if (e.IsAvailable == false)
            {
                logger.Info("Lost network connectivity.");
                
                if (isWindows7Machine)
                {
                    ClientServiceRegistry.Instance.SleepOrHibernate(EventConnectDisconnectReason.NetworkConnectionLost);
                }
            }
            else
            {
                logger.Info("Network became enabled again.");
                if (isWindows7Machine)
                {
                    UserContext ctx = ClientSession.GetUserContext();
                    ClientServiceRegistry.Instance.ResumeOnWakeup(ctx.RootsForSelectedFunctionalLocations, ctx.RootFlocSetForWorkPermits.FunctionalLocations, ctx.RootFlocSetForRestrictions.FunctionalLocations, ctx.ReadableVisibilityGroupIds);
                    logger.Info("Re-connected to Event repeater.");
                }
            }
        }

        private static void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            bool isWindowsXpMachine = IsWindowsXPMachine();
            // for now, we are just logging Power Mode Changes, but not doing anything with them.
            if (e.Mode == PowerModes.Suspend)
            {
                logger.Info("System going into PowerModes.Suspend");
                if (isWindowsXpMachine)
                {
                    ClientServiceRegistry.Instance.SleepOrHibernate(EventConnectDisconnectReason.NetworkConnectionLost);
                }

            }
            else if (e.Mode == PowerModes.Resume)
            {
                logger.Info("System going into PowerModes.Resume");
                if (isWindowsXpMachine)
                {
                    Thread.Sleep(3000); // give it a few second to re-connect the network. Might want to look at:
                    // http://www.codeproject.com/Articles/64975/Detect-Internet-Network-Availability
                    // as a better way of detecting the ability to connect. 
                    // In addition, a ping to the server url would be useful as this is what we need to connect to.
                    UserContext ctx = ClientSession.GetUserContext();
                    ClientServiceRegistry.Instance.ResumeOnWakeup(ctx.RootsForSelectedFunctionalLocations, ctx.RootFlocSetForWorkPermits.FunctionalLocations, ctx.RootFlocSetForRestrictions.FunctionalLocations,ctx.ReadableVisibilityGroupIds);
                    logger.Info("Re-connected to Event repeater.");
                }
            }
        }

        private static void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.Logoff)
            {
                logger.Info("User is logging off while OLT is running.");
                CleanupOnExit(EventConnectDisconnectReason.SessionEndLogoff);                
            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
				logger.Info("System is shutting down while OLT is running.");                
                CleanupOnExit(EventConnectDisconnectReason.SessionEndSystemShutdown);
            }
        }

        private static void Application_ThreadExit(object sender, EventArgs e)
        {
            CleanupOnExit(EventConnectDisconnectReason.ApplicationExit);
            CleanupStaticEvents();
        }

        private static bool cleanupExecuted;


        private static void CleanupOnExit(EventConnectDisconnectReason reason)
        {
            if (cleanupExecuted)
                return;

            try
            {
                logger.Info("Starting to cleanup on exit.");

                FlushAnalytics();
                DisconnectRemoteEventRepeater(reason);
                ReleaseAllClientLocks();
                CloseServices();

                logger.Info("Done cleanup on exit.");
            }
            finally
            {
                cleanupExecuted = true;    
            }
        }

        private static void CloseServices()
        {
            try
            {
                logger.Info("Attempting to close client side services.");
                ClientServiceRegistry.Instance.CloseAll();
                logger.Info("Done closing client side services.");
            }
            catch (Exception e)
            {
                logger.Error("Error closing client side services: " + e.Message, e);
            }
        }

        private static void ReleaseAllClientLocks()
        {
            try
            {
                logger.Info("Attempting to release all locks.");
                IObjectLockingService lockingService = ClientServiceRegistry.Instance.GetService<IObjectLockingService>();
                if (lockingService != null)
                {
                    lockingService.ReleaseLock(ClientSession.GetInstance().GuidAsString);
                }
                logger.Info("Done releasing all locks.");
            }
            catch (Exception e)
            {
                logger.Error("Error releasing all locks: " + e.Message, e);
            }
        }

        private static void DisconnectRemoteEventRepeater(EventConnectDisconnectReason reason)
        {
            try
            {
                logger.Info("Attempting to disconnect remote event repeater.");
                IRemoteEventRepeater remoteEventRepeater = ClientServiceRegistry.Instance.RemoteEventRepeater;
                if (remoteEventRepeater != null)
                {
                    remoteEventRepeater.Disconnect(reason);
                }
                logger.Info("Done disconnecting remote event repeater.");
            }
            catch (Exception e)
            {
                logger.Error("Error disconnectiong remote event repeater: " + e.Message, e);
            }
        }

        private static void FlushAnalytics()
        {
            try
            {
                Analytics.FlushSynchronously();
            }
            catch (Exception e)
            {
                logger.Error("Error flushing analytics events: " + e.Message, e);
            }
        }

        private static void HandleApplicationException(object sender, ThreadExceptionEventArgs e)
        {
            Exception exception = e.Exception;
            
            string message;
            if (exception is WebException || exception is SocketException)
            {
                message = StringResources.ApplicationException_NetworkIssue;
            }
            else
            {
                message = StringResources.ApplicationException_GeneralError;
            }

            if (exception is FaultException)
            {
                logger.Error(message + Environment.NewLine +  exception.Message);
            }
            else
            {
                logger.Error(message, exception);                
            }

            CleanupOnExit(EventConnectDisconnectReason.ApplicationException);

            OltMessageBox.Show(Form.ActiveForm, message, StringResources.OLTErrorTitle, MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

            Application.Exit();
        }


        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error("Unhandled exception on client: " + e.ExceptionObject);                
        }
    }
}