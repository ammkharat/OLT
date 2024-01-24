using System;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Osherove.ThreadTester;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class ActionItemTimerManagerTest
    {
        [Test][Ignore]
        public void ShouldHandleMultipleThreadCallToAddTimerForSameActionItem()
        {
            var timerManager = new ActionItemTimerManager();

            ActionItemDTO dto = ActionItemDTOFixture.CreateActionItemRequiresResponseDto();
            var time = new TimeSpan(0, 0, 0 , 0, 20);
            var tt = new ThreadTester();
            for (int i = 0; i < 50; i++)
            {
                tt.AddThreadAction(() => timerManager.RegisterTimer(
                                             dto,
                                             time, delegate { return; }, null));
            }

            tt.RunBehavior = ThreadRunBehavior.RunUntilAllThreadsFinish;
            tt.StartAllThreads(10000);
        }

        [Test][Ignore]
        public void ShouldHandleMultipleThreadCallToRemoveAndAddTimerForSameActionItem()
        {
            var timerManager = new ActionItemTimerManager();

            ActionItemDTO dto = ActionItemDTOFixture.CreateActionItemRequiresResponseDto();
            var time = new TimeSpan(0, 0, 0, 0, 20);
            var tt = new ThreadTester();
            for (int i = 0; i < 50; i++)
            {
                tt.AddThreadAction(delegate
                {
                    timerManager.Unregister(dto);
                    timerManager.RegisterTimer(
                        dto,
                        time, delegate { return; }, null);
                });
            }

            tt.RunBehavior = ThreadRunBehavior.RunUntilAllThreadsFinish;
            tt.StartAllThreads(10000);
        }

        [Test][Ignore]
        public void ShouldHandleMultipleThreadCallToRemoveAndAddTimerForDifferentActionItems()
        {
            var timerManager = new ActionItemTimerManager();

            var time = new TimeSpan(0, 0, 0, 0, 20);
            var tt = new ThreadTester();
            for (int i = 1; i <= 50; i++)
            {
                tt.AddThreadAction(delegate
                {
                    ActionItemDTO dto = ActionItemDTOFixture.CreateActionItemRequiresResponseDto(i);
                    timerManager.Unregister(dto);
                    timerManager.RegisterTimer(
                        dto,
                        time, delegate { return; }, null);
                });
            }

            tt.RunBehavior = ThreadRunBehavior.RunUntilAllThreadsFinish;
            tt.StartAllThreads(10000);
        }

    }
}
