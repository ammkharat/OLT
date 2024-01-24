using System;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Reports.Adapters
{
    [Serializable]
    public class OnPremisePersonnelShiftReportDetailsAdapter : IReportAdapter
    {
        private readonly string _shiftLabel;

        private readonly OnPremisePersonnelShiftReportDetailDTO _shiftReportDetailDTO;

        public OnPremisePersonnelShiftReportDetailsAdapter(DateTime shiftStart, string shiftLabel,
            OnPremisePersonnelShiftReportDetailDTO shiftReportDetailDTO)
        {
            ShiftStart = shiftStart;
            _shiftLabel = shiftLabel;
            _shiftReportDetailDTO = shiftReportDetailDTO;
        }

        public DateTime ShiftStart { get; private set; }

        public string Trade
        {
            get { return _shiftReportDetailDTO.Trade; }
        }

        public string PersonnelName
        {
            get { return _shiftReportDetailDTO.PersonnelName; }
        }

        public string PrimaryLocation
        {
            get { return _shiftReportDetailDTO.PrimaryLocation; }
        }

        public string PhoneNumber
        {
            get { return _shiftReportDetailDTO.PhoneNumber; }
        }

        public string Radio
        {
            get { return _shiftReportDetailDTO.Radio; }
        }

        public string Company
        {
            get { return _shiftReportDetailDTO.Company; }
        }

        public string Description
        {
            get { return _shiftReportDetailDTO.Description; }
        }

        public string ShiftLabel
        {
            get { return _shiftLabel; }
        }
    }
}