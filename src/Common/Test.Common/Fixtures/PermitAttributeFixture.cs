using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class PermitAttributeFixture
    {
        public static IPermitAttributeFixtureDataProvider dataProvider = new MadeUpPermitAttributeFixtureDataProvider();
        public static void SetDataProvider(IPermitAttributeFixtureDataProvider provider)
        {
            dataProvider = provider;
        }

        public static void UseFakeDataProvider()
        {
            dataProvider = new MadeUpPermitAttributeFixtureDataProvider();
        }

        public interface IPermitAttributeFixtureDataProvider
        {
            List<PermitAttribute> GetBySiteId(long siteId);
        }

        public static List<PermitAttribute> GetReal(long siteId)
        {
            return dataProvider.GetBySiteId(siteId);
        }

        private class MadeUpPermitAttributeFixtureDataProvider : IPermitAttributeFixtureDataProvider
        {
            public List<PermitAttribute> GetBySiteId(long siteId)
            {
                List<PermitAttribute> attributes = new List<PermitAttribute>();
                attributes.Add(new PermitAttribute(1, "attribute1", "c1", siteId));
                attributes.Add(new PermitAttribute(2, "attribute2", "c2", siteId));
                attributes.Add(new PermitAttribute(3, "attribute3", "c3", siteId));
                return attributes;
            }
        }
    }
}
