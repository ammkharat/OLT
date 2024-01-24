using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISignInFormView
    {
        string Username { get; }
        string Password { get; }
        LoginResult Authenticated { set; }
    }
}