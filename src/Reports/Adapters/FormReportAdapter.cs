using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public abstract class FormReportAdapter : BaseEdmontonFormReportAdapter
    {
        protected FormReportAdapter(BaseEdmontonForm baseForm) : base(baseForm)
        {
        }

        public abstract string CommentsAsRtf { get; }

        public virtual string ReturnedBackToService
        {
            get { return string.Empty; }
        }

        public virtual bool IsOperationsRequested
        {
            get { return false; }
        }

        public virtual bool IsMaintenanceRequested
        {
            get { return false; }
        }
    }
}