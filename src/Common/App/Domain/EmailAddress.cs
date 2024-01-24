using System;
using System.Collections.Generic;
using System.Net.Mail;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class EmailAddress
    {
        private readonly string emailAddress;

        public EmailAddress(string emailAddress)
        {
            if (!IsValid(emailAddress))
            {
                throw new ArgumentException("Invalid email address");
            }

            this.emailAddress = emailAddress.Trim();
        }

        public static bool IsValid(string emailString)
        {
            if (emailString.IsNullOrEmptyOrWhitespace())
            {
                return false;
            }

            var emails = SplitDelimitedList(emailString);

            foreach (var email in emails)
            {
                try
                {
                    new MailAddress(email);
                }
                catch (FormatException)
                {
                    return false;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<EmailAddress> ConvertDelimitedListToEmailAddresses(string delimitedEmailAddresses)
        {
            var emailAddressStringList = SplitDelimitedList(delimitedEmailAddresses);
            var emailAddresses = emailAddressStringList.ConvertAll(s => new EmailAddress(s));
            return emailAddresses;
        }

        private static List<string> SplitDelimitedList(string delimitedList)
        {
            return new List<string>(delimitedList.Split(';'));
        }

        public static string ConvertToDelimitedString(List<EmailAddress> emailAddresses)
        {
            return emailAddresses.ToDelimitedString(';');
        }

        public override string ToString()
        {
            return emailAddress;
        }
    }
}