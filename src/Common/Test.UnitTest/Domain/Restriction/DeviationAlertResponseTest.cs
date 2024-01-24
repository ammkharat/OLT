using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [TestFixture]
    public class DeviationAlertResponseTest
    {
        [Test]
        public void ShouldCreateSnapshotWhenNoCommentsOnResponse()
        {
            var deviationAlertResponse = new DeviationAlertResponse("Test comments", UserFixture.CreateOperator(),
                DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            deviationAlertResponse.Id = 100;

            var restrictionReasonCodeThatIsInDb = RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb();
            var restrictionLocationItem =
                RestrictionLocationItemFixture.CreateWithReasonCodes(restrictionReasonCodeThatIsInDb);

            var deviationAlertResponseReasonCodeAssignment =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem,
                    FunctionalLocationFixture.GetAny_Equip1(), restrictionReasonCodeThatIsInDb, null, 100, null,
                    UserFixture.CreateOperator(), DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            var list = deviationAlertResponse.ReasonCodeAssignments;
            list.Add(deviationAlertResponseReasonCodeAssignment);

            var deviationAlertResponseHistory = deviationAlertResponse.TakeSnapshot();
            Assert.That(deviationAlertResponseHistory, Is.Not.Null);

            Assert.That(deviationAlertResponseHistory.ReasonCodes, Is.Not.Null);
            Assert.That(deviationAlertResponseHistory.ReasonCodes, Is.Not.EqualTo(string.Empty));
            Assert.That(deviationAlertResponseHistory.Comments, Is.EqualTo("Test comments"));
        }
    }
}