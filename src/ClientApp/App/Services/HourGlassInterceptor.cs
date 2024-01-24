using Castle.DynamicProxy;

namespace Com.Suncor.Olt.Client.Services
{

    public class HourGlassInterceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            HourGlass.Enabled = true;
        }

        protected override void PostProceed(IInvocation invocation)
        {
            HourGlass.Enabled = false;
        }

    }
}
