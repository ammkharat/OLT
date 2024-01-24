using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace Com.Suncor.Olt.Common.Utility
{
    public class Constants
    {
        public const string VERSION_3_2_STRING = "3.2";
        public const string VERSION_4_9_STRING = "4.9";
        public const string VERSION_4_17_STRING = "4.17";
        public const string VERSION_4_19_STRING = "4.19";
        public const string VERSION_4_18_STRING = "4.18";
        public const int TAG_DAYS_SINCE_LAST_READ_LIMIT = 15;
        public const int TAG_DAYS_SINCE_LAST_WRITE_LIMIT = 15;

        public static Version CURRENT_VERSION =
            new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString(2));

        public static Version VERSION_3_2 = new Version(VERSION_3_2_STRING);

        public static Version VERSION_4_9 = new Version(VERSION_4_9_STRING);
        public static Version VERSION_4_17 = new Version(VERSION_4_17_STRING);
        public static Version VERSION_4_19 = new Version(VERSION_4_19_STRING);
        public static Version VERSION_4_18 = new Version(VERSION_4_18_STRING);
        public static readonly List<string> ALPHANUMERIC_CHARACTERS;
        public static readonly List<string> EXPANDED_ALPHANUMERIC_CHARACTERS;


        static Constants()
        {
            ALPHANUMERIC_CHARACTERS = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
                "m",
                "n",
                "o",
                "p",
                "q",
                "r",
                "s",
                "t",
                "u",
                "v",
                "w",
                "x",
                "y",
                "z",
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                ".",
                "_",
                "-",
                "#",
                ",",
                "%"
            };
            EXPANDED_ALPHANUMERIC_CHARACTERS = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
               "ma",
                "mb",
                "mc",
                "md",
                "me",
                "mf",
                "mg",
                "mh",
                "mi",
                "mj",
                "mk",
                "ml",
                "mm",
                "mn",
                "mo",
                "mp",
                "mq",
                "mr",
                "ms",
                "mt",
                "mu",
                "mv",
                "mw",
                "mx",
                "my",
                "mz",
                "m0",
                "m1",
                "m2a",
                "m2b",
                "m2c",
                "m2d",
                "m2e",
                "m2f",
                "m2g",
                "m2h",
                "m2i",
                "m2j",
                "m2k",
                "m2l",
                "m2m",
                "m2n",
                "m2o",
                "m2p",
                "m2q",
                "m2r",
                "m2s",
                "m2t",
                "m2u",
                "m2v",
                "m2w",
                "m2x",
                "m2y",
                "m2z",
                "m20",
                "m21",
                "m22",
                "m23",
                "m24",
                "m25",
                "m26",
                "m27",
                "m28",
                "m29",
                "m2.",
                "m2_",
                "m2-",
                "m2#",
                "m2,",
                "m2%",
                "m3",
                "m4",
                "m5",
                "m6",
                "m7",
                "m8",
                "m9",
                "m.",
                "m_",
                "m-",
                "m#",
                "m,",
                "m%",
                "m$",
                "n",
                "o",
                "p",
                "q",
                "r",
                "s",
                "t",
                "u",
                "v",
                "w",
                "x",
                "y",
                "z",
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                ".",
                "_",
                "-",
                "#",
                ",",
                "%"
            };
        }

        public static string OLT_REMOTE_APP_CONNECTION_STRING
        {
            get { return ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString; }
        }

        public static TimeSpan WorkPermitTimePreferenceOffsetLimit
        {
            get { return new TimeSpan(04, 00, 00); }
        }

        public static DateTime PAST_END_TIME
        {
            get
            {
                return new DateTime(DateTime.MaxValue.Year, DateTime.MaxValue.Month, DateTime.MaxValue.Day, 12, 0, 0);
            }
        }

        #region Integration App Size Restrictions

        public static int PLANT_ID_MAX_LENGTH = 4;

        public static int FLOC_LEVELS_ALLOWED = 7;
        public static int FLOC_FULL_HIERARCHY_MAX_LENGTH = 100;

        public static int NOTIFICATION_NUMBER_MAX_LENGTH = 12;
        public static int NOTIFICATION_TYPE_MAX_LENGTH = 2;

        public static int SHORT_TEXT_MAX_LENGTH = 40;
        public static int LONG_TEXT_MAX_LENGTH = 4000;
        public static int EQUIPMENT_NUMBER_MAX_LENGTH = 18;
        public static int INCIDENT_ID_MAX_LENGTH = 20;
        public static int CREATOR_MAX_LENGTH = 12;
        public static int EXCEPTION_TEXT_MAX_LENGTH = 60;
        public static int CONTACT_PERSON_MAX_LENGTH = 10;

        public static int TASK_CODE_MAX_LENGTH = 4;
        public static int TASK_CODE_TEXT_MAX_LENGTH = 40;
        public static int TASK_TEXT_MAX_LENGTH = 4000;

        public static int DATE_MAX_LENGTH = 10;
        public static int TIME_MAX_LENGTH = 8;

        public static int WORK_ORDER_NUMBER_MAX_LENGTH = 12;
        public static int WORK_ORDER_OPERATION_NUMBER_MAX_LENGTH = 12;
        public static int SUBOPERATION_MAX_LENGTH = 12;
        public static int WORK_ORDER_TYPE_MAX_LENGTH = 4;
        public static int WORK_ORDER_WORK_CENTRE_ID_MAX_LENGTH = 12;
        public static int WORK_ORDER_WORK_CENTRE_NAME_MAX_LENGTH = 8;
        public static int WORK_ORDER_WORK_CENTRE_TEXT_MAX_LENGTH = 50;

        #endregion

        #region Data constants

        public const string CONN_STORE_NAME = "dbconn";


        public const string SHOULD_SHARED_SQL_CONNECTION_STORE_NAME = "ShouldSharedSqlConnection";
        public const string SHARED_SQL_CONNECTION_STORE_NAME = "SharedSqlConnection";

        #endregion

        #region service constants

        public const string REMOTE_SERVICES_URL_SETTING_NAME = "RemoteServicesURL";
        private const int DefaultHoneywellCacheTime = 10;

        public static string RemoteServicesURL
        {
            get
            {
                var remoteServicesURL = ConfigurationManager.AppSettings.Get(REMOTE_SERVICES_URL_SETTING_NAME);
                if (!string.IsNullOrEmpty(remoteServicesURL) && !remoteServicesURL.EndsWith("/"))
                {
                    remoteServicesURL = remoteServicesURL + "/";
                }
                return remoteServicesURL;
            }
        }

        public static string SitesToLoadTargets
        {
            get { return ConfigurationManager.AppSettings.Get("SitesToLoadTargets"); }
        }

        public static string OLTSAPWebServiceHost
        {
            get { return ConfigurationManager.AppSettings.Get("OLTSAPWebServiceHost"); }
        }

        public static string OLTSAPWebServiceUser
        {
            get { return ConfigurationManager.AppSettings.Get("OLTSAPWebServiceUser"); }
        }

        public static string OLTSAPWebServicePassword
        {
            get { return ConfigurationManager.AppSettings.Get("OLTSAPWebServicePassword"); }
        }

        public static string OLTSAPWebServiceLogRequestURL
        {
            get { return ConfigurationManager.AppSettings.Get("OLTSAPWebServiceLogRequestURL"); }
        }

        public static int HoneywellPhdConfigurationCacheMinutes
        {
            get
            {
                var cacheTime = ConfigurationManager.AppSettings.Get("HoneywellPhdConfigurationCacheMinutes");

                if (cacheTime == null)
                    return DefaultHoneywellCacheTime;

                int timeFromConfigFile;
                if (int.TryParse(cacheTime, out timeFromConfigFile))
                {
                    return timeFromConfigFile;
                }
                return DefaultHoneywellCacheTime;
            }
        }

        #endregion service constants
    }
}