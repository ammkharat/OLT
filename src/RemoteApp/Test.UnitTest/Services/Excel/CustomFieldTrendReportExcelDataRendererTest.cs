using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Excel;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    [TestFixture]
    public class CustomFieldTrendReportExcelDataRendererTest
    {
        private const int DATA_START_ROW = 2;

        [Ignore] [Test]
        public void ShouldShowDtoDataInSpreadsheet()
        {
            CustomField customField = new CustomField(null, "field name", 0, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField numericCustomField = new CustomField(null, "numnum", 1, null, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off, null);
            List<CustomField> customFields = new List<CustomField> { customField, numericCustomField };

            CustomFieldEntry customFieldEntry = new CustomFieldEntry(null, null, "field name", "field entry", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntry numericCustomFieldEntry = new CustomFieldEntry(null, null, "numnum", null, new decimal(123.456),null, 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry> { customFieldEntry, numericCustomFieldEntry };

            DateTime logDateTime = new DateTime(2011, 12, 2, 13, 0, 5);
            const string lastModifiedByFullNameWithUserName = "LastModifiedBy";
            const string shiftName = "shift";
            Date shiftDate = new Date(2011, 12, 4);
            const string floc = "MY-FLOC";
            const string workAssignmentName = "work assignment";
            CustomFieldTrendReportDTO dto = new CustomFieldTrendReportDTO(0, CustomFieldTrendReportDTO.LogType.Standard, lastModifiedByFullNameWithUserName, logDateTime, shiftName, shiftDate, floc, customFieldEntries, workAssignmentName, customFields);

            CustomFieldTrendReportExcelDataRenderer renderer = new CustomFieldTrendReportExcelDataRenderer(new List<CustomFieldTrendReportDTO> { dto });

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet1 = workbook.Worksheets["Page 1"];
            Assert.IsFalse(workbook.Worksheets.Exists("Page 2"));

            const int row = DATA_START_ROW;
            int column = 0;
            Assert.AreEqual("Log", worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(logDateTime, worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual("12/4/2011 - shift", worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(floc, worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(lastModifiedByFullNameWithUserName, worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(workAssignmentName, worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(customFieldEntry.FieldEntryForDisplay, worksheet1.Rows[row].Cells[column++].Value);
            Assert.AreEqual(numericCustomFieldEntry.NumericFieldEntry, worksheet1.Rows[row].Cells[column++].Value);

            Assert.AreEqual(customFieldEntry.CustomFieldName, worksheet1.Rows[0].Cells[6].Value);
            Assert.AreEqual(numericCustomFieldEntry.CustomFieldName, worksheet1.Rows[0].Cells[7].Value);
        }

        [Ignore] [Test]
        public void ShouldDetectNumericValuesInStringsAndPutThemIntoTheCellsAsNumbers()
        {
            CustomField customField = new CustomField(null, "field name", 0, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField numericCustomField = new CustomField(null, "other field", 1, null, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off, null);
            List<CustomField> customFields = new List<CustomField> { customField, numericCustomField };

            CustomFieldEntry customFieldEntry = new CustomFieldEntry(null, null, "field name", "10.53", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntry numericCustomFieldEntry = new CustomFieldEntry(null, null, "other field", "not a number", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry> { customFieldEntry, numericCustomFieldEntry };

            DateTime logDateTime = new DateTime(2011, 12, 2, 13, 0, 5);
            const string lastModifiedByFullNameWithUserName = "LastModifiedBy";
            const string shiftName = "shift";
            Date shiftDate = new Date(2011, 12, 4);
            const string floc = "MY-FLOC";
            const string workAssignmentName = "work assignment";
            CustomFieldTrendReportDTO dto = new CustomFieldTrendReportDTO(0, CustomFieldTrendReportDTO.LogType.Standard, lastModifiedByFullNameWithUserName, logDateTime, shiftName, shiftDate, floc, customFieldEntries, workAssignmentName, customFields);

            CustomFieldTrendReportExcelDataRenderer renderer = new CustomFieldTrendReportExcelDataRenderer(new List<CustomFieldTrendReportDTO> { dto });

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet1 = workbook.Worksheets["Page 1"];
            Assert.IsFalse(workbook.Worksheets.Exists("Page 2"));

            const int row = DATA_START_ROW;
            Assert.AreEqual(new decimal(10.53), worksheet1.Rows[row].Cells[6].Value);
            Assert.AreEqual("not a number", worksheet1.Rows[row].Cells[7].Value);
        }

        [Ignore] [Test]
        public void ShouldSplitSpreadsheetIntoMultiplePages()
        {
            CustomField customField1 = new CustomField(null, "field name 1", 0, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField2 = new CustomField(null, "field name 2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            List<CustomField> customFields = new List<CustomField> { customField1, customField2 };

            CustomFieldEntry customFieldEntry1 = new CustomFieldEntry(null, null, "field name 1", "field entry 1", null,null, 0, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntry customFieldEntry2 = new CustomFieldEntry(null, null, "field name 2", "field entry 2", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry> { customFieldEntry1, customFieldEntry2 };

            DateTime logDateTime = new DateTime(2011, 12, 2, 13, 0, 5);
            const string lastModifiedByFullNameWithUserName = "LastModifiedBy";
            const string shiftName = "shift";
            Date shiftDate = new Date(2012, 12, 4);
            const string floc = "MY-FLOC";
            const string workAssignmentName = "work assignment";
            CustomFieldTrendReportDTO dto = new CustomFieldTrendReportDTO(0, CustomFieldTrendReportDTO.LogType.Standard, lastModifiedByFullNameWithUserName, logDateTime, shiftName, shiftDate, floc, customFieldEntries, workAssignmentName, customFields);

            CustomFieldTrendReportExcelDataRenderer renderer = new CustomFieldTrendReportExcelDataRenderer(new List<CustomFieldTrendReportDTO> { dto }, 7);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet1 = workbook.Worksheets["Page 1"];
            Worksheet worksheet2 = workbook.Worksheets["Page 2"];

            const int row = DATA_START_ROW;
            new List<Worksheet> { worksheet1, worksheet2 }.ForEach(worksheet =>
            {
                int column = 0;
                Assert.AreEqual("Log", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(logDateTime, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("12/4/2012 - shift", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(floc, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(lastModifiedByFullNameWithUserName, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(workAssignmentName, worksheet.Rows[row].Cells[column++].Value);
            });


            Assert.AreEqual(customFieldEntry1.FieldEntryForDisplay, worksheet1.Rows[row].Cells[6].Value);
            Assert.AreEqual(customFieldEntry1.CustomFieldName, worksheet1.Rows[0].Cells[6].Value);

            Assert.AreEqual(customFieldEntry2.FieldEntryForDisplay, worksheet2.Rows[row].Cells[6].Value);
            Assert.AreEqual(customFieldEntry2.CustomFieldName, worksheet2.Rows[0].Cells[6].Value);
        }

    }
}
