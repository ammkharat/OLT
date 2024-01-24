using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using Uniformance.PHD;

namespace Com.Suncor.Olt.PlantHistorian
{
    public class HoneywellPHDProvider : IPHDProvider
    {
        private const decimal writeTestValue = 0;
        private static readonly object syncTagReadWrite = new object();

        private static string lastTagThatGotReadLock;
        private static string lastTagThatGotWriteLock;
        private static string lastOriginThatGotReadLock;

        private readonly DateTime configurationLastModified;
        private readonly ScadaConnectionInfo connectionInfo;
        private readonly ILog logger = GenericLogManager.GetLogger<HoneywellPHDProvider>();
        private readonly bool mockTagWrites;
        private readonly int monitorTimeout;
        private readonly ILog perfLogger = LogManager.GetLogger("TargetSchedulerPerfLogger");

        private readonly long? siteId;

        //ayman pi changes
        private string sampletype;

        private readonly long? scadaConnectionInfoId;

        public long? SiteId
        {
            get { return siteId; }
        }

        //ayman pi changes
        public string SampleType
        {
            get { return sampletype; }
            set { value = sampletype; }
        }


        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly IHoneywellPhdTagDefinitionReader tagDefinitionReader;
        private PHDHistorian historian;
        private PHDServer phdServer;

        public HoneywellPHDProvider(ScadaConnectionInfo connectionInfo)
        {
            this.connectionInfo = connectionInfo;
            siteId = connectionInfo.SiteId;
            scadaConnectionInfoId = connectionInfo.Id;
            mockTagWrites = connectionInfo.MockTagWrites;
            configurationLastModified = connectionInfo.LastModifiedDateTime;

            tagDefinitionReader = AbstractHoneywellTagDefinitionReader.CreateReader(connectionInfo.DatabaseInfo, siteId, scadaConnectionInfoId);

            monitorTimeout = connectionInfo.MonitorTimeout;
            logger.InfoFormat("Honeywell PHD .NET connection for site {0} - MonitorTimeout={1} - ScadaConnectionInfoId={2}.", siteId, monitorTimeout, scadaConnectionInfoId);
            logger.InfoFormat("Honeywell PHD .NET connection for site {0} - ConnectionTimeout={1} - ScadaConnectionInfoId={2}.", siteId,
                connectionInfo.ConnectionTimeout, scadaConnectionInfoId);
            logger.InfoFormat("Honeywell PHD .NET connection for site {0} - RequestTimeout={1} - ScadaConnectionInfoId={2}.", siteId,
                connectionInfo.RequestTimeout, scadaConnectionInfoId);

            SetupHistorianConnection();
        }

        public DateTime ConfigurationLastModified
        {
            get { return configurationLastModified; }
        }

        public void Dispose()
        {
            if (phdServer != null)
            {
                phdServer.Dispose();
                logger.Debug("Disposing phdServer for Site " + siteId + ", scadaConnectionInfoId " +
                             scadaConnectionInfoId);
            }
            if (historian != null)
            {
                historian.Dispose();
                logger.Debug("Disposing historian for Site " + siteId + ", scadaConnectionInfoId " + scadaConnectionInfoId);
            }
        }

        public List<TagInfo> GetTagInfoList(string prefixCharacters)
        {
            return tagDefinitionReader.GetTagInfoList(prefixCharacters);
        }

        public void RemovePHDTagValue(TagInfo tag, DateTime removeTime)
        {
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    historian.DeleteTagData(new Tag(tag.Name), historian.ConvertToPHDTime(removeTime));
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            else
            {
                var message =
                    string.Format(
                        "Operation: RemovePHDTagValue. Unable to get lock to remove tag={0} at={1} after timeout of {2}ms.",
                        tag.Name, removeTime, monitorTimeout);
                logger.Error(message);

                throw new Exception(message);
            }
        }

        public void UpdatePHDTagValue(TagInfo tag, decimal value, DateTime writeTime)
        {
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    //mukesh Changing time as -2 Hours for Sarnia
                    if(tag.SiteId==Site.SARNIA_ID)
                {
                        writeTime = writeTime.AddHours(-2);
                    }

                    lastTagThatGotWriteLock = tag.Name;
                    historian.ModifyTag(new Tag(tag.Name), value, historian.ConvertToPHDTime(writeTime));
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            else
            {
                var message = String.Format(
                    "Operation: UpdatePHDTagValue. Unable to get lock to write tag={0} value={1} after timeout of {2}ms. The last tag to get the write lock was {3}",
                    tag.Name, value, monitorTimeout, lastTagThatGotWriteLock);
                logger.Error(message);

                throw new Exception(message);
            }
        }

       

