using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDefinitionCustomFieldEntryDao : AbstractCustomFieldEntryDao, ILogDefinitionCustomFieldEntryDao
    {
        protected override string InsertStoredProcedureName
        {
            get { return "InsertLogDefinitionCustomFieldEntry"; }
        }

        protected override string QueryByParentIdStoredProcedureName
        {
            get { return "QueryLogDefinitionCustomFieldEntryByLogDefinitionId"; }
        }

        protected override string UpdateStoredProcedureName
        {
            get { return "UpdateLogDefinitionCustomFieldEntry"; }
        }

        protected override string DeleteThoseNoLongerAssociatedToEntityStoredProcedureName
        {
            get { return "DeleteLogDefinitionCustomFieldEntries"; }
        }

        protected override string QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName
        {
            get { return "QueryLogDefinitionCustomFieldEntries"; }
        }

        protected override string ParentEntityIdParameter
        {
            get { return "@LogDefinitionId"; }
        }

        public List<CustomFieldEntry> QueryByLogDefinitionId(long logId)
        {
            return QueryByParentEntityId(logId);
        }
    }
}
