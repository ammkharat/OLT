using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RestrictionDefinitionFixture
    {
        public static RestrictionDefinition CreateDefinition()
        {
            return CreateDefinition(FunctionalLocationFixture.GetAny_Equip1());
        }

        public static RestrictionDefinition CreateDefinition(TagInfo measurementTag)
        {
            RestrictionDefinition definition = CreateDefinition();
            definition.MeasurementTagInfo = measurementTag;
            return definition;
        }

        public static RestrictionDefinition CreateDefinition(RestrictionDefinitionStatus status, Site site)
        {
            RestrictionDefinition definition = CreateDefinition(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI());
            definition.Status = status;
            definition.FunctionalLocation.Site = site;
            return definition;
        }

        public static RestrictionDefinition CreateDefinition(RestrictionDefinitionStatus status, TagInfo measurementTag, TagInfo productionTargetTag)
        {
            RestrictionDefinition definition = CreateDefinition(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI());
            definition.Status = status;
            definition.MeasurementTagInfo = measurementTag;
            definition.ProductionTargetTagInfo = productionTargetTag;
            return definition;
        }

        public static RestrictionDefinition CreateDefinition(FunctionalLocation floc)
        {
            return CreateDefinition("test definition", floc);            
        }

        public static RestrictionDefinition CreateDefinition(FunctionalLocation floc, TagInfo tag)
        {
            return CreateDefinition("test definition", floc, tag);
        }

        public static RestrictionDefinition CreateDefinition(string name, FunctionalLocation floc)
        {
            return CreateDefinition(name, floc, TagInfoFixture.GetWorkingRestrictionDefinitionTargetTagInfoForOilsands());
        }

        public static RestrictionDefinition CreateDefinition(string name, FunctionalLocation floc, TagInfo tag)
        {
            RestrictionDefinition definition = new RestrictionDefinition
                                                   {
                                                       Id = 1,
                                                       Name = name,
                                                       FunctionalLocation = floc,
                                                       Description = "some sort of description",
                                                       MeasurementTagInfo = tag,
                                                       ProductionTargetValue = 123,
                                                       Status = RestrictionDefinitionStatus.Valid,
                                                       IsActive = true,
                                                       LastModifiedBy = UserFixture.CreateUserWithGivenId(1),
                                                       LastModifiedDateTime = DateTimeFixture.DateTimeNow,
                                                       CreatedDate = DateTimeFixture.DateTimeNow
                                                   };






            return definition;
        }
    }

    public class RestrictionLocationItemFixture
    {
        public static RestrictionLocationItem CreateWithOneReasonCodeWithNoLimit()
        {
            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes = new List<RestrictionLocationItemReasonCodeAssociation>
            {
                new RestrictionLocationItemReasonCodeAssociation(RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb(), null)
            };
            RestrictionLocationItem restrictionLocationItem = new RestrictionLocationItem("item1", FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI(), null, reasonCodes);
            return restrictionLocationItem;
        }

        public static RestrictionLocationItem CreateWithOneReasonCodeWithALimit(int limit)
        {
            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes = new List<RestrictionLocationItemReasonCodeAssociation>
            {
                new RestrictionLocationItemReasonCodeAssociation(RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb(), limit)
            };
            RestrictionLocationItem restrictionLocationItem = new RestrictionLocationItem("item1", FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI(), null, reasonCodes);
            return restrictionLocationItem;
        }

        public static RestrictionLocationItem CreateWithReasonCodes(FunctionalLocation functionalLocation, params RestrictionReasonCode[] reasonCodes)
        {
            List<RestrictionLocationItemReasonCodeAssociation> associations = reasonCodes.ConvertAll(rc => new RestrictionLocationItemReasonCodeAssociation(rc, null));
            RestrictionLocationItem restrictionLocationItem = new RestrictionLocationItem("item1", functionalLocation, null, associations);
            return restrictionLocationItem;
        }

        public static RestrictionLocationItem CreateWithReasonCodes(params RestrictionReasonCode[] reasonCodes)
        {
            return CreateWithReasonCodes(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI(), reasonCodes);
        }
    }
}
