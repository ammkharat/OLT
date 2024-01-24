using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class TagServiceClientTest
    {
        private IPlantHistorianService plantHistorianService;
        private ITagService tagService;

        [SetUp]
        public void SetUp()
        {
            tagService = GenericServiceRegistry.Instance.GetService<ITagService>();
            plantHistorianService = GenericServiceRegistry.Instance.GetService<IPlantHistorianService>();
        }

        [Test][Ignore]
        public void ShouldUpdateTagsForOilsands()
        {
            AssertUpdateTags(SiteFixture.Oilsands(), "Z");
        }

        [Test][Ignore]
        public void ShouldUpdateTagsForSarnia()
        {
            AssertUpdateTags(SiteFixture.Sarnia(), "W");
        }

        private void AssertUpdateTags(Site site, string prefix)
        {
            var searchCriteria = new SearchCriteria {Field = GetTagNameField(), Value = prefix};

            var beforeUpdate = tagService.QueryTagInfoByFilter(site, searchCriteria);

            var phdTags = plantHistorianService.GetTagInfoList(site, prefix);

            tagService.UpdatePlantHistorianTagInfoList(site, prefix, phdTags);

            var afterUpdate = tagService.QueryTagInfoByFilter(site, searchCriteria);

            Assert.IsTrue(afterUpdate.Count >= beforeUpdate.Count);
        }

        public static SearchField GetTagNameField()
        {
            return new SearchField("Tag Name", "Name", FieldType.Text);
        }
    }
}