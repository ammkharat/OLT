using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class BaseFormTest
    {
        [Test]
        public void ShouldSetDefaultDateTimeValues_BasicDayCase()
        {
            DateTime stupidDateTime = new DateTime(1975, 3, 9);


            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, stupidDateTime, stupidDateTime, null, Clock.Now, 8);           //ayman generic forms

            Date today = new Date(2012, 10, 26);
            Time time = new Time(14);

            baseForm.SetDefaultDatesBasedOnShift(true, today, time);

            Assert.AreEqual(new DateTime(2012, 10, 26, 18, 30, 0), baseForm.ToDateTime);          
        }

        [Test]
        public void ShouldSetDefaultDateTimeValues_CaseWhereTimeIsEveningInNightShift()
        {
            DateTime stupidDateTime = new DateTime(1975, 3, 9);

            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, stupidDateTime, stupidDateTime, null, Clock.Now, 8);      //ayman generic forms

            Date today = new Date(2012, 10, 26);
            Time time = new Time(20, 15);

            baseForm.SetDefaultDatesBasedOnShift(false, today, time);

            Assert.AreEqual(new DateTime(2012, 10, 27, 18, 30, 0), baseForm.ToDateTime);          
        }

        [Test]
        public void ShouldSetDefaultDateTimeValues_CaseWhereTimeIsMorningInNightShift()
        {
            DateTime stupidDateTime = new DateTime(1975, 3, 9);

            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, stupidDateTime, stupidDateTime, null, Clock.Now, 8);          //ayman generic forms

            Date today = new Date(2012, 10, 27);
            Time time = new Time(1, 15);

            baseForm.SetDefaultDatesBasedOnShift(false, today, time);

            Assert.AreEqual(new DateTime(2012, 10, 27, 18, 30, 0), baseForm.ToDateTime);          
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnPermitFlocsAndNotMainFlocs()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Edmonton());
            siteConfiguration.FormsFlocSetType = FunctionalLocationSetType.WorkPermit;

            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, new DateTime(1975, 3, 9), new DateTime(1975, 3, 9), null, Clock.Now, 8);             //ayman generic forms
            ((FormGN59)baseForm).FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            Assert.IsTrue(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string> { "ED1-A001" },null, siteConfiguration));
            Assert.IsFalse(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string> { "ED1-A002" }, null,siteConfiguration));
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnMainFlocsIfThereAreNoPermitFlocsEvenIfTheTypeIsSetToWorkPermit()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Edmonton());
            siteConfiguration.FormsFlocSetType = FunctionalLocationSetType.WorkPermit;

            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, new DateTime(1975, 3, 9), new DateTime(1975, 3, 9), null, Clock.Now, 8);              //ayman generic forms
            ((FormGN59)baseForm).FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            Assert.IsFalse(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string>(),new List<string>(), siteConfiguration));
            Assert.IsTrue(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string>(),new List<string>(), siteConfiguration));
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnMainFlocsIfTheSiteConfigurationSaysToUseThem()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Edmonton());
            siteConfiguration.FormsFlocSetType = FunctionalLocationSetType.LogIn;

            BaseEdmontonForm baseForm = new FormGN59(null, FormStatus.Draft, new DateTime(1975, 3, 9), new DateTime(1975, 3, 9), null, Clock.Now, 8);       //ayman generic forms
            ((FormGN59)baseForm).FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007() };

            Assert.IsFalse(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string> { "ED1-A001" },new List<string>(),  siteConfiguration));
            Assert.IsTrue(baseForm.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string> { "ED1-A002" },new List<string>(),  siteConfiguration));
        }
    }
}


