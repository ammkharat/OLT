using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class UserActionException : OLTException
    {
        public UserActionException(string message) : base(message)
        {
            
        }
    }
}