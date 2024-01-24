using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TagDao : AbstractManagedDao, ITagDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertTagInfo";
        private const string REMOVE_STORED_PROCEDURE = "RemoveTagInfo";
        private const string UPDATE_TAGINFO_FROM_PHD = "UpdateTagInfoFromPHD";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryTagById";
        private const string QUERY_BY_SITE_ID_AND_PREFIX_CHARACTER = "QueryTagInfoBySiteId";
        private const string QUERY_TAGS_BY_FILTER_STOREDPROC = "QueryTagsByFilter";
        private const string QUERY_BY_TAG_GROUP = "QueryTagInfoByTagGroupId";
        private const string QUERY_BY_SITE_ID_AND_PREFIX_CHARS = QUERY_BY_SITE_ID_AND_PREFIX_CHARACTER;

        public TagDao()
        {
            DaoRegistry.GetDao<ISiteDao>();
        }

        public void Insert(TagInfo tagInfo)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(tagInfo, AddInsertParameters, INSERT_STORED_PROCEDURE);
            tagInfo.Id = id;
        }

        public void Remove(TagInfo tagInfo)
        {
            if (tagInfo.IsInDatabase())
            {
                ManagedCommand.Remove(tagInfo.IdValue, REMOVE_STORED_PROCEDURE);
            }
        }

        /// <summary>
        /// Note: This also sets the DELETED flag to 0.
        /// </summary>
        public void Update(TagInfo tagInfo)
        {
            ManagedCommand.ExecuteNonQuery(tagInfo, UPDATE_TAGINFO_FROM_PHD, AddUpdateTagInfoFromPHDParameters);
        }

        public List<TagInfo> QueryTagInfoByFilter(Site site, SearchCriteria criteria)
        {
            string filterString = BuildQueryList(criteria);
            return QueryTagInfoByFilter(filterString, site.IdValue);
        }

        private List<TagInfo> QueryTagInfoByFilter(string filterString, long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@filter", filterString);
            command.AddParameter("@siteId", Convert.ToString(siteId));
            return command.QueryForListResult<TagInfo>(PopulateInstanceWithScadaProviderDescription, QUERY_TAGS_BY_FILTER_STOREDPROC);
        }

        public TagInfo QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<TagInfo> QueryBySiteIdAndPrefixCharacterIncludeDeleted(long siteId, string prefixCharacters)
        {
            string searchPrefix = prefixCharacters.Replace("_", "[_]").Replace("%", "[%]"); 

            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@PrefixCharacter", searchPrefix);
            return command.QueryForListResult<TagInfo>(PopulateInstance, QUERY_BY_SITE_ID_AND_PREFIX_CHARS);
        }

        public List<TagInfo> QueryByTagGroupId(long tagGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TagGroupId",  tagGroupId);
            return command.QueryForListResult<TagInfo>(PopulateInstance , QUERY_BY_TAG_GROUP);
        }

        private static void AddInsertParameters(TagInfo tagInfo, SqlCommand command)
        {       
            SetCommonAttributes(tagInfo, command);
            command.AddParameter("@ScadaConnectionInfoId", tagInfo.ScadaConnectionInfoId.Value);            
        }

        private static void AddUpdateTagInfoFromPHDParameters(TagInfo tagInfo, SqlCommand command)
        {
            SetCommonAttributes(tagInfo, command);
        }

        private static void SetCommonAttributes(TagInfo tagInfo, SqlCommand command)
        {
            command.AddParameter("@Name", tagInfo.Name);
            command.AddParameter("@Description", tagInfo.Description);
            command.AddParameter("@Units", tagInfo.Units ?? string.Empty);
            command.AddParameter("@SiteId", tagInfo.SiteId.Value);            
        }

        private static TagInfo PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string name = reader.Get<string>("Name");
            string description = reader.Get<string>("Description");
            string units = reader.Get<string>("Units");
            
            long siteId = reader.Get<long>("SiteId");
            long scadaConnectionInfoId = reader.Get<long>("ScadaConnectionInfoId");
            bool deleted = reader.Get<bool>("Deleted");

            TagInfo tagInfo = new TagInfo(id, siteId, name, description, units, deleted,scadaConnectionInfoId);
            return tagInfo;
        }
        
        private static TagInfo PopulateInstanceWithScadaProviderDescription(SqlDataReader reader)
        {
            var tagInfo = PopulateInstance(reader);
            tagInfo.ScadaProviderDescription = reader.Get<string>("ScadaProviderDescription");
            return tagInfo;
        }

        public static string BuildQueryList(SearchCriteria filter)
        {
            if (filter == null)
                throw new OLTException();

            var filterstring = new StringBuilder(filter.Field.Name);
            
            switch (filter.Field.Fieldtype)
            {
                case FieldType.Text:
                    {
                        filterstring.Append(" LIKE ");
                        filterstring.Append("'%");
                        filterstring.Append(filter.Value);
                        filterstring.Append("%'");
                        break;
                    }
                case FieldType.Numeric:
                    {
                        filterstring.Append(" = ");
                        filterstring.Append(filter.Value);
                        break;
                    }
                case FieldType.DateTime:
                    {
                        filterstring.Append(" BETWEEN ");
                        filterstring.Append("CONVERT(DATETIME, '");
                        filterstring.Append(filter.Value);
                        filterstring.Append(" 00:00:00) AND CONVERT(DATETIME, '");
                        filterstring.Append(filter.Value);
                        filterstring.Append(" 23:59:59',102)");
                        break;
                    }
            }


            return filterstring.ToString();
        }
    }
}