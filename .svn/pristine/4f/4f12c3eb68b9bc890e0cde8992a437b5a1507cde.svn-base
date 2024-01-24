using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN75AFormPrintActions : EdmontonFormPrintActions<FormGN75A, FormGN75AReport, FormGN75AReportAdapter>
    {
        private readonly bool printedFromWorkPermit;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        public EdmontonGN75AFormPrintActions(bool printedFromWorkPermit, IWorkPermitEdmontonService workPermitEdmontonService)
        {
            this.printedFromWorkPermit = printedFromWorkPermit;
            this.workPermitEdmontonService = workPermitEdmontonService;
        }

        protected override void AddPageSpecificWatermarks(FormGN75AReport report, IEnumerable<FormGN75AReportAdapter> adapters)
        {
            if (printedFromWorkPermit)
            {
                AddPageSpecificWatermarksBasedOnDeletedAndStatus(report, adapters);
            }
            else
            {
                base.AddPageSpecificWatermarks(report, adapters);
            }
        }

        protected override FormGN75AReport CreateSpecificReport()
        {
            return new FormGN75AReport();
        }

        protected override List<FormGN75AReportAdapter> CreateReportAdapter(FormGN75A domainObject)
        {
            List<WorkPermitEdmontonDTO> permitDtos = workPermitEdmontonService.QueryDtosByFormGN75AId(domainObject.IdValue);
            string permitNumbers = permitDtos.AsString(dto => Convert.ToString(dto.PermitNumber));           

            FormGN75AReportAdapter formReportAdapter = new FormGN75AReportAdapter(domainObject, permitNumbers);            
            return new List<FormGN75AReportAdapter> { formReportAdapter };
        }
    }
}