using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TagGroupDao : AbstractManagedDao, ITagGroupDao
    {
        private const string INSERT_STORE_PROCECURE = "InsertTagInfoGroup";
        private const string QUERY_BY_ID = "QueryTagInfoGroupById";
        private const string QUERY_BY_SITE = "QueryTagInfoGroupBySite";
        private const string NAME_COUNT_PROCEDURE = "CountTagGroupNameBySite";
        private const string REMOVE_TAGGROUP_AND_TAGINFO_ASSOCIATION = "RemoveTagGroupAndTagAssociation";
        private const string INSERT_TAGGROUP_AND_TAGINFO_ASSOCIATION = "InsertTagGroupAndTagAssociation";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTagInfoGroup";
        private const string REMOVE_STORED_PROCEDURE = "RemoveTagInfoGroup";

        private readonly ISiteDao siteDao;
        private readonly ITagDao tagDao;

        public TagGroupDao()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
        }

        public TagInfoGroup Insert(TagInfoGroup newTagInfoGroup)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(newTagInfoGroup, AddInsertParameter, INSERT_STORE_PROCECURE);
            newTagInfoGroup.Id = (long?)idParameter.Value;

            InsertTagGroupAndTagAssociation(command, newTagInfoGroup);

            return newTagInfoGroup;
        }

        private static void InsertTagGroupAndTagAssociation(SqlCommand command, TagInfoGroup tagInfoGroup)
        {
            long tagInfoGroupId = tagInfoGroup.Id.Value;

            foreach (TagInfo tagInfo in tagInfoGroup.TagInfoList)
            {
                InsertIndividualTagGroupAndTagAssociation(command, tagInfoGroupId, tagInfo.Id.Value);
            }
        }

        public TagInfoGroup QueryById(long id)
        {
            return ManagedCommand.QueryById<TagInfoGroup>(id, PopulateInstance, QUERY_BY_ID);
        }

        public List<TagInfoGroup> QueryTagInfoGroupListBySite(Site site)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  site.IdValue);
            return command.QueryForListResult<TagInfoGroup>(PopulateInstance, QUERY_BY_SITE);
        }

        public void Remove(TagInfoGroup tagInfoGroup)
        {
            SqlCommand command = ManagedCommand;
            foreach(TagInfo tagInfo in tagInfoGroup.TagInfoList)
            {
                RemoveTagGroupAndTagAssociation(command, tagInfoGroup.Id.Value, tagInfo.Id.Value);
            }

            command.Parameters.Clear();
            if (tagInfoGroup.IsInDatabase())
            {
                ManagedCommand.Remove(tagInfoGroup.IdValue, REMOVE_STORED_PROCEDURE);
            }
        }

        public bool IsNameUniqueToSite(string name, Site site)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Name", name);
            command.AddParameter("@SiteId",  site.Id.Value);
            int nameCount = command.GetCount(NAME_COUNT_PROCEDURE);

            return nameCount <= 0;
        }

        public void Update(TagInfoGroup tagInfoGroupToBeUpdated)
        {
            SqlCommand command = ManagedCommand;
            command.Update(tagInfoGroupToBeUpdated, AddUpdateParameter, UPDATE_STORED_PROCEDURE);
            UpdateTagGroupAndTagAssociation(command, tagInfoGroupToBeUpdated);
        }

        private void UpdateTagGroupAndTagAssociation(SqlCommand command, TagInfoGroup tagInfoGroup)
        {
            TagInfoGroup tagInfoInDB = QueryById(tagInfoGroup.Id.Value);
            
            List<long> oldTagInfoIdList = tagInfoInDB.TagInfoList.AsIdList();


            foreach (TagInfo tagInfo in tagInfoGroup.TagInfoList)
            {
                if (!oldTagInfoIdList.Remove(tagInfo.Id.Value))
                {
                    InsertIndividualTagGroupAndTagAssociation(command, tagInfoGroup.Id.Value, tagInfo.Id.Value);
                }
            }

            foreach (long oldTagInfoId in oldTagInfoIdList)
            {
                RemoveTagGroupAndTagAssociation(command, tagInfoGroup.Id.Value, oldTagInfoId);
            }
        }

        private static void InsertIndividualTagGroupAndTagAssociation(SqlCommand command, long tagInfoGroupId, long tagInfoId)
        {
            command.Parameters.Clear();
            command.AddParameter("@TagGroupId",  tagInfoGroupId);
            command.AddParameter("@TagId",  tagInfoId);
            command.ExecuteNonQuery(INSERT_TAGGROUP_AND_TAGINFO_ASSOCIATION);
        }

        private static void RemoveTagGroupAndTagAssociation(SqlCommand command, long tagInfoGroupId, long tagInfoId)
        {
            command.Parameters.Clear();
            command.AddParameter("@TagGroupId",  tagInfoGroupId);
            command.AddParameter("@TagId",  tagInfoId);
            command.ExecuteNonQuery(REMOVE_TAGGROUP_AND_TAGINFO_ASSOCIATION);
        }

        private TagInfoGroup PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string name = reader.Get<string>("Name");
            long siteId = reader.Get<long>("SiteId");
            Site site = siteDao.QueryById(siteId);

            List<TagInfo> tagInfoList = tagDao.QueryByTagGroupId(id.Value);
            
            var ret = new TagInfoGroup(id, name, site) {TagInfoList = tagInfoList};
            return ret;
        }

        private static void AddInsertParameter(TagInfoGroup tagInfoGroup, SqlCommand command)
        {
            SetCommonAttributes(command, tagInfoGroup);
        }

        private static void AddUpdateParameter(TagInfoGroup tagInfoGroup, SqlCommand command)
        {
            command.Parameters.Clear();
            command.AddParameter("@Id",  tagInfoGroup.Id.Value);
            SetCommonAttributes(command, tagInfoGroup);
        }

        private static void SetCommonAttributes(SqlCommand command, TagInfoGroup tagInfoGroup)
        {
            command.AddParameter("Name", tagInfoGroup.Name);
            command.AddParameter("SiteId",  tagInfoGroup.Site.Id.Value);
        }
    }
}
