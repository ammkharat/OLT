using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogCustomFieldEntryDao : AbstractCustomFieldEntryDao, ILogCustomFieldEntryDao
    {
        protected override string InsertStoredProcedureName
        {
            get { return "InsertLogCustomFieldEntry"; }
        }

        protected override string QueryByParentIdStoredProcedureName
        {
            get { return "QueryLogCustomFieldEntryByLogId"; }
        }

        protected override string UpdateStoredProcedureName
        {
            get { return "UpdateLogCustomFieldEntry"; }
        }

        protected override string DeleteThoseNoLongerAssociatedToEntityStoredProcedureName
        {
            get { return "DeleteLogCustomFieldEntries"; }
        }

        protected override string QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName
        {
            get { return "QueryLogCustomFieldEntries"; }
        }

        protected override string ParentEntityIdParameter
        {
            get { return "@LogId"; }
        }

        public List<CustomFieldEntry> QueryByLogId(long logId)
        {
            return QueryByParentEntityId(logId);
        }
    }
}