        public bool CanWritePHDTagValue(TagInfo tag)
        {
            // TODO: In Denver, all writes can be found by looking at the ptattribute, 'datasecurity'. 
            // This attribute has a value OLTWrite: A(r,w) set-up on it for any tag that the OLT user, OLTClient, has permissions to write. 
            // This would be a better way to check rather than writing a tag and then removing the value.
            try
            {
                var dateTime = DateTime.Now.GetNetworkPortable();
                UpdatePHDTagValue(tag, writeTestValue, dateTime);
                RemovePHDTagValue(tag, dateTime);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public decimal?[] FetchPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes)
        {
            return FetchPHDTagValue(origin, tagName, requestedTimes, SetupHistorianForTargetFetch);
        }


        public List<TagValue> FetchPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime)
        {
            IDictionary<string, decimal?> resultValueMap = new Dictionary<string, decimal?>();
            var phdTagList = new Tags();
            tagList.ForEach(t => phdTagList.Add(new Tag(t)));

            var stopwatch = new Stopwatch();
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    lastTagThatGotReadLock = "Multiple";

                    stopwatch.Start();
                    var structData = AttemptMultiTagFetchWithRetry(phdTagList, requestedTime, 2);
                    stopwatch.Stop();

                    stopwatch.Reset();
                    stopwatch.Start();

                    // consider using a hashset<Tagvalue> if this is too slow since we return 50 values for each tag
                    foreach (PHDataStruct structDataItem in structData)
                    {
                        if (structDataItem != null && structDataItem.TagName != null)
                        {
                            var tagName = structDataItem.TagName;

                            if (!resultValueMap.ContainsKey(tagName))
                            {
                                decimal? tagValue = null;
                                if (structDataItem.Value != null)
                                {
                                    tagValue = Convert.ToDecimal(structDataItem.Value);
                                }

                                resultValueMap.Add(tagName, tagValue);
                            }
                        }
                    }
                    stopwatch.Stop();
                    logger.DebugFormat("Pulling {0} tag values from PHDataStruct to dictionary tool {1} seconds.",
                        structData.Count, stopwatch.Elapsed.TotalSeconds);
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            else
            {
                var message = String.Format(
                    "Operation: FetchPHDTagValue (list of tags). Unable to get lock to get tag value for a list of tags at {0} after timeout of {1}ms. The last tag to get read lock was {2}.",
                    requestedTime, monitorTimeout, lastTagThatGotReadLock);
                logger.Error(message);
                throw new Exception(message);
            }

            var tagValues = new List<TagValue>();
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var tagName in tagList)
            {
                if (resultValueMap.ContainsKey(tagName))
                {
                    var value = new TagValue(tagName, resultValueMap[tagName], requestedTime);
                    tagValues.Add(value);
                }
                else
                {
                    logger.Warn(
                        string.Format(
                            "A value for tag '{0}' was not found in the results returned from the historian server",
                            tagName));
                }
            }
            stopwatch.Stop();
            logger.DebugFormat("Took {0} seconds to create tagvalues from the dictionary.",
                stopwatch.Elapsed.TotalSeconds);

            return tagValues;
        }

        public decimal? FetchDeviationTagValue(string tagName, DateTime fromDateTime, DateTime toDateTime)
        {
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    lastTagThatGotReadLock = tagName;

                    historian.StartTime = historian.ConvertToPHDTime(toDateTime);
                    historian.EndTime = historian.ConvertToPHDTime(toDateTime);
                    short[] conf = { 0 };
                    historian.Sampletype = SAMPLETYPE.InterpolatedRaw;
                    historian.UseSampleFrequency = false;
                    historian.SampleFrequency = 0;
                    historian.ReductionFrequency = 3600;
                    historian.ReductionOffset = REDUCTIONOFFSET.Before;
                    historian.ReductionType = REDUCTIONTYPE.Average;

                    double[] timeStamp = null;
                    double[] value = null;
                    historian.FetchData(new Tag(tagName), ref timeStamp, ref value, ref conf);

                    var @decimal = new decimal(value[0]);

                    return decimal.Round(@decimal, 3);
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            var message = String.Format(
                "Operation: FetchDeviationTagValue. Unable to get lock to get deviation tag value for {0} from {1} to {2} after timeout of {3}ms. The last tag to get read lock was {4}.",
                tagName, fromDateTime, toDateTime, monitorTimeout, lastTagThatGotReadLock);
            logger.Error(message);

            throw new Exception(message);
        }

