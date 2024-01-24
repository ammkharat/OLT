using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitRequestMontrealFixture
    {
        public static PermitRequestMontreal GetPermitRequest(User user)
        {            
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3();

            DateTime currentTimeAtSite = new DateTime(2012, 1, 18);
            WorkPermitMontrealType permitType = WorkPermitMontrealType.COLD;

            Date startDate = new Date(2012, 1, 18);
            Date endDate = new Date(2012, 1, 18);

            string workOrderNumber = "1234-5";
            string operationNumber = "42";
            string subOperationNumber = "123";

            string trade = "Trade";
            string description = "Description";
            string sapDescription = "SAP Description";
            string company = string.Empty;
            string supervisor = string.Empty;
            string excavationNumber = string.Empty;
            DataSource dataSource = DataSource.SAP;
            User lastImportedByUser = user;
            DateTime? lastImportedDateTime = currentTimeAtSite;
            User lastSubmittedByUser = null;
            DateTime? lastSubmittedDateTime = null;
            User createdBy = user;
            DateTime createdDateTime = currentTimeAtSite;
            User lastModifiedBy = user;
            DateTime lastModifiedDateTime = currentTimeAtSite;

            PermitRequestMontreal request = new PermitRequestMontreal(
                null,
                permitType,
                new List<FunctionalLocation> { floc },
                startDate,
                endDate,
                workOrderNumber,
                operationNumber,
                subOperationNumber,
                trade,
                description,
                sapDescription,
                company,
                supervisor,
                excavationNumber,
                dataSource,
                lastImportedByUser,
                lastImportedDateTime,
                lastSubmittedByUser,
                lastSubmittedDateTime,
                createdBy,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime,
                WorkPermitMontrealGroupFixture.CreateForInsert(),
                PermitRequestCompletionStatus.Complete);

            return request;
        }

        public static PermitRequestMontreal GetFullyPopulatedPermitRequest()
        {            
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3();

            DateTime currentTimeAtSite = new DateTime(2012, 1, 18);
            WorkPermitMontrealType permitType = WorkPermitMontrealType.COLD;

            Date startDate = new Date(2012, 1, 18);
            Date endDate = new Date(2012, 1, 18);

            string workOrderNumber = "1234-5";
            string operationNumber = "42";
            string subOperationNumber = "222";

            string trade = "Trade";
            string description = "SAP Description";
            string sapDescription = "Description";
            string company = "Company";
            string supervisor = "Supervisor";
            string excavationNumber = "Excavation Number";
            DataSource dataSource = DataSource.SAP;
            User lastImportedByUser = UserFixture.CreateOperator(-4, "Nobody");
            DateTime? lastImportedDateTime = currentTimeAtSite;
            User lastSubmittedByUser = UserFixture.CreateOperator(-1, "Eric");
            DateTime? lastSubmittedDateTime = new DateTime(2012, 1, 1, 5, 6, 0);
            User createdBy = UserFixture.CreateOperator(-2, "Ginger"); ;
            DateTime createdDateTime = currentTimeAtSite;
            User lastModifiedBy = UserFixture.CreateOperator(-3, "Jack");
            DateTime lastModifiedDateTime = currentTimeAtSite;

            PermitRequestMontreal request = new PermitRequestMontreal(
                null,
                permitType,
                new List<FunctionalLocation> { floc },
                startDate,
                endDate,
                workOrderNumber,
                operationNumber,
                subOperationNumber,
                trade,
                description,
                sapDescription,
                company,
                supervisor,
                excavationNumber,
                dataSource,
                lastImportedByUser,
                lastImportedDateTime,
                lastSubmittedByUser,
                lastSubmittedDateTime,
                createdBy,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime,
                WorkPermitMontrealGroupFixture.CreateForInsert(),
                PermitRequestCompletionStatus.Complete);

            return request;
        }

        public static PermitRequestMontreal GetEmptyPermitRequest()
        {            
            PermitRequestMontreal request = new PermitRequestMontreal(
                null,
                null,
                null,
                DateTimeFixture.DateNow,
                DateTimeFixture.DateNow,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                new DateTime(0), 
                null,
                new DateTime(0),
                null,
                PermitRequestCompletionStatus.Incomplete);

            return request;
        }

        public static PermitRequestMontreal CreateForInsert(DataSource dataSource)
        {
            return new PermitRequestMontreal(
                null,
                WorkPermitMontrealType.MODERATE_HOT,
                new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A001_U010() },
                new Date(2001, 2, 3),
                new Date(2001, 4, 5),
                "112233",
                "020",
                "0110",
                "trade ABC",
                "permit request description",
                "permit request description (SAP)",
                "Black & McDonald",
                "Some Supervisor",
                "01234",
                dataSource,
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite(),
                new DateTime(2001, 10, 11),
                UserFixture.CreateAdmin(),
                new DateTime(2001, 12, 13),
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2002, 6, 7),
                UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                new DateTime(2002, 8, 9),
                WorkPermitMontrealGroupFixture.CreateWithExistingId(),
                PermitRequestCompletionStatus.Complete);
        }
    }
}
