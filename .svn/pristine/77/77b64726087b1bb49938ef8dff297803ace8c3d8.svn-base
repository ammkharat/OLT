using System;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class OpmXhqServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private IExcursionImportService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IExcursionImportService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [Test]
        [Ignore("Problems doing a full local build even though test tool can get this tag value")]
        public void ShouldGetCurrentTagValue()
        {
            var currentTagValue = service.GetCurrentOpmTagValue("5LIC749");
            Assert.IsNotNull(currentTagValue);

            // e.g. 
            // OpmTagValueDTO ( Description = 5C99 GASOIL DRAW, Quality = GOOD, TimeStamp = 1/28/2015 1:15:18 PM, Units = %, Value = 56.187546, Id = 0 )

            Assert.AreEqual("5C99 GASOIL DRAW", currentTagValue.Description);
            Assert.Contains(currentTagValue.Quality, new[] {"GOOD"});
            Assert.AreEqual("%", currentTagValue.Units);
            Assert.IsTrue(currentTagValue.Value.IsWithinRange(0, 100)); // percent should be in 0-100 range...duh :p
            Assert.IsTrue(currentTagValue.TimeStamp.IsWithinTimeSpan(TimeSpan.FromHours(1)));
                // Tag value should be pretty recent (i.e. easily within an hour)
        }


        [Test]
        [Ignore("Problems doing a full local build even though test tool can get the excursions")]
        public void ShouldGetNewExcursions()
        {
            var excursionImportResult = service.ImportOpmExcursionDtosFromDate(DateTime.Now.Subtract(TimeSpan.FromDays(3)));
            
            Assert.IsNotNull(excursionImportResult);
            Assert.IsNotEmpty(excursionImportResult.ImportedExcursions);
//            Assert.IsEmpty(excursionImportResult.Rejections);
            Assert.IsTrue(excursionImportResult.HasResults);
//            Assert.IsFalse(excursionImportResult.HasError);
//            Assert.IsFalse(excursionImportResult.HasRejections);
        }

        [Test]
        [Ignore ("Jason to address? Seems like data is always changing so maybe  a more generic test is needed")]
        public void ShouldGetToeDefinition()
        {
            var toeDefinitionImportResult = service.ImportOpmToeDefinition("M22FDI222.DACA.PV", 0);
            Assert.IsNotNull(toeDefinitionImportResult);
            Assert.IsNull(toeDefinitionImportResult.Rejection);
            Assert.IsTrue(toeDefinitionImportResult.HasResults);
            Assert.IsFalse(toeDefinitionImportResult.HasError);
            Assert.IsFalse(toeDefinitionImportResult.HasRejection);

            var toeDefinition = toeDefinitionImportResult.ImportedToeDefinition;
            Assert.IsNotNull(toeDefinition);
            Assert.AreEqual("M22FDI222.DACA.PVA GRP PUMP INBOARD-HP B. FLUID DISCREPANCY SL High", toeDefinition.ToeName);
            Assert.AreEqual("M22FDI222.DACA.PV", toeDefinition.HistorianTag);
            Assert.AreEqual("MR1-P022-0022", toeDefinition.FunctionalLocation);
            Assert.AreEqual(ToeType.HighSl, toeDefinition.ToeType);
        }
    }
}