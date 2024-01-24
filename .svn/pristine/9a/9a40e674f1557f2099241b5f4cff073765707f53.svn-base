using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserPrintPreferenceDao : AbstractManagedDao, IUserPrintPreferenceDao
    {
        private const string QUERY_BY_USERID = "QueryUserPrintPreferenceByUserId";
        private const string INSERT_STORED_PROCEDURE = "InsertUserPrintPreference";
        private const string UPDATE_STORED_PROCEDURE = "UpdateUserPrintPreference";
        private const string REMOVE_STORED_PROCEDURE = "RemoveUserPrintPreference";

        public UserPrintPreference Insert(UserPrintPreference preference)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(preference, AddInsertParameters, INSERT_STORED_PROCEDURE);
            preference.Id = long.Parse(idParameter.Value.ToString());
            return preference;
        }

        public void Update(UserPrintPreference preferenceToUpdate)
        {
            ManagedCommand.Update(preferenceToUpdate, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        public void Remove(UserPrintPreference preferenceToRemove)
        {
            ManagedCommand.ExecuteNonQuery(preferenceToRemove, REMOVE_STORED_PROCEDURE, AddDeleteParameters);
        }

        public UserPrintPreference QueryByUserId(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<UserPrintPreference>(PopulateInstance , QUERY_BY_USERID);
        }

        private static void AddInsertParameters(UserPrintPreference preference, SqlCommand command)
        {
            command.AddParameter("@UserId",  preference.UserId);
            command.AddParameter("@PrinterName", preference.PrinterName);
            command.AddParameter("@NumberOfCopies",  preference.NumberOfCopies);
            command.AddParameter("@NumberOfTurnaroundCopies", preference.NumberOfTurnaroundCopies);
            command.AddParameter("@ShowPrintDialog",  preference.ShowPrintDialog);
            command.AddParameter("@ShowShifthandoverAlertDialog", preference.ShowShiftHandoverAlertDialog); //RITM0387753-Shift Handover creation alert(Aarti)
            command.AddParameter("@ShowSoundAlertforActionItemDirectiveTargets ", preference.SoundAlertEnable);  // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
        }

        private static void AddUpdateParameters(UserPrintPreference preference, SqlCommand command)
        {
            command.AddParameter("@Id",  preference.Id);
            command.AddParameter("@UserId",  preference.UserId);
            command.AddParameter("@PrinterName", preference.PrinterName);
            command.AddParameter("@NumberOfCopies",  preference.NumberOfCopies);
            command.AddParameter("@NumberOfTurnaroundCopies",  preference.NumberOfTurnaroundCopies);
            command.AddParameter("@ShowPrintDialog",  preference.ShowPrintDialog);
            command.AddParameter("@ShowShifthandoverAlertDialog", preference.ShowShiftHandoverAlertDialog);//RITM0387753-Shift Handover creation alert(Aarti)
            command.AddParameter("@ShowSoundAlertforActionItemDirectiveTargets ", preference.SoundAlertEnable);  // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
        }

        private static void AddDeleteParameters(UserPrintPreference preference, SqlCommand command)
        {command.AddParameter("@Id",  preference.Id);
        }

        private static UserPrintPreference PopulateInstance(SqlDataReader reader)
        {
            var preference = new UserPrintPreference(reader.Get<long>("Id"),
                                                        reader.Get<long>("UserId"),
                                                        reader.Get<string>("PrinterName"),
                                                        reader.Get<int>("NumberOfCopies"),
                                                        reader.Get<int>("NumberOfTurnaroundCopies"),
                                                        reader.Get<bool>("ShowPrintDialog"),
                                                        reader.Get<bool>("ShowShifthandoverAlertDialog"),//RITM0387753-Shift Handover creation alert(Aarti)
                                                        reader.Get<bool>("ShowSoundAlertforActionItemDirectiveTargets") // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                                                        );
            return preference;
        }
    }
}