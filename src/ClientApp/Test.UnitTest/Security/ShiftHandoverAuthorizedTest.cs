using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{

    [TestFixture]
    public class ShiftHandoverAuthorizedTest
    {
        [Test]
        public void ShouldNotAllowMarkAsReadAfterShiftWhenCreatedBySameUser()
        {
            Authorized authorized = new Authorized();
            Clock.Freeze();
            Clock.Now = new DateTime(2010, 07, 29, 22, 0, 0);

            User markAsReadUser = UserFixture.CreateUserWithGivenId(1);

            DateTime questionnaireCreatedDateTime = new DateTime(2010, 07, 29, 10, 0, 0);
            User createdUser = markAsReadUser;
            ShiftPattern questionnaireShiftPattern = ShiftPatternFixture.CreateDayShift();
            UserShift questionnaireUserShift = new UserShift(questionnaireShiftPattern, questionnaireCreatedDateTime);

            var dto = new ShiftHandoverQuestionnaireDTO(1,
                                                        "daily handover",
                                                        "floc",
                                                        questionnaireShiftPattern.IdValue,
                                                        questionnaireShiftPattern.Name,
                                                        1, "AssignmentName",
                                                        createdUser.FirstName, createdUser.LastName, createdUser.FullNameWithUserName,
                                                        questionnaireCreatedDateTime,
                                                        questionnaireUserShift.StartDate, questionnaireUserShift.EndDate,
                                                        createdUser.IdValue, null, false, null,false, DateTime.MinValue, DateTime.MinValue);

            Assert.IsFalse(authorized.ToMarkShiftHandoverQuestionnairesAsRead(markAsReadUser, dto));
        }

        [Test]
        public void ShouldNotAllowMarkAsReadWhenCreatedBySameUser()
        {
            Authorized authorized = new Authorized();
            Clock.Freeze();
            Clock.Now = new DateTime(2010, 07, 29, 22, 0, 0);
            
            User markAsReadUser = UserFixture.CreateUserWithGivenId(1);

            DateTime questionnaireCreatedDateTime = new DateTime(2010, 07, 29, 20, 0, 0);
            User createdUser = markAsReadUser;
            ShiftPattern questionnaireShiftPattern = ShiftPatternFixture.CreateNightShift();
            UserShift questionnaireUserShift = new UserShift(questionnaireShiftPattern, questionnaireCreatedDateTime);

            var dto = new ShiftHandoverQuestionnaireDTO(1,
                                                        "daily handover",
                                                        "floc",
                                                        questionnaireShiftPattern.IdValue,
                                                        questionnaireShiftPattern.Name,
                                                        1, "AssignmentName",
                                                        createdUser.FirstName, createdUser.LastName, createdUser.FullNameWithUserName,
                                                        questionnaireCreatedDateTime,
                                                        questionnaireUserShift.StartDate, questionnaireUserShift.EndDate,
                                                        createdUser.IdValue, null, false, null,false, DateTime.MinValue, DateTime.MinValue);

            Assert.IsFalse(authorized.ToMarkShiftHandoverQuestionnairesAsRead(markAsReadUser, dto));

        }

        [Test]
        public void ShouldAllowMarkAsReadAfterShiftWhenCreatedByDifferentUser()
        {
            Authorized authorized = new Authorized();
            Clock.Freeze();
            Clock.Now = new DateTime(2010, 07, 29, 22, 0, 0);

            User markAsReadUser = UserFixture.CreateUserWithGivenId(1);

            DateTime questionnaireCreatedDateTime = new DateTime(2010, 07, 29, 10, 0, 0);
            User createdUser = UserFixture.CreateUserWithGivenId(2);
            ShiftPattern questionnaireShiftPattern = ShiftPatternFixture.CreateDayShift();
            UserShift questionnaireUserShift = new UserShift(questionnaireShiftPattern, questionnaireCreatedDateTime);

            var dto = new ShiftHandoverQuestionnaireDTO(1,
                                                        "daily handover",
                                                        "floc",
                                                        questionnaireShiftPattern.IdValue,
                                                        questionnaireShiftPattern.Name,
                                                        1, "AssignmentName",
                                                        createdUser.FirstName, createdUser.LastName, createdUser.FullNameWithUserName,
                                                        questionnaireCreatedDateTime,
                                                        questionnaireUserShift.StartDate, questionnaireUserShift.EndDate,
                                                        createdUser.IdValue, null, false, null,false, DateTime.MinValue, DateTime.MinValue);

            Assert.IsTrue(authorized.ToMarkShiftHandoverQuestionnairesAsRead(markAsReadUser, dto));

        }


    }
}
