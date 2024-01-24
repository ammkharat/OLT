using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Reports.Adapters;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    [TestFixture]
    public class GenericMultiLogReportAdapterBuilderTest 
    {
        [Test]
        public void ShouldLinkFunctionalLocations()
        {
            DetailedLogReportDTO dto1 = CreateDto(1, new List<string> {"FLOCA 1", "FLOCB 1", "FLOCC 1"});
            DetailedLogReportDTO dto2 = CreateDto(2, new List<string> { "FLOCA 2", "FLOCB 2", "FLOCC 2" });

            GenericMultiLogReportAdapterBuilder builder = new GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy.Assignment);

            List<GenericMultiLogReportAdapter> adapters = new List<GenericMultiLogReportAdapter>();
            adapters.AddRange(builder.BuildAdapter(dto1));
            adapters.AddRange(builder.BuildAdapter(dto2));

            Assert.AreEqual(2, adapters.Count);
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "1"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2"));
            
            List<FunctionalLocationReportAdapter> flocAdapters = new List<FunctionalLocationReportAdapter>();
            adapters.ForEach(a => flocAdapters.AddRange(a.FlocReportAdapters));
            Assert.AreEqual(6, flocAdapters.Count);

            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "1" && obj.FunctionalLocation == "FLOCA 1"));
            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "1" && obj.FunctionalLocation == "FLOCB 1"));
            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "1" && obj.FunctionalLocation == "FLOCC 1"));
            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "2" && obj.FunctionalLocation == "FLOCA 2"));
            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "2" && obj.FunctionalLocation == "FLOCB 2"));
            Assert.IsTrue(flocAdapters.Exists(obj => obj.ParentId == "2" && obj.FunctionalLocation == "FLOCC 2"));
        }

        private static DetailedLogReportDTO CreateDto(int id, List<string> functionalLocationNames)
        {
            return new DetailedLogReportDTO(
                id, id, "Shift" + id, new DateTime(2011, 3, id), new DateTime(2011, 3, id),
                "Last Modified User" + id,
                new DateTime(2011, 4, id), "Work Assignment" + id,
                false,
                false, false, false, false, false, false,
                functionalLocationNames,
                new List<FunctionalLocationSegmentDTO>(),                
                new List<DocumentLinkDTO>(), null,
                "comment",
                "comment", null);   
        }

        [Test]
        public void ShouldLinkDocumentLinks()
        {
            DetailedLogReportDTO dto1 = CreateDto(1, new List<DocumentLinkDTO>{
                new DocumentLinkDTO("UrlA 1", "TitleA 1"),
                new DocumentLinkDTO("UrlB 1", "TitleB 1")});
            DetailedLogReportDTO dto2 = CreateDto(2, new List<DocumentLinkDTO>{
                new DocumentLinkDTO("UrlA 2", "TitleA 2"),
                new DocumentLinkDTO("UrlB 2", "TitleB 2"),
                new DocumentLinkDTO("UrlC 2", "TitleC 2")});

            GenericMultiLogReportAdapterBuilder builder = new GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy.Assignment);

            List<GenericMultiLogReportAdapter> adapters = new List<GenericMultiLogReportAdapter>();
            adapters.AddRange(builder.BuildAdapter(dto1));
            adapters.AddRange(builder.BuildAdapter(dto2));

            Assert.AreEqual(2, adapters.Count);
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "1"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2"));

            List<DocumentLinkReportAdapter> documentLinkReportAdapters = new List<DocumentLinkReportAdapter>();
            adapters.ForEach(a => documentLinkReportAdapters.AddRange(a.DocumentLinkReportAdapters));

            Assert.AreEqual(5, documentLinkReportAdapters.Count);
            Assert.IsTrue(documentLinkReportAdapters.Exists(obj => obj.ParentId == "1" && obj.Url == "UrlA 1"));
            Assert.IsTrue(documentLinkReportAdapters.Exists(obj => obj.ParentId == "1" && obj.Url == "UrlB 1"));
            Assert.IsTrue(documentLinkReportAdapters.Exists(obj => obj.ParentId == "2" && obj.Url == "UrlA 2"));
            Assert.IsTrue(documentLinkReportAdapters.Exists(obj => obj.ParentId == "2" && obj.Url == "UrlB 2"));
            Assert.IsTrue(documentLinkReportAdapters.Exists(obj => obj.ParentId == "2" && obj.Url == "UrlC 2"));
        }

        private static DetailedLogReportDTO CreateDto(int id, List<DocumentLinkDTO> documentLinkDtos)
        {
            return new DetailedLogReportDTO(
                id, id, "Shift" + id, new DateTime(2011, 3, id), new DateTime(2011, 3, id),
                "Last Modified User" + id,
                new DateTime(2011, 4, id), "Work Assignment" + id,
                false,
                false, false, false, false, false, false,
                new List<string>(),
                new List<FunctionalLocationSegmentDTO>(),                
                documentLinkDtos,
                null,
                "comment",
                "comment", null);
        }

        [Test]
        public void ShouldSetDataForGroupByAssignment()
        {
            DetailedLogReportDTO dto1 = CreateDto(1, "Work Assignment A");
            DetailedLogReportDTO dto2 = CreateDto(2, "Work Assignment B");
            DetailedLogReportDTO dto3 = CreateDto(3, "Work Assignment A");

            GenericMultiLogReportAdapterBuilder builder = new GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy.Assignment);

            List<GenericMultiLogReportAdapter> adapters = new List<GenericMultiLogReportAdapter>();
            adapters.AddRange(builder.BuildAdapter(dto1));
            adapters.AddRange(builder.BuildAdapter(dto2));
            adapters.AddRange(builder.BuildAdapter(dto3));

            Assert.AreEqual(3, adapters.Count);
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "1" && obj.WorkAssignment == "Work Assignment A" && obj.GroupByValue == "Work Assignment A"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.WorkAssignment == "Work Assignment B" && obj.GroupByValue == "Work Assignment B"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "3" && obj.WorkAssignment == "Work Assignment A" && obj.GroupByValue == "Work Assignment A"));
        }

        private static DetailedLogReportDTO CreateDto(int id, string workAssignment)
        {
            return new DetailedLogReportDTO(
                id, id, "Shift" + id, new DateTime(2011, 3, id), new DateTime(2011, 3, id),
                "Last Modified User" + id,
                new DateTime(2011, 4, id), workAssignment,
                false,
                false, false, false, false, false, false,
                new List<string>(),
                new List<FunctionalLocationSegmentDTO>(),               
                new List<DocumentLinkDTO>(),
                null,
                "comment", "comment", null);
        }

        [Test]
        public void ShouldSetDataForGroupBySection()
        {
            DetailedLogReportDTO dto1 = CreateDto(1, new List<FunctionalLocationSegmentDTO>{
                new FunctionalLocationSegmentDTO("A", "B", ""),});
            DetailedLogReportDTO dto2 = CreateDto(2, new List<FunctionalLocationSegmentDTO>{
                new FunctionalLocationSegmentDTO("A", "B", ""),
                new FunctionalLocationSegmentDTO("A", "C", ""),
                new FunctionalLocationSegmentDTO("A", "B", "")});

            GenericMultiLogReportAdapterBuilder builder = new GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy.Section);

            List<GenericMultiLogReportAdapter> adapters = new List<GenericMultiLogReportAdapter>();
            adapters.AddRange(builder.BuildAdapter(dto1));
            adapters.AddRange(builder.BuildAdapter(dto2));

            Assert.AreEqual(3, adapters.Count);

            Assert.IsTrue(adapters.Exists(obj => obj.Id == "1" && obj.GroupByValue == "A-B"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-B"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-C"));
        }

        private static DetailedLogReportDTO CreateDto(int id, List<FunctionalLocationSegmentDTO> segmentDtos)
        {
            return new DetailedLogReportDTO(
                id, id, "Shift" + id, new DateTime(2011, 3, id), new DateTime(2011, 3, id),
                "Last Modified User" + id,
                new DateTime(2011, 4, id), "Work Assignment" + id,
                false,
                false, false, false, false, false, false,
                new List<string>(),
                segmentDtos,                
                new List<DocumentLinkDTO>(),
                null,
                "comment",
                "comment", null);
        }

        [Test]
        public void ShouldSetDataForGroupByUnit()
        {
            DetailedLogReportDTO dto1 = CreateDto(1, new List<FunctionalLocationSegmentDTO>{
                new FunctionalLocationSegmentDTO("A", "B", "C"),});
            DetailedLogReportDTO dto2 = CreateDto(2, new List<FunctionalLocationSegmentDTO>{
                new FunctionalLocationSegmentDTO("A", "B", ""),
                new FunctionalLocationSegmentDTO("A", "B", "D"),
                new FunctionalLocationSegmentDTO("A", "B", "E"),
                new FunctionalLocationSegmentDTO("A", "B", "D"),
                new FunctionalLocationSegmentDTO("A", "F", null)});

            GenericMultiLogReportAdapterBuilder builder = new GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy.Unit);

            List<GenericMultiLogReportAdapter> adapters = new List<GenericMultiLogReportAdapter>();
            adapters.AddRange(builder.BuildAdapter(dto1));
            adapters.AddRange(builder.BuildAdapter(dto2));

            Assert.AreEqual(5, adapters.Count);
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "1" && obj.GroupByValue == "A-B-C"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-B"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-B-D"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-B-E"));
            Assert.IsTrue(adapters.Exists(obj => obj.Id == "2" && obj.GroupByValue == "A-F"));
        }
    }
}