using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class PermitRequestMudsDTODao : AbstractManagedDao, IPermitRequestMudsDTODao
    {
        private const string QUERY_BY_FLOC_STORED_PROCEDURE = "QueryPermitRequestMudsDTOsByFlocUnitAndBelow";
        private const string QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE = "QueryPermitRequestTemplateDto";

        public List<PermitRequestMudsDTO> QueryByFlocUnitAndBelow(
                   IFlocSet flocSet, DateRange dateRange)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@FlocIds", flocids);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return GetDtos(command, QUERY_BY_FLOC_STORED_PROCEDURE);
        }

        

        private static List<PermitRequestMudsDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, PermitRequestMudsDTO> result = new Dictionary<long, PermitRequestMudsDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        PermitRequestMudsDTO dto = result[id];
                        string functionalLocationFullHierarchy = reader.Get<string>("FunctionalLocationName");
                        dto.AddFunctionalLocation(functionalLocationFullHierarchy);
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<PermitRequestMudsDTO>(result.Values);
        }

        private static List<PermitRequestMudsDTO> GetTemplateDtos(SqlCommand command, string query)
        {
            Dictionary<long, PermitRequestMudsDTO> result = new Dictionary<long, PermitRequestMudsDTO>();
            List<string> ctg = new List<string>();
            List<string> temp = new List<string>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        int count = 0;
                        int count1 = 0;
                        string tempName = reader.Get<string>("TemplateName");
                        string catg = reader.Get<string>("Categories");

                        if (result.ContainsKey(id))
                        {
                            foreach (var item in temp)
                            {
                                if (item == tempName)
                                {
                                    count++;
                                }
                            }
                            foreach (var item in ctg)
                            {
                                if (item == catg)
                                {
                                    count1++;
                                }
                            }

                            if (count > 0 && count1 > 0)
                            {
                                result.Add(id, PopulateInstanceForTemplate(reader));

                                PermitRequestMudsDTO dto = result[id];
                                string functionalLocationFullHierarchy = reader.Get<string>("FunctionalLocationName");

                                dto.AddFunctionalLocation(functionalLocationFullHierarchy); 

                            }
                            else
                            {
                                PermitRequestMudsDTO dto = result[id];
                                string functionalLocationFullHierarchy = reader.Get<string>("FunctionalLocationName");

                                dto.AddFunctionalLocation(functionalLocationFullHierarchy); 
                            }
                            ctg.Add(catg);
                            temp.Add(tempName);

                        }

                        //PermitRequestMudsDTO dto = result[id];
                        //string functionalLocationFullHierarchy = reader.Get<string>("FunctionalLocationName");
                        
                        //    dto.AddFunctionalLocation(functionalLocationFullHierarchy);
                        
                    }
                    else
                    {
                        result.Add(id, PopulateInstanceForTemplate(reader));
                    }
                }
            }

            return new List<PermitRequestMudsDTO>(result.Values);
        }

        private static PermitRequestMudsDTO PopulateInstance(SqlDataReader reader)
        {
            PermitRequestMudsDTO permitRequest = new PermitRequestMudsDTO(
                reader.Get<long>("Id"),
                WorkPermitMudsType.Get(reader.Get<int>("WorkPermitTypeId")),
                new List<string> { reader.Get<string>("FunctionalLocationName") },
                new Date(reader.Get<DateTime>("StartDate")),
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("OperationNumber"),
                reader.Get<string>("Trade"),
                reader.Get<string>("RequestedByGroup"),
                reader.Get<string>("Description"),
                DataSource.GetById(reader.Get<int>("SourceId")),
                reader.GetUser("LastImportedByFirstName", "LastImportedByLastName", "LastImportedByUserName"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                 reader.GetUser("LastSubmittedByFirstName", "LastSubmittedByLastName", "LastSubmittedByUserName"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                reader.Get<long>("CreatedByUserId"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId")),
                reader.Get<string>("NbTravail"), reader.Get<bool>("FormationCheck"), reader.Get<string>("NomsEnt"), 
                reader.Get<string>("NomsEnt_1"), reader.Get<string>("NomsEnt_2"), reader.Get<string>("NomsEnt_3"), reader.Get<string>("Surveilant"),
                reader.Get<DateTime>("StartDateTime"), reader.Get<DateTime>("EndDateTime"),
                reader.Get<bool>("Analyse_Attribute_CheckBox"), reader.Get<bool>("Cadenassage_multiple_Attribute_CheckBox"), reader.Get<bool>("Cadenassage_simple_Attribute_CheckBox"),
                reader.Get<bool>("Procédure_Attribute_CheckBox"), reader.Get<bool>("Espace_clos_Attribute_CheckBox")
                
                );// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            return permitRequest;
        }


        public List<PermitRequestMudsDTO> QueryByFlocUnitAndBelowForTemplate(
                   IFlocSet flocSet, DateRange dateRange, string username)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;
            //command.AddParameter("@FlocIds", flocids);
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);
            
            return command.QueryForListResult<PermitRequestMudsDTO>(PopulateInstanceForTemplate, QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE);
           // return GetTemplateDtos(command, QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE);
        }

        private static PermitRequestMudsDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {
            PermitRequestMudsDTO permitRequest = new PermitRequestMudsDTO(
              reader.Get<long>("Id"),
              reader.Get<string>("TemplateName"),
              reader.Get<string>("Categories"),
              reader.Get<string>("WorkPermitType"),
              reader.Get<string>("Description"),
              reader.Get<bool>("Global"),
              reader.Get<long>("TemplateId")
              //new List<string> { reader.Get<string>("FunctionalLocationName") }
              );
            return permitRequest;

        }
    }
}
