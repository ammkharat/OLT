using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class GenericMultiLogReportAdapterBuilder
    {
        private readonly AssignmentSectionUnitReportGroupBy groupBy;

        public GenericMultiLogReportAdapterBuilder(AssignmentSectionUnitReportGroupBy groupBy)
        {
            this.groupBy = groupBy;
        }

        public List<GenericMultiLogReportAdapter> BuildAdapter(DetailedLogReportDTO dto)
        {
            var flocGroupByValues = new List<string>();
            if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.Section.IdValue)
            {
                foreach (var segmentDto in dto.FunctionalLocationSegmentDtos)
                {
                    flocGroupByValues.AddIfNotExist(segmentDto.SectionFullHierarchy);
                }
            }
            else if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.Unit.IdValue)
            {
                foreach (var segmentDto in dto.FunctionalLocationSegmentDtos)
                {
                    flocGroupByValues.AddIfNotExist(segmentDto.UnitFullHierarchyOrSectionFullHierachyIfOnlySectionExists);
                }
            }

            if (flocGroupByValues.Count == 0)
            {
                return new List<GenericMultiLogReportAdapter>
                {
                    new GenericMultiLogReportAdapter(dto, groupBy, string.Empty)
                };
            }
            var adapters = new List<GenericMultiLogReportAdapter>(flocGroupByValues.Count);
            foreach (var flocGroupByValue in flocGroupByValues)
            {
                adapters.Add(new GenericMultiLogReportAdapter(dto, groupBy, flocGroupByValue));
            }
            return adapters;
        }
    }
}