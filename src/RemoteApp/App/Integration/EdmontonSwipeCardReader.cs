using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.Exceptions;
using log4net;
using Com.Suncor.Olt.Common.Domain.Form;
namespace Com.Suncor.Olt.Remote.Integration
{
    public class EdmontonSwipeCardReader : IEdmontonSwipeCardReader
    {
        private static readonly string edmontonSwipeCardSystemUrl = ConfigurationManager.AppSettings["EdmontonSwipeCardReaderUrl"];

        public List<EdmontonPerson> GetCardsFromSwipeCardSystem(int days)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["days"] = days.ToString(CultureInfo.InvariantCulture);

            var uriBuilder = new UriBuilder(edmontonSwipeCardSystemUrl) {Query = queryString.ToString()};
            var uri = uriBuilder.Uri;

            var objRequest = (HttpWebRequest) WebRequest.Create(uri);
            objRequest.Method = "GET";
            objRequest.ProtocolVersion = HttpVersion.Version11;
            objRequest.ContentType = "text/xml";

            WebResponse webResponse = null;
            Stream responseStream = null;

            CardDataSet swipeCardData;
            try
            {
                webResponse = objRequest.GetResponse();
                responseStream = webResponse.GetResponseStream();
                var serializer = new XmlSerializer(typeof (CardDataSet));
                swipeCardData = serializer.Deserialize(responseStream) as CardDataSet;
            }
            catch (Exception ex)
            {
                // some issue getting the swipe card data from the external system. Should probably return a custom error, and not empty list 
                // so that we know that there was an issue and we don't want to sync with local data.
                throw new EdmontonCardSwipeSystemReadException(string.Format("Could not read data from Card Swipe System for URL {0}", edmontonSwipeCardSystemUrl),
                    ex);
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
            }

            var edmontonPersons = new List<EdmontonPerson>();
            if (swipeCardData == null)
                return edmontonPersons;

            var items = swipeCardData.Items;
            foreach (var item in items)
            {
                var person = CreateIfIsValid(item);
                if (person != null)
                {
                    edmontonPersons.Add(person);
                }
            }

            return edmontonPersons;
        }

        public EdmontonPerson CreateIfIsValid(UserCardData item)
        {
            var lastAccessDateTime = item.LastAccessDateTime;
            var lastDoorName = item.LastDoorName;
            var firstName = item.FirstName;
            var lastName = item.LastName;
            var identifier = item.Identifier;

            if (lastAccessDateTime == null || firstName.IsNullOrEmptyOrWhitespace() || lastName.IsNullOrEmptyOrWhitespace() ||
                lastDoorName.IsNullOrEmptyOrWhitespace() || identifier.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            DateTime dateTimeOfItem;
            var parsed = DateTime.TryParse(lastAccessDateTime, out dateTimeOfItem);
            // TODO: Should have a way of making a user configurable list of items that shouldn't show up in OLT drop down list so that we aren't coding these changes.
            if (!parsed)
            {
                return null;
            }
            if (IsNotARealPerson(lastName))
            {
                return null;
            }
            // the swipe card data from edmonton doesn't specify the date time correctly using UTC offsets, this hack fixes it
            dateTimeOfItem = lastAccessDateTime.EndsWith("-7:00") ? dateTimeOfItem.AddHours(-7) : dateTimeOfItem.AddHours(-6);

            BadgeScanStatus scanStatus = lastDoorName.StartsWith("PC-Out", StringComparison.OrdinalIgnoreCase) ? BadgeScanStatus.Out : BadgeScanStatus.In;

            return new EdmontonPerson(null,
                firstName,
                lastName,
                identifier,
                TimeZoneInfo.ConvertTimeBySystemTimeZoneId
                    (dateTimeOfItem, "Mountain Standard Time"),
                scanStatus);
        }

        private bool IsNotARealPerson(string lastName)
        {
            return lastName.StartsWith("visitor pass", StringComparison.OrdinalIgnoreCase) || lastName.StartsWith("vehicle gate", StringComparison.OrdinalIgnoreCase) ||
                   lastName.StartsWith("emergency access", StringComparison.OrdinalIgnoreCase);
        }
    }

    public interface IEdmontonSwipeCardReader
    {
        List<EdmontonPerson> GetCardsFromSwipeCardSystem(int days);
    }
}