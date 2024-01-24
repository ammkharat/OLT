using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ActionItemCustomFieldEntryDao : AbstractCustomFieldEntryDao, IActionItemCustomFieldEntryDao
    {
        protected override string InsertStoredProcedureName
        {
            get { return "InsertActionItemCustomFieldEntry"; }
        }

        protected override string QueryByParentIdStoredProcedureName
        {
            get { return "QueryActionItemCustomFieldEntryByActionItemId"; }
        }

        protected override string UpdateStoredProcedureName
        {
            get { return "UpdateActionItemCustomFieldEntry"; }
        }

        protected override string DeleteThoseNoLongerAssociatedToEntityStoredProcedureName
        {
            get { return "DeleteActionItemCustomFieldEntries"; }
        }

        protected override string QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName
        {
            get { return "QueryActionItemCustomFieldEntries"; }
        }

        protected override string ParentEntityIdParameter
        {
            get { return "@ActionItemId"; }
        }

        public List<CustomFieldEntry> QueryByActionItemId(long actionitemId)
        {
            return QueryByParentEntityId(actionitemId);
        }
    }
}
