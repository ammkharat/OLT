using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkAssignmentFixture
    {
        private static IWorkAssignmentFixtureDataProvider dataProvider = new MadeUpWorkAssignmentFixtureDataProvider();

        public static void SetDataProvider(IWorkAssignmentFixtureDataProvider provider)
        {
            dataProvider = provider;
        }

        public static void UseFakeDataProvider()
        {
            dataProvider = new MadeUpWorkAssignmentFixtureDataProvider();
        }

        public interface IWorkAssignmentFixtureDataProvider
        {
            List<WorkAssignment> GetBySite(long siteId);
        }

        private class MadeUpWorkAssignmentFixtureDataProvider : IWorkAssignmentFixtureDataProvider
        {
            public List<WorkAssignment> GetBySite(long siteId)
            {
                List<WorkAssignment> workAssignments = new List<WorkAssignment>();
                for (int i = 0; i < 10; i++)
                {
                    string name = "WorkAssignment" + i;
                    WorkAssignment workAssignment = CreateConsoleOperator(siteId);
                    workAssignment.Name = name;
                    workAssignments.Add(workAssignment);
                }
                return workAssignments;
            }
        }

        public static WorkAssignment CreateUnitLeader()
        {
            return CreateUnitLeader(null);
        }

        public static WorkAssignment CreateShiftEngineer()
        {
            return new WorkAssignment(3, "SE", "Shift Engineer", null, 1, RoleFixture.CreateOperatorRole(), true, true, null, null, null,false,false);
        }

        public static WorkAssignment CreateConsoleOperator()
        {
            const long siteId = 1;
            return CreateConsoleOperator(siteId);
        }

        public static WorkAssignment CreateConsoleOperator(long siteId)
        {
            return new WorkAssignment(2, "CO", "Console Operator", null, siteId, RoleFixture.GetRealRoleA(siteId), true, true, null, null, null,false,false);
        }
        
        public static WorkAssignment CreateUnitLeader(List<FunctionalLocation> flocList)
        {
            return new WorkAssignment(1, "IU", "UnitLeader", null, 1, RoleFixture.CreateOperatorRole(), true, true, flocList, null, null,false,false);
        }

        private static WorkAssignment CreateUnitLeaderWithFunctionalLocations(int numberOfFlocs)
        {
            List<FunctionalLocation> flocList =
                FunctionalLocationFixture.CreateNewListOfNewItems(numberOfFlocs);
            return CreateUnitLeader(flocList);
        }

        public static List<WorkAssignment> CreateWorkAssignmentList(int count)
        {
            List<WorkAssignment> result = new List<WorkAssignment>();

            for(int i = 0; i < count; i++)
            {
                WorkAssignment workAssignment = CreateUnitLeaderWithFunctionalLocations(5);
                result.Add(workAssignment);
            }
            return result;
        }

        public static WorkAssignment GetSarniaAssignmentThatIsReallyInTheDatabaseTestData()
        {
            return new WorkAssignment(2224, "CA", "Crude/Vac/PT Console", "Plant 2", 1, RoleFixture.GetRealRole(1, "Operator"), true, true, null, null, null,false,false);
        }   
        
        public static WorkAssignment GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData()
        {
            return new WorkAssignment(2225, "TEST2", "TEST2", null, 1, RoleFixture.CreateOperatorRole(), true, true, null, null, null,false,false);
        }

        public static WorkAssignment GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData()
        {
            return new WorkAssignment(2254, "Blending Coordinator", "TEST1", null, 1, RoleFixture.CreateOperatorRole(), true, true, null, null, null,false,false);
        }   
        
        public static WorkAssignment GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData()
        {
            return new WorkAssignment(2255, "TEST2", "TEST2", null, 1, RoleFixture.CreateOperatorRole(), true, true, null, null, null,false,false);
        }

        public static WorkAssignment GetYetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData()
        {
            return new WorkAssignment(2257, "TEST3", "TEST3", null, 1, RoleFixture.CreateOperatorRole(), true, true, null, null, null,false,false);
        }

        public static List<WorkAssignment> GetListOfEdmontonWorkAssigments()
        {
            return new List<WorkAssignment> { 
                GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData(), 
                GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData(), 
                GetYetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData() };
        } 

        public static List<WorkAssignment> GetListOfSarniaAssignments(FunctionalLocation functionalLocation)
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>{functionalLocation};
            return new List<WorkAssignment>
                {
                    new WorkAssignment(2254, "Test", "Test", "General", 1, RoleFixture.CreateOperatorRole(), true, true, flocs, null, null,false,false)
                };
        }

        public static List<AssignmentFlocConfiguration> GetListOfSarniaAssignmentConfigurations(FunctionalLocation functionalLocation)
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { functionalLocation };
            return new List<AssignmentFlocConfiguration> { new AssignmentFlocConfiguration(1, "Test", RoleFixture.CreateOperatorRole().Name, "Test", "General", flocs) };
        }

        public static WorkAssignment CreateSarniaWorkAssignmentToBeInsertedInDatabase(string name)
        {
            return new WorkAssignment(name, name, "Summary Log Test", Site.SARNIA_ID, RoleFixture.GetRealRoleA(Site.SARNIA_ID));
        }

        public static WorkAssignment CreateOilsandsWorkAssignmentToBeInsertedInDatabase(string name)
        {
            return new WorkAssignment(name, name, "Summary Log Test", Site.OILSAND_ID, RoleFixture.GetRealRoleA(Site.OILSAND_ID));
        }

        public static WorkAssignment CreateEdmontonWorkAssignmentToBeInsertedInDatabase(string name)
        {
            return new WorkAssignment(name, name, "Edmonton Work Assignment", Site.EDMONTON_ID, RoleFixture.GetRealRoleA(Site.EDMONTON_ID));
        }

        public static WorkAssignment CreateRealExtractionWorkAssignmentInDatabase(string name)
        {
            return dataProvider.GetBySite(3).Find(wa => wa.Name.Equals(name));
        }

        public static List<WorkAssignment> GetListOfRealWorkAssignments(long siteId, int count)
        {
            return dataProvider.GetBySite(siteId).First(count);
        }
    }
}