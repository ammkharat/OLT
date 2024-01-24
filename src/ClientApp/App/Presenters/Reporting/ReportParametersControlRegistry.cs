using System;
using System.Collections;
using Com.Suncor.Olt.Client.Controls.Reporting;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class ReportParametersControlRegistry
    {
        private static readonly IDictionary parametersControlDictionary = new Hashtable();

        public static void RegisterParametersControl(Type key, IReportParametersControl control)
        {
            parametersControlDictionary.Add(key, control);
        }

        public static T GetParametersControl<T>(Type key) where T : class, IReportParametersControl
        {
            if (parametersControlDictionary.Contains(key))
            {
                return (T)parametersControlDictionary[key];
            }
            else
            {
                return null;
            }
        }

        public static void RemoveParametersControl(Type key)
        {
            if (parametersControlDictionary.Contains(key))
            {
                parametersControlDictionary.Remove(key);
            }
        }
    }
}