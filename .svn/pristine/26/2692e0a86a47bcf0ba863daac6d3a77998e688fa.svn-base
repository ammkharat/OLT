using System;
using System.IO;
using NMock2;
using NMock2.Monitoring;

namespace Com.Suncor.Olt.Common
{
    public class ReturnNullableValueAction<T> : IAction where T : struct
    {
        private T? returnValue;

        public ReturnNullableValueAction(T? returnValue)
        {
            this.returnValue = returnValue;
        }

        public void Invoke(Invocation invocation)
        {
            if (returnValue.HasValue)
            {
                Return.Value(returnValue).Invoke(invocation);
            }
        }

        public void DescribeTo(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }    
}
