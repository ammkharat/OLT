using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserLoginHistoryDao : AbstractManagedDao, IUserLoginHistoryDao
    {
        private readonly IUserDao userDao;
        private readonly IShiftPatternDao shiftPatternDao;
        private readonly IUserLoginHistoryFunctionalLocationDao historyFlocDao;
        private readonly IWorkAssignmentDao assignmentDao;
        
        private const string QUERY_LAST_LOGIN_BY_USER_ID = "QueryUserLoginHistoryLastByUserId";
        private const string INSERT_STORED_PROCEDURE = "InsertUserLoginHistory";

        public UserLoginHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            historyFlocDao = DaoRegistry.GetDao<IUserLoginHistoryFunctionalLocationDao>();
            assignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public UserLoginHistory QueryLastLoginByUserId(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<UserLoginHistory>(PopulateInstance , QUERY_LAST_LOGIN_BY_USER_ID);
        }

        private UserLoginHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long userId = reader.Get<long>("UserId");
            DateTime loginDateTime = reader.Get<DateTime>("LoginDateTime");
            long shiftId = reader.Get<long>("ShiftId");
            DateTime shiftStartDateTime = reader.Get<DateTime>("ShiftStartDateTime");
            DateTime shiftEndDateTme = reader.Get<DateTime>("ShiftEndDateTime");
            long? assignmentId = reader.Get<long?>("AssignmentId");
            string clientUri = reader.Get<string>("ClientUri");
            string clientUpdatePath = reader.Get<string>("ClientUpdatePath");
            string machineName = reader.Get<string>("MachineName");
            string windowsVersion = reader.Get<string>("WindowsVersion");
            string dotNetVersion = reader.Get<string>("DotNetVersion");

            bool? nullableIsClickOnce = reader.Get<bool?>("IsClickOnce");
            bool isClickOnce = nullableIsClickOnce != null && nullableIsClickOnce.Value;

            User user = userDao.QueryById(userId);
            WorkAssignment assignment = !assignmentId.HasValue ? null : assignmentDao.QueryById(assignmentId.Value);

            ShiftPattern shift = shiftPatternDao.QueryById(shiftId);

            List<FunctionalLocation> flocs = historyFlocDao.QuerySelectedFunctionalLocations(id);

            return new UserLoginHistory(
                id, 
                user, 
                loginDateTime, 
                shift, 
                shiftStartDateTime, 
                shiftEndDateTme, 
                assignment, 
                flocs,
                clientUri,
                clientUpdatePath,
                machineName,
                windowsVersion,
                dotNetVersion,
                isClickOnce);
        }


        public UserLoginHistory Insert(UserLoginHistory userLoginHistory)
        {
            SqlCommand command = ManagedCommand;
            
            long id = command.InsertAndReturnId(userLoginHistory, AddInsertParameters, INSERT_STORED_PROCEDURE);
            userLoginHistory.Id = id;
            historyFlocDao.InsertSelectedFunctionalLocations(userLoginHistory);

            return userLoginHistory;
        }

        private static void AddInsertParameters(UserLoginHistory userLoginHistory, SqlCommand command)
        {
            command.AddParameter("@UserId",  userLoginHistory.User.Id);
            command.AddParameter("@LoginDateTime",  userLoginHistory.LoginDateTime);
            command.AddParameter("@ShiftId",  userLoginHistory.Shift.Id);
            command.AddParameter("@ShiftStartDateTime",  userLoginHistory.ShiftStartDateTime);
            command.AddParameter("@ShiftEndDateTime",  userLoginHistory.ShiftEndDateTme);
            command.AddParameter("@AssignmentId",  (userLoginHistory.Assignment == null ? null : userLoginHistory.Assignment.Id));
            command.AddParameter("@ClientUri", userLoginHistory.ClientUri);
            command.AddParameter("@ClientUpdatePath", userLoginHistory.ClientUpdatePath);
            command.AddParameter("@MachineName", userLoginHistory.MachineName);
            command.AddParameter("@IsClickOnce", userLoginHistory.IsClickOnce);

            string windowsVersion = userLoginHistory.WindowsVersion;
            if (!string.IsNullOrEmpty(windowsVersion))
            {
                windowsVersion = windowsVersion.LeftSubstring(100);
            }
            command.AddParameter("@WindowsVersion", windowsVersion);
            string dotNetVersion = userLoginHistory.DotNetVersion;
            if (!string.IsNullOrEmpty(dotNetVersion))
            {
                dotNetVersion = dotNetVersion.LeftSubstring(200);
            }
            command.AddParameter("@DotNetVersion", dotNetVersion);
        }

        public void ReplaceLoginFlocs(UserLoginHistory userLoginHistory)
        {
            historyFlocDao.DeleteFunctionalLocations(userLoginHistory);
            historyFlocDao.InsertSelectedFunctionalLocations(userLoginHistory);
        }
    }
}