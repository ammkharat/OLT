using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Client.Services
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            string user = string.Empty;
            string shift = string.Empty;

            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null)
            {
                if (userContext.User != null && userContext.User.Id.HasValue)
                {
                    user = userContext.User.Id.ToString();
                }
                if (userContext.UserShift != null && 
                    userContext.UserShift.ShiftPattern != null && 
                    userContext.UserShift.ShiftPattern.Id.HasValue)
                {
                    shift = userContext.UserShift.ShiftPattern.Id.ToString();
                }
                
            }

            string clientUri = ClientServiceRegistry.Instance.ClientServiceHostAddress;
            string clientUiCulture = CultureInfo.CurrentUICulture.Name;

            MessageHeaderUtility.AddUserHeaderInformation(ref request, user, shift, clientUri, clientUiCulture);
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
