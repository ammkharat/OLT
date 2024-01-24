using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using NUnit.Framework;
using Osherove.ThreadTester;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    [TestFixture]
    [Category("IntegrationPlantHistorian")]
    public class Sarnia_Honeywell300PHDProviderTest
    {
        private HoneywellPHDProvider oilsandsProvider;
        private HoneywellPHDProvider phdProvider;

        [SetUp]
        public void SetUp()
        {
            phdProvider = new HoneywellPHDProvider(PlantHistorianConnectionFixture.GetSarniaPhd300Info());
        }

        [TearDown]
        public void TearDown()
        {
            if (phdProvider != null)
            {
                phdProvider.Dispose();
            }

            if (oilsandsProvider != null)
            {
                oilsandsProvider.Dispose();
            }
        }

        [Test]
        public void CanNotWrite()
        {
            var canWritePHDTagValue =
                phdProvider.CanWritePHDTagValue(TagInfoFixture.CreateMockTagForSarnia(1, "00FQI054_2.PV"));
            Assert.That(canWritePHDTagValue, Is.False);
        }

        [Test]
        public void CanWrite()
        {
            {
                var canWritePHDTagValue =
                    phdProvider.CanWritePHDTagValue(TagInfoFixture.CreateMockTagForSarnia(1, "olttest.ptarget10"));
                Assert.That(canWritePHDTagValue, Is.True);
            }
//            {
//                bool canWritePHDTagValue = phdProvider.CanWritePHDTagValue(TagInfoFixture.CreateMockTagForSarnia(1, "03FC050.PTARGET"));
//                Assert.That(canWritePHDTagValue, Is.True);
//            }
        }

        [Test]
        public void FetchBatchShouldGetExpectedValuesThatMatchModTag()
        {
            var requestedDateTime = new DateTime(2013, 07, 12, 18, 57, 0);
            const string tag2 = "31TI111.PV";
            var fetchPHDTagValue = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, new List<string> {tag2},
                requestedDateTime);
            var result = fetchPHDTagValue[0].Value.Value;
            const double expected = 73.7785;
            Assert.AreEqual(expected, (double) result, .1);
        }

        [Test]
        public void FetchCurrentValue()
        {
            const string tag1 = "12TI732A.PV";
            var requestedDateTime = Clock.Now;
            var tag1Values = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tag1, new[] {requestedDateTime});
            Assert.That(tag1Values, Is.Not.Null);
            Assert.That(tag1Values[0], Is.Not.Null);
        }

        [Test]
        [Ignore]
        public void GetPHDTagsShouldRetrieveTagsByPrefix_Short()
        {
            const string prefix = "s";
            var tags = phdProvider.GetTagInfoList(prefix);
            Assert.IsTrue(tags.Count > 0);
            Console.WriteLine("Total count: " + tags.Count);
            foreach (var tag in tags)
            {
                var name = tag.Name.ToLower();
                Assert.IsTrue(name.StartsWith(prefix.ToLower()), name);
            }
        }

        [Test]
        public void ShouldGetSameValuesForSingleFetchAsBatchFetch()
        {
            const string tag1 = "12TI732A.PV";
            const string tag2 = "31TI111.PV";

            var requestedDateTime = Clock.Now.AddDays(-5);

            while (requestedDateTime < Clock.Now)
            {
                var tag1Values = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tag1, new[] {requestedDateTime});
                var tag2Values = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tag2, new[] {requestedDateTime});
                var fetchPHDTagValue = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test,
                    new List<string> {tag1, tag2}, requestedDateTime);

                var tag1SingleFetchValue = tag1Values[0].Value;
                var tag2SingleFetchValue = tag2Values[0].Value;

                var tag1BatchFetchValue = fetchPHDTagValue.Find(v => v.TagName.Equals(tag1)).Value.Value;
                var tag2BatchFetchValue = fetchPHDTagValue.Find(v => v.TagName.Equals(tag2)).Value.Value;

                const double within = .1;
                Assert.AreEqual((double) tag1SingleFetchValue, (double) tag1BatchFetchValue, within,
                    "Single Fetch versus Batch Fetch values are now equal at {0} for tag {1}", requestedDateTime, tag1);
                Assert.AreEqual((double) tag2SingleFetchValue, (double) tag2BatchFetchValue, within,
                    "Single Fetch versus Batch Fetch values are now equal at {0} for tag {2}", requestedDateTime, tag2);
                requestedDateTime = requestedDateTime.AddHours(4);
            }
        }

        [Test]
        [Ignore(
            "Used to get a list of attributes for a tag to see if we can use them instead or writing for the 'CanWrite' test."
            )]
        public void ShouldGetTagDefnFromPhd()
        {
            phdProvider.GetDfn("00FQI054_2.PV");
            phdProvider.GetDfn("03FC050.PTARGET");
        }

        [Test]
        public void ShouldGetTagValueFromSarniaConfiguredServer()
        {
            const string tagName = "10AI004_1.PV";
            var requestedDateTime = new DateTime(2011, 03, 04, 14, 30, 30);
            var returnedValue =
                phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName, new[] {requestedDateTime});
            Assert.IsNotNull(returnedValue[0]);
        }

        [Test]
        public void ShouldNotGetNullValueFromSarniaForTagWithConfidenceBelow100()
        {
            const string tagName = "OLTTEST.PTARGET1";
            var requestedDateTime = new DateTime(2011, 03, 4, 14, 56, 16);
            var returnedValue = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName,
                new[] {requestedDateTime});

            Assert.IsNotNull(returnedValue[0]);
        }

        [Test][Ignore]
