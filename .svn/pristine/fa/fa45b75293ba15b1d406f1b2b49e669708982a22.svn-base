using System;
using System.IO;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class DirectoryInfoExtensions
    {
        public static bool IsUncDrive(this DirectoryInfo info)
        {
            if (info == null)
                return false;
            if (info.Extension.HasValue())
                return false;

            Uri uri;
            return Uri.TryCreate(info.FullName, UriKind.Absolute, out uri) && uri.IsUnc;
        }
    }
}