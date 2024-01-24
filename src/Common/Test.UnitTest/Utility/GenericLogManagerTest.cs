using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class GenericLogManagerTest
    {
        [Test]
        public void ShouldCreateSimpleNameForAClass()
        {
            string loggerNameString = GenericLogManager.CreateLoggerNameString(typeof (TestDomainObject));
            Assert.That(loggerNameString, Is.EqualTo("Com.Suncor.Olt.Common.Utility.TestDomainObject"));
        }

        [Test]
        public void ShouldCreateGenericNameForGenericClass()
        {
            string loggerName = GenericLogManager.CreateLoggerNameString(typeof (List<TestDomainObject>));
            Assert.That(loggerName, Is.EqualTo("System.Collections.Generic.List`1<Com.Suncor.Olt.Common.Utility.TestDomainObject>"));
        }

        [Test]
        public void ShouldCreateGenericNameForDoubleGenericClass()
        {
            string loggerName = GenericLogManager.CreateLoggerNameString(typeof(Dictionary<String, TestDomainObject>));
            Assert.That(loggerName, Is.EqualTo("System.Collections.Generic.Dictionary`2<System.String, Com.Suncor.Olt.Common.Utility.TestDomainObject>"));
        }

        [Test]
        public void ShouldCreateGenericNameForDoubleGenericClassWhereOneIsAlsoAGeneric()
        {
            string loggerName = GenericLogManager.CreateLoggerNameString(typeof(Dictionary<String, List<TestDomainObject>>));
            Assert.That(loggerName, Is.EqualTo("System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<Com.Suncor.Olt.Common.Utility.TestDomainObject>>"));
        }

    }

    class TestDomainObject
    {
        
    }
}