using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SummaryLogCustomFieldEntryDao : AbstractCustomFieldEntryDao, ISummaryLogCustomFieldEntryDao
    {
        protected override string InsertStoredProcedureName
        {
            get { return "InsertSummaryLogCustomFieldEntry"; }
        }

        protected override string QueryByParentIdStoredProcedureName
        {
            get { return "QuerySummaryLogCustomFieldEntryBySummaryLogId"; }
        }

        protected override string UpdateStoredProcedureName
        {
            get { return "UpdateSummaryLogCustomFieldEntry"; }
        }

        protected override string DeleteThoseNoLongerAssociatedToEntityStoredProcedureName
        {
            get { return "DeleteSummaryLogCustomFieldEntries"; }
        }

        protected override string QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName
        {
            get { return "QuerySummaryLogCustomFieldEntries"; }
        }

        protected override string ParentEntityIdParameter
        {
            get { return "@SummaryLogId"; }
        }

        public List<CustomFieldEntry> QueryBySummaryLogId(long summaryLogId)
        {
            return QueryByParentEntityId(summaryLogId);
        }
    }
}
