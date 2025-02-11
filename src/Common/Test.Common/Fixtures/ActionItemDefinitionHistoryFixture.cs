using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemDefinitionHistoryFixture
    {
        public static List<ActionItemDefinitionHistory> CreateActionItemDefinitionHistories()
        {
            ActionItemDefinitionHistory history1 = CreateActionItemDefinitionHistory();
            history1.LastModifiedDate = new DateTime(2006, 05, 16, 12, 00, 00);
            history1.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ActionItemDefinitionHistory history2 = CreateActionItemDefinitionHistory();
            history2.Description = history2.Description + "Changed";
            history2.LastModifiedDate = new DateTime(2006, 05, 16, 14, 00, 00);
            ActionItemDefinitionHistory history3 = CreateActionItemDefinitionHistory();
            history3.Status = ActionItemDefinitionStatus.Approved;
            history3.Description = history2.Description;
            history3.LastModifiedDate = new DateTime(2006, 05, 17, 08, 00, 00);


            var histories = new List<ActionItemDefinitionHistory> {history1, history2, history3};
            return histories;
        }
        
        public static ActionItemDefinitionHistory CreateActionItemDefinitionHistory()
        {
            return CreateActionItemDefinitionHistory("assignment 1");
        }

        public static ActionItemDefinitionHistory CreateActionItemDefinitionHistory(string workAssignmentName)
        {
            var actionItemDefinitionHistory = new ActionItemDefinitionHistory(1, "name",
                                                                              BusinessCategoryFixture.GetRoutineActivityCategory(),
                                                                              ActionItemDefinitionStatus.Pending,
                                                                              "schedule", "description",true,
                                                                              DataSource.MANUAL, true, false, true,  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                                                                              UserFixture.CreateSupervisor(),
                                                                              new DateTime(2006, 05, 16, 13, 42, 00),
                                                                              "functional locations",
                                                                              "target definitions",
                                                                              "doc links",
                                                                              OperationalMode.Normal, Priority.High, workAssignmentName, true, null);
            return actionItemDefinitionHistory;
        }
    }
}
