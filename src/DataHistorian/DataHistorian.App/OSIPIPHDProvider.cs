using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using PISDK;
using PISDKCommon;
using Uniformance.PHD;

namespace Com.Suncor.Olt.PlantHistorian
{
    // Denver and Firebag uses this Provider.
    public class OSIPIPHDProvider : IPHDProvider
    {
        private const decimal writeTestValue = 0;
        private static readonly ILog logger = GenericLogManager.GetLogger<OSIPIPHDProvider>();
        private long? siteId;
        private readonly bool mockTagWrites;
        private readonly long? scadaConnectionInfoId;
        private readonly IOSIPIServerManager serverManager;
        private readonly DateTime configurationLastModified;

       //ayman PI changes
        private static string sampletype;

        public long? SiteId { get { return siteId; } }

        public static string SampleType
        {
            get { return sampletype; }
            set { value = sampletype; }
        }


        public OSIPIPHDProvider(OSIPiConnectionInfo connectionInfo)
        {
            //ayman PI changes
            sampletype = connectionInfo.SampleType;
            
            siteId = connectionInfo.SiteId;
            scadaConnectionInfoId = connectionInfo.ScadaConnectionInfoId;
            logger.InfoFormat("Start initializing OSI PI .NET connection for site {0}, scadaConnectionInfoId {1}.",
                SiteId, scadaConnectionInfoId);
            serverManager = new OSIPIServerManager(connectionInfo);
            configurationLastModified = connectionInfo.LastModifiedDateTime;

            mockTagWrites = connectionInfo.MockTagWrites;
            logger.InfoFormat("Finished initializing OSI PI .NET connection for site {0}, scadaConnectionInfoId {1}.",
                SiteId, scadaConnectionInfoId);
        }
        public DateTime ConfigurationLastModified
        {
            get { return configurationLastModified; }
        }

        public bool MockTagWrites
        {
            get { return mockTagWrites; }
        }

        public List<TagInfo> GetTagInfoList(string prefixCharacters)
        {
            var points = GetPHDTags(prefixCharacters);
            var tagInfos = new List<TagInfo>();
            foreach (PIPoint point in points)
            {
                tagInfos.Add(new TagInfo(SiteId,
                    point.Name,
                    point.PointAttributes["descriptor"].Value.ToString(),
                    point.PointAttributes["engunits"].Value.ToString(),
                    false, scadaConnectionInfoId));
            }
            return tagInfos;
        }

        public void UpdatePHDTagValue(TagInfo tag, decimal value, DateTime writeTime)
        {
            //COMMENT: trg - OSIPI SDK docs shows that to always have it be NOW as the timestamp. pass 0
            object defaultTimeStampOnPIServer = 0;
            var piPoint = GetTag(tag.Name);

            piPoint.Data.UpdateValue(value, writeTime, DataMergeConstants.dmReplaceDuplicates, null);

  
        }
        


        public void RemovePHDTagValue(TagInfo tag, DateTime removeTime)
        {
            var piPoint = GetTag(tag.Name);
            piPoint.Data.RemoveValues(removeTime, removeTime, DataRemovalConstants.drRemoveFirstOnly, null);
        }

        public bool CanWritePHDTagValue(TagInfo tag)
        {
            try
            {
                var dateTime = DateTime.Now.GetNetworkPortable();
                //if (tag.SiteId != Site.MACKAY_ID || tag.SiteId != Site.DENVER_ID )
                //{
                //    UpdatePHDTagValue(tag, writeTestValue, dateTime);
                //    RemovePHDTagValue(tag, dateTime);
                //    return true;
                //}
                //else
                //{
                var piPoint = GetTag(tag.Name);
                string DSString = piPoint.PointAttributes["datasecurity"].Value.ToString(); //ayman PI 
                if (DSString.RemoveAllWhiteSpace().ToLower().Contains("olt:a(r,w)"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //}
            }
            catch (Exception)
            {
                return false;
            }
        }

        public decimal?[] FetchPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes)
        {
            var tag = GetTag(tagName);
            var values = new decimal?[requestedTimes.Length];
            for (var i = 0; i < requestedTimes.Length; i++)
            {
                values[i] = GetFirstTagValueAfterRequestedDateTime(tag, requestedTimes[i]);
            }
            return values;
        }

        public List<TagValue> FetchPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime)
        {
            var values = new List<TagValue>(tagList.Count);

            foreach (var tag in tagList)
            {
                var tagValues = FetchPHDTagValue(origin, tag, new[] {requestedTime});
                var tagValue = tagValues != null && tagValues.Length > 0 ? tagValues[0] : null;
                values.Add(new TagValue(tag, tagValue, requestedTime));
            }

            return values;
        }

        public decimal? FetchDeviationTagValue(string tagName, DateTime fromDateTime, DateTime toDateTime)
        {
            //throw new NotImplementedException();     ayman restrictions pi

            PIPoint piPoint = GetTag(tagName);
            return  GetFirstTagValueAfterRequestedDateTime(piPoint, fromDateTime);
        }

