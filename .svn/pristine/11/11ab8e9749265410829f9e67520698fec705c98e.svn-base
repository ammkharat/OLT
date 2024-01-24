using System;
using System.Reflection;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class TestRendererUtils
    {
        public static bool ColumnHeaderNameExistsAsPropertyInObject(String ColumnHeaderName, object domainObject)
        {
            PropertyInfo propertyInfo = domainObject.GetType().GetProperty(ColumnHeaderName);
            return propertyInfo != null;
        }
    }
}
