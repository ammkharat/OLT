using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class DirectiveDTOTest
    {
        [Test]
        public void ShouldKnowIfDTOIsInFuture()
        {
            Directive nextDaySameTime = DirectiveFixture.CreateForInsert();
            nextDaySameTime.ActiveFromDateTime = new DateTime(2013, 12, 2, 15, 15, 0);            
            DirectiveDTO nextDaySameTimeDTO = new DirectiveDTO(nextDaySameTime);            

            Directive sameDaySameTime = DirectiveFixture.CreateForInsert();
            sameDaySameTime.ActiveFromDateTime = new DateTime(2013, 12, 1, 15, 15, 0);            
            DirectiveDTO sameDaySameTimeDTO = new DirectiveDTO(sameDaySameTime);            

            Directive sameDayOneSecondLater = DirectiveFixture.CreateForInsert();
            sameDayOneSecondLater.ActiveFromDateTime = new DateTime(2013, 12, 1, 15, 15, 1);            
            DirectiveDTO sameDayOneSecondLaterDTO = new DirectiveDTO(sameDayOneSecondLater); 
          
            Directive inPast = DirectiveFixture.CreateForInsert();
            inPast.ActiveFromDateTime = new DateTime(2013, 11, 1, 15, 15, 1);            
            DirectiveDTO inPastDTO = new DirectiveDTO(inPast);            
         
            DateTime now = new DateTime(2013, 12, 1, 15, 15, 0); // Dec 1, 2013 3:15pm

            Assert.IsTrue(nextDaySameTimeDTO.IsInFuture(now));
            Assert.IsFalse(sameDaySameTimeDTO.IsInFuture(now));
            Assert.IsTrue(sameDayOneSecondLaterDTO.IsInFuture(now));
            Assert.IsFalse(inPastDTO.IsInFuture(now));
        }

        [Test]
        public void ShouldKnowIfDTOIsRelevantToAssignment()
        {
            WorkAssignment ass1 = WorkAssignmentFixture.CreateConsoleOperator();
            WorkAssignment ass2 = WorkAssignmentFixture.CreateUnitLeader();

            Directive directive1 = DirectiveFixture.CreateForInsert();
            directive1.WorkAssignments = new List<WorkAssignment> { ass1, ass2 };
            DirectiveDTO dto1 = new DirectiveDTO(directive1);
            Assert.IsTrue(dto1.IsRelevantToAssignment(ass1));
            Assert.IsTrue(dto1.IsRelevantToAssignment(ass2));
            Assert.IsTrue(dto1.IsRelevantToAssignment(null));

            Directive directive2 = DirectiveFixture.CreateForInsert();
            directive2.WorkAssignments = new List<WorkAssignment> { ass1 };
            DirectiveDTO dto2 = new DirectiveDTO(directive2);
            Assert.IsTrue(dto2.IsRelevantToAssignment(ass1));
            Assert.IsFalse(dto2.IsRelevantToAssignment(ass2));
            Assert.IsTrue(dto2.IsRelevantToAssignment(null));

            Directive directive3 = DirectiveFixture.CreateForInsert();
            directive3.WorkAssignments = new List<WorkAssignment> { ass2 };
            DirectiveDTO dto3 = new DirectiveDTO(directive3);
            Assert.IsFalse(dto3.IsRelevantToAssignment(ass1));
            Assert.IsTrue(dto3.IsRelevantToAssignment(ass2));
            Assert.IsTrue(dto3.IsRelevantToAssignment(null));

            Directive directive4 = DirectiveFixture.CreateForInsert();
            directive4.WorkAssignments = new List<WorkAssignment>();
            DirectiveDTO dto4 = new DirectiveDTO(directive4);
            Assert.IsTrue(dto4.IsRelevantToAssignment(ass1));
            Assert.IsTrue(dto4.IsRelevantToAssignment(ass2));
            Assert.IsTrue(dto4.IsRelevantToAssignment(null));
        }
    }
}
