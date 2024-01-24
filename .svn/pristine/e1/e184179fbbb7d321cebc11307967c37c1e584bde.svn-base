using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormOilsandsTrainingFixture
    {
        public static FormOilsandsTraining CreateForInsert(List<FunctionalLocation> flocs, FormStatus status, TrainingBlock trainingBlock)
        {
            User createdBy = UserFixture.CreateUserWithGivenId(1);
            return CreateForInsert(flocs, status, trainingBlock, createdBy);
        }

        public static FormOilsandsTraining CreateForInsert(List<FunctionalLocation> flocs, FormStatus status, TrainingBlock trainingBlock, User createdBy)
        {
            DateTime createdDateTime = Clock.Now;

            Role operatorRole = RoleFixture.GetRealRoleA(Site.OILSAND_ID);

            FormOilsandsTraining form = new FormOilsandsTraining(null, status, createdBy, createdDateTime, operatorRole)
                {
                    TrainingDate = new Date(2013, 6, 12),
                    GeneralComments = "General comments, yo.",
                    ApprovedDateTime = Clock.Now.AddDays(1),
                    FunctionalLocations = flocs,
                    WorkAssignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData(),
                    ShiftPattern = ShiftPatternFixture.CreateOilsandsDayShift(),
                    LastModifiedBy = createdBy,
                    LastModifiedDateTime = Clock.Now,
                    Approvals = new List<FormApproval> { new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 1) }
                };

            FormOilsandsTrainingItem formOilsandsTrainingItem = new FormOilsandsTrainingItem(null, null, trainingBlock, "comments","supervisor", false, 3.5m);
            form.TrainingItems = new List<FormOilsandsTrainingItem> { formOilsandsTrainingItem };

            return form;
        }

    }
}