        public List<TagValue> FetchLabAlertTagValues(string tagName, DateTime fromDateTime, DateTime toDateTime)
        {
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    lastTagThatGotReadLock = tagName;

                    historian.StartTime = historian.ConvertToPHDTime(fromDateTime);
                    historian.EndTime = historian.ConvertToPHDTime(toDateTime);
                    short[] conf = { 0 };
                    historian.Sampletype = SAMPLETYPE.Raw;
                    historian.UseSampleFrequency = false;
                    historian.SampleFrequency = 0;
                    historian.ReductionOffset = REDUCTIONOFFSET.Before;
                    historian.ReductionType = REDUCTIONTYPE.None;

                    double[] timeStamp = null;
                    double[] value = null;
                    historian.FetchData(new Tag(tagName), ref timeStamp, ref value, ref conf);

                    if (value == null)
                    {
                        throw new OLTException("A null value was returned from the historian for tag: " + tagName);
                    }

                    var tagValues = new List<TagValue>();

                    for (var i = 0; i < value.Length; i++)
                    {
                        var date = DateTime.FromOADate(timeStamp[i]);
                        var decimalValue = new decimal(value[i]);

                        tagValues.Add(new TagValue(tagName, decimal.Round(decimalValue, 3), date));
                    }
                    return tagValues;
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            var message = String.Format(
                "Operation: FetchLabAlertTagValues. Unable to get lock to get deviation tag value for {0} from {1} to {2} after timeout of {3}ms. The last tag to get read lock was {4}.",
                tagName, fromDateTime, toDateTime, monitorTimeout, lastTagThatGotReadLock);
            logger.Error(message);
            throw new Exception(message);
        }

        public bool MockTagWrites
        {
            get { return mockTagWrites; }
        }

        private void SetupHistorianConnection()
        {
            try
            {
                logger.InfoFormat("Start initializing Honeywell .NET PHD connection for site {0}, scadaConnectionInfoId {1}.", siteId, scadaConnectionInfoId);

                historian = new PHDHistorian();

                var version = GetApiVersion();
                phdServer = new PHDServer(connectionInfo.PhdServer, version);

                if (connectionInfo.UseWindowsAuthentication)
                {
                    phdServer.WindowsUsername = connectionInfo.PhdUsername;
                    phdServer.WindowsPassword = connectionInfo.PhdPassword;
                }
                else
                {
                    phdServer.UserName = connectionInfo.PhdUsername;
                    phdServer.Password = connectionInfo.PhdPassword;
                }
                historian.DefaultServer = phdServer;

                // note: connection timeout seems to override request timeout even though we set
                // request timeout here separately
                historian.ConnectionTimeout = (uint)connectionInfo.ConnectionTimeout;
                phdServer.RequestTimeout = (uint)connectionInfo.RequestTimeout;


                logger.InfoFormat("Finished initializing Honeywell PHD .NET connection for site {0}, scadaConnectionInfoId {1}.", siteId, scadaConnectionInfoId);
            }
            catch (Exception e)
            {
                logger.Error("There was a problem contructing the PHD Connection.", e);
                throw;
            }
        }

        private SERVERVERSION GetApiVersion()
        {
            var apiVersion = connectionInfo.ApiVersion.ToUpper();
            try
            {
                return apiVersion.Parse<SERVERVERSION>();
            }
            catch (Exception)
            {
                throw new InvalidPlantHistorianConnectionInfoException(
                    string.Format("Value of {0} for ApiVersion does not match an known Honeywell value.", apiVersion));
            }
        }

