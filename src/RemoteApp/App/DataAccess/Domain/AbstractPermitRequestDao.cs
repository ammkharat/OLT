﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public abstract class AbstractPermitRequestDao<T> : AbstractManagedDao where T : BasePermitRequest
    {
        protected readonly IFunctionalLocationDao functionalLocationDao;
        protected readonly IUserDao userDao;

        protected AbstractPermitRequestDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected abstract string QueryByIdStoredProcedure { get; }
        protected abstract string QueryByWorkOrderAndOperationAndSourceStoredProcedure { get; }
        protected abstract string QueryByDateRangeAndDataSourceStoredProcedure { get; }
        protected abstract string InsertStoredProcedure { get; }
        protected abstract string UpdateStoredProcedure { get; }
        protected abstract string RemoveStoredProcedure { get; }
        protected abstract string InsertPermitAttributeAssociationStoredProcedure { get; }
        protected abstract string DeletePermitAttributeStoredProcedure { get; }
        protected abstract string QueryLastImportDateTimeStoredProcedure { get; }        

        public T QueryById(long id)
        {
            return ManagedCommand.QueryById<T>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public List<T> QueryByWorkOrderNumberAndOperationAndSource(string workOrderNumber, string operationNumber, string subOperationNumber, DataSource dataSource)
        {
            SqlCommand command = ManagedCommand;            

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);

            command.AddParameter("@SourceId", dataSource.IdValue);

            List<T> result = command.QueryForListResult<T>(PopulateInstance, QueryByWorkOrderAndOperationAndSourceStoredProcedure);

            return result;            
        }

        public List<T> QueryByDateRangeAndDataSource(Date fromDate, Date toDate, DataSource dataSource)
        {
            SqlCommand command = ManagedCommand;

            DateRange dateRange = new DateRange(fromDate, toDate);

            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);
            command.AddParameter("@DataSourceId", dataSource.IdValue);

            return command.QueryForListResult<T>(PopulateInstance, QueryByDateRangeAndDataSourceStoredProcedure);
        }

        protected abstract T BuildPermitRequest(SqlDataReader reader);

        protected T PopulateInstance(SqlDataReader reader)
        {
            T permitRequest = BuildPermitRequest(reader);            
            return permitRequest;
        }

        protected User GetUser(SqlDataReader reader, string userIdColumn)
        {
            User user = null;
            {
                long? userid = reader.Get<long?>(userIdColumn);
                if (userid.HasValue)
                {
                    user = userDao.QueryById(userid.Value);
                }
            }
            return user;
        }

        public T Insert(T permitRequest)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(permitRequest, AddInsertParameters, InsertStoredProcedure);
            permitRequest.Id = (long?)idParameter.Value;

            InsertPermitWorkOrderSources(command, permitRequest);
            InsertPermitAttributes(command, permitRequest);
            InsertFunctionalLocations(command, permitRequest);
            InsertDocumentLinks(command, permitRequest);
            UpdateWorkAssignmentAutoTagAssociations(permitRequest);

            return permitRequest;
        }

        protected virtual void AddInsertParameters(T permitRequest, SqlCommand command)
        {
            command.AddParameter("@CreatedByUserId", permitRequest.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", permitRequest.CreatedDateTime);
            command.AddParameter("@SourceId", permitRequest.DataSource.IdValue);
            SetInsertUpdateAttributes(permitRequest, command);
        }

        protected abstract void InsertFunctionalLocations(SqlCommand command, T permitRequest);
        protected abstract void UpdateFunctionalLocations(SqlCommand command, T permitRequest);
        protected abstract void InsertDocumentLinks(SqlCommand command, T permitRequest);
        protected abstract void RemoveDocumentLinks(SqlCommand command, T permitRequest);
        
        public void Update(T permitRequest)
        {
            SqlCommand command = ManagedCommand;
            command.Update(permitRequest, AddUpdateParameters, UpdateStoredProcedure);

            DeletePermitWorkOrderSources(command, permitRequest);
            InsertPermitWorkOrderSources(command, permitRequest);
            DeletePermitAttributes(command, permitRequest);
            InsertPermitAttributes(command, permitRequest);
            UpdateFunctionalLocations(command, permitRequest);
            RemoveDocumentLinks(command, permitRequest);
            InsertDocumentLinks(command, permitRequest);
            UpdateWorkAssignmentAutoTagAssociations(permitRequest);
        }

        protected virtual void DeletePermitWorkOrderSources(SqlCommand command, T permitRequest)
        {            
        }

        protected virtual void InsertPermitWorkOrderSources(SqlCommand command, T permitRequest)
        {            
        }

        protected virtual void InsertPermitAttributes(SqlCommand command, T permitRequest)
        {            
        }

        protected virtual void DeletePermitAttributes(SqlCommand command, T permitRequest)
        {            
        }

        protected virtual void UpdateWorkAssignmentAutoTagAssociations(T permitRequest)
        {
            ;
        }

        private void AddUpdateParameters(T permitRequest, SqlCommand command)
        {
            command.AddParameter("@Id", permitRequest.Id);
            SetInsertUpdateAttributes(permitRequest, command);
        }

        protected virtual void SetInsertUpdateAttributes(T permitRequest, SqlCommand command)
        {            
            command.AddParameter("@EndDate", permitRequest.EndDate.ToDateTimeAtStartOfDay());
            
            command.AddParameter("@Description", permitRequest.Description);
            command.AddParameter("@SapDescription", permitRequest.SapDescription);

            command.AddParameter("@Company", permitRequest.Company);
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            if (permitRequest.FunctionalLocationNamesAsString.StartsWith("UDS"))
            {
                command.AddParameter("@Company_1", permitRequest.Company_1);
                command.AddParameter("@Company_2", permitRequest.Company_2);
               
            }

            if (permitRequest.LastImportedByUser != null)
            {
                command.AddParameter("@LastImportedByUserId", permitRequest.LastImportedByUser.IdValue);
            }
            if (permitRequest.LastImportedDateTime.HasValue)
            {
                command.AddParameter("@LastImportedDateTime", permitRequest.LastImportedDateTime);
            }
            if (permitRequest.LastSubmittedByUser != null)
            {
                command.AddParameter("@LastSubmittedByUserId", permitRequest.LastSubmittedByUser.IdValue);
            }
            if (permitRequest.LastSubmittedDateTime.HasValue)
            {
                command.AddParameter("@LastSubmittedDateTime", permitRequest.LastSubmittedDateTime);
            }

            command.AddParameter("@LastModifiedByUserId", permitRequest.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", permitRequest.LastModifiedDateTime);

            command.AddParameter("@IsModified", permitRequest.IsModified);
        }

        public void Remove(T permitRequest)
        {
            ManagedCommand.ExecuteNonQuery(permitRequest, RemoveStoredProcedure, AddRemoveParameters);            
        }

        private static void AddRemoveParameters(T permitRequest, SqlCommand command)
        {
            command.AddParameter("@Id", permitRequest.Id);
            command.AddParameter("@LastModifiedByUserId", permitRequest.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", permitRequest.LastModifiedDateTime);            
        }

        public DateTime? QueryLastImportDateTime()
        {
            return ManagedCommand.QueryForSingleResult<DateTime?>(PopulateImportDateTime, QueryLastImportDateTimeStoredProcedure);
        }

        private static DateTime? PopulateImportDateTime(SqlDataReader reader)
        {
            DateTime? result = reader.Get<DateTime?>("LastImportedDateTime");
            return result;
        }
    }
}