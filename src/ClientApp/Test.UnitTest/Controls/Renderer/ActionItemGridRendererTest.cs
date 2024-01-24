using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class ActionItemGridRendererTest
    {
        private ActionItemGridRenderer renderer;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }
        [Ignore]
        [Test]
        public void ShouldDetermineActionItemColor()
        {

           renderer = new ActionItemGridRenderer();

            AssertActionItemColor(Color.Green, ActionItemStatus.Complete, TimeStatus.DoNotCare);
            AssertActionItemColor(Color.Red, ActionItemStatus.CannotComplete, TimeStatus.DoNotCare);

            AssertActionItemColor(Color.Blue, ActionItemStatus.Current, TimeStatus.Early);
            AssertActionItemColor(Color.Black, ActionItemStatus.Current, TimeStatus.Current);
            AssertActionItemColor(Color.Red, ActionItemStatus.Current, TimeStatus.Late);
        }
        [Ignore]
        [Test]
        public void ShouldRegisterTimerToRerenderIfNecesary()
        {
            Clock.Now = new DateTime(2006, 05, 05, 6, 0, 0);
            ClientSession.GetNewInstance();

            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(new Time(4, 0, 0), new Time(8, 0, 0), Clock.Now);

            TestRegisterTimerToRender(ActionItemStatus.Complete, TimeStatus.DoNotCare);
            TestRegisterTimerToRender(ActionItemStatus.CannotComplete, TimeStatus.DoNotCare);
            TestRegisterTimerToRender(ActionItemStatus.Current, TimeStatus.Late);

            // Timer should be registered for early items... when they become current (time-wise),
            // we will want to re-render them:
            TestRegisterTimerToRender(ActionItemStatus.Current, TimeStatus.Early);

            // Timer should be registered for current items that require response... 
            // when they become late, we will want to re-render them:
            TestRegisterTimerToRender(ActionItemStatus.Current, TimeStatus.Current);
        }
        [Ignore]
        [Test]
        public void ShouldNotRegisterTimerBecauseItIsEarlyAndWillNotFireDuringTheCurrentShift()
        {
            Clock.Now = new DateTime(2006, 05, 05, 6, 0, 0);
            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(new Time(4, 0, 0), new Time(8, 0, 0), Clock.Now);
            
            ActionItemDTO actionItem =
                CreateActionItem(ActionItemStatus.Current, new DateTime(2006, 05, 05, 5, 0, 0),
                                 new DateTime(2006, 05, 05, 11, 0, 0));

            Mockery mocks = new Mockery();
            ITimerManager timerManager =
                mocks.NewMock<ITimerManager>();
            renderer = new ActionItemGridRenderer(timerManager);
            
            UltraGridRow row = null;

            Expect.Never.On(timerManager).Method("RegisterTimer");

            // Execute:
            renderer.RegisterRenderTimer(actionItem, row);

            mocks.VerifyAllExpectationsHaveBeenMet();
            
        }
        [Ignore]
        [Test]
        public void ShouldNotRegisterTimerBecauseItIsCurrentButHasNoEndDate()
        {
            Clock.Now = new DateTime(2006, 05, 05, 6, 0, 0);
            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(new Time(4, 0, 0), new Time(8, 0, 0), Clock.Now);

            ActionItemDTO actionItem =
                CreateActionItem(ActionItemStatus.Current, new DateTime(2006, 05, 05, 5, 50, 5),
                                 DateTime.MaxValue);

            Mockery mocks = new Mockery();
            ITimerManager timerManager =
                mocks.NewMock<ITimerManager>();
            renderer = new ActionItemGridRenderer(timerManager);

            UltraGridRow row = null;

            Expect.Never.On(timerManager).Method("RegisterTimer");

            // Execute:
            renderer.RegisterRenderTimer(actionItem, row);

            mocks.VerifyAllExpectationsHaveBeenMet();

        }
        [Ignore]
        [Test]
        public void ShouldRegisterTimerBecauseItWillFireDuringTheCurrentShift()
        {
            Clock.Now = new DateTime(2006, 05, 05, 6, 0, 0);
            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(new Time(4, 0, 0), new Time(8, 0, 0), Clock.Now);

            ActionItemDTO actionItem =
                CreateActionItem(ActionItemStatus.Current, new DateTime(2006, 05, 05, 6, 0, 5),
                                 new DateTime(2006, 05, 05, 7, 59, 0));

            Mockery mocks = new Mockery();
            ITimerManager timerManager =
                mocks.NewMock<ITimerManager>();
            renderer = new ActionItemGridRenderer(timerManager);

            UltraGridRow row = null;

            Expect.Once.On(timerManager).Method("RegisterTimer");

            // Execute:
            renderer.RegisterRenderTimer(actionItem, row);

            mocks.VerifyAllExpectationsHaveBeenMet();

        }

        private void TestRegisterTimerToRender(ActionItemStatus status, TimeStatus timeStatus)
        {
            Mockery mocks = new Mockery();
            ITimerManager timerManager =
                mocks.NewMock<ITimerManager>();
            renderer = new ActionItemGridRenderer(timerManager);

            UltraGridRow row = null;
            ActionItemDTO actionItem = CreateActionItem(status, timeStatus);

            if (timeStatus == TimeStatus.Early)
            {
                SetExpectationForRegisteringTimer(timerManager, actionItem,
                                                  actionItem.StartDateTime.Subtract(Clock.Now));
            }
            else if (timeStatus == TimeStatus.Current)
            {
                SetExpectationForRegisteringTimer(timerManager, actionItem,
                                                  actionItem.EndDateTime.Subtract(Clock.Now));
            }
            else
            {
                // No timer should be registered.
            }

            // Execute:
            renderer.RegisterRenderTimer(actionItem, row);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static void SetExpectationForRegisteringTimer(ITimerManager timerManager,
                                                       ActionItemDTO actionItem, TimeSpan dueTime)
        {
            Expect.Once.On(timerManager).Method("RegisterTimer")
                .With(Is.EqualTo(actionItem), Is.EqualTo(dueTime),
                      TestUtil.IsTypeOf(typeof (TimerCallback)), Is.Null);
        }

        private void AssertActionItemColor(Color expectedColor, ActionItemStatus status, TimeStatus timeStatus)
        {
            ActionItemDTO actionItem = CreateActionItem(status, timeStatus);
            Assert.AreEqual(expectedColor, ActionItemGridRenderer.GetColorForActionItem(actionItem));
        }

        private ActionItemDTO CreateActionItem(ActionItemStatus status, TimeStatus timeStatus)
        {
            if (timeStatus == TimeStatus.Early)
            {
                // Current time is before action item start time:
                ActionItemDTO actionItem = CreateActionItem(status,
                                                            Clock.Now.AddHours(1), Clock.Now.AddHours(2));
                Assert.IsTrue(actionItem.IsEarly(Clock.Now));
                return actionItem;
            }
            if (timeStatus == TimeStatus.Late)
            {
                // Current time is after action item end time:
                ActionItemDTO actionItem = CreateActionItem(status,
                                                            Clock.Now.AddHours(-2), Clock.Now.AddHours(-1));
                Assert.IsTrue(actionItem.IsLate(Clock.Now));
                return actionItem;
            }
            else
            {
                ActionItemDTO actionItem = CreateActionItem(status,
                                                            Clock.Now.AddHours(-1), Clock.Now.AddHours(1));
                Assert.IsTrue(actionItem.IsCurrent(Clock.Now));
                return actionItem;
            }
        }

        private static ActionItemDTO CreateActionItem(ActionItemStatus status,
                                               DateTime startDateTime, DateTime endDateTime)
        {
            return new ActionItemDTO(-99, startDateTime, startDateTime, endDateTime, endDateTime,
                                     status.IdValue, Priority.Normal, string.Empty, 0, string.Empty,
                                     string.Empty, new List<string> { string.Empty }, new List<string> { string.Empty }, true, null, "some name", null, null, null,null,0,false);
        }

        private enum TimeStatus
        {
            DoNotCare,
            Early,
            Current,
            Late
        } ;
    }
}