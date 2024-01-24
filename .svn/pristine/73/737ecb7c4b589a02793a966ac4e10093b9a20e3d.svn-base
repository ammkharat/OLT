using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PlantHistorianService : IPlantHistorianService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<PlantHistorianService>();

        private readonly IPlantHistorianGateway gateway;
        public PlantHistorianService() : this(PlantHistorianGateway.Instance)
        {
        }

        public PlantHistorianService(IPlantHistorianGateway gateway)
        {
            this.gateway = gateway;
        }

        public List<TagValue> ReadTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime)
        {
            return gateway.ReadTagValues(origin, tagNames, site, readTime);
        }

        public decimal?[] ReadTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] readTimes)
        {
            return gateway.ReadTagValues(origin, tagInfo, readTimes);
        }

        public decimal? ReadRestrictionDeviationTagValue(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                return gateway.ReadRestrictionDeviationTagValue(tagInfo, fromDateTime, toDateTime);
            }
            // Just return null value to indicate the value wasn't found.
            catch (Exception e)
            {
                logger.Debug("Error encountered while reading restriction deviation tag value: ", e);
                return null;
            }
            
        }

        public List<TagValue> ReadLabAlertTagValues(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime)
        {
            // This code purposely doesn't handle any potential exceptions.
            List<TagValue> unfilteredTagValues = gateway.ReadLabAlertTagValues(tagInfo, fromDateTime, toDateTime);
          
            // This is because the Honeywell PHD tag server returns "bonus raw" values on either side of the date range. Other
            // providers in the future shouldn't have a problem with this code because values should still be within the date 
            // range. (Dustin, Mar 2011)
            return unfilteredTagValues.FindAll(tagValue => tagValue.DateTime >= fromDateTime && tagValue.DateTime <= toDateTime);           
        }

        public bool CanReadTagValue(TagInfo tagInfo)
        {
            return gateway.CanReadTagValue(tagInfo);
        }

        public bool CanWriteTagValue(TagInfo tagInfo)
        {
            return gateway.CanWriteTagValue(tagInfo);
        }

        public List<TagInfo> GetTagInfoList(Site site, string prefixCharacters)
        {
            return gateway.GetTagInfoList(site, prefixCharacters);
        }
        
        public bool HasPlantHistorian(Site site)
        {
            return gateway.HasPlantHistorian(site);
        }

        public void WriteTagValue(TagInfo tagInfo, decimal value, DateTime writeTime)
        {
            gateway.WriteTagValue(tagInfo, value, writeTime);
        }

        //Added by Mukesh :-RITM0238302
        public void WriteTagValue(TagInfo tagInfo, string value, DateTime writeTime)
        {
            gateway.WriteTagValue(tagInfo, value, writeTime);
        }
        //Added by Mukesh :-RITM0238302
        public string TagType(TagInfo tag)
        {
           return gateway.TagType(tag);

        }

        public void RemoveTagValue(TagInfo tagInfo, DateTime removeTime)
        {
            gateway.RemoveTagValue(tagInfo, removeTime);
        }

        public void WriteCustomFieldsToPhd(IHasCustomFieldEntries log)
        {
            List<CustomFieldEntry> customFieldEntries = log.CustomFieldEntries.FindAll(entry => entry.PhdLinkType == CustomFieldPhdLinkType.Write && !entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());
            foreach (CustomFieldEntry entry in customFieldEntries)
            {
                CustomField customField = log.CustomFields.Find(cf => cf.Id == entry.CustomFieldId);
                if (customField == null)
                {
                    logger.WarnFormat("CustomField '{0}' with value '{1}' not written to PHD because the associated CustomField doesn't match up.", entry.CustomFieldName, entry.FieldEntryForDisplay);
                    continue;
                }

                try
                {
                    if (customField.Type == CustomFieldType.GeneralText || customField.Type==CustomFieldType.DropDownList)

                        WriteTagValue(customField.TagInfo, entry.FieldEntry, log.LogDateTime);

                    else
                        WriteTagValue(customField.TagInfo, entry.NumericFieldEntry.Value, log.LogDateTime);
                }
                catch (InvalidPlantHistorianWriteException e)
                {
                    logger.WarnFormat("CustomField '{0}' for Tag '{1}' with value '{2}' not written to PHD because of an error.{3}", entry.CustomFieldName, customField.TagInfo.Name, entry.FieldEntryForDisplay, e.InnerException.Message);
                }
                catch (Exception e)
                {
                    logger.WarnFormat("CustomField '{0}' for Tag '{1}' with value '{2}' not written to PHD because of an error.{3}", entry.CustomFieldName, customField.TagInfo.Name, entry.FieldEntryForDisplay, e.Message);
                }
            }

        }

        public void UpdateCustomFieldsToPhd(IHasCustomFieldEntries oldLog, IHasCustomFieldEntries newLog)
        {
            RemoveCustomFieldsFromPhd(oldLog);
            WriteCustomFieldsToPhd(newLog);
        }

        public void RemoveCustomFieldsFromPhd(IHasCustomFieldEntries log)
        {
            if (log == null)
                return;

            List<CustomFieldEntry> customFieldEntries = log.CustomFieldEntries.FindAll(entry => entry.PhdLinkType == CustomFieldPhdLinkType.Write && !entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());
            foreach (CustomFieldEntry entry in customFieldEntries)
            {
                CustomField customField = log.CustomFields.Find(cf => cf.Id == entry.CustomFieldId);
                if (customField == null)
                {
                    logger.WarnFormat("CustomField '{0}' for Tag '{1}' with value '{2}' not be removed from PHD because the associated CustomField doesn't match up.", entry.CustomFieldName,
                        customField.TagInfo.Name, entry.FieldEntryForDisplay);
                    continue;
                }

                try
                {
                    RemoveTagValue(customField.TagInfo, log.LogDateTime);
                }
                catch (InvalidPlantHistorianWriteException e)
                {
                    logger.WarnFormat("User, {0}, CustomField '{0}' associated to Tag '{1}' at '{2}' was not removed from PHD because of an error.{3}", entry.CustomFieldName, customField.TagInfo.Name, log.LogDateTime, e.InnerException.Message);
                }
                catch (Exception e)
                {
                    logger.WarnFormat("CustomField '{0}' associated to Tag '{1}' at '{2}' was not removed from PHD because of an error.{3}", entry.CustomFieldName, customField.TagInfo.Name, log.LogDateTime, e.Message);
                }
            }
        }

        #region //Added by Mukesh :-RITM0238302
       
        public List<TagValue> ReadAlphaNumericTagValues(PlantHistorianOrigin origin, List<string> tagNames, Site site, DateTime readTime)
        {
           return gateway.ReadAlphaNumericTagValues(origin, tagNames, site, readTime);
        }

        public object[] ReadAlphaNumericTagValues(PlantHistorianOrigin origin, TagInfo tagInfo, params DateTime[] readTimes)
        {
            return gateway.ReadAlphaNumericTagValues(origin, tagInfo, readTimes);
        }
        #endregion

    }
}