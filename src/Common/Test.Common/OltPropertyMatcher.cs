using System;
using System.IO;
using System.Reflection;
using NMock2;
using NMock2.Matchers;

namespace Com.Suncor.Olt.Common
{
    public struct OltMatcherPropertyValuePair
    {
        public string PropertyName;
        public object Value;

        public OltMatcherPropertyValuePair(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }
    }

    /// <summary>
    /// Used to match an object on just one of its properties
    /// (rather than relying on the <code>Equals</code> method).
    /// 
    /// For example, to expect a method call to do something with a WorkPermit with a status of Approved:
    /// <pre>
    /// Expect.Once.On(myMock)
    ///     .Method("DoSomething")
    ///     .With(new OltPropertyMatcher&lt;WorkPermit&gt;("Status", approved);
    /// </pre>
    /// </summary>
    public class OltPropertyMatcher<T> : PropertyMatcher
    {
        private readonly string propertyName;
        private readonly Matcher valueMatcher;

        public OltPropertyMatcher(string propertyName, object value)
            : this(propertyName, Is.EqualTo(value))
        {
        }

        public OltPropertyMatcher(string propertyName, Matcher valueMatcher)
            : base(propertyName, valueMatcher)
        {
            if (HasGetter(typeof(T), propertyName) == false)
            {
                throw new ArgumentException("type " + typeof(T) + " does not have a getter for property "
                                            + propertyName);
            }

            this.propertyName = propertyName;
            this.valueMatcher = valueMatcher;
        }

        

        // NOTE: Eric: This is needed because the default implementation for the version of NMock2 we use
        //       just throws a NotImplementedException.
        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("Object of type:<" + typeof(T) + "> with property:<" + propertyName
                         + "> and value:<");
            valueMatcher.DescribeTo(writer);
            writer.Write(">");
        }

        private bool HasGetter(Type objectType, string getterPropertyName)
        {
            PropertyInfo propertyInfo = objectType.GetProperty(getterPropertyName);
            return propertyInfo != null && propertyInfo.CanRead;
        }

        public static Matcher HasProperties(params OltMatcherPropertyValuePair[] oltMatcherPropertyValueList)
        {
            Matcher ret = new AlwaysTrueMatcher();

            foreach (OltMatcherPropertyValuePair propertyValue in oltMatcherPropertyValueList)
            {
                OltPropertyMatcher<T> newMatcher = new OltPropertyMatcher<T>(propertyValue.PropertyName, propertyValue.Value);

                ret = (ret & newMatcher);
            }
            return ret;
        }
    }
}