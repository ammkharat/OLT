using System.Collections.Generic;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Providers
{
    public interface IAuthenticationProvider
    {
        bool IsValidActiveDirectoryLogon(string username, string password);
        List<IOltGroupMembership> GetOltGroupMemberships(string username, string password);
        UserInformation GetUserInformation(string username, string password);
    }
}