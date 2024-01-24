using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class RequireManagerOperationsMontrealCsdTest
    {
        private IFormEdmontonService mockFormService;
        private ISiteService mockSiteService;
        private ITimeService mockTimeService;
        private IUserService mockUserService;

        [SetUp]
        public void Setup()
        {
            mockFormService = MockRepository.GenerateMock<IFormEdmontonService>();
            mockTimeService = MockRepository.GenerateStub<ITimeService>();
            mockSiteService = MockRepository.GenerateStub<ISiteService>();
            mockUserService = MockRepository.GenerateStub<IUserService>();

            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

      
    }
}