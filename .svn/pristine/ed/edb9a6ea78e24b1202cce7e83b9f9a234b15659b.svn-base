using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain
{
    public class ExcursionResponseDisplayAdapter : IDataErrorInfo
    {
        private readonly List<string> errors = new List<string>();
        private readonly OpmExcursion opmExcursion;

        public ExcursionResponseDisplayAdapter(OpmExcursion opmExcursion)
        {
            this.opmExcursion = opmExcursion;
        }

        public long OpmExcursionId
        {
            get { return opmExcursion.IdValue; }
        }

        public DateTime StartTime
        {
            get { return opmExcursion.StartDateTime; }
        }

        public ToeType Type
        {
            get { return opmExcursion.ToeType; }
        }

        public ExcursionStatus Status
        {
            get { return opmExcursion.Status; }
        }

        public decimal Limit
        {
            get { return opmExcursion.ToeLimitValue; }
        }

        public decimal Peak
        {
            get { return opmExcursion.Peak; }
        }

        public decimal Average
        {
            get { return opmExcursion.Average; }
        }

        public decimal Duration
        {
            get { return opmExcursion.Duration; }
        }

        public decimal IlpNumber
        {
            get { return opmExcursion.Duration; }
        }

        public string CauseActionRoadblock
        {
            get { return opmExcursion.OpmExcursionResponse.Response; }
            set { opmExcursion.OpmExcursionResponse.Response = value; }
        }
//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM

        public string Asset
        {
            get { return opmExcursion.OpmExcursionResponse.Asset; }
            set { opmExcursion.OpmExcursionResponse.Asset = value; }
        }
        public string Code
        {
            get { return opmExcursion.OpmExcursionResponse.Code; }
            set { opmExcursion.OpmExcursionResponse.Code = value; }
        }

       

        public string this[string columnName]
        {
            get { return null; } // we do not have cell-level validation turned on, so this should never be called
        }


        [Browsable(false)] // setting browsable to false ensures that an Error column doesn't appear in the grid
        public string Error
        {
            get { return errors.Join(Environment.NewLine); }
        }

        public OpmExcursion GetOpmExcursion()
        {
            return opmExcursion;
        }

        public void ClearErrors()
        {
            errors.Clear();
        }

        public void AddError(string error)
        {
            errors.AddIfNotExist(error);
        }
    }
}