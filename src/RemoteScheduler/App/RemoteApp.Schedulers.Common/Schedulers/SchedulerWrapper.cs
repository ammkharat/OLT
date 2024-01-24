using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using log4net.Config;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class SchedulerWrapper<T> where T : ISchedulingService
    {
        private readonly ILog logger;
        private bool isServiceStarting;

        private ISchedulingService schedulingService;
        private Thread workerThread;

        public SchedulerWrapper()
        {
            logger = GenericLogManager.GetLogger<SchedulerWrapper<T>>();
        }

        private string GenerateBigMessageBlock(string customMessageToLog)
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            var padding = string.Empty.PadRight(80, '*');

            builder.AppendLine(padding);
            builder.AppendLine(padding);
            builder.AppendLine(padding);
            builder.AppendLine(customMessageToLog);
            builder.AppendLine(padding);
            builder.AppendLine(padding);
            builder.AppendLine(padding);
            return builder.ToString();
        }

        public void OnStart()
        {
            isServiceStarting = true;

            ThreadStart threadStart = StartService;
            workerThread = new Thread(threadStart);

            workerThread.Start();
        }

        /// <summary>
        ///     Starting the scheduling services including setting up the services
        /// </summary>
        private void StartService()
        {
            XmlConfigurator.Configure();

            logger.Info("Starting background scheduling services.");

            RegisterEventRepeater();

            SetupSchedulers();

            logger.Info("Complete starting background services.");
            isServiceStarting = false;
        }


        public void OnStop()
        {
            // Don't try to stop while we are still starting up.
            while (isServiceStarting)
            {
                Thread.Sleep(100);
            }

            // Try to be nice and stop the thread politely.
            ThreadStart threadStart = StopScheduler;
            var workerStopThread = new Thread(threadStart);
            workerStopThread.Start();

            // Wait for this new thread to stop the scheduler and the original thread that started the schedule are complete.
            // Only wait a minute for them.  Then tell them sorry, we tried to be nice and wait, but now you must die!
            workerStopThread.Join(new TimeSpan(0, 1, 0));
            workerThread.Join(new TimeSpan(0, 1, 0));

            StopService();
            logger.Info(string.Format("Completed stopping {0}", schedulingService.ScheduleName));
        }

        private void StopScheduler()
        {
            logger.Info(String.Format("Stopping {0}...", schedulingService.ScheduleName));
            schedulingService.StopService();
        }

        private void StopService()
        {
            UnregisterEventRepeater();
            SchedulerServiceRegistry.Instance.CloseAll();
        }

        /// <summary>
        ///     Start up the schedulers and load the definitions
        /// </summary>
        private void SetupSchedulers()
        {
            try
            {
                logger.Info(string.Format("Attempting to create {0}", typeof (T)));
                schedulingService = (ISchedulingService) Activator.CreateInstance(typeof (T));
            }
            catch (Exception e)
            {
                var errorMessage =
                    GenerateBigMessageBlock(
                        string.Format(
                            "Could Not create {0}. Are you missing a no-arg constructor? SHUTTING DOWN THE SERVICE",
                            typeof (T)));
                logger.Error(errorMessage, e);
                throw;
            }

            try
            {
                logger.Info(string.Format("Setting up the {0}.", schedulingService.ScheduleName));
                schedulingService.LoadScheduler();
                logger.Info(string.Format("{0} successfully started.", schedulingService.ScheduleName));
            }
            catch (Exception e)
            {
                var errorMessage =
                    GenerateBigMessageBlock(string.Format("Error starting {0}.  SHUTTING DOWN THE SERVICE",
                        schedulingService.ScheduleName));
                logger.Error(errorMessage, e);
                throw;
            }
        }

        /// <summary>
        ///     register the client side event sink and create the server side hooks
        /// </summary>
        private void RegisterEventRepeater()
        {
            const int maxAttempts = 3;

            var attemptNumber = 1;
            var successful = false;

            logger.Info("Setting up the remote event repeater.");

            while (attemptNumber <= maxAttempts && !successful)
            {
                try
                {
                    logger.Info(String.Format("Attempting to connect to remote events, attempt #{0}", attemptNumber));
                    SchedulerServiceRegistry.Instance.RemoteEventRepeater.Connect(new List<FunctionalLocation>(),
                        new List<FunctionalLocation>(), new List<FunctionalLocation>(),null, EventConnectDisconnectReason.SchedulerStart);
                    successful = true;
                    logger.Info(String.Format("Succeeded in connecting to remote events on attempt #{0}", attemptNumber));
                }
                catch (Exception e)
                {
                    logger.Info(
                        String.Format("Error attempting to connect to remote events on attempt #{0}", attemptNumber), e);
                    if (attemptNumber < maxAttempts)
                    {
                        logger.Info(String.Format("Sleeping for 1 second, and then will retry again"));
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        logger.Info(String.Format("Max number of attempts has been exceeded.  No more retrying."));
                    }
                }
                attemptNumber++;
            }

            if (!successful)
            {
                var remoteEventHandlerConnectionError =
                    string.Format(
                        "An error occurred while attempting to connect with the remote server to register event handlers for {0}. SHUTTING DOWN THE SERVICE.",
                        typeof (T).Name);

                var errorMessage = GenerateBigMessageBlock(remoteEventHandlerConnectionError);
                logger.Error(errorMessage);
                throw new CommunicationException(remoteEventHandlerConnectionError);
            }
        }

        /// <summary>
        ///     clears the server side event hooks in the event sink
        /// </summary>
        private void UnregisterEventRepeater()
        {
            logger.Info("Unregistering  the remote event repeater.");
            SchedulerServiceRegistry.Instance.RemoteEventRepeater.Disconnect(EventConnectDisconnectReason.SchedulerStop);
        }
    }
}