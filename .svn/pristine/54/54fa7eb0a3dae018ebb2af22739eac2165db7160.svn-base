using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class MergingPermitRequestPersistanceProcessorTest
    {
        private User someUser;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 1, 20);

            someUser = UserFixture.CreateUserWithGivenId(1);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]        
        public void ShouldInsertIfNotFoundInDatabase()
        {
            PermitRequestEdmontonSAPImportData permitRequestEdmontonSapImportData = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(
                    FunctionalLocationFixture.GetReal("ED1-A001-IFST"), WorkPermitEdmontonGroupFixture.CreateP4(), UserFixture.CreateSupervisor());
            permitRequestEdmontonSapImportData.SubOperationNumber = null; // make an operation instead
            permitRequestEdmontonSapImportData.DoNotMerge = false;

            List<ISAPImportData> incomingRequests = new List<ISAPImportData> { permitRequestEdmontonSapImportData };

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(new List<IMergeablePermitRequest>(), incomingRequests, Clock.Now, someUser);
            processor.Process();

            Assert.IsEmpty(processor.UpdateList);
            Assert.IsTrue(processor.InsertList.Count == 1);
            Assert.AreEqual(permitRequestEdmontonSapImportData.WorkOrderNumber, processor.InsertList[0].WorkOrderNumber);
        }

        [Test]
        public void ShouldMergeByWorkOrderNumberAndWorkCentreCode()
        {
            PermitRequestEdmontonSAPImportData item1 = CreatePermitRequestImportData("123", "0001", null, "WC1", "desc1");
            PermitRequestEdmontonSAPImportData item2 = CreatePermitRequestImportData("123", "0002", null, "WC1", "desc2");
            PermitRequestEdmontonSAPImportData item3 = CreatePermitRequestImportData("123", "0003", null, "WC2", "desc3");
            PermitRequestEdmontonSAPImportData item4 = CreatePermitRequestImportData("123", "0004", null, "WC2", "desc4");

            List<ISAPImportData> incoming = new List<ISAPImportData> { item1, item2, item3, item4 };
            List<IMergeablePermitRequest> existing = new List<IMergeablePermitRequest>();

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existing, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.IsEmpty(processor.UpdateList);
            Assert.AreEqual(2, processor.InsertList.Count);

            IMergeablePermitRequest firstResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("123", "0001", null)));
            Assert.IsTrue(firstResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0002", null))));

            IMergeablePermitRequest secondResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("123", "0003", null)));
            Assert.IsTrue(secondResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0004", null))));                        
        }

        [Test]
        public void ShouldMergeWithExisting()
        {
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("123", "10", null, "WC1", "new desc 1");            
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("123", "20", null, "WC1", "new desc 2");            
            PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("123", "30", null, "WC1", "new desc 3");
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("123", "40", null, "WC1", "new desc 4");
            List<ISAPImportData> incoming = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4 };
            
            PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("123", "10", null);
            PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("123", "20", null);
            PermitRequestWorkOrderSource source3 = new PermitRequestWorkOrderSource("123", "30", null);
            PermitRequestWorkOrderSource source4 = new PermitRequestWorkOrderSource("123", "40", null);
            PermitRequestEdmonton existing1 = CreatePermitRequest("123", "Old Description", new Date(2013, 1, 20), new Date(2013, 1, 23), WorkPermitEdmontonType.COLD_WORK, source1, source2, source3, source4);
            existing1.Id = 42;            
            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest> { existing1 };

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(1, processor.UpdateList.Count);
            Assert.IsEmpty(processor.InsertList);

            IMergeablePermitRequest result = processor.UpdateList[0];
            Assert.IsTrue(result.Description.Contains("new desc 1"));
            Assert.IsTrue(result.Description.Contains("new desc 2"));
            Assert.IsFalse(result.Description.Contains("Old Description"));
            Assert.AreEqual(42, result.IdValue);
        }

        [Test]
        public void ShouldMergeWithExistingProperlyIfExistingIsModified()
        {
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("123", "10", null, "WC1", "new desc 1");            
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("123", "20", null, "WC1", "new desc 2");            
            PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("123", "30", null, "WC1", "new desc 3");
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("123", "40", null, "WC1", "new desc 4");
            List<ISAPImportData> incoming = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4 };
            
            PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("123", "10", null);
            PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("123", "20", null);
            PermitRequestWorkOrderSource source3 = new PermitRequestWorkOrderSource("123", "30", null);
            PermitRequestWorkOrderSource source4 = new PermitRequestWorkOrderSource("123", "40", null);
            PermitRequestEdmonton existing1 = CreatePermitRequest("123", "Old Description", new Date(2013, 1, 20), new Date(2013, 1, 23), WorkPermitEdmontonType.COLD_WORK, source1, source2, source3, source4);
            existing1.Id = 42;
            existing1.IsModified = true;
            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest> { existing1 };

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(1, processor.UpdateList.Count);
            Assert.IsEmpty(processor.InsertList);

            IMergeablePermitRequest result = processor.UpdateList[0];
            Assert.IsFalse(result.Description.Contains("new desc 1"));
            Assert.IsFalse(result.Description.Contains("new desc 2"));
            Assert.IsTrue(result.Description.Contains("Old Description"));

            Assert.IsTrue(result.SapDescription.Contains("new desc 1"));
            Assert.IsTrue(result.SapDescription.Contains("new desc 2"));

            Assert.AreEqual(42, result.IdValue);
        }

        [Test]
        public void WhenAnExistingSubmittedPermitDoesNotComeInFromSapWeShouldUpdateTheEndDateAndLastModifiedValues()
        {
            // Incoming
            List<ISAPImportData> incoming = new List<ISAPImportData>();

            // Existing
            PermitRequestWorkOrderSource source = new PermitRequestWorkOrderSource("23", "030", null);
            PermitRequestEdmonton existing = CreatePermitRequest("Elec", "old desc 1", new Date(2013, 1, 20), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK, source);
            existing.LastSubmittedByUser = someUser;
            existing.LastSubmittedDateTime = Clock.Now;
            existing.Id = 1;

            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest> { existing };

            User user2 = UserFixture.CreateUserWithGivenId(2);
            DateTime now = Clock.Now;
            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, now, user2);
            processor.Process();

            Assert.AreEqual(0, processor.InsertList.Count);
            Assert.AreEqual(1, processor.UpdateList.Count);

            IMergeablePermitRequest result = processor.UpdateList.Find(t => t.ContainsWorkOrderSource(new PermitKeyData("23", "030", null)));
            Assert.IsNotNull(result);
            Assert.AreEqual(new Date(now), result.EndDate);
            Assert.AreEqual(user2, result.LastModifiedBy);
            Assert.AreEqual(now, result.LastModifiedDateTime);
        }

        [Test]
        public void Scenario_1a()
        {
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 21), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "030", null, "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK);
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "040", null, "Elec", "new desc 4", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "050", null, "Elec", "new desc 5", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            incoming5.DoNotMerge = true;
            List<ISAPImportData> incoming = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4, incoming5 };
            incoming.Reverse();

            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest>();

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            List<IMergeablePermitRequest> inserts = processor.InsertList;
            Assert.AreEqual(3, inserts.Count);

            {
                IMergeablePermitRequest result = inserts.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "010", null)));
                Assert.IsNotNull(result);
                Assert.AreEqual(WorkPermitEdmontonType.HOT_WORK, ((PermitRequestEdmonton) result).WorkPermitType);
                Assert.IsTrue(result.Description.Contains("new desc 1"));
                Assert.IsTrue(result.Description.Contains("new desc 2"));
                Assert.IsTrue(result.Description.Contains("new desc 3"));                
            }

            {
                IMergeablePermitRequest result = inserts.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "040", null)));
                Assert.IsNotNull(result);
                Assert.AreEqual(WorkPermitEdmontonType.COLD_WORK, ((PermitRequestEdmonton) result).WorkPermitType);
                Assert.IsTrue(result.Description.Contains("new desc 4"));
            }

            {
                IMergeablePermitRequest result = inserts.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "050", null)));
                Assert.IsNotNull(result);
                Assert.AreEqual(WorkPermitEdmontonType.COLD_WORK, ((PermitRequestEdmonton) result).WorkPermitType);
                Assert.IsTrue(result.Description.Contains("new desc 5"));
            }
        }

        [Test]
        public void Scenario_1b()
        {
            // Incoming
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 21), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            //PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "030", null, "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK);
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "040", null, "Elec", "new desc 4", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "050", null, "Elec", "new desc 5", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            incoming5.DoNotMerge = true;
            List<ISAPImportData> incoming = new List<ISAPImportData> { incoming4, incoming5, incoming1, incoming2 };
            incoming.Reverse();

            // Existing
            PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("23", "010", null);
            PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("23", "020", null);
            PermitRequestWorkOrderSource source3 = new PermitRequestWorkOrderSource("23", "030", null);
            PermitRequestEdmonton existing1 = CreatePermitRequest("Elec", "old desc 1", new Date(2013, 1, 20), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK, source1, source2, source3);
            existing1.Id = 1;

            PermitRequestWorkOrderSource source4 = new PermitRequestWorkOrderSource("23", "040", null);
            PermitRequestEdmonton existing2 = CreatePermitRequest("Elec", "old desc 2", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK, source4);
            existing2.Id = 2;

            PermitRequestWorkOrderSource source5 = new PermitRequestWorkOrderSource("23", "050", null);
            PermitRequestEdmonton existing3 = CreatePermitRequest("Elec", "old desc 3", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source5);
            existing3.DoNotMerge = true;
            existing3.Id = 3;

            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest> { existing1, existing2, existing3 };

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(0, processor.InsertList.Count);
            Assert.AreEqual(3, processor.UpdateList.Count);

            IMergeablePermitRequest result = processor.UpdateList.Find(t => t.ContainsWorkOrderSource(new PermitKeyData("23", "010", null)));
            Assert.IsNotNull(result);
            Assert.IsFalse(processor.UpdateList.Exists(t => t.ContainsWorkOrderSource(new PermitKeyData("23", "030", null))));
            Assert.IsTrue(processor.UpdateList.Exists(t => t.ContainsWorkOrderSource(new PermitKeyData("23", "020", null))));

            result = processor.UpdateList.Find(t => t.ContainsWorkOrderSource(new PermitKeyData("23", "050", null)));
            Assert.IsTrue(result.Description.Contains("new desc 5"));
        }

        [Test]
        public void Scenario_1c()
        {
            // Incoming
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 21), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Carp", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            //PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "030", null, "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK);
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "040", null, "Elec", "new desc 4", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "050", null, "Elec", "new desc 5", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            incoming5.DoNotMerge = true;
            //List<PermitRequestEdmontonSAPImportData> incoming = new List<PermitRequestEdmontonSAPImportData> { incoming1, incoming2, incoming4, incoming5 };
            List<ISAPImportData> incoming = new List<ISAPImportData> { incoming5, incoming2, incoming4, incoming1 };
            incoming.Reverse();

            // Existing
            PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("23", "010", null);
            PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("23", "020", null);            
            PermitRequestEdmonton existing1 = CreatePermitRequest("Elec", "old desc 1", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source1, source2);
            existing1.Id = 1;

            PermitRequestWorkOrderSource source4 = new PermitRequestWorkOrderSource("23", "040", null);
            PermitRequestEdmonton existing2 = CreatePermitRequest("Elec", "old desc 2", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK, source4);
            existing2.Id = 2;

            PermitRequestWorkOrderSource source5 = new PermitRequestWorkOrderSource("23", "050", null);
            PermitRequestEdmonton existing3 = CreatePermitRequest("Elec", "old desc 3", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source5);
            existing3.DoNotMerge = true;
            existing3.Id = 3;

            List<IMergeablePermitRequest> existingList = new List<IMergeablePermitRequest> { existing1, existing2, existing3 };
            existingList.Reverse();

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(1, processor.InsertList.Count);
            Assert.AreEqual(3, processor.UpdateList.Count);
        }

        [Test]
        public void Scenario_1d()
        {
            List<ISAPImportData> incoming;
            List<IMergeablePermitRequest> existingList;

            // Incoming
            {
                PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 20), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "030", null, "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 24), WorkPermitEdmontonType.HOT_WORK);
                PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "040", null, "Elec", "new desc 4", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "050", null, "Elec", "new desc 5", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
                incoming = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4, incoming5 };
                //incoming.Reverse();
            }

            // Existing
            {
                PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("23", "010", null);
                PermitRequestEdmonton existing1 = CreatePermitRequest("Elec", "old desc 1", new Date(2013, 1, 20), new Date(2013, 1, 20), WorkPermitEdmontonType.COLD_WORK, source1);
                existing1.Id = 1;

                PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("23", "040", null);
                PermitRequestEdmonton existing2 = CreatePermitRequest("Elec", "old desc 2", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK, source2);
                existing2.Id = 2;

                PermitRequestWorkOrderSource source3 = new PermitRequestWorkOrderSource("23", "050", null);
                PermitRequestEdmonton existing3 = CreatePermitRequest("Elec", "old desc 3", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source3);
                existing3.DoNotMerge = true;
                existing3.LastSubmittedDateTime = new DateTime(2013, 1, 20); // date doesn't matter, just need it to be submitted
                Assert.IsTrue(existing3.IsSubmitted); // just making sure
                existing3.Id = 3;

                PermitRequestWorkOrderSource source4 = new PermitRequestWorkOrderSource("23", "020", null);
                PermitRequestEdmonton existing4 = CreatePermitRequest("Carp", "old desc 4", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source4);
                existing4.Id = 4;

                existingList = new List<IMergeablePermitRequest> { existing1, existing2, existing3, existing4 };
                //existingList.Reverse();
            }

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(0, processor.InsertList.Count);

            List<IMergeablePermitRequest> updates = processor.UpdateList;
            Assert.AreEqual(2, updates.Count);
            IMergeablePermitRequest result = updates.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "010", null)));
            Assert.IsTrue(result.ContainsWorkOrderSource(new PermitKeyData("23", "020", null)));
            Assert.IsTrue(result.ContainsWorkOrderSource(new PermitKeyData("23", "030", null)));
            Assert.IsTrue(result.ContainsWorkOrderSource(new PermitKeyData("23", "040", null)));
            Assert.IsTrue(result.ContainsWorkOrderSource(new PermitKeyData("23", "050", null)));
            Assert.AreEqual(new Date(2013, 1, 20), result.RequestedStartDate);
            Assert.AreEqual(new Date(2013, 1, 27), result.EndDate);

            IMergeablePermitRequest submittedOneUpdatedToToday = updates.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "050", null)) && i.IsSubmitted);
            Assert.IsNotNull(submittedOneUpdatedToToday);
            Assert.AreEqual(new Date(Clock.Now), submittedOneUpdatedToToday.EndDate);

            Assert.AreEqual(2, processor.DeleteList.Count);
        }

        [Test]
        public void Scenario_2a()
        {
            List<ISAPImportData> incoming;
            List<IMergeablePermitRequest> existingList;

            // Incoming
            {
                PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 21), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "020", "010", "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 23), WorkPermitEdmontonType.HOT_WORK);
                PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "020", "020", "Elec", "new desc 4", new Date(2013, 1, 23), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "020", "030", "Carp", "new desc 5", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);

                incoming2.DoNotMerge = true;
                incoming3.DoNotMerge = true;

                incoming = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4, incoming5 };                
