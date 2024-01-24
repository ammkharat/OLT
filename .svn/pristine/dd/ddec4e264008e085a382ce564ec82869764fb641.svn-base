using System;
using System.ServiceModel;

namespace Com.Suncor.Olt.Common.Wcf
{
    /// <summary>
    ///     This class contains extension methods related to WCF services.
    /// </summary>
    public static class WcfServiceExtensions
    {
        /// <summary>
        ///     Extends ICommunicationObject to handle exceptions thrown by the Close method
        ///     by calling the Abort method to ensure the transition to the Closed state.
        /// </summary>
        /// <param name="communicationObject">
        ///     The communicationObject to Close or Abort then Dispose.
        /// </param>
        public static void CloseOrAbort(this ICommunicationObject communicationObject)
        {
            // do not throw null reference exception        
            if (communicationObject == null)
            {
                return;
            }

            if (communicationObject.State == CommunicationState.Faulted)
            {
                communicationObject.Abort();
            }
            else if (communicationObject.State != CommunicationState.Closed &&
                     communicationObject.State != CommunicationState.Closing)
            {
                try
                {
                    // if Close attempts closing the session on the server and there                
                    // is a problem during the roundtrip it will throw an exception                
                    // and never transition to the Closed state                
                    communicationObject.Close();
                }
                catch (CommunicationException)
                {
                    // not closed - call Abort to transition to the closed state                
                    communicationObject.Abort();
                }
                catch (TimeoutException)
                {
                    // not closed - call Abort to transition to the closed state                
                    communicationObject.Abort();
                }
                catch (Exception)
                {
                    // not closed - call Abort to transition to the closed state                
                    communicationObject.Abort();
                    // this is an unexpected exception type - throw                
                    throw;
                }
            }
        }
    }
}