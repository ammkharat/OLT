﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    public class LogReportDTOContainer 
    {
        private readonly List<CustomField> customFields;
        private readonly LogReportDTO dto;
        
        public LogReportDTOContainer(LogReportDTO dto, List<CustomField> customFields)
        {
            this.dto = dto;
            this.customFields = customFields;
        }

        public LogReportDTO Dto
        {
            get { return dto; }
        }

        public List<CustomField> CustomFields
        {
            get { return customFields; }
        }

        public void AddCustomField(CustomField customField)
        {
            if (customField != null && !HasCustomFieldAlready(customField))
            {
                CustomFields.Add(customField);
            }
        }

        private bool HasCustomFieldAlready(CustomField customField)
        {
            return CustomFields.Exists(e => e.Id == customField.Id);
        }
    }
}