        private void SetupHistorianForTargetFetch(DateTime requestedDateTime)
        {
            // why do we need to pass in a range, and one of five minutes? what happens if we just set starttime equal to endtime
            // does it give us a single value? what happens if our time is greater than the current time on the phd server?
            historian.StartTime =
                historian.ConvertToPHDTime(requestedDateTime.Subtract(connectionInfo.StartTimeOffset.Minutes()));
            historian.EndTime =
                historian.ConvertToPHDTime(requestedDateTime.Subtract(connectionInfo.EndTimeOffset.Minutes()));

            var sampletype = connectionInfo.SampleType.Parse<SAMPLETYPE>();
            historian.Sampletype = sampletype;
            if (sampletype != SAMPLETYPE.Raw)
            {
                if (connectionInfo.SampleFrequency.HasValue)
                {
                    historian.UseSampleFrequency = true;
                    historian.SampleFrequency = (uint)connectionInfo.SampleFrequency.Value;
                }
                var reductiontype = connectionInfo.DataReductionType.Parse<REDUCTIONTYPE>();
                historian.ReductionType = reductiontype;
                if (reductiontype != REDUCTIONTYPE.None)
                {
                    historian.ReductionFrequency = (uint)connectionInfo.DataReductionFrequency.Value;
                    historian.ReductionOffset = connectionInfo.DataReductionOffset.Parse<REDUCTIONOFFSET>();
                }
            }
        }

