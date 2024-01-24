using System.IO;
using System.Text;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Integration.HTTPHandlers.Utilities;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures
{
    public class SAPFixture
    {
        /// <summary>
        ///     Creates a unique 12 digit string that "looks" like an SAP Notification number
        ///     based on the current DateTime tick value. The number should look something like
        ///     "000930003739".
        /// </summary>
        /// <returns></returns>
        protected static string CreateNotificationNumber()
        {
            var ticks = string.Format("{0}", DateTimeFixture.DateTimeNow.Ticks);
            return string.Format("{0}{1}", "0009", ticks.Substring(ticks.Length - 8));
        }

        public static string GetFileData(string name)
        {
            var builder = GetFileAsString(name);
            return builder;
        }

        private static string GetFileAsString(string name)
        {
            var builder = new StringBuilder();
            var fileNameAndPath = Constants.HandlerFunctionalTestDataDirectory + @"\" + name;
            using (var sr = new StreamReader(fileNameAndPath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    builder.Append(line);
                }
            }
            return builder.ToString();
        }

        public static string GetFileData(string name, string token, string replacementToken)
        {
            var builder = GetFileAsString(name);
            builder = builder.Replace(token, replacementToken);
            return builder;
        }
    }
}