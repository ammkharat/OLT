using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class EdmontonPersonDao : AbstractManagedDao, IEdmontonPersonDao
    {
        public List<EdmontonPerson> QueryAll()
        {
            return ManagedCommand.QueryForListResult(PopulateInstance, "QueryAllEdmontonPersons");
        }

        private EdmontonPerson PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string firstName = reader.Get<string>("FirstName");
            string lastName = reader.Get<string>("LastName");
            string badgeId = reader.Get<string>("BadgeId");
            DateTime lastScan = reader.Get<DateTime>("LastScan");
            byte scanStatus = reader.Get<byte>("ScanStatus");
            return new EdmontonPerson(id, firstName, lastName, badgeId, lastScan, scanStatus.ToEnum<BadgeScanStatus>());
        }

        public List<EdmontonPerson> QueryAllDeleted()
        {
            return ManagedCommand.QueryForListResult(PopulateInstance, "QueryAllDeletedEdmontonPersons");
        }

        public void Insert(EdmontonPerson person)
        {
            ManagedCommand.InsertAndSetId(person, AddInsertParameters, "InsertEdmontonPerson");
        }

        private void AddInsertParameters(EdmontonPerson person, SqlCommand command)
        {
            command.AddParameter("FirstName", person.FirstName);
            command.AddParameter("LastName", person.LastName);
            AddCommonParameters(person, command);
        }

        private void AddCommonParameters(EdmontonPerson person, SqlCommand command)
        {
            command.AddParameter("BadgeId", person.BadgeId);
            command.AddParameter("LastScan", person.LastScan);
            command.AddParameter("ScanStatus", person.ScanStatus);
        }

        public void UndoRemove(EdmontonPerson person)
        {
            ManagedCommand.Update(person, AddundoRemoveParameters, "UndoRemoveEdmontonPerson");
        }

        private void AddundoRemoveParameters(EdmontonPerson person, SqlCommand command)
        {
            command.AddParameter("Id", person.Id);
        }

        private void AddUpdateParameters(EdmontonPerson person, SqlCommand command)
        {
            command.AddParameter("Id", person.Id);
            AddCommonParameters(person, command);
        }

        public void Update(EdmontonPerson person)
        {
            ManagedCommand.Update(person, AddUpdateParameters, "UpdateEdmontonPerson");
        }

        public void Remove(EdmontonPerson person)
        {
            ManagedCommand.Remove(person.IdValue, "RemoveEdmontonPerson");
        }
    }
}