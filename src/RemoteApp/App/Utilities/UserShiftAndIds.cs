using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    // holds the list of usershifts and the associated permit request ids that would end up in those user shifts.
    public class UserShiftandIds
    {
        readonly Dictionary<UserShift, List<long>> dictionary = new Dictionary<UserShift, List<long>>();

        internal void Add(UserShift userShift, long permitRequestId)
        {
            if (!dictionary.ContainsKey(userShift))
            {
                dictionary.Add(userShift, new List<long>());
            }
            List<long> ids = dictionary[userShift];
            ids.Add(permitRequestId);
        }

        internal IEnumerable<UserShift> Keys
        {
            get { return new List<UserShift>(dictionary.Keys); }
        }

        internal List<long> GetIdsFor(UserShift shift)
        {
            return !dictionary.ContainsKey(shift) ? new List<long>(0) : dictionary[shift];
        }
    }

}
