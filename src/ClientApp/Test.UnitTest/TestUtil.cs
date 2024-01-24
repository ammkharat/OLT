using System;
using System.Threading;
using System.Windows.Forms;
using NMock2;
using Com.Suncor.Olt.Common;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

namespace Com.Suncor.Olt.Client
{
    public class TestUtil
    {
        public static readonly Matcher IsGetter = new MethodNameMatcher("get_.*");
        private static readonly Matcher IsSetter = new MethodNameMatcher("set_.*");

        protected TestUtil() { }

        public static Matcher IsStringContaining(params string[] values)
        {
            Matcher matcher = Is.StringContaining(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                matcher = matcher & Is.StringContaining(values[i]);
            }
            return matcher;
        }

        public static Matcher HasProperty<T>(string propertyName, Matcher valueMatcher)
        {
            return new OltPropertyMatcher<T>(propertyName, valueMatcher);
        }

        public static Matcher HasFirstArrayElement(Matcher firstElementMatcher)
        {
            return new ArrayElementMatcher(0, firstElementMatcher);
        }

        public static Matcher IsTypeOf(Type objectType)
        {
            return new TypeMatcher(objectType);
        }

        public static Matcher IsSetterNotEndingWith(string setterNameEndFragment)
        {
            return IsSetter & !IsMethodEndingWith(setterNameEndFragment);
        }

        public static Matcher IsMethodEndingWith(string methodNameEndFragment)
        {
            return IsMethodWithNameMatching(".*" + methodNameEndFragment);
        }

        public static Matcher IsMethodStartingWith(string methodNameStartFragment)
        {
            return IsMethodWithNameMatching(methodNameStartFragment + ".*");
        }

        private static Matcher IsMethodWithNameMatching(string pattern)
        {
            return new MethodNameMatcher(pattern);
        }
        
        public static Matcher IsMethodStartingWithAndReturning(string methodNameStartFragment, Type returnType)
        {
            return new MethodNameAndReturnTypeMatcher(methodNameStartFragment, returnType);
        }

        public static Matcher IsMethodReturning(Type returnType)
        {
            return new MethodReturnTypeMatcher(returnType);
        }

        private class MethodNameMatcher : Matcher
        {
            private Regex methodNameRegex;

            public MethodNameMatcher(string pattern)
            {
                methodNameRegex = new Regex(pattern);
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("method with name matching pattern:<" + methodNameRegex + ">");
            }

            public override bool Matches(object o)
            {
                MethodInfo methodInfo = (MethodInfo)o;
                return methodNameRegex.IsMatch(methodInfo.Name);
            }
        }

        private class MethodReturnTypeMatcher : Matcher
        {
            private readonly Type returnType;

            public MethodReturnTypeMatcher(Type returnType)
            {
                this.returnType = returnType;
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("method with return type:<" + returnType + ">");
            }

            public override bool Matches(object o)
            {
                MethodInfo methodInfo = (MethodInfo)o;
                return returnType.IsAssignableFrom(methodInfo.ReturnType);
            }
        }
        
        private class MethodNameAndReturnTypeMatcher : Matcher
        {
            private readonly Regex methodNameRegex;
            private readonly Type returnType;

            public MethodNameAndReturnTypeMatcher(string pattern, Type returnType)
            {
                methodNameRegex = new Regex(pattern);
                this.returnType = returnType;
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("method with name matching pattern:<" + methodNameRegex + "> and return type:<" + returnType + ">");
            }

            public override bool Matches(object o)
            {
                MethodInfo methodInfo = (MethodInfo)o;
                return methodNameRegex.IsMatch(methodInfo.Name) && returnType.IsAssignableFrom(methodInfo.ReturnType);
            }
        }

        public static void WaitAndDoEvents()
        {
            WaitAndDoEvents(500);
        }

        public static void WaitAndDoEvents(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            Application.DoEvents();
        }
    }
}
