using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    // [TestFixture]
    public class DomainBasedCodeGenerationDriver
    {

        ////[Test]
        //public void BuildCreateSQL()
        //{
        //    PropertyInfo[] propertyInfos = typeof(WorkPermitEdmonton).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    List<PropertyInfo> infoList = new List<PropertyInfo>(propertyInfos);

        //    foreach (PropertyInfo propertyInfo in infoList)
        //    {
        //        Type propertyType = propertyInfo.PropertyType;

        //        string sqlType = GetSQLTypeForDotNetType(propertyType);

        //        string name = propertyInfo.Name;

        //        //string text = string.Format(@"command.AddParameter(""{0}"", workPermit.{0});", name);
        //        //string text = string.Format(@"Assert.AreEqual(workPermit.{0}, requeried.{0});", name);
        //        string text = string.Format(@"permit.{0} = reader.Get<string>(""{0}"");", name);

        //        Console.WriteLine(text);

        //        // command.AddParameter("WorkPermitStatusId", workPermit.WorkPermitStatus.IdValue);            
        //        // //Assert.AreEqual(workPermit.WorkPermitStatus, requeried.WorkPermitStatus);
        //        // permit.Company = reader.Get<string>("Company"); ;

        //    }
        //}

        //private string GetSQLTypeForDotNetType(Type dotNetType)
        //{
        //    if (dotNetType.IsGenericType && dotNetType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //    {
        //        dotNetType = dotNetType.GetGenericArguments()[0];
        //    }

        //    string sqlType = null;

        //    if (dotNetType == typeof(string))
        //    {
        //        sqlType = "varchar(100)";
        //    }
        //    else if (dotNetType == typeof(DateTime) || dotNetType == typeof(Time))
        //    {
        //        sqlType = "datetime";
        //    }
        //    else if (dotNetType == typeof(int))
        //    {
        //        sqlType = "int";
        //    }
        //    else if (dotNetType == typeof(bool))
        //    {
        //        sqlType = "bit";
        //    }
        //    else
        //    {
        //        sqlType = string.Format("UNKNOWN ({0})", dotNetType);
        //    }

        //    return sqlType;
        //}

        //[Test]
        public void ReadLines()
        {
            PropertyInfo[] propertyInfos = typeof(WorkPermitEdmonton).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<PropertyInfo> infoList = new List<PropertyInfo>(propertyInfos);
            Dictionary<string, string> propertyToTypeMap = new Dictionary<string, string>();
                
            foreach (PropertyInfo propertyInfo in infoList)
            {
                propertyToTypeMap.Add(propertyInfo.Name, propertyInfo.PropertyType.Name);
            }

            try
            {
                using (StreamReader sr = new StreamReader(@"c:\dev\permitreqed-updateparams.txt"))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //DoWork(line);
                    

                        line = line.Trim();
                        if (line.Length > 0)
                        {
                            //ConvertTableCreateFieldsToStoredProcParams(line);
                            //BuildDaoSetters(line);
                            //BuildDaoObjectAssignments(line, propertyToTypeMap);
                            ConvertUpdateParamsToSetValues(line);
                        }
                    }
                }
            }
            catch
            {                
                Console.WriteLine("****************************************************************** This test shouldn't run with the automated build.");
                Thread.Sleep(10000);
            }
        }

        private void BuildDaoObjectAssignments(string line, Dictionary<string, string> propertyToTypeMap)
        {
            string type;

            if (!propertyToTypeMap.ContainsKey(line))
            {
                type = "**NO TYPE IN MAP FOR KEY: " + line;
            }
            else
            {
                type = propertyToTypeMap[line];
            }

            string output = string.Format(@"permitRequest.{1} = ({0})wrappedReader[""{1}""];", type, line);
            Console.WriteLine(output);
            //permitRequest.Location = (string)wrappedReader["Location"];
        }

        private void BuildDaoSetters(string line)
        {
            // command.Parameters.AddWithValue("@StartDateTimeDay", permitRequest.RequestedStartTimeDay);
            string output = string.Format(@"command.Parameters.AddWithValue(""@{0}"", permitRequest.{0});", line);
            Console.WriteLine(output);
        }

        private void ConvertUpdateParamsToSetValues(string line)
        {
            //@SAPOperationLongText varchar(500) = NULL,
            int atSignIndex = line.IndexOf('@');
            int spaceIndex = line.IndexOf(' ');

            string fieldName = line.Substring(atSignIndex + 1, spaceIndex - atSignIndex - 1);

            // LastModifiedByUserId = @LastModifiedByUserId,
            string output = string.Format("{0} = @{0},", fieldName);

            Console.WriteLine(output);
        }

        private void ConvertTableCreateFieldsToStoredProcParams(string line)
        {
            int openBracketIndex = line.IndexOf('[');
            int closeBracketIndex = line.IndexOf(']');

            string fieldName = line.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);

            string type = GetSQLType(line);
            string nullSpecifier = GetNullSpecifierForParameter(line);

            //OutputLineForStoredProcParams(fieldName, line)

            string output = string.Format("@{0} {1}{2},", fieldName, type, nullSpecifier);
            //string output = string.Format("{0},", fieldName);

            Console.WriteLine(output);
        }

        private string GetNullSpecifierForParameter(string inputLine)
        {
            string line = inputLine.ToUpper();

            if (line.Contains("NULL") && !line.Contains("NOT"))
            {
                return " = NULL";
            }

            return string.Empty;
        }

        private string GetSQLType(string line)
        {
            List<string> knownTypes = new List<string> { "bit", "int", "bigint", "datetime" };

            foreach (string knownType in knownTypes)
            {
                if (line.Contains(knownType))
                {
                    return knownType;
                }
            }

            if (line.Contains("varchar"))
            {
                int start = line.IndexOf("varchar");
                int end = line.IndexOf(")");

                return line.Substring(start, end - start + 1);
            }

            return "UNKNOWNTYPE (" + line + ")";
        }
    }
}
