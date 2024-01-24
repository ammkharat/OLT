using System;
using System.Collections.Generic;
using System.Security;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net;
using Microsoft.Win32;

namespace Com.Suncor.Olt.Common.Utility
{
    public class OltEnvironment
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<OltEnvironment>();

        public static string MachineName
        {
            get
            {
                try
                {
                    return Environment.MachineName;
                }
                catch (Exception e)
                {
                    logger.Error("Error trying to get machine name: " + e);
                }
                return StringResources.Unknown;
            }
        }

        public static string DotNetVersion
        {
            get
            {
                var dotNetVersions = new List<string>();
                try
                {
                    var installedVersions =
                        Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");

                    if (installedVersions == null)
                        return String.Empty;
                    var versionNames = installedVersions.GetSubKeyNames();
                    foreach (var version in versionNames)
                    {
                        if (!version.StartsWith("v"))
                            continue;
                        var dotNetVersionKey = installedVersions.OpenSubKey(version);
                        if (dotNetVersionKey == null)
                            continue;
                        if (String.Equals(version, "v4"))
                        {
                            dotNetVersionKey = dotNetVersionKey.OpenSubKey("Full");
                            if (dotNetVersionKey == null)
                                continue;
                        }
                        var dotNetVersion = dotNetVersionKey.GetValue("Version") != null
                            ? dotNetVersionKey.GetValue("Version").ToString()
                            : null;
                        if (dotNetVersion == null)
                            continue;
                        var spVersion = dotNetVersionKey.GetValue("SP") != null
                            ? dotNetVersionKey.GetValue("SP").ToString()
                            : null;
                        if (spVersion != null)
                        {
                            dotNetVersions.Add(String.Format("{0} SP {1}", dotNetVersion, spVersion));
                        }
                        else
                        {
                            dotNetVersions.Add(dotNetVersion);
                        }
                    }
                    return dotNetVersions.ToCommaSeparatedString();
                }
                catch (SecurityException exception)
                {
                    return "Unknown: Could not determine .NET Versions because of SecurityException";
                }
                catch (Exception exception)
                {
                    return "Unknown";
                }
            }
        }
    }
}