//                incoming.Reverse();
            }

            // Existing
            {               
                existingList = new List<IMergeablePermitRequest>();                                
            }

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            List<IMergeablePermitRequest> inserts = processor.InsertList;
            Assert.AreEqual(2, inserts.Count);

            List<IMergeablePermitRequest> updates = processor.UpdateList;
            Assert.AreEqual(0, updates.Count);

            IMergeablePermitRequest result = inserts.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "010", null)));
            Assert.IsTrue(result.WorkOrderSourceList.Count == 1);

            IMergeablePermitRequest otherResult = inserts.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("23", "020", null)));
            Assert.IsTrue(otherResult.WorkOrderSourceList.Count == 3);

            // NOTE: the 23-020-030 line gets thrown away because it's a single sub-operation
        }

        [Test]
        public void Bug2342()
        {
            List<ISAPImportData> incoming;
            List<IMergeablePermitRequest> existingList;

            // Incoming
            {
                PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
                PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);

                incoming = new List<ISAPImportData> { incoming1, incoming2 };
              
            }

            // Existing
            {                
                PermitRequestWorkOrderSource source1 = new PermitRequestWorkOrderSource("23", "010", null);
                PermitRequestEdmonton existing1 = CreatePermitRequest("Elec", "old desc 1", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source1);
                existing1.Id = 1;
                
                PermitRequestWorkOrderSource source2 = new PermitRequestWorkOrderSource("23", "020", null);
                PermitRequestEdmonton existing2 = CreatePermitRequest("Elec", "old desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK, source2);
                existing2.DoNotMerge = true;
                existing2.Id = 2;

                existingList = new List<IMergeablePermitRequest> { existing1, existing2 };
            }

            AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existingList, incoming, Clock.Now, someUser);
            processor.Process();

            Assert.AreEqual(0, processor.InsertList.Count);
            Assert.AreEqual(1, processor.UpdateList.Count);
            Assert.AreEqual(1, processor.DeleteList.Count);            
        }

        [Test]
        public void ShouldGroupItemsByDate()
        {
            PermitRequestEdmontonSAPImportData incoming1 = CreatePermitRequestImportData("23", "010", null, "Elec", "new desc 1", new Date(2013, 1, 20), new Date(2013, 1, 20), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming2 = CreatePermitRequestImportData("23", "020", null, "Elec", "new desc 2", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming3 = CreatePermitRequestImportData("23", "030", null, "Elec", "new desc 3", new Date(2013, 1, 21), new Date(2013, 1, 24), WorkPermitEdmontonType.HOT_WORK);
            PermitRequestEdmontonSAPImportData incoming4 = CreatePermitRequestImportData("23", "040", null, "Elec", "new desc 4", new Date(2013, 1, 24), new Date(2013, 1, 27), WorkPermitEdmontonType.COLD_WORK);
            PermitRequestEdmontonSAPImportData incoming5 = CreatePermitRequestImportData("23", "050", null, "Elec", "new desc 5", new Date(2013, 1, 20), new Date(2013, 1, 22), WorkPermitEdmontonType.COLD_WORK);            

            {
                List<ISAPImportData> items = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4, incoming5 };
                List<List<ISAPImportData>> groups = AbstractMergingPermitRequestPersistanceProcessor.GroupItemsByDate(items);
                Assert.AreEqual(1, groups.Count);                
            }

            {
                List<ISAPImportData> items = new List<ISAPImportData> { incoming1, incoming2, incoming3, incoming4, incoming5 };
                items.Reverse();
                List<List<ISAPImportData>> groups = AbstractMergingPermitRequestPersistanceProcessor.GroupItemsByDate(items);
                Assert.AreEqual(1, groups.Count);                
            }
        }

        [Test]
        public void ShouldThrowAwayAnySuboperationsThatDoNotHaveParents()
        {
            {
                PermitRequestEdmontonSAPImportData item1 = CreatePermitRequestImportData("123", "0001", null, "WC1", "desc1");
                PermitRequestEdmontonSAPImportData item2 = CreatePermitRequestImportData("123", "0002", null, "WC1", "desc2");            
                PermitRequestEdmontonSAPImportData item4 = CreatePermitRequestImportData("123", "0002", "0010", "WC1", "desc4");
                PermitRequestEdmontonSAPImportData item3 = CreatePermitRequestImportData("124", "0003", "0010", "WC2", "desc3");

                List<ISAPImportData> incoming = new List<ISAPImportData> { item1, item2, item3, item4 };
                List<IMergeablePermitRequest> existing = new List<IMergeablePermitRequest>();

                AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existing, incoming, Clock.Now, someUser);
                processor.Process();

                Assert.IsEmpty(processor.UpdateList);
                Assert.AreEqual(1, processor.InsertList.Count);

                IMergeablePermitRequest firstResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("123", "0001", null)));
                Assert.IsTrue(firstResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0002", null))));
                Assert.IsTrue(firstResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0002", "0010"))));

                IMergeablePermitRequest secondResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("124", "0003", "0010")));
                Assert.IsNull(secondResult);                
            }

            {
                PermitRequestEdmontonSAPImportData item1 = CreatePermitRequestImportData("123", "0001", null, "WC1", "desc1");
                PermitRequestEdmontonSAPImportData item2 = CreatePermitRequestImportData("123", "0002", null, "WC1", "desc2");            
                PermitRequestEdmontonSAPImportData item3 = CreatePermitRequestImportData("123", "0002", "0010", "WC1", "desc4");

                PermitRequestEdmontonSAPImportData item4 = CreatePermitRequestImportData("124", "0003", "0010", "WC2", "desc3");
                PermitRequestEdmontonSAPImportData item5 = CreatePermitRequestImportData("124", "0003", null, "WC2", "desc3");

                List<ISAPImportData> incoming = new List<ISAPImportData> { item1, item2, item3, item4, item5 };
                List<IMergeablePermitRequest> existing = new List<IMergeablePermitRequest>();

                AbstractMergingPermitRequestPersistanceProcessor processor = new EdmontonMergingPermitRequestPersistenceProcessor(existing, incoming, Clock.Now, someUser);
                processor.Process();

                Assert.IsEmpty(processor.UpdateList);
                Assert.AreEqual(2, processor.InsertList.Count);

                IMergeablePermitRequest firstResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("123", "0001", null)));
                Assert.IsTrue(firstResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0002", null))));
                Assert.IsTrue(firstResult.WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(new PermitKeyData("123", "0002", "0010"))));

                IMergeablePermitRequest secondResult = processor.InsertList.Find(i => i.ContainsWorkOrderSource(new PermitKeyData("124", "0003", "0010")));
                Assert.IsNotNull(secondResult);                
            }
        }


        private PermitRequestEdmontonSAPImportData CreatePermitRequestImportData(
            string workOrderNumber, string operationNumber, string subOperationNumber, string sapWorkCentreCode, string description, Date start, Date end, WorkPermitEdmontonType permitType)
        {
            PermitRequestEdmontonSAPImportData item = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert(
                    FunctionalLocationFixture.GetReal("ED1-A001-IFST"), WorkPermitEdmontonGroupFixture.CreateP4(), UserFixture.CreateSupervisor());

            item.DoNotMerge = false;
            item.Description = description;

            item.RequestedStartDate = start;
            item.EndDate = end;

            item.WorkPermitType = permitType;

            item.WorkOrderNumber = workOrderNumber;
            item.OperationNumber = operationNumber;
            item.SubOperationNumber = subOperationNumber;
            item.SAPWorkCentre = sapWorkCentreCode;

            return item;
        }  
 
        private PermitRequestEdmontonSAPImportData CreatePermitRequestImportData(string workOrderNumber, string operationNumber, string subOperationNumber, string sapWorkCentreCode, string description)
        {
            return CreatePermitRequestImportData(workOrderNumber, operationNumber, subOperationNumber, sapWorkCentreCode, description, new Date(2013, 1, 20), new Date(2013, 1, 20), WorkPermitEdmontonType.COLD_WORK);
        }

        private PermitRequestEdmonton CreatePermitRequest(string workCentre, string description, Date from, Date to, WorkPermitEdmontonType permitType, params PermitRequestWorkOrderSource[] workOrderSources)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            PermitRequestEdmonton pr = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, floc,WorkPermitEdmontonGroupFixture.CreateP4());
            pr.LastSubmittedByUser = null;
            pr.LastSubmittedDateTime = null;
            pr.ClearWorkOrderSources();
            pr.SAPWorkCentre = workCentre;
            pr.Description = description;

            pr.RequestedStartDate = from;
            pr.EndDate = to;
            pr.WorkPermitType = permitType;

            foreach (PermitRequestWorkOrderSource source in workOrderSources)
            {
                pr.AddWorkOrderSource(source);
            }

            Assert.IsFalse(pr.IsSubmitted);

            return pr;
        }
    }
}
