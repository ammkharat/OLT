using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Integration
{
    [TestFixture]
    public class WorkOrderRequestClientTest
    {
        [Ignore] [Test]
        public void ShouldBeAbleToSerializeToObjectWhenPriorityIsInMessage()
        {
            string fileAsString = GetFileAsString("WOListWithPriority.xml");
            StringReader stringReader = new StringReader(fileAsString);
            var serializer = new XmlSerializer(typeof(WorkOrderOLTdata));
            WorkOrderOLTdata workOrderData = serializer.Deserialize(stringReader) as WorkOrderOLTdata;
            
            Assert.That(workOrderData, Is.Not.Null);
                
            Assert.That(workOrderData.WorkOrderRecordList.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails[0].Priority, Is.EqualTo("2"));
        }

        [Ignore] [Test]
        public void ShouldBeAbleToSerializeToObjectWhenPriorityIsNotInMessage()
        {
            string fileAsString = GetFileAsString("WOListWithoutPriority.xml");
            StringReader stringReader = new StringReader(fileAsString);
            var serializer = new XmlSerializer(typeof(WorkOrderOLTdata));
            WorkOrderOLTdata workOrderData = serializer.Deserialize(stringReader) as WorkOrderOLTdata;

            Assert.That(workOrderData, Is.Not.Null);

            Assert.That(workOrderData.WorkOrderRecordList.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails[0].Priority, Is.Null);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToSerializeWhenThereIsSomeFieldWeDoNotRecognize()
        {
            string fileAsString = GetFileAsString("WOListWithPriorityAndSomeFieldWeDoNotKnow.xml");
            StringReader stringReader = new StringReader(fileAsString);
            var serializer = new XmlSerializer(typeof(WorkOrderOLTdata));
            WorkOrderOLTdata workOrderData = serializer.Deserialize(stringReader) as WorkOrderOLTdata;

            Assert.That(workOrderData, Is.Not.Null);

            Assert.That(workOrderData.WorkOrderRecordList.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails.Length, Is.GreaterThan(0));
            Assert.That(workOrderData.WorkOrderRecordList[0].WorkOrderDetails[0].Priority, Is.EqualTo("2"));
        }

        private static string GetFileAsString(string name)
        {
            StringBuilder builder = new StringBuilder();
            string testDataFilesDirectory = ConfigurationManager.AppSettings["WebMethodsPullTests"];
            string fileNameAndPath = Path.Combine(testDataFilesDirectory, name);
            
            using (StreamReader sr = new StreamReader(fileNameAndPath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    builder.Append(line);
                }
            }
            return builder.ToString();
        }

    }
}
