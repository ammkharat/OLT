using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common
{
    public class TestUtil
    {
        public static TypeToTest SerializeAndDeSerialize<TypeToTest>(TypeToTest objectToSerialize) where TypeToTest : class
        {
            return SerializeAndDeSerialize(objectToSerialize, new BinaryFormatter());
        }

        public static TypeToTest SerializeAndDeSerialize<TypeToTest>(TypeToTest objectToSerialize,IFormatter formatterToUse) where TypeToTest : class
        {
            TypeToTest result;
            IFormatter formatter = formatterToUse;
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objectToSerialize);
                stream.Position = 0;
                result = formatter.Deserialize(stream) as TypeToTest;
            }
            return result;
        }

        public static void SetProperty(object obj, string propertyName, object value)
        {
            Type objectType = obj.GetType();
            PropertyInfo property = objectType.GetProperty(propertyName);
            Assert.IsNotNull(property, "Couldn't find property:<" + propertyName
                + "> in:<" + objectType + ">");
            property.SetValue(obj, value, null);
        }

        public static string RandomString()
        {
            return DateTimeFixture.DateTimeNow.Ticks.ToString(CultureInfo.InvariantCulture);
        }

        public static int RandomNumber()
        {
            return (int)(DateTimeFixture.DateTimeNow.Ticks % 1000);
        }

        public static double RandomDoubleNumber()
        {
            return DateTimeFixture.DateTimeNow.Ticks % 1000;
        }
    }
}
