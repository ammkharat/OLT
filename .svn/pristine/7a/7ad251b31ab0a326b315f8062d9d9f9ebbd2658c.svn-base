using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class MessageHeaderUtility
    {
        private const string HEADER_NAMESPACE = "Com.Suncor.Olt";
        private const string USER_HEADER_NAME = "USER_HEADER_NAME";
        private const string SHIFT_HEADER_NAME = "SHIFT_HEADER_NAME";
        private const string CLIENT_URI_HEADER_NAME = "CLIENT_URI_HEADER_NAME";
        private const string CLIENT_UI_CULTURE_HEADER_NAME = "CLIENT_UI_CULTURE_HEADER_NAME";

        public static void AddUserHeaderInformation(ref Message request, string user, string shift, string clientUri,
            string clientUICulture)
        {
            request.Headers.Add(MessageHeader.CreateHeader(USER_HEADER_NAME, HEADER_NAMESPACE, user));
            request.Headers.Add(MessageHeader.CreateHeader(SHIFT_HEADER_NAME, HEADER_NAMESPACE, shift));
            request.Headers.Add(MessageHeader.CreateHeader(CLIENT_URI_HEADER_NAME, HEADER_NAMESPACE, clientUri));
            request.Headers.Add(MessageHeader.CreateHeader(CLIENT_UI_CULTURE_HEADER_NAME, HEADER_NAMESPACE,
                clientUICulture));
        }

        public static string GetUserHeaderInformation(OperationContext operationContext)
        {
            var user = GetValue(USER_HEADER_NAME, operationContext);
            var shift = GetValue(SHIFT_HEADER_NAME, operationContext);
            var clientUri = GetValue(CLIENT_URI_HEADER_NAME, operationContext);
            return string.Format("[User:{0}] [Shift:{1}] [ClientUri:{2}]", user ?? "<null>", shift ?? "<null>",
                clientUri ?? "<null>");
        }

        public static string GetClientCultureInfoName(OperationContext operationContext)
        {
            var cultureInfo = GetValue(CLIENT_UI_CULTURE_HEADER_NAME, operationContext);
            return cultureInfo;
        }

        public static string GetClientUri(OperationContext operationContext)
        {
            var clientUri = GetValue(CLIENT_URI_HEADER_NAME, operationContext);
            return clientUri;
        }

        private static string GetValue(string userHeaderName, OperationContext operationContext)
        {
            var headerIndex = operationContext.IncomingMessageHeaders.FindHeader(userHeaderName, HEADER_NAMESPACE);
            if (headerIndex >= 0)
            {
                return operationContext.IncomingMessageHeaders.GetHeader<string>(headerIndex);
            }
            return null;
        }
    }
}