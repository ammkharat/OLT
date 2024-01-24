using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class UserPrintPreferenceFixture
    {
        public static UserPrintPreference CreateWorkPermitPrintPreference()
        {
            return CreateWorkPermitPrintPreference(UserFixture.CreateSupervisor());
        }
        public static UserPrintPreference CreateWorkPermitPrintPreference(User user)
        {
            return CreateWorkPermitPrintPreference(user.IdValue);
        }
        public static UserPrintPreference CreateWorkPermitPrintPreference(long userId)
        {
            return new UserPrintPreference(null, userId, "Printer1", 1, 3, false,false,false);
        }
        public static UserPrintPreference CreateWorkPermitPrintPreference(long userId, string printerName, int numCopies, int numTACopies, bool showDialog, bool showShiftHandoverAlertdialog, bool showSoundAlertforActionItemDirectiveTargets)
        {
            return new UserPrintPreference(null, userId, printerName, numCopies, numTACopies, showDialog, showShiftHandoverAlertdialog, showSoundAlertforActionItemDirectiveTargets);
        }
        
    }
}