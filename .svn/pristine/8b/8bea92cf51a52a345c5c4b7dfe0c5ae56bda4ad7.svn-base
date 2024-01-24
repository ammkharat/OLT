using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class CustomFieldTrendReportDTOTest
    {

        [Test]
        public void ShouldEnsureThatEachDtoHasAllCustomFields()
        {
            List<CustomFieldTrendReportDTO> dtos = new List<CustomFieldTrendReportDTO>();

            const long customFieldGroupId = 1;

            long? customField1Id = 1;
            long? customField2Id = 2;
            long? customField3Id = 3;
            long? customField4Id = 4;
            long? customField5Id = 5;

            long? customField1NewNameId = 6;

            CustomField customField1 = new CustomField(customField1Id, "Custom Field 1", 0, customFieldGroupId, customFieldGroupId, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField2 = new CustomField(customField2Id, "Custom Field 2", 1, customFieldGroupId, customFieldGroupId, customField2Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField3 = new CustomField(customField3Id, "Custom Field 3", 2, customFieldGroupId, customFieldGroupId, customField3Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField4 = new CustomField(customField4Id, "Custom Field 4", 4, customFieldGroupId, customFieldGroupId, customField4Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField5 = new CustomField(customField5Id, "Zalphabet doesn't matter", 3, customFieldGroupId, customFieldGroupId, customField5Id, null, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off, null);

            CustomField customField1NewName = new CustomField(customField1NewNameId, "Custom Field 1 - new name", 0, customFieldGroupId, customFieldGroupId, customField1Id, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            {
                List<CustomField> customFields = new List<CustomField> {customField1};

                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>
                    {
                        new CustomFieldEntry(null, customField1Id, "Custom Field 1", "Entry 1", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null)
                    };

                dtos.Add(CreateDtoWithCustomFieldEntries(customFieldEntries, customFields));
            }

            {
                List<CustomField> customFields = new List<CustomField> {customField2, customField3};

                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>
                    {
                        new CustomFieldEntry(null, customField2Id, "Custom Field 2", "Entry 2", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null)
                    };

                dtos.Add(CreateDtoWithCustomFieldEntries(customFieldEntries, customFields));
            }

            {
                List<CustomField> customFields = new List<CustomField> {customField1NewName, customField3, customField4, customField5};


                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>
                    {
                        new CustomFieldEntry(null, customField5Id, "Zalphabet doesn't matter", null, new decimal(111.222),null, 0, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null),
                        new CustomFieldEntry(null, customField3Id, "Custom Field 3", "Entry 3 (another)", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null),
                        new CustomFieldEntry(null, customField1NewNameId, "Custom Field 1 - new name", "Entry 1 (another)", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null)
                    };

                dtos.Add(CreateDtoWithCustomFieldEntries(customFieldEntries, customFields));
            }


            List<CustomFieldTrendReportDTO> standardizedDtos = CustomFieldTrendReportDTO.StandardizeCustomFields(dtos);

            foreach (CustomFieldTrendReportDTO dto in standardizedDtos)
            {
                Assert.AreEqual(5, dto.CustomFieldEntries.Count);
                Assert.AreEqual("Custom Field 1 - new name", dto.CustomFieldEntries[0].CustomFieldName);
                Assert.AreEqual("Custom Field 2", dto.CustomFieldEntries[1].CustomFieldName);
                Assert.AreEqual("Custom Field 3", dto.CustomFieldEntries[2].CustomFieldName);
                Assert.AreEqual("Zalphabet doesn't matter", dto.CustomFieldEntries[3].CustomFieldName);
                Assert.AreEqual("Custom Field 4", dto.CustomFieldEntries[4].CustomFieldName);
            }

            CustomFieldTrendReportDTO firstDto = standardizedDtos[0];
            Assert.AreEqual("Entry 1", firstDto.CustomFieldEntries[0].FieldEntry);
            Assert.AreEqual("N/A", firstDto.CustomFieldEntries[1].FieldEntry);
            Assert.AreEqual("N/A", firstDto.CustomFieldEntries[2].FieldEntry);
            Assert.AreEqual("N/A", firstDto.CustomFieldEntries[3].FieldEntry);
            Assert.AreEqual("N/A", firstDto.CustomFieldEntries[4].FieldEntry);

            CustomFieldTrendReportDTO secondDto = standardizedDtos[1];
            Assert.AreEqual("N/A", secondDto.CustomFieldEntries[0].FieldEntry);
            Assert.AreEqual("Entry 2", secondDto.CustomFieldEntries[1].FieldEntry);
            Assert.AreEqual(null, secondDto.CustomFieldEntries[2].FieldEntry);
            Assert.AreEqual("N/A", secondDto.CustomFieldEntries[3].FieldEntry);
            Assert.AreEqual("N/A", secondDto.CustomFieldEntries[4].FieldEntry);

            CustomFieldTrendReportDTO thirdDto = standardizedDtos[2];
            Assert.AreEqual("Entry 1 (another)", thirdDto.CustomFieldEntries[0].FieldEntry);
            Assert.AreEqual("N/A", thirdDto.CustomFieldEntries[1].FieldEntry);
            Assert.AreEqual("Entry 3 (another)", thirdDto.CustomFieldEntries[2].FieldEntry);
            Assert.AreEqual("111.222", thirdDto.CustomFieldEntries[3].FieldEntryForDisplay);
            Assert.AreEqual(null, thirdDto.CustomFieldEntries[4].FieldEntry);

            Assert.AreEqual(CustomFieldType.GeneralText, thirdDto.CustomFieldEntries[2].Type);
            Assert.AreEqual(CustomFieldType.NumericValue, thirdDto.CustomFieldEntries[3].Type);
        }

        [Test]
        public void ShouldExcludeDtosWithNoCustomFieldEntriesOrWithNoPopulatedCustomFieldEntries()
        {
            const long customFieldGroupId = 1;

            List<CustomFieldTrendReportDTO> dtos = new List<CustomFieldTrendReportDTO>();

            CustomFieldTrendReportDTO somePopulatedAndSomeEmpty = null;
            CustomFieldTrendReportDTO noEntries = null;
            CustomFieldTrendReportDTO allEmpty = null;
            CustomFieldTrendReportDTO allPopulated = null;

            // some populated entries, some empty entries
            {
                List<CustomField> customFields = new List<CustomField>
                    {
                        new CustomField(1, "Custom Field 1", 0, customFieldGroupId, customFieldGroupId, 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                        new CustomField(2, "Custom Field 2", 0, customFieldGroupId, customFieldGroupId, 2, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null)
                    };

                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>
                    {
                        new CustomFieldEntry(1, null, "Custom Field 1", "Entry 1", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null),
                        new CustomFieldEntry(2, null, "Custom Field 2", "", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null)
                    };

                somePopulatedAndSomeEmpty = CreateDtoWithCustomFieldEntries(1, customFieldEntries, customFields);
                dtos.Add(somePopulatedAndSomeEmpty);
            }

            // no entries
            {
                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();
                noEntries = CreateDtoWithCustomFieldEntries(2, customFieldEntries, new List<CustomField>());
                dtos.Add(noEntries);
            }

            // all empty entries
            {
                List<CustomField> customFields = new List<CustomField>
                    {
                        new CustomField(1, "Custom Field 2", 0, customFieldGroupId, customFieldGroupId, 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                        new CustomField(2, "Custom Field 1", 0, customFieldGroupId, customFieldGroupId, 2, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                        new CustomField(3, "Custom Field 3", 0, customFieldGroupId, customFieldGroupId, 3, null, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off, null)
                    };

                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>
                    {
                        new CustomFieldEntry(2, null, "Custom Field 2", null, null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null),
                        new CustomFieldEntry(1, null, "Custom Field 1", "", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null),
                        new CustomFieldEntry(3, null, "Custom Field 3", null, null,null, 3, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null)
                    };

                allEmpty = CreateDtoWithCustomFieldEntries(3, customFieldEntries, customFields);
                dtos.Add(allEmpty);
            }

            // all populated entries
            {
                List<CustomField> customFields = new List<CustomField>
                    {
                        new CustomField(3, "Custom Field 3", 0, customFieldGroupId, customFieldGroupId, 1, null, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off, null)
                    };

                List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry> { new CustomFieldEntry(3, null, "Custom Field 3", null,null, 22, 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null) };

                allPopulated = CreateDtoWithCustomFieldEntries(4, customFieldEntries, customFields);
                dtos.Add(allPopulated);
            }

            List<CustomFieldTrendReportDTO> resultDtos = CustomFieldTrendReportDTO.RemoveEmpties(dtos);
            Assert.AreEqual(2, resultDtos.Count);
            Assert.IsTrue(resultDtos.Exists(dto => dto.Id == allPopulated.Id));
            Assert.IsTrue(resultDtos.Exists(dto => dto.Id == somePopulatedAndSomeEmpty.Id));
        }

        private CustomFieldTrendReportDTO CreateDtoWithCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            return CreateDtoWithCustomFieldEntries(0, customFieldEntries, customFields);
        }

        private CustomFieldTrendReportDTO CreateDtoWithCustomFieldEntries(long id, List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            return new CustomFieldTrendReportDTO(id, CustomFieldTrendReportDTO.LogType.Standard, "last modified", Clock.Now, "shift name", new Date(2012, 12, 4), "MT1-BLAH",
                                              customFieldEntries, "work assignment", customFields);
        }
    }
}
