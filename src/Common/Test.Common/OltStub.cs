using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NMock2;
using NMock2.Actions;
using NMock2.Internal;
using NMock2.Monitoring;

namespace Com.Suncor.Olt.Common
{
    /// <summary>
    /// Use this to overcome NMock2's current limitation of throwing exceptions about
    /// 'byref return values cannot be null' when stubbing out a mock which has methods/properties
    /// that return value types.
    /// </summary>
    public static class OltStub
    {
        public static void On(params object[] mocks)
        {
            foreach (object mock in mocks)
            {
                StubOn(mock);
            }
        }

        private static void StubOn(object mock)
        {
            StubMethod(mock,
                       new MethodOrPropertyReturningNonVoidNonNullableValueTypeMatcher(),
                       new ReturnValueTypeDefaultAction());
            StubMethod(mock,
                       new MethodOrPropertyReturningGenericIList(),
                       new ReturnEmptyGenericComparableListAction());

            Stub.On(mock);
        }
        
        private static void StubMethod(object mock, Matcher methodMatcher, IAction action)
        {
            StubMethod((IMockObject)mock, methodMatcher, action);
        }

        private static void StubMethod(IMockObject mockObject, Matcher methodMatcher, IAction action)
        {
            // If we blindly stub without checking if the mocked type actually has
            // such a method/property, the stub expectations will screw up.
            // So, we guard this condition ourselves:
            if (mockObject.HasMethodMatching(methodMatcher))
            {
                Stub.On(mockObject).Method(methodMatcher).Will(action);
            }
        }

        private class MethodOrPropertyReturningNonVoidNonNullableValueTypeMatcher : Matcher
        {
            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("method/property returning a non-void, non-Nullable<T> value type");
            }

            public override bool Matches(object o)
            {
                MethodInfo method = (MethodInfo)o;

                if (method.ReturnType.IsValueType == false) { return false; }
                if (IsVoid(method.ReturnType)) { return false; }
                if (IsNullableType(method.ReturnType)) { return false; }

                return true;
            }

            private bool IsVoid(Type type)
            {
                return type == typeof(void);
            }

            private bool IsNullableType(Type type)
            {
                return type.IsGenericType &&
                       type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
            }
        }

        private class ReturnValueTypeDefaultAction : IAction
        {
            public void Invoke(Invocation invocation)
            {
                new ReturnAction(ValueTypeDefault(invocation.Method.ReturnType)).Invoke(invocation);
            }

            public void DescribeTo(TextWriter writer)
            {
                writer.Write("return value type default value");
            }

            private object ValueTypeDefault(Type valueType)
            {
                return Activator.CreateInstance(valueType);
            }
        }

        private class MethodOrPropertyReturningGenericIList : Matcher
        {
            public override bool Matches(object o)
            {
                MethodInfo method = (MethodInfo)o;
                Type returnType = method.ReturnType;
                
                if (returnType.IsGenericType == false) { return false; }

                Type[] genericTypeArguments = returnType.GetGenericArguments();
                Type iListT = typeof(IList<>).MakeGenericType(genericTypeArguments);

                // Is return type assignable to IList<T>?
                return iListT.IsAssignableFrom(returnType);
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("method/property returning an IList<T>");
            }
        }

        private class ReturnEmptyGenericComparableListAction : IAction
        {
            public void Invoke(Invocation invocation)
            {
                Type iListT = invocation.Method.ReturnType;
                Type[] genericTypeArguments = iListT.GetGenericArguments();
                invocation.Result = EmptyComparableListT(genericTypeArguments);
            }

            public void DescribeTo(TextWriter writer)
            {
                writer.Write("return an empty List<T>");
            }

            private object EmptyComparableListT(Type[] genericTypeArguments)
            {
                Type comparableListT = typeof(List<>).MakeGenericType(genericTypeArguments);
                return Activator.CreateInstance(comparableListT);
            }
        }
    }
}
