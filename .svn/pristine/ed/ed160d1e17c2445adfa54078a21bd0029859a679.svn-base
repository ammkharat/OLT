using System;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Bootstrap;
using Com.Suncor.Olt.Remote.Caching;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public abstract class AbstractDaoTest
    {
        private TransactionOptions transactionOptions;
        private TransactionScope trans;
        
        protected abstract void TestInitialize();
        protected abstract void Cleanup();

        // To cause the transaction to rollback after the test, set this to true. Set to false to debug tests.
        private readonly bool rollbackTransaction = true;

        protected AbstractDaoTest()
        {            
        }

        protected AbstractDaoTest(bool rollbackTransaction)
        {
            this.rollbackTransaction = rollbackTransaction;
        }

        [SetUp]
        public void BaseSetup()
        {
            Thread.SetData(Thread.GetNamedDataSlot(Constants.SHOULD_SHARED_SQL_CONNECTION_STORE_NAME), true);
            Thread.SetData(Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME), null);

            CacheInterceptorSelector.IsDaoTest = true;
            transactionOptions = new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted};

            if (rollbackTransaction)
            {
                trans = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            }
			
            Bootstrapper.BootstrapDaos();
            FunctionalLocationFixture.SetDataProvider(new FunctionalLocationFixtureRealDataProvider());
            RoleFixture.SetDataProvider(new RoleFixtureRealDataProvider());
            PermitAttributeFixture.SetDataProvider(new PermitAttributeRealDataProvider());
            WorkAssignmentFixture.SetDataProvider(new WorkAssignmentRealDataProvider());

            TestInitialize();
        }

        [TearDown]
        public void BaseCleanup()
        {
            if (rollbackTransaction)
            {
                trans.Dispose();            
            }
            CacheInterceptorSelector.IsDaoTest = false;
            Cleanup();
            CleanUpSqlConnectionDataStore();
            
            CleanUpSqlConnectionDataStore();

            FunctionalLocationFixture.UseFakeDataProvider();
            RoleFixture.UseFakeDataProvider();
            PermitAttributeFixture.UseFakeDataProvider();
        }

        private static void CleanUpSqlConnectionDataStore()
        {
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHOULD_SHARED_SQL_CONNECTION_STORE_NAME);
                Thread.SetData(slot, null);
            }
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME);
                IDisposable connection = Thread.GetData(slot) as IDisposable;
                if (connection != null)
                {
                    connection.Dispose();
                }
                Thread.SetData(slot, null);
            }
        }
        private class FunctionalLocationFixtureRealDataProvider : FunctionalLocationFixture.IFunctionalLocationFixtureDataProvider
        {
            private static readonly Dictionary<string, FunctionalLocation> cache = new Dictionary<string, FunctionalLocation>();
            private static readonly IFunctionalLocationDao dao = DaoRegistry.GetDao<IFunctionalLocationDao>();

            public FunctionalLocation GetByFullHierarchy(string fullHierarchy)
            {
                return GetFunctionalLocation(fullHierarchy);
            }


            // Warning, this makes assumptions based on first level of the floc. Also, this won't work with Site wide services.
            private static FunctionalLocation GetFunctionalLocation(string fullhierarchy)
            {
                if (!cache.ContainsKey(fullhierarchy))
                {
                    FunctionalLocation floc = dao.QueryByFullHierarchy(fullhierarchy, GetSiteForFloc(fullhierarchy));
                    cache.Add(fullhierarchy, floc);
                }
                return (FunctionalLocation)cache[fullhierarchy].Clone();
            }

            private static long GetSiteForFloc(string fullHierarchy)
            {
                if (fullHierarchy.IsNullOrEmptyOrWhitespace())
                    return -1;

                string firstLevelFloc = new FunctionalLocationHierarchy(fullHierarchy).Division;
                switch (firstLevelFloc.ToUpper())
                {
                    case "SR1":
                        return Site.SARNIA_ID;
                    case "DN1":
                        return Site.DENVER_ID;
                    case "FB1":
                        return Site.FIREBAG_ID;
                    case "UP1":
                    case "UP2":
                    case "EX1":
                        return Site.OILSAND_ID;
                    case "MT1":
                        return Site.MONTREAL_ID;
                    case "ED1":
                        return Site.EDMONTON_ID;
                    case "MR1":
                        return Site.MACKAY_ID;
                    case "MI1":
                        return Site.LUBES_ID;
                    default:
                        return -1;
                }
            }
        }

        private class RoleFixtureRealDataProvider : RoleFixture.IRoleFixtureDataProvider
        {
            private static readonly Dictionary<long, List<Role>> rolesBySite = new Dictionary<long, List<Role>>();
            private static readonly IRoleDao roleDao = DaoRegistry.GetDao<IRoleDao>();

            public List<Role> GetBySite(long siteId)
            {
                if (!rolesBySite.ContainsKey(siteId))
                {
                    List<Role> roles = roleDao.QueryBySiteId(siteId);
                    rolesBySite.Add(siteId, roles);
                }

                return rolesBySite[siteId];
            }
        }

        private class PermitAttributeRealDataProvider : PermitAttributeFixture.IPermitAttributeFixtureDataProvider
        {
            private static readonly Dictionary<long, List<PermitAttribute>> attributesBySite = new Dictionary<long, List<PermitAttribute>>();

            public List<PermitAttribute> GetBySiteId(long siteId)
            {
                if (!attributesBySite.ContainsKey(siteId))
                {
                    IPermitAttributeDao dao = DaoRegistry.GetDao<IPermitAttributeDao>();
                    List<PermitAttribute> attributes = dao.QueryBySiteId(siteId);
                    attributesBySite.Add(siteId, attributes);
                }

                return attributesBySite[siteId];
            }
        }

        private class WorkAssignmentRealDataProvider : WorkAssignmentFixture.IWorkAssignmentFixtureDataProvider
        {
            private static readonly Dictionary<long, List<WorkAssignment>> workAssignmentsBySite = new Dictionary<long, List<WorkAssignment>>();
            private static readonly IWorkAssignmentDao workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();

            public List<WorkAssignment> GetBySite(long siteId)
            {
                if (!workAssignmentsBySite.ContainsKey(siteId))
                {
                    List<WorkAssignment> roles = workAssignmentDao.QueryBySiteId(siteId);
                    workAssignmentsBySite.Add(siteId, roles);
                }

                return workAssignmentsBySite[siteId];                
            }
        }
    }
}