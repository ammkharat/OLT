using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Wcf;
using log4net;

namespace Com.Suncor.Olt.Remote.Clients
{
    public class OpmXhqImporter
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<OpmXhqImporter>();

        private readonly OpmXhqServiceSettings opmXhqServiceSettings;

        public OpmXhqImporter(OpmXhqServiceSettings opmXhqServiceSettings)
        {
            this.opmXhqServiceSettings = opmXhqServiceSettings;
        }

        public OpmToeDefinition GetOpmToeDefinition(string historianTag, long? versionId)
        {
            var binding = GetBasicHttpBinding();

            var uri = opmXhqServiceSettings.URI;
            var endpointAddress = new EndpointAddress(uri);

            using (var client = CreateOpmXhqServiceClient(binding, endpointAddress))
            {
                var transactionKey = Guid.NewGuid().ToString();
                var fromString = DateTime.Now.ToShortDateString();

                OpmToeDefinition results = null;

                try
                {
                    if (client.InnerChannel.State == CommunicationState.Faulted)
                    {
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportUnsuccessful);
                    }

                    results = client.GetOpmToeDefinition(historianTag, versionId);
                }
                catch (Exception e)
                {
                    if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message) &&
                        e.InnerException.Message.Contains("The remote server returned an error: (401) Unauthorized."))
                    {
                        var message = string.Format(
                            "Authorization for domain user '{6}\\{7}' to import TOE definitions from OPM via web service was denied.  Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}, Historian Tag: {4}, Version Id: {5}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID, historianTag,
                            versionId,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                        logger.Error(message, e);
                        throw new OpmXhqInvalidAuthenticationException(ErrorCodes.OpmXhqAuthorizationFailedException, e,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                    }
                    else
                    {
                        var message = string.Format(
                            "An exception was thrown while importing TOE definitions from OPM via web service. Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}, Historian Tag: {4}, Version Id: {5}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID, historianTag,
                            versionId);
                        logger.Error(message, e);
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportException, e);
                    }
                }
                finally
                {
                    if (results != null)
                    {
                        if (logger.IsDebugEnabled)
                        {
                            logger.DebugFormat(
                                "TOE Definition for Historian tag {0} was received from an OPMXHQServiceClient.GetOpmToeDefinition() import request",
                                historianTag);
                        }
                    }

                    try
                    {
                        client.Close();
                    }
                    catch
                    {
                    }
                }

