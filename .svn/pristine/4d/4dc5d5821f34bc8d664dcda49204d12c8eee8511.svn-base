using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GasTestElementDao : AbstractManagedDao, IGasTestElementDao
    {
        public static string INSERT_GAS_TEST_ELEMENT = "InsertGasTestElement";
        public static string UPDATE_GAS_TEST_ELEMENT = "UpdateGasTestElement";
        public static string REMOVE_GAS_TEST_ELEMENT = "RemoveGasTestElement";
        public static string QUERY_ALL_GAS_TEST_ELEMENT_BY_WORK_PERMIT_ID = "QueryAllGasTestElementByWorkPermitId";

// Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue

        public static string INSERT_GAS_TEST_ELEMENT_FOR_SELC = "InsertGasTestElementForSELC";
        public static string QUERY_ALL_GAS_TEST_ELEMENT_BY_WORK_PERMIT_ID_FOR_SELC = "QueryAllGasTestElementByWorkPermitIdForSELC";
        public static string REMOVE_GAS_TEST_ELEMENT_FOR_SELC = "RemoveGasTestElementForSELC";
        public static string UPDATE_GAS_TEST_ELEMENT_FOR_SELC = "UpdateGasTestElementForSELC";

        private readonly IGasTestElementInfoDao gasTestElementInfoDao;

        public GasTestElementDao()
        {
            gasTestElementInfoDao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
        }

        public GasTestElement Insert(GasTestElement gasTestElement, long workPermitId)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            // I am not sure if we should be saving GasTestElementInfo here.
            // Shouldn't it have been saved elsewhere?
            if (gasTestElement.ElementInfo.Id.HasNoValue())
            {
                gasTestElementInfoDao.Insert(gasTestElement.ElementInfo);
            }

            long elementInfoId = gasTestElement.ElementInfo.IdValue;
            command.AddParameter("@GasTestElementInfoId", elementInfoId);
            command.AddParameter("@WorkPermitId", workPermitId);

            if (gasTestElement.ElementInfo.Site.id == Site.SELC_ID) // Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue
            {
                command.Insert(gasTestElement, AddInsertParameters, INSERT_GAS_TEST_ELEMENT_FOR_SELC);
            }
            else
            {
                command.Insert(gasTestElement, AddInsertParameters, INSERT_GAS_TEST_ELEMENT);
            }
            
            gasTestElement.Id = long.Parse(idParameter.Value.ToString());
            return gasTestElement;
        }

        public void Update(GasTestElement gasTestElement)
        {
            SqlCommand command = ManagedCommand;

            if (gasTestElement.ElementInfo.IsStandard == false && gasTestElement.ElementInfo.Id.HasValue)
            {
                gasTestElementInfoDao.Update(gasTestElement.ElementInfo);
            }

            if (gasTestElement.ElementInfo.Site.id == Site.SELC_ID) // Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue
            {
                command.Update(gasTestElement, AddUpdateParameters, UPDATE_GAS_TEST_ELEMENT_FOR_SELC);
            }
            else
            {
                command.Update(gasTestElement, AddUpdateParameters, UPDATE_GAS_TEST_ELEMENT);
            }
            
        }

        public List<GasTestElement> QueryAllGasTestElementByWorkPermitIdAndSiteId(long workPermitId,long siteid)         //ayman USPipeline workpermit
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", workPermitId);
            command.AddParameter("@SiteId", siteid);

            if (siteid == Site.SELC_ID) // Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue
            {
                return command.QueryForListResult<GasTestElement>(PopulateInstance, QUERY_ALL_GAS_TEST_ELEMENT_BY_WORK_PERMIT_ID_FOR_SELC);
            }
            else
            {
                return command.QueryForListResult<GasTestElement>(PopulateInstance, QUERY_ALL_GAS_TEST_ELEMENT_BY_WORK_PERMIT_ID);
            }

            
        }

        public void Remove(GasTestElement element)
        {
            if (element.IsInDatabase())
            {
                if (element.ElementInfo.Site.id == Site.SELC_ID) // Added by Vibhor : RITM0630157 - to fix SELC foreign key constraint issue
                {
                    ManagedCommand.Remove(element.IdValue, REMOVE_GAS_TEST_ELEMENT_FOR_SELC);
                }
                else
                {
                    ManagedCommand.Remove(element.IdValue, REMOVE_GAS_TEST_ELEMENT);
                }
                
            }
        }

        private GasTestElement PopulateInstance(SqlDataReader reader)
        {
            var result = new GasTestElement
                             {
                                 Id = (reader.Get<long>("Id")),
                                 ImmediateAreaTestRequired = (reader.Get<bool>("RequiredTest")),
                                 ImmediateAreaTestResult = (reader.Get<double?>("FirstTestResult")),
                                 ConfinedSpaceTestResult = (reader.Get<double?>("ConfinedSpaceTestResult")),
                                 ConfinedSpaceTestRequired = (reader.Get<bool>("ConfinedSpaceTestRequired")),
                                 SystemEntryTestResult = (reader.Get<double?>("SystemEntryTestResult")),
                                 SystemEntryTestNotApplicable = (reader.Get<bool>("SystemEntryTestNotApplicable")),
                                 ElementInfo =
                                     gasTestElementInfoDao.QueryById(reader.Get<long>("GasTestElementInfoId"))
                             };

            return result;
        }

        private static void AddInsertParameters(GasTestElement gasTestElement, SqlCommand command)
        {
            SetCommonAttributes(gasTestElement, command);
        }

        private static void AddUpdateParameters(GasTestElement gasTestElement, SqlCommand command)
        {
            command.AddParameter("@Id", gasTestElement.Id);
            SetCommonAttributes(gasTestElement, command);
        }

        private static void SetCommonAttributes(GasTestElement gasTestElement, SqlCommand command)
        {
            command.AddParameter("@RequiredTest", gasTestElement.ImmediateAreaTestRequired);
            command.AddParameter("@FirstTestResult", gasTestElement.ImmediateAreaTestResult);
            command.AddParameter("@ConfinedSpaceTestResult", gasTestElement.ConfinedSpaceTestResult);
            command.AddParameter("@ConfinedSpaceTestRequired", gasTestElement.ConfinedSpaceTestRequired);
            command.AddParameter("@SystemEntryTestResult", gasTestElement.SystemEntryTestResult);
            command.AddParameter("@SystemEntryTestNotApplicable", gasTestElement.SystemEntryTestNotApplicable);
        }

        public GasTestElement InsertMuds(GasTestElement gasTestElement, long workPermitId)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            // I am not sure if we should be saving GasTestElementInfo here.
            // Shouldn't it have been saved elsewhere?
            if (gasTestElement.ElementInfo.Id.HasNoValue())
            {
                gasTestElementInfoDao.Insert(gasTestElement.ElementInfo);
            }

            long elementInfoId = gasTestElement.ElementInfo.IdValue;
            command.AddParameter("@GasTestElementInfoId", elementInfoId);
            command.AddParameter("@WorkPermitId", workPermitId);

            command.AddParameter("@FirstRequiredTest", gasTestElement.ImmediateAreaTestRequired);
            command.AddParameter("@FirstTestResult", gasTestElement.ImmediateAreaTestResult);

            command.AddParameter("@SecondTestResult", gasTestElement.ConfinedSpaceTestResult);
            command.AddParameter("@SecondRequiredTest", gasTestElement.ConfinedSpaceTestRequired);

            command.AddParameter("@ThirdTestResult", gasTestElement.ThirdTestResult);
            command.AddParameter("@ThirdRequiredTest", gasTestElement.ThirdTestRequired);

            command.AddParameter("@FourthTestResult", gasTestElement.FourthTestResult);
            command.AddParameter("@FourthRequiredTest", gasTestElement.FourthTestRequired);
                       

            command.Insert("InsertGasTestElementMUDS");
            gasTestElement.Id = long.Parse(idParameter.Value.ToString());
            return gasTestElement;
        }


        public List<GasTestElement> QueryAllGasTestElementByWorkPermitIdMuds(long workPermitId, long siteid)         //for Muds
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", workPermitId);
            command.AddParameter("@SiteId", siteid);
            return command.QueryForListResult<GasTestElement>(PopulateInstanceMuds, "QueryAllGasTestElementByWorkPermitMudsId");
        }

        public void UpdateMuds(GasTestElement gasTestElement)
        {
          
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", gasTestElement.Id);
            command.AddParameter("@FirstRequiredTest", gasTestElement.ImmediateAreaTestRequired);
            command.AddParameter("@FirstTestResult", gasTestElement.ImmediateAreaTestResult);

            command.AddParameter("@SecondTestResult", gasTestElement.ConfinedSpaceTestResult);
            command.AddParameter("@SecondRequiredTest", gasTestElement.ConfinedSpaceTestRequired);

            command.AddParameter("@ThirdTestResult", gasTestElement.ThirdTestResult);
            command.AddParameter("@ThirdRequiredTest", gasTestElement.ThirdTestRequired);

            command.AddParameter("@FourthTestResult", gasTestElement.FourthTestResult);
            command.AddParameter("@FourthRequiredTest", gasTestElement.FourthTestRequired);


            command.Update("UpdateGasTestElementMUDS");
        }

        private GasTestElement PopulateInstanceMuds(SqlDataReader reader)
        {
            var result = new GasTestElement
            {
                Id = (reader.Get<long>("Id")),
                ImmediateAreaTestRequired = (reader.Get<bool>("FirstRequiredTest")),
                ImmediateAreaTestResult = (reader.Get<double?>("FirstTestResult")),
                ConfinedSpaceTestResult = (reader.Get<double?>("SecondTestResult")),
                ConfinedSpaceTestRequired = (reader.Get<bool>("SecondRequiredTest")),
                ThirdTestResult = (reader.Get<double?>("ThirdTestResult")),
                ThirdTestRequired = (reader.Get<bool>("ThirdRequiredTest")),
                FourthTestResult = (reader.Get<double?>("FourthTestResult")),
                FourthTestRequired = (reader.Get<bool>("FourthRequiredTest")),
                ElementInfo =
                    gasTestElementInfoDao.QueryById(reader.Get<long>("GasTestElementInfoId"))
            };

            return result;
        }


    }
}