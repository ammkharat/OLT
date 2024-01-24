using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Infragistics.Excel;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    [TestFixture]
    public class AnalyticsExcelExportDataRendererTest
    {
        private const int DATA_START_ROW = 2;

        [Ignore] [Test]
        public void ShouldShowDataInSpreadsheet()
        {
            Property stringProperty = new Property("key1", "val");
            Property numberProperty = new Property("key2", 5.3m);
            Property dateTimeProperty = new Property("key3", new DateTime(2013, 2, 2));

            const long userId = 1;
            const long siteId = 1;
            DateTime eventDateTime = new DateTime(2013, 10, 1, 8, 0, 0);
            Event @event = new Event(null, userId, siteId, "flush toilet", eventDateTime, new List<Property> { stringProperty, numberProperty, dateTimeProperty });

            AnalyticsExcelExportDataRenderer renderer = new AnalyticsExcelExportDataRenderer(new List<Event> { @event });

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet1 = workbook.Worksheets["Events"];

            const int headerRowIndex = 0;
            const int dataRowIndex = DATA_START_ROW;
            int column = 0;

            Assert.AreEqual("Name", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual("flush toilet", worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("Date", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(eventDateTime, worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("User", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(userId, worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("Site", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(siteId, worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("key1", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual("val", worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("key2", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(5.3m, worksheet1.Rows[dataRowIndex].Cells[column++].Value);

            Assert.AreEqual("key3", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(new DateTime(2013, 2, 2), worksheet1.Rows[dataRowIndex].Cells[column++].Value);
        }

        [Ignore] [Test]
        public void ShouldShowDataInSpreadsheet_MoreComplicatedPropertyScenario()
        {
            const long userId = 1;
            const long siteId = 1;
            Event event1 = new Event(null, userId, siteId, "flush toilet", new DateTime(2013, 10, 1, 8, 0, 0), new List<Property> { new Property("key1", "val"), new Property("key2", 5.3m), new Property("key3", new DateTime(2013, 2, 2)) });
            Event event2 = new Event(null, userId, siteId, "flush toilet", new DateTime(2013, 10, 1, 8, 0, 1), new List<Property> { new Property("key2", 2.5m), new Property("key1", "val2"), new Property("key4", new DateTime(2013, 1, 1)) });

            AnalyticsExcelExportDataRenderer renderer = new AnalyticsExcelExportDataRenderer(new List<Event> { event1, event2 });

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet1 = workbook.Worksheets["Events"];

            const int headerRowIndex = 0;
            const int dataRow1Index = DATA_START_ROW;
            const int dataRow2Index = dataRow1Index + 1;
            int column = 0;

            Assert.AreEqual("Name", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual("flush toilet", worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual("flush toilet", worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("Date", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(new DateTime(2013, 10, 1, 8, 0, 0), worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(new DateTime(2013, 10, 1, 8, 0, 1), worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("User", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(userId, worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(userId, worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("Site", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(siteId, worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(siteId, worksheet1.Rows[dataRow1Index].Cells[column++].Value);

            Assert.AreEqual("key1", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual("val", worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual("val2", worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("key2", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(5.3m, worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(2.5m, worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("key3", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(new DateTime(2013, 2, 2), worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(null, worksheet1.Rows[dataRow2Index].Cells[column++].Value);

            Assert.AreEqual("key4", worksheet1.Rows[headerRowIndex].Cells[column].Value);
            Assert.AreEqual(null, worksheet1.Rows[dataRow1Index].Cells[column].Value);
            Assert.AreEqual(new DateTime(2013, 1, 1), worksheet1.Rows[dataRow2Index].Cells[column].Value);
        }

    }
}
