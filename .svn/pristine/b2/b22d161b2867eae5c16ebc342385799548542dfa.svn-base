using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class TargetAlertExcelReportDTO : TargetAlertDTO
    {
        public TargetAlertExcelReportDTO(TargetAlertDTO targetAlertDto, string targetDefinitionName,
            bool definitionIsActive, string alertTagName,
            TargetAlertStatus typeOfViolationStatus,
            decimal? maxAtEvaluation,
            decimal? minAtEvaluation,
            decimal? nteMaxAtEvaluation,
            decimal? nteMinAtEvaluation,
            decimal? actualValueAtEvaluation,
            List<TargetAlertResponseReportDetailDTO> targetAlertResponseReportDetailDtos) :
                base(
                targetAlertDto.Id, targetAlertDto.TargetName, targetAlertDto.FunctionalLocationName,
                targetAlertDto.CategoryName,
                targetAlertDto.Description, targetAlertDto.OriginalTargetValue, targetAlertDto.ActualValue,
                targetAlertDto.NeverToExceedMax,
                targetAlertDto.Max, targetAlertDto.Min, targetAlertDto.NeverToExceedMin, targetAlertDto.GapUnitValue,
                targetAlertDto.CreatedDateTime,
                targetAlertDto.Status, targetAlertDto.Priority, targetAlertDto.Losses,
                targetAlertDto.ResponseRequiredAsBool,
                targetAlertDto.AcknowledgedDateTime, targetAlertDto.LastModifiedUserId,
                targetAlertDto.LastViolatedDateTime, targetAlertDto.WorkAssignmentName)
        {
            TargetDefinitionName = targetDefinitionName;
            DefinitionIsActive = definitionIsActive;
            TagNameFromAlert = alertTagName;
            Responses = targetAlertResponseReportDetailDtos ?? new List<TargetAlertResponseReportDetailDTO>();

            TypeOfViolationStatus = typeOfViolationStatus;
            MaxAtEvaluation = maxAtEvaluation;
            MinAtEvaluation = minAtEvaluation;
            NTEMaxAtEvaluation = nteMaxAtEvaluation;
            NTEMinAtEvaluation = nteMinAtEvaluation;
            ActualValueAtEvaluation = actualValueAtEvaluation;
        }

        public string TargetDefinitionName { get; private set; }

        public bool DefinitionIsActive { get; private set; }

        public string TagNameFromAlert { get; private set; }

        public List<TargetAlertResponseReportDetailDTO> Responses { get; private set; }

        public TargetAlertStatus TypeOfViolationStatus { get; private set; }
        public decimal? MaxAtEvaluation { get; private set; }
        public decimal? MinAtEvaluation { get; private set; }
        public decimal? NTEMaxAtEvaluation { get; private set; }
        public decimal? NTEMinAtEvaluation { get; private set; }
        public decimal? ActualValueAtEvaluation { get; private set; }
    }
}