using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;
using log4net.Config;

namespace RemoteApp.Target.Scheduler
{
    public partial class TargetSchedulerTestRunner : Form
    {
        private static ITargetDefinitionService targetDefinitionService;
        private static IFunctionalLocationService functionalLocationService;
        private static FunctionalLocation floc;
        private static readonly Site sarnia = new Site(1, null, null, null, null);

        private static int nameCounter;
        private TargetScheduler scheduler;

        public TargetSchedulerTestRunner()
        {
            XmlConfigurator.Configure();

            InitializeComponent();

            targetDefinitionService = SchedulerServiceRegistry.Instance.GetService<ITargetDefinitionService>();
            functionalLocationService = SchedulerServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new TargetScheduler();
            scheduler.StartService();
            runningIndicatorPanel.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            return;

            floc = functionalLocationService.QueryByFullHierarchy("SR1-OFFS-DOCK", 1);

            try
            {
                for (var i = 0; i < 20; i++)
                {
                    var definition = CreateTargetDefinitionWithoutId(null);
                    targetDefinitionService.Insert(definition);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            var service = new TargetSchedulingService();

            try
            {
                MessageBox.Show("Starting scheduler");
                service.LoadScheduler();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tagInfo1 = new TagInfo(3, "54AI0061", "PSA BUILDING CO #1", "PPM", false,null) {Id = 132502};
            var tagInfo2 = new TagInfo(3, "54AI0062", "PSA BUILDING CO #2", "PPM", false,null) {Id = 132503};
            var tagInfo3 = new TagInfo(3, "54AI0063", "PSA BUILDING CO #3", "PPM", false,null) {Id = 132504};
            var tagInfo4 = new TagInfo(3, "54AI0064", "PSA BUILDING CO #4", "PPM", false,null) {Id = 132505};
            var tagInfo5 = new TagInfo(3, "53AI7001F", "PLT 53 SOUR H2O PUMP H2S", "PPM", false,null) {Id = 132851};

            var tags = new List<TagInfo> {tagInfo1, tagInfo2, tagInfo3, tagInfo4, tagInfo5};

            floc = functionalLocationService.QueryByFullHierarchy("UP1-FACL-BLDC", 3);

            try
            {
                for (var i = 0; i < 400; i++)
                {
                    var tagIndex = i%5;
                    var currentTag = tags[tagIndex];

                    var definition = CreateTargetDefinitionWithoutId(currentTag);
                    var notifiedEvents = targetDefinitionService.Insert(definition);
                }

                MessageBox.Show("Done inserting definitions.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception);
            }
        }

        public static TargetDefinition CreateTargetDefinitionWithoutId(TagInfo tagInfo)
        {
            var target = CreateTargetDefinition(tagInfo);
            target.Id = null;
            return target;
        }

        public static TargetDefinition CreateTargetDefinition(TagInfo tagInfo)
        {
            /*
54AI0061
54AI0062
54AI0063
54AI0064
53AI7001F
            
132502
132503
132504
132505
132851
             * 
             * 
             */

            var target = new TargetDefinition
                (
                UniqueName("CT"),
                "Target Fixture Description",
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Approved,
                tagInfo,
                CreateEvery2Minutes(),
                0.01m,
                0.02m,
                new decimal?(), //null, //2.34, //
                null,
                1,
                1,
                null,
                null,
                null,
                null,
                1,
                1,
                TargetValue.CreateEmptyTarget(), //Target value
                0,
                floc,
                false,
                true,
                false,
                true,
                new List<TargetDefinitionDTO>(),
                CreateUser("FSmith", "Fred", "Smith"),
                Clock.Now,
                true,
                OperationalMode.Normal,
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                WorkAssignment.NoneWorkAssignment) {Id = 1};

            return target;
        }


        // This is a test to see if it will work out.


        private static string UniqueName(string suffix)
        {
            nameCounter = nameCounter + 1;
            return Clock.Now.Ticks + "_" + nameCounter + suffix;
        }

        public static User CreateUser(string username, string firstname, string lastname)
        {
            var user = new User(username, firstname, lastname,
                new List<SiteRolePlant>(),
                "42",
                null,
                null,
                null,
                Clock.Now);

            user.Id = 1;

            return user;
        }

        public static RecurringMinuteSchedule CreateEvery2Minutes()
        {
            var fromTime = new Time(0); //Clock.TimeNow.Add(new TimeSpan(0, 0, 0, 0));
            var toTime = new Time(23, 59); //Clock.TimeNow.Add(new TimeSpan(0, 0, 0, 0));
            var startDate = Clock.DateNow;
            var endDate = Clock.DateNow.AddDays(5);
            var frequency = 1;
            var recurringMinuteSchedule =
                new RecurringMinuteSchedule(startDate, endDate, fromTime, toTime, frequency, sarnia);

            return recurringMinuteSchedule;
        }
    }
}