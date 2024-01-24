using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    internal class RestrictionLocationWorkAssignmentDao : AbstractManagedDao, IRestrictionLocationWorkAssignmentDao
    {
        public void Insert(long restrictionLocationId, WorkAssignment workAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionLocationId", restrictionLocationId);
            command.AddParameter("@WorkAssignmentId", workAssignment.Id);

            command.Insert("InsertRestrictionLocationWorkAssignment");
        }
    }
}