//        [Ignore("not working quite right, but only to do with the thread tester.")]
        public void ShouldReadAndWriteOnDifferentThreads()
        {
            oilsandsProvider =
                new HoneywellPHDProvider(PlantHistorianConnectionFixture.GetOilSandsPhd310InfoUsingSqlServer());
            IPHDProvider sarniaProvider = new HoneywellPHDProvider(PlantHistorianConnectionFixture.GetSarniaPhd300Info());

            var waitHandles = new List<WaitHandle>();

            const int numIterations = 5;

            var sarniaThreadResult = new ThreadResult();
            {
                WaitHandle waitHandle = new AutoResetEvent(false);
                waitHandles.Add(waitHandle);
                ThreadPool.QueueUserWorkItem(DoSarniaWrite,
                    new object[] {0, numIterations, sarniaProvider, waitHandle, sarniaThreadResult});
            }

            var oilsandsThreadResult = new ThreadResult();
            {
                WaitHandle waitHandle = new AutoResetEvent(false);
                waitHandles.Add(waitHandle);
                ThreadPool.QueueUserWorkItem(DoOilsandsRead,
                    new object[] {1, numIterations, oilsandsProvider, waitHandle, oilsandsThreadResult});
            }

            WaitHandle.WaitAll(waitHandles.ToArray(), 300000);
            Assert.AreEqual(numIterations, sarniaThreadResult.NumSuccessfulIterations);
            Assert.AreEqual(numIterations, oilsandsThreadResult.NumSuccessfulIterations);
        }

        [Test] // fetching these values is odd because of our fetch times?
        public void ShouldWriteTagValueToSarnia()
        {
            const string tagName = "olttest.ptarget10";
            var tag = TagInfoFixture.CreateMockTagForSarnia(1, tagName);
            var now = DateTimeFixture.DateTimeNow;
            var currentValues = phdProvider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName,
                new[] {now});
            var newValue = currentValues[0].Value + 1;
            // This at least tests that we can write values
            phdProvider.UpdatePHDTagValue(tag, newValue, now);
        }

        [Test]
        public void TestingReadWriteThreadsWithSingleProvider()
        {
            var tt = new ThreadTester();

            for (var i = 0; i < 5; i++)
            {
                tt.AddThreadAction(() => DoSarniaWrite2(phdProvider));
                tt.AddThreadAction(() => DoSarniaRead2(phdProvider));
            }

            tt.RunBehavior = ThreadRunBehavior.RunUntilAllThreadsFinish;
            tt.StartAllThreads(50000);
        }

        private static void DoSarniaRead2(IPHDProvider provider)
        {
            const string tagName = "10AI004_1.PV";
            var requestedDateTime = new DateTime(2010, 03, 04, 14, 30, 30);
            var returnedValue =
                provider.FetchPHDTagValue(PlantHistorianOrigin.Test, tagName, new[] {requestedDateTime});
            Assert.IsNotNull(returnedValue[0]);
        }


        private static void DoSarniaWrite2(IPHDProvider provider)
        {
            const string tagName = "olttest.ptarget6";
            var tagInfo = new TagInfo(null, tagName, null, null, false,null);
            decimal? newValue = null;
            try
            {
                var now = DateTimeFixture.DateTimeNow;
                var currentValues = provider.FetchPHDTagValue(PlantHistorianOrigin.Test,
                    tagName, new[] {now});
                newValue = currentValues[0].Value + 1;
                // This at least tests that we can write values

                provider.UpdatePHDTagValue(tagInfo, newValue.Value, now);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Write error: " + e);
                throw new InvalidPlantHistorianWriteException(tagInfo, newValue);
            }
        }

        private static void DoSarniaWrite(object state)
        {
            var inputs = (object[]) state;
            var iterations = (int) inputs[1];
            var provider = (HoneywellPHDProvider) inputs[2];
            var autoResetEvent = (AutoResetEvent) inputs[3];
            var threadResult = (ThreadResult) inputs[4];

            for (var i = 0; i < iterations; i++)
            {
                try
                {
                    const string tagName = "olttest.ptarget6";
                    var now = DateTimeFixture.DateTimeNow;
                    var currentValues = provider.FetchPHDTagValue(PlantHistorianOrigin.Test,
                        tagName, new[] {now});
                    var newValue = currentValues[0].Value + 1;
                    // This at least tests that we can write values
                    provider.UpdatePHDTagValue(new TagInfo(null, tagName, null, null, false,null), newValue, now);
                    threadResult.NumSuccessfulIterations = threadResult.NumSuccessfulIterations + 1;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Write error: {0}", e.Message);
                    break;
                }
            }

            autoResetEvent.Set();
        }

        private static void DoOilsandsRead(object state)
        {
            var inputs = (object[]) state;
            var iterations = (int) inputs[1];
            var provider = (HoneywellPHDProvider) inputs[2];
            var autoResetEvent = (AutoResetEvent) inputs[3];
            var threadResult = (ThreadResult) inputs[4];

            var now = DateTime.Now;
            var nowAtHour = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            for (var i = 0; i < iterations; i++)
            {
                //Console.Out.WriteLine(String.Format("Oilsands Thread {0} - {1}", threadNumber, i));
                try
                {
                    provider.FetchDeviationTagValue("P86_REST_MASS_TARGET_TEST", nowAtHour.AddHours(-1), nowAtHour);
                    threadResult.NumSuccessfulIterations = threadResult.NumSuccessfulIterations + 1;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Read error: " + e);
                    break;
                }
            }

            autoResetEvent.Set();
        }

        private class ThreadResult
        {
            public int NumSuccessfulIterations { get; set; }
        }
    }
}