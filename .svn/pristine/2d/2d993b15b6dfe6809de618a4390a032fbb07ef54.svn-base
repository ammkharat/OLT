using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ShiftHandoverQuestionnaireFixture
    {
        public static ShiftHandoverQuestionnaire Create()
        {
            return Create(new List<FunctionalLocation> {FunctionalLocationFixture.GetAny_Unit1()});
        }

        public static ShiftHandoverQuestionnaire Create(List<FunctionalLocation> functionalLocations)
        {
            return Create(functionalLocations, WorkAssignmentFixture.CreateShiftEngineer());
        }

        public static ShiftHandoverQuestionnaire Create(List<FunctionalLocation> functionalLocations, WorkAssignment assignment)
        {
            return Create(assignment, UserFixture.CreateUserWithGivenId(1),
                ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 2, 11, 4, 15, 0), functionalLocations);
        }

        public static ShiftHandoverQuestionnaire Create(WorkAssignment assignment, User createdByUser, ShiftPattern shiftPattern, DateTime createdDateTime, List<FunctionalLocation> functionalLocations)
        {
            return Create(null, assignment, createdByUser, shiftPattern, createdDateTime, functionalLocations);
        }

        public static ShiftHandoverQuestionnaire Create(long? id, WorkAssignment assignment, User createdByUser, ShiftPattern shiftPattern, DateTime createdDateTime, List<FunctionalLocation> functionalLocations)
        {
            ShiftHandoverAnswer answer1 = ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments 1", "question 1","Yes","pk@hotmail.com");//Yes is added by ppanigrahi
            ShiftHandoverAnswer answer2 = ShiftHandoverAnswerFixture.GetShiftHandoverAnswerToInsert("comments 2", "question 2", "No", "pk@hotmail.com");//No is added by ppanigrahi

            List<ShiftHandoverAnswer> answers = new List<ShiftHandoverAnswer> { answer1, answer2 };

            return new ShiftHandoverQuestionnaire(
                id,
                "a config name here",
                shiftPattern,
                assignment,
                createdByUser,
                createdDateTime,
                functionalLocations,
                answers,
                new List<long>(), DateTime.MinValue, DateTime.MinValue, true);
        }
    }
}