        private decimal?[] FetchPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes,
            Action<DateTime> setupHistorian)
        {
            var result = new decimal?[requestedTimes.Length];

            for (var index = 0; index < requestedTimes.Length; index++)
            {
                double[] value = null;
                double[] timeStamp = null;
                short[] conf = { 0 };

                var requestedTime = requestedTimes[index];

                if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
                {
                    stopwatch.Reset();
                    try
                    {
                        lastTagThatGotReadLock = tagName;
                        lastOriginThatGotReadLock = origin != null ? origin.ToString() : "null";

                        setupHistorian(requestedTime);
                        stopwatch.Start();
                        historian.FetchData(new Tag(tagName), ref timeStamp, ref value, ref conf);
                        stopwatch.Stop();
                    }
                    finally
                    {
                        Monitor.Exit(syncTagReadWrite);
                        perfLogger.Debug(string.Format("{0}, {1}", tagName, stopwatch.ElapsedMilliseconds));
                    }
                }
                else
                {
                    var message = String.Format(
                        "Operation: FetchPHDTagValue for Target Definition Read/Write tag configuration. Unable to get lock to get tag value for {0} at {1} after timeout of {2}ms. The last tag to get read lock was {3}. Last Origin to get read lock: {4}",
                        tagName, requestedTime, monitorTimeout, lastTagThatGotReadLock, lastOriginThatGotReadLock);
                    logger.Error(message);

                    throw new Exception(message);
                }

                if (value.IsEmpty())
                {
                    logger.WarnFormat("Value is null for tag {0} at {1}.", tagName, requestedTime);
                    throw new InvalidPlantHistorianReadException(tagName, requestedTimes);
                }

                var @decimal = new decimal(value[0]);
                result[index] = decimal.Round(@decimal, 3);
            }
            return result;
        }

        private ArrayList AttemptMultiTagFetchWithRetry(Tags phdTagList, DateTime requestedTime, int retries)
        {
            try
            {
                var stopwatch = new Stopwatch();
                SetupHistorianForTargetFetch(requestedTime);
                stopwatch.Start();
                var structData = historian.FetchStructData(phdTagList);
                stopwatch.Stop();

                var list = new List<string>(phdTagList.Count);
                foreach (Tag tag in phdTagList)
                {
                    list.Add(tag.TagName);
                }
                perfLogger.Debug(string.Format("{0}, {1}", list.ToCommaSeparatedString(), stopwatch.ElapsedMilliseconds));

                return structData;
            }
            catch (PHDErrorException phdErrorException)
            {
                logger.Error(
                    string.Format("Error reading {0} tags from PHD.{1}Message: {2}", phdTagList.Count,
                        Environment.NewLine, phdErrorException.Message), phdErrorException);
                if (retries > 0)
                {
                    Thread.Sleep(2000); // sleep for two seconds and retry.
                    SetupHistorianConnection();
                    return AttemptMultiTagFetchWithRetry(phdTagList, requestedTime, --retries);
                }
                throw;
            }
        }

        public void GetDfn(string tagName)
        {
            var dataSet = historian.TagDfn(tagName);
            foreach (DataTable table in dataSet.Tables)
            {
                var dataColumnCollection = table.Columns;
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in dataColumnCollection)
                    {
                        Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
                    }
                }
            }
        }




        #region Added by Mukesh :-RITM0238302

        //Added by Mukesh :-RITM0238302
        public void UpdatePHDTagValue(TagInfo tag, string value, DateTime writeTime)
        {
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    lastTagThatGotWriteLock = tag.Name;
                    historian.ModifyTag(new Tag(tag.Name), value, historian.ConvertToPHDTime(writeTime));
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            else
            {
                var message = String.Format(
                    "Operation: UpdatePHDTagValue. Unable to get lock to write tag={0} value={1} after timeout of {2}ms. The last tag to get the write lock was {3}",
                    tag.Name, value, monitorTimeout, lastTagThatGotWriteLock);
                logger.Error(message);

                throw new Exception(message);
            }
        }
        //Added by Mukesh :-RITM0238302
        public string TagType(TagInfo Tag)
        {

            return "";
        }
        public object[] FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, string tagName, DateTime[] requestedTimes)
        {
            decimal?[] b= FetchPHDTagValue(origin, tagName, requestedTimes, SetupHistorianForTargetFetch);
            object[] obj = new object[b.Length];
            int index = 0;
            foreach(decimal d in b)
            {
                obj[index] = d;
                index++;

            }
            return obj;
        }
     
        public List<TagValue> FetchAlhpaNumericPHDTagValue(PlantHistorianOrigin origin, List<string> tagList, DateTime requestedTime)
        {
            IDictionary<string, decimal?> resultValueMap = new Dictionary<string, decimal?>();
            var phdTagList = new Tags();
            tagList.ForEach(t => phdTagList.Add(new Tag(t)));

            var stopwatch = new Stopwatch();
            if (Monitor.TryEnter(syncTagReadWrite, monitorTimeout))
            {
                try
                {
                    lastTagThatGotReadLock = "Multiple";

                    stopwatch.Start();
                    var structData = AttemptMultiTagFetchWithRetry(phdTagList, requestedTime, 2);
                    stopwatch.Stop();

                    stopwatch.Reset();
                    stopwatch.Start();

                    // consider using a hashset<Tagvalue> if this is too slow since we return 50 values for each tag
                    foreach (PHDataStruct structDataItem in structData)
                    {
                        if (structDataItem != null && structDataItem.TagName != null)
                        {
                            var tagName = structDataItem.TagName;

                            if (!resultValueMap.ContainsKey(tagName))
                            {
                                decimal? tagValue = null;
                                if (structDataItem.Value != null)
                                {
                                    tagValue = Convert.ToDecimal(structDataItem.Value);
                                }

                                resultValueMap.Add(tagName, tagValue);
                            }
                        }
                    }
                    stopwatch.Stop();
                    logger.DebugFormat("Pulling {0} tag values from PHDataStruct to dictionary tool {1} seconds.",
                        structData.Count, stopwatch.Elapsed.TotalSeconds);
                }
                finally
                {
                    Monitor.Exit(syncTagReadWrite);
                }
            }
            else
            {
                var message = String.Format(
                    "Operation: FetchPHDTagValue (list of tags). Unable to get lock to get tag value for a list of tags at {0} after timeout of {1}ms. The last tag to get read lock was {2}.",
                    requestedTime, monitorTimeout, lastTagThatGotReadLock);
                logger.Error(message);
                throw new Exception(message);
            }

            var tagValues = new List<TagValue>();
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var tagName in tagList)
            {
                if (resultValueMap.ContainsKey(tagName))
                {
                    var value = new TagValue(tagName, resultValueMap[tagName], requestedTime);
                    tagValues.Add(value);
                }
                else
                {
                    logger.Warn(
                        string.Format(
                            "A value for tag '{0}' was not found in the results returned from the historian server",
                            tagName));
                }
            }
            stopwatch.Stop();
            logger.DebugFormat("Took {0} seconds to create tagvalues from the dictionary.",
                stopwatch.Elapsed.TotalSeconds);

            return tagValues;
        }


        #endregion Added by Mukesh :-RITM0238302



    }


    public interface IHoneywellPhdTagDefinitionReader
    {
        List<TagInfo> GetTagInfoList(string prefixCharacters);
    }
}