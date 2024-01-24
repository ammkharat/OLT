using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class ActionItemDTOTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void IsLateShouldReturnTrueIfActionItemDtoIsAfterCurrentTime()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 7, 0, 0), new DateTime(2006, 1, 1, 8, 0, 0));

            Assert.IsTrue(actionItemDto.IsLate(new DateTime(2006, 1, 1, 9, 0, 0)));
        }

        [Test]
        public void IsLateShouldReturnFalseIfActionItemDtoIsDuringCurrentTime()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 9, 0, 0), new DateTime(2006, 1, 1, 10, 0, 0));

            Assert.IsFalse(actionItemDto.IsLate(new DateTime(2006, 1, 1, 8, 0, 0)));
        }

        [Test]
        public void IsLateShouldReturnFalseIfActionItemDtoHasNoEndDate()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 8, 0, 0), DateTime.MaxValue);

            Assert.IsFalse(actionItemDto.IsLate(new DateTime(2006, 1, 1, 9, 0, 0)));
        }

        [Test]
        public void ShouldEvaluateIfIsCurrent()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 8, 0, 0), new DateTime(2006, 1, 1, 10, 0, 0));

            Assert.IsFalse(actionItemDto.IsCurrent(new DateTime(2006, 1, 1, 7, 59, 59)));

            Assert.IsTrue(actionItemDto.IsCurrent(new DateTime(2006, 1, 1, 9, 0, 0)));

            Assert.IsFalse(actionItemDto.IsCurrent(new DateTime(2006, 1, 1, 10, 0, 1)));
        }

        [Test]
        public void IsLateLogicTest()
        {
            ActionItemDTO actionItemDto =
                new ActionItemDTO(1, new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 8, 0, 0),
                                  new DateTime(2006, 1, 1, 10, 0, 0), new DateTime(2006, 3, 3, 10, 0, 0), 1,
                                  Priority.Normal, "BLA",
                                  1, "the description", "1", new List<string> { "SR1" }, new List<string> { "SR1 (SR1)" }, true, null, "some name", null, null, null,null,0,false);

            Assert.IsTrue(actionItemDto.IsLate(new DateTime(2006, 2, 2, 11, 0, 0)));
        }

        [Test]
        public void IsEarlyShouldReturnTrueIfActionItemDtoStartDateIsAfterCurrentTime()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 9, 0, 0), new DateTime(2006, 1, 1, 10, 0, 0));

            Assert.IsTrue(actionItemDto.IsEarly(new DateTime(2006, 1, 1, 8, 0, 0)));
        }

        [Test]
        public void IsEarlyShouldReturnFalseIfActionItemDtoStartDateIsBeforeCurrentTime()
        {
            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemRequiresResponseDtoWithDates
                (new DateTime(2006, 1, 1), new DateTime(2006, 1, 1, 8, 0, 0), new DateTime(2006, 1, 1, 10, 0, 0));

            Assert.IsFalse(actionItemDto.IsEarly(new DateTime(2006, 1, 1, 9, 0, 0)));
        }
    }
}