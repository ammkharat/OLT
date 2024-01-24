using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TagService : ITagService
    {
        private readonly ITagDao dao;
        private readonly ITargetDefinitionService targetDefinitionService;
        private readonly IRestrictionDefinitionService restrictionDefinitionService;
        private readonly ILabAlertDefinitionService labAlertDefinitionService;

        private readonly ILog logger = GenericLogManager.GetLogger<TagService>();

        public TagService() : this(new TargetDefinitionService(),
            new RestrictionDefinitionService(),
            new LabAlertDefinitionService())
        {
        }

        public TagService(ITargetDefinitionService targetDefinitionService, IRestrictionDefinitionService restrictionDefinitionService, ILabAlertDefinitionService labAlertDefinitionService)
        {
            dao = DaoRegistry.GetDao<ITagDao>();
            this.targetDefinitionService = targetDefinitionService;
            this.restrictionDefinitionService = restrictionDefinitionService;
            this.labAlertDefinitionService = labAlertDefinitionService;
        }

        public List<TagInfo> QueryTagInfoByFilter(Site site, SearchCriteria criteria)
        {
            return dao.QueryTagInfoByFilter(site, criteria);
        }

        public void UpdatePlantHistorianTagInfoList(Site site, string tagPrefix, List<TagInfo> phdServerTags)
        {
            try
            {   
                logger.Debug("For site " + site.Id + " Found " + phdServerTags.Count + " tags in plant historian with prefix '" + tagPrefix + "'...");

                List<TagInfo> oltTags = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix);

                InsertNewTags(site, phdServerTags, oltTags);
                UndeleteTags(site, phdServerTags, oltTags);
                RemoveTags(site, phdServerTags, oltTags);
                UpdateTags(phdServerTags, oltTags);
            }
            catch (Exception exception)
            {
                logger.Error("Error: Getting Tag Info List: " + exception.Message, exception);
                throw new TagSchedulerException(exception.Message, exception.InnerException);
            }
        }

        private void UpdateTags(List<TagInfo> phdTags, List<TagInfo> oltTags)
        {
            HashSet<TagInfo> oltTagss = new HashSet<TagInfo>(oltTags, new TagInfoNameEqualityComparer());
            Dictionary<string, TagInfo> phdTagss = new Dictionary<string, TagInfo>(phdTags.Count);
            foreach(TagInfo phdTag in phdTags)
            {
                phdTagss.Add(phdTag.Name.ToLower()+phdTag.ScadaConnectionInfoId, phdTag);
            }

            oltTagss.IntersectWith(phdTags);
            
            foreach(TagInfo oltTag in oltTagss)
            {
                // don't update a tag that is deleted in OLT. Another process takes care of undelete and updating the tag description and units.
                if (oltTag.Deleted)
                    continue;

                // find the cooresponding PHD Tag and see if the description and name are different, and update the olt tag if they are.
                TagInfo phdTag = phdTagss[oltTag.Name.ToLower() + oltTag.ScadaConnectionInfoId];
                if (!phdTag.Description.EqualsIgnoreCase(oltTag.Description) || !phdTag.Units.EqualsIgnoreCase(oltTag.Units))
                {
                    TagInfo newVersionOfTag = new TagInfo(oltTag.Id, oltTag.SiteId, oltTag.Name, phdTag.Description, phdTag.Units, false,phdTag.ScadaConnectionInfoId);
                    dao.Update(newVersionOfTag);
                }
            }
        }

        private void UndeleteTags(Site site, List<TagInfo> phdTagInfoList, List<TagInfo> oltTags)
        {
            HashSet<TagInfo> existingDeletedTags = new HashSet<TagInfo>(oltTags.FindAll(t => t.Deleted), new TagInfoNameEqualityComparer());
            existingDeletedTags.IntersectWith(phdTagInfoList);
            foreach (TagInfo deletedTag in existingDeletedTags)
            {
                // may need to update the description and units, as well as undelete the thing.
                TagInfo phdTag = phdTagInfoList.Find(t => string.Equals(t.Name + t.ScadaConnectionInfoId, deletedTag.Name + deletedTag.ScadaConnectionInfoId, StringComparison.InvariantCultureIgnoreCase));

                TagInfo tagToUndelete = new TagInfo(deletedTag.Id, deletedTag.SiteId, deletedTag.Name, phdTag.Description, phdTag.Units, false,deletedTag.ScadaConnectionInfoId);
                dao.Update(tagToUndelete);

                targetDefinitionService.UpdateStatusForValidTag(tagToUndelete, site);
                restrictionDefinitionService.UpdateStatusForValidTag(tagToUndelete, site);
                labAlertDefinitionService.UpdateStatusForValidTag(tagToUndelete, site);
            }
        }

        private void InsertNewTags(Site site, List<TagInfo> phdTagInfoList, List<TagInfo> oltTags)
        {
            HashSet<TagInfo> phdTags = new HashSet<TagInfo>(phdTagInfoList, new TagInfoNameEqualityComparer());

            // Find the tags that need to be inserted
            phdTags.ExceptWith(oltTags);
            foreach (TagInfo phdTag in phdTags)
            {
                logger.Debug("For site " + site.Id + " Inserting tag " + phdTag.Name);
                dao.Insert(phdTag);
            }
        }

        private void RemoveTags(Site site, List<TagInfo> phdTagInfoList, IEnumerable<TagInfo> databaseTagInfoList)
        {
            HashSet<TagInfo> databaseTags = new HashSet<TagInfo>(databaseTagInfoList, new TagInfoNameEqualityComparer());
            databaseTags.ExceptWith(phdTagInfoList);

            foreach (TagInfo tag in databaseTags)
            {
                // don't need to delete a tag that is already deleted.
                if (tag.Deleted)
                    continue;

                dao.Remove(tag);
                // Update the status of target definitions assocciated to this tag to INVALID TAG as the tag is deleted.
                targetDefinitionService.UpdateStatusForInvalidTag(tag, site);
                restrictionDefinitionService.UpdateStatusForInvalidTag(tag, site);
                labAlertDefinitionService.UpdateStatusForInvalidTag(tag, site);
            }
        }
    }
    
    internal class TagInfoNameEqualityComparer : IEqualityComparer<TagInfo>
    {
        public bool Equals(TagInfo x, TagInfo y)
        {
            return string.Equals(x.Name + x.ScadaConnectionInfoId, y.Name + y.ScadaConnectionInfoId, StringComparison.CurrentCulture);
        }

        public int GetHashCode(TagInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}