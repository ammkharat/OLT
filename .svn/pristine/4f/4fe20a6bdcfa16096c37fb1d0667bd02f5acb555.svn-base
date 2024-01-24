using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class AdministratorListDao : AbstractManagedDao, IAdministratorListDao
    {
        public List<AdministratorList> QueryAdminMember()
        {
            var command = ManagedCommand;
            return command.QueryForListResult(PopulateDocumentRoots, "QueryAdminMemberList");
        }

        public void InsertAdminMember(AdministratorList editObject)
        {
            var command = ManagedCommand;
            command.AddParameter("SiteName", editObject.SiteName);
            command.AddParameter("Group", editObject.Group);
            command.AddParameter("SiteAdmin", editObject.SiteAdmin);
            command.AddParameter("SiteRepresentative", editObject.SiteRepresentative);
            command.AddParameter("BEA", editObject.BEA);
            command.Insert("InsertAdminMember");
            //var id = command.InsertAndReturnId("InsertAdminMember");
            //editObject.Id = id;
        }

        public void UpdateAdminMember(AdministratorList editObject)
        {
            var command = ManagedCommand;
            command.AddParameter("Id", editObject.IdValue);
            command.AddParameter("SiteName", editObject.SiteName);
            command.AddParameter("Group", editObject.Group);
            command.AddParameter("SiteAdmin", editObject.SiteAdmin);
            command.AddParameter("SiteRepresentative", editObject.SiteRepresentative);
            command.AddParameter("BEA", editObject.BEA);
            command.Update("UpdateAdminMember");
        }

        public void RemoveAdminMember(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("Id", id);
            command.ExecuteNonQuery("RemoveAdminMember");
        }
        
        private AdministratorList PopulateDocumentRoots(SqlDataReader reader)
        {
            var id = reader.Get<long?>("Id");
            var siteName = reader.Get<String>("SiteName");
            var group = reader.Get<String>("Group");
            var siteAdmin = reader.Get<String>("SiteAdmin");
            var siteRepresentative = reader.Get<String>("SiteRepresentative");
            var bea = reader.Get<String>("BEA");
            return new AdministratorList(siteName, group, siteRepresentative, siteAdmin, bea) { Id = id };
        }
    }
}