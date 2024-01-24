using System;
using System.Windows.Forms;
using log4net;

namespace Com.Suncor.Olt.Client
{
    public class HourGlass : IDisposable
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HourGlass));

        public HourGlass()
        {
            Enabled = true;
        }

        public void Dispose()
        {
            Enabled = false;
        }

        public static bool Enabled
        {            
            set
            {
                try
                {
                    Application.UseWaitCursor = value;
                }
                catch (Exception e)
                {
                    logger.Error("There was an error setting the hourglass on the forms.", e);
                }
            }
        }
    }
}