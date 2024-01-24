using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client
{
    [TestFixture]
    public class WorkPermitFormsFactoryTest
    {
        [Test]
        public void ShouldReturnSarniaSpecificForms()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            WorkPermitForms build = new WorkPermitFormsFactory().Build();
            Assert.IsInstanceOf(typeof (SarniaWorkPermitForms), build);
        }

        [Test]
        public void ShouldReturnDenverSpecificForms()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Denver(), null);
            WorkPermitForms build = new WorkPermitFormsFactory().Build();
            Assert.IsInstanceOf(typeof(DenverWorkPermitForms), build);
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void ShouldReturnDefaultsForFirebag()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Firebag(), null);
            new WorkPermitFormsFactory().Build();
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void ShouldReturnDefaultsForOilSandsExtraction()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Oilsands(), null);
            new WorkPermitFormsFactory().Build();
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void ShouldReturnDefaultsForOilSandsUpgrading()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Oilsands(), null);
            new WorkPermitFormsFactory().Build();
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void ShouldReturnDefaultsForSiteWideServices()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.SiteWideServices(), null);
            new WorkPermitFormsFactory().Build();
        }
    }
}