        public List<TagValue> FetchLabAlertTagValues(string tagName, DateTime fromDateTime, DateTime toDateTime)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (serverManager != null)
                serverManager.Dispose();
        }

        private PointList GetPHDTags(string prefixCharacters)
        {
            object boxedInt = 1; // required to satisfy the NamedValues collection.
            var attributeNamedValues = new NamedValues();
            attributeNamedValues.Add("tag", ref boxedInt);
            attributeNamedValues.Add("descriptor", ref boxedInt);
            attributeNamedValues.Add("engunits", ref boxedInt);
            return
                ((IGetPoints2) serverManager.GetServerConnection()).GetPoints2(
                    string.Format("Tag = '{0}*'", prefixCharacters),
                    attributeNamedValues,
                    GetPointsRetrievalTypes.useGetPoints,
                    null,
                    null,
                    null);
        }
      
        private static decimal? GetFirstTagValueAfterRequestedDateTime(PIPoint tag, DateTime requestedDateTime)
        {
            //ayman pi changes average

            var timefrom = requestedDateTime; //requestedDateTime.Date.Day.ToString() + "-" + requestedDateTime.ToString("MMM") + "-" + requestedDateTime.ToString("yy") + " " + (requestedDateTime.Hour ) + ":00:00";
            var timeto = requestedDateTime.AddHours(1); //requestedDateTime.Date.Day.ToString() + "-" + requestedDateTime.ToString("MMM") + "-" + requestedDateTime.ToString("yy") + " " + (requestedDateTime.Hour + 1) + ":00:00";
            

            if (SampleType == SAMPLETYPE.Average.ToString())
            {
                
              var  values = tag.Data.Summary(timefrom,timeto, ArchiveSummaryTypeConstants.astAverage,     
                    CalculationBasisConstants.cbTimeWeighted);
              var piValue = values;
              
                return GetTagValueFromPIValue(piValue);
            }

            else if (SampleType == SAMPLETYPE.Snapshot.ToString())
            {
                var values = tag.Data.RecordedValuesByCount(requestedDateTime,
                    1,
                    DirectionConstants.dReverse,
                    BoundaryTypeConstants.btInside,
                    null,
                    FilteredViewConstants.fvUseExpressionTimes,
                    null);
                var piValue = values.Count == 0 ? tag.Data.Snapshot : values[1];
                return GetTagValueFromPIValue(piValue);
            }

            if (SampleType == "Mean")
            {
                var values = tag.Data.Summary(timefrom,timeto, ArchiveSummaryTypeConstants.astMean,
                    CalculationBasisConstants.cbEventWeighted, null);
                var piValue = values;
                return GetTagValueFromPIValue(piValue);
            }

         
            return null;
        }

        private static decimal? GetTagValueFromPIValue(PIValue piValue)
        {
            var piObjectValue = GetTagValue(piValue);

            decimal piDecimalValue;
            if (piObjectValue == null || piObjectValue.ToString().TryParse(out piDecimalValue) == false)
            {
                return null;
            }
            return decimal.Round(piDecimalValue,3);            //ayman pi changes
        }

        private static object GetTagValue(PIValue piValue)
        {
            if (piValue.Value is DigitalState)
            {
                var myDigState = (DigitalState) piValue.Value;
                return myDigState.Name;
            }
            return piValue.Value;
        }
        
       
        private PIPoint GetTag(string tagName)
        {
            try
            {
                return serverManager.GetServerConnection().PIPoints[tagName];
            }
            catch (COMException)
            {
                throw new TagDoesNotExistExpection(tagName);
            }
        }



        //Added by Mukesh :-RITM0238302
        public void UpdatePHDTagValue(TagInfo tag, string value, DateTime writeTime)
        {
            //COMMENT: trg - OSIPI SDK docs shows that to always have it be NOW as the timestamp. pass 0
            object defaultTimeStampOnPIServer = 0;
            var piPoint = GetTag(tag.Name);

            piPoint.Data.UpdateValue(value, writeTime, DataMergeConstants.dmReplaceDuplicates, null);


        }
        #region   //Added by Mukesh :-RITM0238302
        public string TagType(TagInfo tag)
        {
            try
            {
                return serverManager.GetServerConnection().PIPoints[tag.Name].PointType.ToString();
            }
            catch (COMException)
            {
                throw new TagDoesNotExistExpection(tag.Name);
            }
        }

