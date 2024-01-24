using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture]
    [Category("Database")]
    public class StoredProcedureTest
    {
        [Ignore] [Test]
        public void ShouldExecuteSelectStoredProceduresToCheckForValidTableReferences()
        {
            var storedProcedures = GetStoredProcedures();
            // Console.Out.WriteLine("StoredProcedures.Count = {0}", storedProcedures.Count);

            var errors = new List<ExecutionError>();
            foreach (var storedProcedure in storedProcedures)
            {
                try
                {
                    // Console.Out.WriteLine("storedProcedure.ExecStatement = {0}", storedProcedure.ExecStatement);
                    TestDataAccessUtil.ExecuteExpression(storedProcedure.ExecStatement);
                }
                catch (Exception e)
                {
                    // Console.Out.WriteLine("e.Message = {0}", e.Message);
                    errors.Add(new ExecutionError(storedProcedure, e.Message));
                }
            }

            foreach (var error in errors)
            {
                Console.Out.WriteLine("{0} - {1}", error.Procedure.Name, error.Error);
            }
            Assert.AreEqual(0, errors.Count);
        }

        private static List<StoredProcedure> GetStoredProcedures()
        {
            var storedProcedures = new Dictionary<string, StoredProcedure>();

            const string sql =
                @"select distinct a.name as StoredProcedureName, b.name as ParameterName, b.parameter_id, c.name as ParameterTypeName, b.is_output as IsOutput
from sys.procedures a
left join sys.parameters b on a.object_id = b.object_id
left join sys.types c on b.system_type_id = c.system_type_id
where 1=1
and (lower(a.name) like 'Count%' or lower(a.name) like 'Query%')
and lower(a.name) != 'QueryTagsByFilter'
order by 1, 2, 3";

            var reader = TestDataAccessUtil.ExecuteReader(sql);
            try
            {
                while (reader.Read())
                {
                    var storedProcedureName = reader.Get<string>("StoredProcedureName");
                    if (!storedProcedures.ContainsKey(storedProcedureName))
                    {
                        storedProcedures.Add(storedProcedureName, new StoredProcedure(storedProcedureName));
                    }
                    var parameterName = reader.Get<string>("ParameterName");
                    if (!string.IsNullOrEmpty(parameterName))
                    {
                        var parameterTypeName = reader.Get<string>("ParameterTypeName");
                        storedProcedures[storedProcedureName].Parameters.Add(new StoredProcedureParameter(
                            parameterName, parameterTypeName));
                    }
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

            return new List<StoredProcedure>(storedProcedures.Values);
        }

        private class StoredProcedure
        {
            private readonly string name;
            private readonly List<StoredProcedureParameter> parameters = new List<StoredProcedureParameter>();

            public StoredProcedure(string name)
            {
                this.name = name;
            }

            public string Name
            {
                get { return name; }
            }

            public List<StoredProcedureParameter> Parameters
            {
                get { return parameters; }
            }

            public string ExecStatement
            {
                get
                {
                    var sb = new StringBuilder();
                    sb.Append("exec ");
                    sb.Append(name);

                    for (var i = 0; i < parameters.Count; i++)
                    {
                        var parameter = parameters[i];
                        if (i != 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(" ");
                        sb.Append(parameter.Name);
                        sb.Append("=");
                        sb.Append(parameter.DummyParameterValue);
                    }

                    return sb.ToString();
                }
            }
        }

        private class StoredProcedureParameter
        {
            private readonly string name;
            private readonly string typeName;

            public StoredProcedureParameter(string name, string typeName)
            {
                this.name = name;
                this.typeName = typeName;
            }

            public string Name
            {
                get { return name; }
            }

            public object DummyParameterValue
            {
                get
                {
                    if (Equals(name, "@filter"))
                    {
                        return "'1=2'";
                    }
                    if (Equals(typeName, "int") ||
                        Equals(typeName, "decimal") ||
                        Equals(typeName, "tinyint") ||
                        Equals(typeName, "float") ||
                        Equals(typeName, "bigint") ||
                        Equals(typeName, "bit"))
                    {
                        return 0;
                    }
                    if (Equals(typeName, "text") ||
                        Equals(typeName, "varchar") ||
                        Equals(typeName, "char"))
                    {
                        return "'1'";
                    }
                    if (Equals(typeName, "datetime") || Equals(typeName, "date"))
                    {
                        return "'01Jan2011'";
                    }

                    return null;
                }
            }
        }

        private class ExecutionError
        {
            private readonly string error;
            private readonly StoredProcedure procedure;

            public ExecutionError(StoredProcedure procedure, string error)
            {
                this.procedure = procedure;
                this.error = error;
            }

            public StoredProcedure Procedure
            {
                get { return procedure; }
            }

            public string Error
            {
                get { return error; }
            }
        }
    }
}