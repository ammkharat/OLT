using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;


namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormEdmontonGN75BDTODao : AbstractManagedDao, IFormEdmontonGN75BDTODao
    {
        private const string QueryDtos = "QueryFormEdmontonGN75BDTO";
        private const string QuerySarniaFormDtos = "QueryFormSarniaGN75BDTO";       //ayman Sarnia eip DMND0008992
        private const string QueryTemplateDtos = "QueryFormSarniaGN75BTemplateDTO";         //ayman Sarnia eip DMND0008992
        private const string QueryDtoById = "QueryFormEdmontonGN75BDTOById";

        public List<FormEdmontonGN75BDTO> QueryDTOs(IFlocSet flocSet, List<FormStatus> formStatuses,long siteId)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            managedCommand.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            managedCommand.AddParameter("@siteid",siteId);

            return managedCommand.QueryForListResult<FormEdmontonGN75BDTO>(PopulateInstance, QueryDtos);        
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTOforPriorityScreen> QuerySarniaFormDTOsForPriorityScreen(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            managedCommand.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            managedCommand.AddParameter("@siteid", siteId);

            return managedCommand.QueryForListResult<FormEdmontonGN75BDTOforPriorityScreen>(PopulateSarniaFormInstanceForPriorityScreen, QuerySarniaFormDtos);
        }


        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QuerySarniaFormDTOs(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            managedCommand.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            managedCommand.AddParameter("@siteid", siteId);

            return managedCommand.QueryForListResult<FormEdmontonGN75BDTO>(PopulateSarniaFormInstance, QuerySarniaFormDtos);
        }


        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryTemplateDTOs(IFlocSet flocSet, List<FormStatus> formStatuses)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            managedCommand.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());

            return managedCommand.QueryForListResult<FormEdmontonGN75BDTO>(PopulateInstance, QueryTemplateDtos);
        }


        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryApprovedTemplateDTOs(long templateid, long siteid)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@id", templateid);
            managedCommand.AddParameter("@siteid", siteid);

            return managedCommand.QueryForListResult<FormEdmontonGN75BDTO>(PopulateEipTemplateInstance, "QueryTemplateByIDToShowApprovedByHowManyeipforms");
        }


        public FormEdmontonGN75BDTO QueryById(long id)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("@Id", id);

            return managedCommand.QueryForSingleResult<FormEdmontonGN75BDTO>(PopulateInstance, QueryDtoById);
        }

        private FormEdmontonGN75BDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            string functionalLocation = reader.Get<string>("FunctionalLocationName");
            string location = reader.Get<string>("Location");
            
            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
                        
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            bool deleted = reader.Get<bool>("Deleted");
            long templateid = reader.Get<long>("templateid");              //ayman Sarnia eip DMND0008992

            return new FormEdmontonGN75BDTO(id, formStatus, functionalLocation, location, equipmentType, lockBoxNumber, createdByUserId, createdByFullNameWithUserName, lastModifiedByUserId,
                                            lastModifiedByFullNameWithUserName, createdDateTime, closedDateTime, lastModifiedDateTime, deleted,templateid);         //ayman Sarnia eip DMND0008992
        }


        //ayman Sarnia eip DMND0008992
        private FormEdmontonGN75BDTOforPriorityScreen PopulateSarniaFormInstanceForPriorityScreen(SqlDataReader reader)
        {

             
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            string functionalLocation = reader.Get<string>("FunctionalLocationName");
            string location = reader.Get<string>("Location");

            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            bool deleted = reader.Get<bool>("Deleted");
            long templateid = reader.Get<long>("templateid");  //ayman Sarnia eip DMND0008992
            DateTime? fromDateTime = null;
            DateTime? toDateTime = null;

            return new FormEdmontonGN75BDTOforPriorityScreen(id, functionalLocation, EdmontonFormType.GN75BSarniaEIP ,id,location, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId,
                                           lastModifiedDateTime, createdDateTime, lastModifiedDateTime, formStatus, null, closedDateTime, null);         //ayman Sarnia eip DMND0008992
        }



        //ayman Sarnia eip DMND0008992
        private FormEdmontonGN75BDTO PopulateSarniaFormInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            string functionalLocation = reader.Get<string>("FunctionalLocationName");
            string location = reader.Get<string>("Location");

            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");
            bool blindsRequired = reader.Get<bool>("BlindsRequired");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            bool deleted = reader.Get<bool>("Deleted");
            long templateid = reader.Get<long>("templateid");              //ayman Sarnia eip DMND0008992

            return new FormEdmontonGN75BDTO(id, formStatus, functionalLocation, location, equipmentType, lockBoxNumber, createdByUserId, createdByFullNameWithUserName, lastModifiedByUserId,
                                            lastModifiedByFullNameWithUserName, createdDateTime, closedDateTime, lastModifiedDateTime, deleted, templateid);         //ayman Sarnia eip DMND0008992
        }


        //ayman Sarnia eip DMND0008992
        private FormEdmontonGN75BDTO PopulateEipTemplateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            string functionalLocation = reader.Get<long>("FunctionalLocationId").ToString();
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            bool deleted = reader.Get<bool>("Deleted");

            string location = "";

            string equipmentType = reader.Get<string>("EquipmentType");
            string lockBoxNumber = reader.Get<string>("LockBoxNumber");



            string createdByFullNameWithUserName = ""; // reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            string lastModifiedByFullNameWithUserName = ""; // reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");



            
            long templateid = reader.Get<long>("templateid");              //ayman Sarnia eip DMND0008992

            return new FormEdmontonGN75BDTO(id, formStatus, functionalLocation, location, equipmentType, lockBoxNumber, createdByUserId, createdByFullNameWithUserName, lastModifiedByUserId,
                                            lastModifiedByFullNameWithUserName, createdDateTime, closedDateTime, lastModifiedDateTime, deleted, templateid);         //ayman Sarnia eip DMND0008992
        }

    }
}