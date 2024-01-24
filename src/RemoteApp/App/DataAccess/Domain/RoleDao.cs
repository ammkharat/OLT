using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RoleDao : AbstractManagedDao, IRoleDao
    {
        private const string QUERY_ALL_WITH_AT_LEAST_ONE_ROLE_ELEMENT = "QueryRoleBySiteAndAtLeastOneRoleElement";
        private const string QUERY_BY_ACTIVE_DIRECTORY_KEY = "QueryRoleByActiveDirectoryKey";
        private const string QUERY_ROLE_BY_SITE_ID = "QueryRoleBySiteId";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryRoleById";
        private const string UPDATE_WORK_ASSIGNMENT_NOT_SELECTED_WARNING = "UpdateRoleWorkAssignmentNotSelectedWarning";

        //RITM-RITM0164850   Mukesh
        private const string INSERT_ROLE = "InsertRole";
        private const string UPDATE_ROLE = "UpdateRole";
        private const string REMOVE_ROLE = "RemoveRole";


        public Role QueryById(long id)
        {
            return ManagedCommand.QueryById<Role>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<Role> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);

            return command.QueryForListResult<Role>(PopulateInstance, QUERY_ROLE_BY_SITE_ID);                                   
        }

        public Role QueryByActiveDirectoryKey(Site site, string roleKey)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  site.IdValue);
            command.AddParameter("@ActiveDirectoryKey", roleKey);

            return command.QueryForSingleResult<Role>(PopulateInstance, QUERY_BY_ACTIVE_DIRECTORY_KEY);
        }

        public List<Role> QueryAllAvailableInSiteWithAnyRoleElement(long siteId, List<RoleElement> roleElements)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@CsvRoleElementIds", roleElements.BuildIdStringFromList());
            managedCommand.AddParameter("@SiteId",  siteId);

            return managedCommand.QueryForListResult<Role>(PopulateInstance, QUERY_ALL_WITH_AT_LEAST_ONE_ROLE_ELEMENT);
        }

        public Role QueryDefaultReadOnlyRole(Site site)
        {
            List<Role> roles = QueryBySiteId(site.IdValue);
            Role readOnlyRole = roles.Find(obj => obj.IsDefaultReadOnlyRoleForSite);
            return readOnlyRole;
        }

        private static Role PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");

            string activeDirectoryKey = reader.Get<string>("ActiveDirectoryKey");

            bool isAdministratorRole = reader.Get<bool>("IsAdministratorRole");
            bool isReadOnlyRole = reader.Get<bool>("IsReadOnlyRole");
            bool isDefaultReadOnlyRoleForSite = reader.Get<bool>("IsDefaultReadOnlyRoleForSite");
            bool isWorkPermitNonOperationsRole = reader.Get<bool>("IsWorkPermitNonOperationsRole");

            bool warnIfWorkAssignmentNotSelected = reader.Get<bool>("WarnIfWorkAssignmentNotSelected");
            string alias = reader.Get<string>("Alias");
            long siteId = reader.Get<long>("SiteId");

            Role role = new Role(
                id, name, activeDirectoryKey,
                isAdministratorRole, isReadOnlyRole, isDefaultReadOnlyRoleForSite, isWorkPermitNonOperationsRole,
                warnIfWorkAssignmentNotSelected,
                alias, siteId);
            return role;
        }

        public void UpdateWorkAssignmentNotSelectedWarning(Role role)
        {
            SqlCommand command = ManagedCommand;
            command.Update(role, AddUpdateParameters, UPDATE_WORK_ASSIGNMENT_NOT_SELECTED_WARNING);
        }

        private static void AddUpdateParameters(Role role, SqlCommand command)
        {
            command.AddParameter("@Id", role.Id);
            command.AddParameter("@WarnIfWorkAssignmentNotSelected", role.WarnIfWorkAssignmentNotSelected);
        }


        //RITM-RITM0164850   Mukesh
      public  void InsertRole(Role role)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(role, AddInsertParameters, INSERT_ROLE);       

        }

        public  void UpdateRole(Role role)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(role, AddInsertParameters, UPDATE_ROLE);
        }
      public  void Removerole(Role role)
        {
            ManagedCommand.ExecuteNonQuery(role, REMOVE_ROLE, AddRemoveParameters);            
        }

      private static void AddCommonParameters(SqlCommand command, Role role)
      {

          command.AddParameter("@Name", role.Name);
          command.AddParameter("@ActiveDirectoryKey", role.ActiveDirectoryKey);
          command.AddParameter("@IsAdministratorRole", role.IsAdministratorRole);
          command.AddParameter("@IsReadOnlyRole", role.IsReadOnlyRole);
          command.AddParameter("@IsWorkPermitNonOperationsRole", role.IsWorkPermitNonOperationsRole);
          command.AddParameter("@SiteId", role.SiteId);
          command.AddParameter("@WarnIfWorkAssignmentNotSelected", role.WarnIfWorkAssignmentNotSelected);
          command.AddParameter("@IsDefaultReadOnlyRoleForSite", role.IsDefaultReadOnlyRoleForSite);
          command.AddParameter("@Alias", role.Alias);
          command.AddParameter("@Id", role.Id);
      }

      private static void AddRemoveParameters(Role role, SqlCommand command)
      {
          command.AddParameter("@Id", role.Id);
      }

      public void Remove(Role role)
      {
          ManagedCommand.ExecuteNonQuery(role, REMOVE_ROLE, AddRemoveParameters);
      }

      
      private static void AddInsertParameters(Role contractor, SqlCommand command)
      {
          AddCommonParameters(command, contractor);
      }


        //END RITM-RITM0164850   Mukesh





    }

    }
