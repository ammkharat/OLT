using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class BusinessCategoryFixture
    {
        public static BusinessCategory GetEnvironmentalSafetyCategory()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime date = new DateTime(2010, 6, 9);
            BusinessCategory bc = new BusinessCategory("Environmental / Safety", "Env", user, date, date, Site.SARNIA_ID);
            bc.Id = 107;
            return bc;
        }

        public static BusinessCategory GetProductionCategory()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime date = new DateTime(2010, 6, 9);
            BusinessCategory bc = new BusinessCategory("Production", "Prod", user, date, date, Site.SARNIA_ID);
            bc.Id = 114;
            return bc;
        }   
        
        public static BusinessCategory GetRoutineActivityCategory()
        {
            User user = UserFixture.CreateUserWithGivenId(-1);
            DateTime date = new DateTime(2010, 6, 10, 15, 44, 14, 220);

            //2010-06-10 15:44:14.220

            BusinessCategory bc = new BusinessCategory("Routine Activity", "Rtn", user, date, date, Site.SARNIA_ID);
            bc.Id = 121;
            return bc;
        }

        public static BusinessCategory GetUnitGuidelineProcessCategory()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime date = new DateTime(2010, 6, 9);
            BusinessCategory bc = new BusinessCategory("Unit Guideline / Process", "Proc", user, date, date, Site.SARNIA_ID);
            bc.Id = 100;
            return bc;
        }

        public static List<BusinessCategory> GetList()
        {
            return new List<BusinessCategory> { GetEnvironmentalSafetyCategory(), GetProductionCategory(), GetRoutineActivityCategory(), GetUnitGuidelineProcessCategory() };
        }
    }
}