        public object[] FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes)
        {
            var tag = GetTag(tagName);
            var values = new object[requestedTimes.Length];
            for (var i = 0; i < requestedTimes.Length; i++)
            {
                values[i] = GetFirstAlhpaNumericTagValueAfterRequestedDateTime(tag, requestedTimes[i]);
            }
            return values;
        }

        public List<TagValue> FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime)
        {
            var values = new List<TagValue>(tagList.Count);

            foreach (var tag in tagList)
            {
                var tagValues = FetchAlhpaNumericPHDTagValue(origin, tag, new[] { requestedTime });
                 values.Add(new TagValue(tag, tagValues, requestedTime));
            }

            return values;
        }

        private static object GetFirstAlhpaNumericTagValueAfterRequestedDateTime(PIPoint tag, DateTime requestedDateTime)
        {
            //ayman pi changes average

            var timefrom = requestedDateTime; //requestedDateTime.Date.Day.ToString() + "-" + requestedDateTime.ToString("MMM") + "-" + requestedDateTime.ToString("yy") + " " + (requestedDateTime.Hour ) + ":00:00";
            var timeto = requestedDateTime.AddHours(1); //requestedDateTime.Date.Day.ToString() + "-" + requestedDateTime.ToString("MMM") + "-" + requestedDateTime.ToString("yy") + " " + (requestedDateTime.Hour + 1) + ":00:00";
            if (tag.PointType == PointTypeConstants.pttypString)
            {

                var values = tag.Data.RecordedValuesByCount(requestedDateTime,
                    1,
                    DirectionConstants.dReverse,
                    BoundaryTypeConstants.btInside,
                    null,
                    FilteredViewConstants.fvUseExpressionTimes,
                    null);
                var piValue = values.Count == 0 ? tag.Data.Snapshot : values[1];
                return GetAlhpaNumericTagValueFromPIValue(piValue);
            }

            if (SampleType == SAMPLETYPE.Average.ToString())
            {

                var values = tag.Data.Summary(timefrom, timeto, ArchiveSummaryTypeConstants.astAverage,
                      CalculationBasisConstants.cbTimeWeighted);
                var piValue = values;

                return GetTagValueFromPIValue(piValue);
            }

            else if (SampleType == SAMPLETYPE.Snapshot.ToString())
            {
                var values = tag.Data.RecordedValuesByCount(requestedDateTime,
                    1,
                    DirectionConstants.dReverse,
                    BoundaryTypeConstants.btInside,
                    null,
                    FilteredViewConstants.fvUseExpressionTimes,
                    null);
                var piValue = values.Count == 0 ? tag.Data.Snapshot : values[1];
                return GetTagValueFromPIValue(piValue);
            }

            if (SampleType == "Mean")
            {
                var values = tag.Data.Summary(timefrom, timeto, ArchiveSummaryTypeConstants.astMean,
                    CalculationBasisConstants.cbEventWeighted, null);
                var piValue = values;
                return GetTagValueFromPIValue(piValue);
            }


            return null;
        }

        private static object GetAlhpaNumericTagValueFromPIValue(PIValue piValue)
        {
            var piObjectValue = GetTagValue(piValue);

            decimal piDecimalValue;
            if (piObjectValue == null || piObjectValue.ToString().TryParse(out piDecimalValue) == false)
            {
                return piObjectValue;
            }
            return decimal.Round(piDecimalValue, 3);            //ayman pi changes
        }
        #endregion//RITM0238302

        // Note: This method is not currently being used.  Searching of tags will be performed against
        // the local database which is updated with tag values via the scheduled tag job.  This method
        // allows searching of tags against OSI PI directly.
        public List<TagInfo> QueryTags(Site site, string attribute, string queryText)
        {
            var points =
                serverManager.GetServerConnection().GetPoints(string.Format("{0} = '{1}*'", attribute, queryText), null);
            var tagInfos = new List<TagInfo>();
            foreach (PIPoint point in points)
            {
                tagInfos.Add(new TagInfo(site.Id,
                    point.Name,
                    point.PointAttributes["descriptor"].Value.ToString(),
                    point.PointAttributes["engunits"].Value.ToString(),
                    false, scadaConnectionInfoId));
            }
            return tagInfos;
        }

        private class OSIPIServerManager : IOSIPIServerManager
        {
            private const string Format = "UID={0}; PWD={1}; PORT=5450";
            private readonly object lockObject = new object();


            private readonly OSIPiConnectionInfo plantHistorianConnectionInfo;
            private Server piServer;

            public OSIPIServerManager(OSIPiConnectionInfo plantHistorianConnectionInfo)
            {
                this.plantHistorianConnectionInfo = plantHistorianConnectionInfo;
                ValidateConnectionInfo();
            }

            public Server GetServerConnection()
            {
                lock (lockObject)
                {
                    if (piServer != null && piServer.Connected)
                        return piServer;

                    PISDK.PISDK sdk = new PISDKClass();
                    try
                    {
                        piServer = sdk.Servers[plantHistorianConnectionInfo.Server];
                        piServer.Open(string.Format(Format, plantHistorianConnectionInfo.Username,
                            plantHistorianConnectionInfo.Password));
                    }
                    catch (COMException)
                    {
                        throw new InvalidPlantHistorianServerException(plantHistorianConnectionInfo.Server);
                    }
                    return piServer;
                }
            }

            public void Dispose()
            {
                if (piServer != null && piServer.Connected)
                {
                    piServer.Close();
                    piServer = null;
                }
            }

            private void ValidateConnectionInfo()
            {
                if (string.IsNullOrEmpty(plantHistorianConnectionInfo.Server))
                {
                    throw new InvalidPlantHistorianServerException("Server name is empty or null.");
                }
            }
        }
    }

    internal interface IOSIPIServerManager
    {
        Server GetServerConnection();
        void Dispose();
    }
}