                return results;
            }
        }

        public OpmToeDefinition[] GetOpmToeDefinitions(string historianTag, long? versionId)
        {
            return null;
        }

        public List<OPMExcursion> GetOpmExcursions(DateTime dateAndTimeQueryFrom)
        {
            var binding = GetBasicHttpBinding();

            var uri = opmXhqServiceSettings.URI;
            var endpointAddress = new EndpointAddress(uri);

            using (var client = CreateOpmXhqServiceClient(binding, endpointAddress))
            {
                var transactionKey = Guid.NewGuid().ToString();
                var fromString = dateAndTimeQueryFrom.ToShortDateString();

                OPMExcursion[] results = null;

                try
                {
                    if (client.InnerChannel.State == CommunicationState.Faulted)
                    {
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportUnsuccessful);
                    }

                    results = client.GetOpmExcursions(dateAndTimeQueryFrom);
                }
                catch (Exception e)
                {
                    if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message) &&
                        e.InnerException.Message.Contains("The remote server returned an error: (401) Unauthorized."))
                    {
                        var message = string.Format(
                            "Authorization for domain user '{4}\\{5}' to import excursions from OPM via web service was denied.  Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                        logger.Error(message, e);
                        throw new OpmXhqInvalidAuthenticationException(ErrorCodes.OpmXhqAuthorizationFailedException, e,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                    }
                    else
                    {
                        var message = string.Format(
                            "An exception was thrown while importing excursions from OPM via web service. Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID);
                        logger.Error(message, e);
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportException, e);
                    }
                }
                finally
                {
                    if (results != null)
                    {
                        if (logger.IsDebugEnabled)
                        {
                            if (!results.Any())
                            {
                                logger.Debug("A OPM Excursion import completed without error, but no data was returned");
                            }
                            else
                            {
                                logger.Debug(
                                    string.Format(
                                        "{0} Excursions were received from an OPMXHQServiceClient.GetOpmExcursions() import request",
                                        results.Length));
                            }
                        }
                    }

                    try
                    {
                        client.Close();
                    }
                    catch
                    {
                    }
                }

                return results != null ? new List<OPMExcursion>(results) : null;
            }
        }

        public OPMTagValue GetCurrentTagValue(string historianTag)
        {
            var binding = GetBasicHttpBinding();

            var uri = opmXhqServiceSettings.URI;
            var endpointAddress = new EndpointAddress(uri);

            using (var client = CreateOpmXhqServiceClient(binding, endpointAddress))
            {
                var transactionKey = Guid.NewGuid().ToString();
                var fromString = DateTime.Now.ToShortDateString();

                OPMTagValue results = null;

                try
                {
                    if (client.InnerChannel.State == CommunicationState.Faulted)
                    {
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportUnsuccessful);
                    }

                    results = client.GetCurrentTagValue(historianTag);
                }
                catch (Exception e)
                {
                    if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message) &&
                        e.InnerException.Message.Contains("The remote server returned an error: (401) Unauthorized."))
                    {
                        var message = string.Format(
                            "Authorization for domain user '{5}\\{6}' to import the current tag value from OPM via web service was denied.  Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}, Historian Tag: {4}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID, historianTag,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                        logger.Error(message, e);
                        throw new OpmXhqInvalidAuthenticationException(ErrorCodes.OpmXhqAuthorizationFailedException, e,
                            client.ClientCredentials.Windows.ClientCredential.Domain,
                            client.ClientCredentials.Windows.ClientCredential.UserName);
                    }
                    else
                    {
                        var message = string.Format(
                            "An exception was thrown while importing current tag values from OPM via web service. Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}, Historian Tag: {4}",
                            ErrorCodes.OpmXhqImportException, transactionKey, fromString, Site.OILSAND_ID, historianTag);
                        logger.Error(message, e);
                        throw new OpmXhqImportException(ErrorCodes.OpmXhqImportException, e);
                    }
                }
                finally
                {
                    if (results != null)
                    {
                        if (logger.IsDebugEnabled)
                        {
                            logger.DebugFormat(
                                "Current value {0} for Historian tag {1} was received from an OPMXHQServiceClient.GetCurrentTagValue() import request",
                                results.Value, historianTag);
                        }
                    }

                    try
                    {
                        client.Close();
                    }
                    catch
                    {
                    }
                }

                return results;
            }
        }

        private OPMXHQServiceClient CreateOpmXhqServiceClient(Binding binding,
            EndpointAddress remoteAddress)
        {
            var client = new OPMXHQServiceClient(binding, remoteAddress);

            foreach (var operation in client.ChannelFactory.Endpoint.Contract.Operations)
            {
                var behavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (behavior != null)
                {
                    behavior.MaxItemsInObjectGraph = Int32.MaxValue; // 2147483647
                }
            } 

            client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Identification;
            client.ClientCredentials.Windows.ClientCredential = new NetworkCredential
            {
                Domain = opmXhqServiceSettings.Domain,
                UserName = opmXhqServiceSettings.UserName,
                Password = opmXhqServiceSettings.Password
            };

            return client;
        }

        private BasicHttpBinding GetBasicHttpBinding()
        {
            var binding = new BasicHttpBinding
            {
                CloseTimeout = opmXhqServiceSettings.CloseTimeout,
                OpenTimeout = opmXhqServiceSettings.OpenTimeout,
                ReceiveTimeout = opmXhqServiceSettings.ReceiveTimeout,
                SendTimeout = opmXhqServiceSettings.SendTimeout,
                MaxBufferSize = opmXhqServiceSettings.MaxBufferSize,
                MaxReceivedMessageSize = opmXhqServiceSettings.MaxReceivedMessageSize,
                MaxBufferPoolSize = opmXhqServiceSettings.MaxBufferPoolSize,
                ReaderQuotas =
                {
                    MaxDepth = opmXhqServiceSettings.ReaderQuotasMaxDepth,
                    MaxStringContentLength = opmXhqServiceSettings.MaxStringContentLength,
                    MaxArrayLength = opmXhqServiceSettings.MaxArrayLength
                },
                Security =
                {
                    Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport = {ClientCredentialType = HttpClientCredentialType.Ntlm},
                }
            };

            return binding;
        }
    }
}