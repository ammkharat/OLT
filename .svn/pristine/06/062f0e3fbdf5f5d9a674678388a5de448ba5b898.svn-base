using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    internal class LockMessage
    {
        private readonly string lockTitle;
        private readonly string lockText;
        private readonly string nameOfUserWithCurrentLock;

        private LockMessage(string lockTitle, string lockText, string nameOfUserWithCurrentLock)
        {
            this.lockTitle = lockTitle;
            this.lockText = lockText;
            this.nameOfUserWithCurrentLock = nameOfUserWithCurrentLock;
        }

        internal string Title
        {
            get { return lockTitle; }
        }

        internal string Message
        {
            get { return string.Format(lockText, nameOfUserWithCurrentLock); }
        }

        internal static LockMessage CreateEditLockMessage(LockType lockType, string nameOfUserWithCurrentLock)
        {
            switch (lockType)
            {
                case LockType.Close: // TODO: Need to create a more specific 
                    return new LockMessage(StringResources.CloseDeniedTitle, StringResources.CloseDeniedMessage, nameOfUserWithCurrentLock);
                case LockType.Preview:
                    return new LockMessage(StringResources.PreviewDeniedTitle, StringResources.PreviewDeniedMessage, nameOfUserWithCurrentLock);
                case LockType.Print:
                    return new LockMessage(StringResources.PrintDeniedTitle, StringResources.PrintDeniedMessage, nameOfUserWithCurrentLock);
                default: 
                    return new LockMessage(StringResources.EditDeniedTitle, StringResources.EditDeniedMessage, nameOfUserWithCurrentLock);
            }
        }
    }

    public enum LockType
    {
        Edit,
        Print,
        Preview,
        Close
    };
}