using System;
using System.IO;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    /// <summary>
    /// Matches based only on the type of the object.
    /// </summary>
    public class TypeMatcher : Matcher
    {
        private readonly Type expectedType;

        public TypeMatcher(Type expectedType)
        {
            this.expectedType = expectedType;
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("type:<" + expectedType + ">");
        }

        public override bool Matches(object o)
        {
            return expectedType.IsAssignableFrom(o.GetType());
        }
    }
}