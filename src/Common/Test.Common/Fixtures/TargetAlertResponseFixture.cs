using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TargetAlertResponseFixture
    {

        public static TargetAlertResponse CreateNewResponse()
        {
            return CreateNewResponse(ShiftPatternFixture.Create6am_8hour_DayShift(), 
                                     new DateTime(1975, 09, 03, 3, 34, 12), "Response Text");
        }

        public static TargetAlertResponse CreateNewResponse(ShiftPattern shiftPattern, 
                                                            DateTime createdDateTime, 
                                                            string responseText)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.Id = 2;            
            User currentUser = UserFixture.CreateAdmin();

            TargetAlertResponse response = new TargetAlertResponse(alert, responseText, currentUser, createdDateTime, shiftPattern);
            response.GapReason = TargetGapReason.EquipmentFailure;
            response.ResponsibleForGap = alert.FunctionalLocation;
            response.ResponseComment = CommentFixture.CreateComment(createdDateTime);
            response.ResponseComment.Id = 1;

            return response;
        }
    }
}