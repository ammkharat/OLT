using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Client
{
    public class SessionStore
    {
        private readonly IDictionary<SessionStoreKey, object> dictionary = new Dictionary<SessionStoreKey, object>();

        public void Clear()
        {
            dictionary.Clear();
        }

        public void SetValue(SessionStoreKey key, object value)
        {
            dictionary[key] = value;
        }

        public object GetValue(SessionStoreKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];    
            }

            return null;
        }

        public void ClearValue(SessionStoreKey key)
        {
            dictionary.Remove(key);
        }

        public static DateTime? GetEdmontonWorkPermitExpiryFromSessionStore()
        {
            DateTime? dateTimeFromSessionStore = null;

            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            object possiblyStoredEndDateTime = sessionStore.GetValue(SessionStoreKey.WorkPermitEdmontonEndDateTime);

            if (possiblyStoredEndDateTime != null)
            {
                dateTimeFromSessionStore = (DateTime?)possiblyStoredEndDateTime;
            }
            return dateTimeFromSessionStore;
        }

        public static DateTime? GetFortHillsWorkPermitExpiryFromSessionStore()
        {
            DateTime? dateTimeFromSessionStore = null;

            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            object possiblyStoredEndDateTime = sessionStore.GetValue(SessionStoreKey.WorkPermitFortHillsEndDateTime);

            if (possiblyStoredEndDateTime != null)
            {
                dateTimeFromSessionStore = (DateTime?)possiblyStoredEndDateTime;
            }
            return dateTimeFromSessionStore;
        }

        public static bool HasEdmontonWorkPermitExpiryInSessionStore()
        {
            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            object possiblyStoredEndDateTime = sessionStore.GetValue(SessionStoreKey.WorkPermitEdmontonEndDateTime);
            return possiblyStoredEndDateTime is DateTime;
        }

    }

    public class SessionStoreKey
    {
        private readonly string key;

        public static readonly SessionStoreKey WorkPermitMontrealPreparationCheckboxIsTicked = new SessionStoreKey("WorkPermitMontrealPreparationCheckboxIsTicked");
        public static readonly SessionStoreKey WorkPermitMontrealStartDateTime = new SessionStoreKey("WorkPermitMontrealStartDateTime");
        public static readonly SessionStoreKey WorkPermitMontrealEndDateTime = new SessionStoreKey("WorkPermitMontrealEndDateTime");
        public static readonly SessionStoreKey WorkPermitEdmontonEndDateTime = new SessionStoreKey("WorkPermitEdmontonEndDateTime");
        public static readonly SessionStoreKey WorkPermitLubesEndDateTime = new SessionStoreKey("WorkPermitLubesEndDateTime");
        public static readonly SessionStoreKey WorkPermitFortHillsEndDateTime = new SessionStoreKey("WorkPermitFortHillsEndDateTime");

        //RITM0301321 mangesh
        public static readonly SessionStoreKey WorkPermitMudsPreparationCheckboxIsTicked = new SessionStoreKey("WorkPermitMudsPreparationCheckboxIsTicked");
        public static readonly SessionStoreKey WorkPermitMudsStartDateTime = new SessionStoreKey("WorkPermitMudsStartDateTime");
        public static readonly SessionStoreKey WorkPermitMudsEndDateTime = new SessionStoreKey("WorkPermitMudsEndDateTime");

        private SessionStoreKey(string key)
        {
            this.key = key;
        }

        public bool Equals(SessionStoreKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.key, key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SessionStoreKey)) return false;
            return Equals((SessionStoreKey) obj);
        }

        public override int GetHashCode()
        {
            return key.GetHashCode();
        }
    }
}
