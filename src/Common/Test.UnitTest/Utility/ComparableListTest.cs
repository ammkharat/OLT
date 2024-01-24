using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class ComparableListTest
    {
        List<string> list;
        List<string> listWithEqualElements;
        List<string> listOfDifferentSize;
        List<string> listWithSameElementsInDifferentOrder;
        List<int> listOfIntegers;
        List<string> normalGenericListWithIdenticalElements;

        [SetUp]
        public void Setup()
        {
            list = new List<string>(new[] { "one", "two", "three" });
            listWithEqualElements = new List<string>(new[] { "one", "two", "three" });
            listOfDifferentSize = new List<string>(new[] { "one", "two", "three", "four" });
            listWithSameElementsInDifferentOrder = new List<string>(new[] { "two", "one", "three" });
            listOfIntegers = new List<int>(new[] { 1, 2, 3 });
            normalGenericListWithIdenticalElements = new List<string>(new[] { "one", "two", "three" });
        }

        [Test]
        public void ListsWithTheSameElementsInIdenticalOrderShouldBeEqual()
        {
            Assert.AreEqual(list, listWithEqualElements);
        }

        [Test]
        public void ShouldBeAbleToCompareANormalGenericListWithThisComparableList()
        {
            Assert.AreEqual(list, normalGenericListWithIdenticalElements);
        }

        [Test]
        public void ListsWithSameElementsInDifferentOrderShouldNotBeEqual()
        {
            Assert.AreNotEqual(list, listWithSameElementsInDifferentOrder);
        }

        [Test]
        public void ListsOfDifferentSizesShouldNotBeEqual()
        {
            Assert.AreNotEqual(list, listOfDifferentSize);
        }

        [Test]
        public void ListComparedToNonListShouldNotBeEqual()
        {
            Assert.AreNotEqual(list, "not a list");
        }

        [Test]
        public void ListComparedToListWithDifferentGenericObjectsShouldNotBeEqual()
        {
            Assert.AreNotEqual(list, listOfIntegers);
        }

        [Test]
        public void ToStringShouldDisplayTheItemsInTheList()
        {
            Assert.AreEqual("one, two, three", list.BuildCommaSeparatedList());
        }

        [Test]
        public void FirstShouldReturnAllItemsIfLessThanMax()
        {
            List<int> originalList = new List<int>(new[] { 1, 2, 3 });
            List<int> listWithUpTo5Items = originalList.First(5);

            Assert.AreEqual(new List<int>(new[] { 1, 2, 3 }), listWithUpTo5Items);
            Assert.AreNotSame(originalList, listWithUpTo5Items);
        }

        [Test]
        public void FirstShouldReturnOnlyUpToMaxItemsIfGreaterThanMax()
        {
            List<int> originalList = new List<int>(new[] { 1, 2, 3, 4, 5, 6});
            List<int> listWith5Items = originalList.First(5);

            Assert.AreEqual(new List<int>(new[] { 1, 2, 3, 4, 5 }), listWith5Items);
            Assert.AreNotSame(originalList, listWith5Items);            
        }

        [Test]
        public void FirstShouldReturnSameNumberOfItemsIfEqualToMax()
        {
            List<int> originalList = new List<int>(new[] { 1, 2, 3, 4, 5 });
            List<int> listWith5Items = originalList.First(5);

            Assert.AreEqual(new List<int>(new[] { 1, 2, 3, 4, 5 }), listWith5Items);
            Assert.AreNotSame(originalList, listWith5Items);            
        }
        
        [Test]
        public void ShouldConcatenateIntoAStringUsingAGivenDelimiter()
        {
            List<string> stringList = new List<string> {"Kerry", "Oolong", "Dustin"};

            Assert.AreEqual("Kerry, Oolong, Dustin", stringList.BuildCommaSeparatedList());
        }
        
        [Test]
        public void ShouldReturnANonDelimitedStringContainingTheSingleItemIfGivenAListWithASingleItemToConcatenate()
        {
            List<string> stringList = new List<string> {"Oolong"};

            Assert.AreEqual("Oolong", stringList.BuildCommaSeparatedList());
        }
        
        [Test]
        public void ShouldReturnAnEmptyStringIfGivenAnEmptyListToConcatenate()
        {
            List<string> emptyList = new List<string>();
            Assert.AreEqual("", emptyList.BuildCommaSeparatedList());
        }

        [Test]
        public void RenderAListOfFunctionalLocations()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation>
                                                                         {
                                                                             FunctionalLocationFixture.CreateNew("OI1-1003"),
                                                                             FunctionalLocationFixture.CreateNew("OI1-1003"),
                                                                             FunctionalLocationFixture.CreateNew("OI1-1003")
                                                                         };
            Assert.AreEqual("OI1-1003, OI1-1003, OI1-1003", functionalLocations.AsString(floc => floc.FullHierarchy));
        }

        [Test]
        public void AnEmptyListOfFunctionalLocationsShouldRenderAsAnEmptyString()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation>();
            Assert.AreEqual("", functionalLocations.AsString(floc => floc.FullHierarchy));
        }

        [Test]
        public void RenderAListOfTargetDefinitionDTOs()
        {
            List<TargetDefinitionDTO> targetDefinitionDTOs = TargetDefinitionDTOFixture.CreateTargetDefinitionDTOList();
            Assert.AreEqual(targetDefinitionDTOs[0].Name + ", " + targetDefinitionDTOs[1].Name + ", " + targetDefinitionDTOs[2].Name, targetDefinitionDTOs.AsString(tdDto => tdDto.Name));
        }

        [Test]
        public void AnEmptyListOfTargetDefinitionDTOsShouldRenderAsAnEmptyString()
        {
            List<TargetDefinitionDTO> targetDefinitionDTOs = new List<TargetDefinitionDTO>();
            Assert.AreEqual("", targetDefinitionDTOs.AsString(tdDto => tdDto.Name));
        }

        [Test]
        public void RenderAListOfDocumentLinks()
        {
            List<DocumentLink> documentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            Assert.AreEqual("Title for document (http:\\URL for Document), Another Title for document (http:\\Another URL for Document)", documentLinks.AsString(link => link.TitleWithUrl));
        }

        [Test]
        public void AnEmptyListOfDocumentsShouldRenderAsAnEmptyString()
        {
            List<DocumentLink> documentLinks = new List<DocumentLink>();
            Assert.AreEqual("", documentLinks.AsString(link => link.TitleWithUrl));
        }

        [Test]
        public void ShouldRenderAListOfGasTestElementDetails()
        {
            GasTestElement gasTest1 = GasTestElementFixture.CreateGasTestElementWithImmediateConfinedAndSystemEntryData();
            GasTestElement gasTest2 = GasTestElementFixture.CreateGasTestElementWithImmediateConfinedAndSystemEntryData();

            var gasTests = new WorkPermitGasTests();
            gasTests.Elements.Add(gasTest1);
            gasTests.Elements.Add(gasTest2);

            List<GasTestElement> gasTestElements = gasTests.Elements;
            Assert.AreEqual(
                string.Format(
                "Immediate/Work Area Required: True, First Immediate/WorkArea Result: {0}, CS Required: True, First CS Result: {1}, SE N/A: False, First SE Result: {2}, " +
                "Immediate/Work Area Required: True, First Immediate/WorkArea Result: {3}, CS Required: True, First CS Result: {4}, SE N/A: False, First SE Result: {5}",
                    gasTest1.ImmediateAreaTestResult,
                    gasTest1.ConfinedSpaceTestResult,
                    gasTest1.SystemEntryTestResult,
                    gasTest2.ImmediateAreaTestResult,
                    gasTest2.ConfinedSpaceTestResult,
                    gasTest2.SystemEntryTestResult),
                gasTestElements.AsString(gasTestElement => gasTestElement.ToHistoryString()));
        }

    }
}
