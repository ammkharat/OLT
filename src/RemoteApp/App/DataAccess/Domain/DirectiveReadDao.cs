﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DirectiveReadDao : AbstractManagedDao, IDirectiveReadDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertDirectiveRead";
        private const string QUERY_USER_ALREADY_MARKED_AS_READ = "QueryUserMarkedDirectiveAsRead";
        private const string QUERY_USERS_THAT_MARKED_QUESTIONNAIRE_AS_READ = "QueryUsersMarkedDirectiveAsRead";


        private readonly IUserDao userDao;
        public DirectiveReadDao()
        {
           
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public ItemRead<Directive> UserMarkedAsRead(long directiveId, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@DirectiveId", directiveId);
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<ItemRead<Directive>>(PopulateInstance, QUERY_USER_ALREADY_MARKED_AS_READ);
        }

        public void Insert(ItemRead<Directive> itemRead)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(itemRead, AddInsertParameters, INSERT_STORED_PROCEDURE);
        }

        public List<ItemReadBy> UsersThatMarkedAsRead(long directiveId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@DirectiveId", directiveId);
            return command.QueryForListResult < ItemReadBy>(PopulateReadByInstance, QUERY_USERS_THAT_MARKED_QUESTIONNAIRE_AS_READ);
        }
        //Added by ppanigrahi
        public List<ItemNotReadBy> UsersThatMarkedAsNotRead(long directiveId,IFlocSet flocset)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@DirectiveId", directiveId);
            command.AddParameter("@CsvFLOCIds", flocset.FunctionalLocations.BuildIdStringFromList());

            return command.QueryForListResult<ItemNotReadBy>(PopulateNotReadByInstance, "QueryUsersMarkedDirectiveAsNotRead");
        }

        private static ItemReadBy PopulateReadByInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string userName = reader.Get<string>("Username");
            DateTime dateTime = reader.Get<DateTime>("DateTime");
            return new ItemReadBy(User.ToFullNameWithUserName(lastName, firstName, userName),
                dateTime);
        }
        //Added by ppanigrahi
        private ItemNotReadBy PopulateNotReadByInstance(SqlDataReader reader)
        {
            string Id = reader.Get<Int64>("Id").ToString();
            User user = userDao.QueryById(long.Parse(Id));
            string lastName = user.LastName;
            string firstName = user.FirstName;
            string userName = user.Username;
            string fullName = User.ToFullNameWithUserName(lastName, firstName, userName);
            return new ItemNotReadBy(Id,fullName);

        }

        private static void AddInsertParameters(ItemRead<Directive> domainobject, SqlCommand command)
        {
            command.AddParameter("@UserId", domainobject.ReadByUserId);
            command.AddParameter("@DirectiveId", domainobject.ItemId);
            command.AddParameter("@DateTime", domainobject.Time);
        }
        
        private static ItemRead<Directive> PopulateInstance(SqlDataReader reader)
        {
            long directiveId = reader.Get<long>("DirectiveId");
            long userId = reader.Get<long>("UserId");
            DateTime dateTime = reader.Get<DateTime>("DateTime");

            return new ItemRead<Directive>(directiveId, userId, dateTime);
        }

        public void ConvertMarkedAsReadInformation(long fromLogId, long toDirectiveId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FromLogId", fromLogId);
            command.AddParameter("@ToDirectiveId", toDirectiveId);
            command.ExecuteNonQuery("ConvertMarkedAsReadInformationFromLogToDirective");
        }

    }
}