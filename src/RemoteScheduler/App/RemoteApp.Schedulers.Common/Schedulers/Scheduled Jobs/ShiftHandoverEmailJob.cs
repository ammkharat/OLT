using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    public class ShiftHandoverEmailJob : AbstractScheduledJob
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ShiftHandoverEmailJob>();

        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IActionItemService actionItemService;
        private readonly long configurationId;
        private readonly IFunctionalLocationOperationalModeService functionalLocationOperationalModeService;
        private readonly IShiftHandoverService handoverService;
        private readonly string jobName;
        private readonly IFormEdmontonService lubesCsdService;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ITimeService timeService;
        private IExcursionResponseService excursionResponseService;

        public ShiftHandoverEmailJob(
            ShiftHandoverEmailConfiguration configuration,
            IShiftHandoverService shiftHandoverService,
            IActionItemDefinitionService actionItemDefinitionService,
            IShiftPatternService shiftPatternService,
            IActionItemService actionItemService,
            IExcursionResponseService excursionResponseService,
            IFormEdmontonService lubesCsdService,
            IFunctionalLocationOperationalModeService flocOperationalModeService,
            ISiteConfigurationService siteConfigurationService,
            ITimeService timeService)
            : base(configuration.Schedule)
        {
            configurationId = configuration.IdValue;
            jobName = string.Format("Shift Handover E-mail (Configuration Id: #{0})", configurationId);

            handoverService = shiftHandoverService;
            this.actionItemDefinitionService = actionItemDefinitionService;
            this.shiftPatternService = shiftPatternService;
            this.excursionResponseService = excursionResponseService;
            this.actionItemService = actionItemService;
            this.lubesCsdService = lubesCsdService;
            functionalLocationOperationalModeService = flocOperationalModeService;
            this.siteConfigurationService = siteConfigurationService;
            this.timeService = timeService;
        }

        public ShiftHandoverEmailJob(ShiftHandoverEmailConfiguration configuration)
            : this(
                configuration,
                SchedulerServiceRegistry.Instance.GetService<IShiftHandoverService>(),
                SchedulerServiceRegistry.Instance.GetService<IActionItemDefinitionService>(),
                SchedulerServiceRegistry.Instance.GetService<IShiftPatternService>(),
                SchedulerServiceRegistry.Instance.GetService<IActionItemService>(),
            SchedulerServiceRegistry.Instance.GetService<IExcursionResponseService>(),
                SchedulerServiceRegistry.Instance.GetService<IFormEdmontonService>(),
                SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>(),
                SchedulerServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
                SchedulerServiceRegistry.Instance.GetService<ITimeService>())
        {
        }

        public override string Name
        {
            get { return jobName; }
        }

        public override void Execute()
        {
            List<ShiftHandoverQuestionnaireReportAdapter> reportAdapters;

            var configuration = handoverService.QueryShiftHandoverEmailConfigurationById(configurationId);
            var site = configuration.Site;

            UserShift userShift;

            try
            {
                var siteConfiguration = siteConfigurationService.QueryBySiteId(site.IdValue);

                var shiftHandoverQuestionnaireReportAdapterBuilder =
                    new ShiftHandoverQuestionnaireReportAdapterBuilder(handoverService, actionItemDefinitionService,
                        shiftPatternService, actionItemService, functionalLocationOperationalModeService,
                        siteConfiguration, lubesCsdService, null, excursionResponseService);

                Culture.SetSpecificCultureOnThread(site.IsFrenchSite
                    ? Culture.FrenchCultureName
                    : Culture.DEFAULT_CULTURE_NAME);

                var shiftPattern = configuration.ShiftPattern;
                var workAssignments = configuration.WorkAssignments;
                var intendedEmailSendTime = configuration.EmailSendTime;

                // Note: using Clock.Now here is potentially dangerous if the scheduler is running late and sending the email the next day, but it should have sent it the previous day. I can't
                // find a way to know what date the schedule actually should have been sent.
                if (shiftPattern.IsTimeInShiftEndDateExclusive(intendedEmailSendTime))
                {
                    var intendedSendDateTime = intendedEmailSendTime.ToDateTime(new Date(Clock.Now));
                    userShift = new UserShift(shiftPattern, intendedSendDateTime);
                }
                else
                {
                    var intendedEmailSendDateTime = intendedEmailSendTime.ToDateTime(Clock.DateNow);

                    var isInShift = false;

                    var dateTimeToCheck = intendedEmailSendDateTime;

                    while (!isInShift)
                    {
                        isInShift = shiftPattern.IsTimeInShiftEndDateExclusive(dateTimeToCheck.ToTime());

                        if (!isInShift)
                        {
                            // Going back by minute is pretty weird, but it solves the issue of this loop
                            // ever getting infinite because someone creates a shift that lasts less than an hour. If I rolled back by 
                            // hour it would never hit that and loop forver.
                            dateTimeToCheck = dateTimeToCheck.AddMinutes(-1);
                        }
                    }

                    userShift = new UserShift(shiftPattern, dateTimeToCheck);
                }

                var allHandovers = new List<ShiftHandoverQuestionnaire>();

                foreach (var assignment in workAssignments)
                {
                    var handoverQuestionnaires = handoverService.QueryByWorkAssignmentAndShift(assignment.IdValue,
                        userShift);
                    allHandovers.AddRange(handoverQuestionnaires);
                }

                if (allHandovers.Count == 0)
                {
                    logger.Info("There are no handovers to email for configuration with ID: " + configurationId);
                    return;
                }

                reportAdapters = new List<ShiftHandoverQuestionnaireReportAdapter>();

                foreach (var shiftHandoverQuestionnaire in allHandovers)
                {
                    var adapters =
                        shiftHandoverQuestionnaireReportAdapterBuilder.GetShiftHandoverQuestionnaireReportAdapters(
                            shiftHandoverQuestionnaire, siteConfiguration, site);
                    reportAdapters.AddRange(adapters);
                }

                logger.Debug("Done converting handovers to adapters for handover email");
            }
            catch (Exception e)
            {
                logger.Error(
                    "There was an error gathering data and building the report information. Configuration id: " +
                    configurationId, e);
                return;
            }

            try
            {
                logger.Debug("About to initialize report for handover email");
                using (var report = new RtfShiftHandoverQuestionnaireReport())
                {
                    report.SetMasterAndSubReportDataSource(reportAdapters, timeService.GetTime(site.TimeZone));

                    logger.Debug("Creating document handover email document");
                    report.CreateDocument();

                    var emailAddresses = configuration.EmailAddresses;

                    var smtpServer = EmailSettings.SMTPServerURL;
                    var port = EmailSettings.SMTPServerPort;
                    var fromEmailAddress = EmailSettings.FromEmailAddress;

                    var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));

                    var subjectText = BuildSubjectText(userShift);
                    var messageBodyText = BuildBodyText(configuration);
                    var attachmentFilename = BuildAttachmentFilename(userShift);

                    var emails = emailAddresses.ToCommaSeparatedString();

                    logger.Info("Sending emails to: " + emails);

                    using (Stream memoryStream = new MemoryStream())
                    {
                        report.ExportToPdf(memoryStream);

                        foreach (var emailAddress in emailAddresses)
                        {
                            memoryStream.Position = 0;
                            mailSender.SendEmail(emailAddress, messageBodyText, subjectText, memoryStream,
                                attachmentFilename);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(
                    "There was an error exporting the report as a PDF or sending email. Configuration id: " +
                    configurationId, e);
            }
        }

        private string BuildAttachmentFilename(UserShift userShift)
        {
            return String.Format("Handover-{0}_{1}_{2}-{3}.pdf", userShift.StartDate.Month.ToString("0#"),
                userShift.StartDate.Day.ToString("0#"), userShift.StartDate.Year, userShift.ShiftPatternName);
        }

        private string BuildBodyText(ShiftHandoverEmailConfiguration configuration)
        {
            var introText = StringResources.HandoverEmailMessageText;
            var workAssignments = configuration.WorkAssignments;

            var builder = new StringBuilder();

            builder.AppendLine(introText);
            builder.AppendLine();

            foreach (var workAssignment in workAssignments)
            {
                builder.AppendLine("  " + workAssignment.DisplayName);
                // putting in two spaces as a hack (see http://stackoverflow.com/questions/247546/outlook-autocleaning-my-line-breaks-and-screwing-up-my-email-format)
            }

            return builder.ToString();
        }

        private string BuildSubjectText(UserShift shift)
        {
            var shiftHandoverText = StringResources.ShiftHandoverPossiblyPlural;
            var shiftName = shift.ShiftDisplayName;

            return string.Format("{0} - {1}", shiftHandoverText, shiftName);
        }
    }
}