using System;

namespace Com.Suncor.Olt.Common.Wcf
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NonTransactionalOperationAttribute : Attribute
    {
    }
}