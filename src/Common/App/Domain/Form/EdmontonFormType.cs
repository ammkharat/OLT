using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public static class EdmontonFormTypeName
    {
        public static long EdmontonFormTypeSite = 0;

    }

    [Serializable]
    public class EdmontonFormType : SortableSimpleDomainObject, IMultiGridContextSelection
    {
        //ayman generic forms
        
        
        public static EdmontonFormType GN7 = new EdmontonFormType(1, StringResources.Multigrid_Category_Forms, 3);
        public static EdmontonFormType GN59 = new EdmontonFormType(2, StringResources.Multigrid_Category_Forms, 5);
        public static EdmontonFormType OP14 = new EdmontonFormType(3, StringResources.Multigrid_Category_Forms, 8);
        public static EdmontonFormType GN24 = new EdmontonFormType(4, StringResources.Multigrid_Category_Forms, 4);
        public static EdmontonFormType GN6 = new EdmontonFormType(5, StringResources.Multigrid_Category_Forms, 2);
        public static EdmontonFormType GN75A = new EdmontonFormType(6, StringResources.Multigrid_Category_Forms, 6);
        public static EdmontonFormType GN75B = new EdmontonFormType(7, StringResources.Multigrid_Category_Forms, 7);
        public static EdmontonFormType GN1 = new EdmontonFormType(8, StringResources.Multigrid_Category_Forms, 1);
        public static EdmontonFormType Overtime = new EdmontonFormType(9, StringResources.Multigrid_Category_Forms, 9);
        public static EdmontonFormType LubesCsd = new EdmontonFormType(10, StringResources.Multigrid_Category_Forms, 1);

        public static EdmontonFormType MontrealCsd = new EdmontonFormType(11, StringResources.Multigrid_Category_Forms,1);

        public static EdmontonFormType LubesAlarmDisable = new EdmontonFormType(12,StringResources.Multigrid_Category_Forms, 2);

        public static EdmontonFormType OilsandsPermitAssessment = new EdmontonFormType(13,StringResources.Multigrid_Category_Forms, 2);

        public static EdmontonFormType DocumentSuggestion = new EdmontonFormType(14,StringResources.Multigrid_Category_Forms, 1);

        public static EdmontonFormType ProcedureDeviation = new EdmontonFormType(15,StringResources.Multigrid_Category_Forms, 1);
 public static EdmontonFormType TemporaryInstallationsMuds = new EdmontonFormType(16, StringResources.Multigrid_Category_Forms, 1); //RITM0268131 - mangesh
        //ayman Sarnia eip DMND0008992
        public static EdmontonFormType GN75BTemplate = new EdmontonFormType(17, StringResources.Multigrid_Category_Forms,1);
        public static EdmontonFormType GN75BSarniaEIP = new EdmontonFormType(18, StringResources.Multigrid_Category_Forms, 1);
       

        //generictemplate - mangesh
        public static EdmontonFormType OdourNoiseComplaint = new EdmontonFormType(1001, StringResources.Multigrid_Category_Forms, 11);
        public static EdmontonFormType Deviation = new EdmontonFormType(1002, StringResources.Multigrid_Category_Forms, 12);
        public static EdmontonFormType RoadClosure = new EdmontonFormType(1003, StringResources.Multigrid_Category_Forms, 13);
        public static EdmontonFormType GN11GroundDisturbance = new EdmontonFormType(1004, StringResources.Multigrid_Category_Forms, 14);
        public static EdmontonFormType GN27FreezePlug = new EdmontonFormType(1005, StringResources.Multigrid_Category_Forms, 15);
        public static EdmontonFormType HazardAssessment = new EdmontonFormType(1006, StringResources.Multigrid_Category_Forms, 16);
        
        //TASK0593631 - mangesh
        public static EdmontonFormType NonEmergencyWaterSystemApproval = new EdmontonFormType(1009, StringResources.Multigrid_Category_Forms, 19);

        //RITM0341710 - mangesh
        public static EdmontonFormType FortHillOilSample = new EdmontonFormType(1007, StringResources.Multigrid_Category_Forms, 17);
        public static EdmontonFormType FortHillDailyInspection = new EdmontonFormType(1008, StringResources.Multigrid_Category_Forms, 18);

        public static readonly EdmontonFormType[] all =
        {
            GN7, GN59, OP14, GN24, GN6, GN75A, GN75B, GN1, Overtime,
            LubesCsd, MontrealCsd, LubesAlarmDisable, OilsandsPermitAssessment, 
            DocumentSuggestion, ProcedureDeviation  
         ,TemporaryInstallationsMuds //RITM0268131 - mangesh           
 //generictemplate - mangesh
            ,OdourNoiseComplaint,Deviation,RoadClosure,GN11GroundDisturbance,GN27FreezePlug,HazardAssessment,GN75BTemplate,GN75BSarniaEIP           //ayman Sarnia eip DMND0008992
             
            //RITM0341710 - mangesh
             , FortHillOilSample, FortHillDailyInspection
             
             //TASK0593631 - mangesh
             , NonEmergencyWaterSystemApproval
        };

        private EdmontonFormType(long id, string category, int sortOrder) : base(id, sortOrder)
        {
            Category = category;
        }

        public static List<EdmontonFormType> All
        {
            get { return new List<EdmontonFormType>(all); }
        }

        public string Category { get; private set; }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.FormType_GN7;
            }
            if (IdValue == 2)
            {
                return StringResources.FormType_GN59;
            }
            
            if (IdValue == 3)
            {
                switch (EdmontonFormTypeName.EdmontonFormTypeSite)
                {
                    case 1:
                        return StringResources.FormType_SarniaOP14;
                        break;
                    case 8:
                        return StringResources.FormType_OP14;
                        break;
                    case 13:
                        return StringResources.FormType_SelcOP14;
                        break;
                    case 12:
                        return StringResources.FormType_GenericOP14;
                        break;
                    case 0:
                        return StringResources.FormType_OP14;
                        break;
                }
            }
            if (IdValue == 4)
            {
                return StringResources.FormType_GN24;
            }
            if (IdValue == 5)
            {
                return StringResources.FormType_GN6;
            }
            if (IdValue == 6)
            {
                return StringResources.FormType_GN75A;
            }
            if (IdValue == 7)
            {
                return StringResources.FormType_GN75B;
                //switch (EdmontonFormTypeName.EdmontonFormTypeSite)
                //{
                //    case 1:
                //        return StringResources.FormType_SarniaGN75BForm;              //ayman Sarnia eip DMND0008992
                //        break;
                //    case 8:
                //        return StringResources.FormType_GN75B;
                //        break;
                //    case 0:
                //        return StringResources.FormType_GN75B;
                //        break;
                //}
            }
            if (IdValue == 8)
            {
                return StringResources.FormType_GN1;
            }
            if (IdValue == 9)
            {
                return StringResources.FormType_Overtime;
            }
            if (IdValue == 10)
            {
                return StringResources.FormType_LubesCsd;
            }
            if (IdValue == 11)
            {
                return StringResources.FormType_MontrealCsd;
            }
            if (IdValue == 12)
            {
                return StringResources.FormType_LubesAlarmDisable;
            }
            if (IdValue == 13)
            {
                return StringResources.FormType_OilsandsPermitAssessment;
            }
            if (IdValue == 14)
            {
                return StringResources.FormType_DocumentSuggestion;
            }
            if (IdValue == 15)
            {
                return StringResources.FormType_ProcedureDeviation;
            }
    //RITM0268131 - mangesh
            if (IdValue == 16)
            {
                return StringResources.FormType_MontrealSulphurTemporaryInstallations;
            }
            //ayman Sarnia eip DMND0008992
            if (IdValue == 17)
            {
                return StringResources.FormType_SarniaGN75BTemplate;
            }
            if (IdValue == 18)
            {
                return StringResources.FormType_SarniaGN75BForm;
            }

            //generic template - mangesh

            if (IdValue == 1001)
            {
                return StringResources.FormType_OdourNoiseComplaint;
            }
            if (IdValue == 1002)
            {
                return StringResources.FormType_Deviation;
            }
            if (IdValue == 1003)
            {
                return StringResources.FormType_RoadClosure;
            }
            if (IdValue == 1004)
            {
                return StringResources.FormType_GN11GroundDisturbance;
            }
            if (IdValue == 1005)
            {
                return StringResources.FormType_GN27FreezePlug;
            }
            if (IdValue == 1006)
            {
                return StringResources.FormType_HazardAssessment;
            }
            //TASK0593631 - mangesh
            if (IdValue == 1009)
            {
                return StringResources.FormType_NonEmergencyWaterSystemApproval;
            }
            //--------
            //RITM0341710 - mangesh
            if (IdValue == 1007)
            {
                return StringResources.FormType_OilSample;
            }
            if (IdValue == 1008)
            {
                return StringResources.FormType_DailyInspection;
            }
            //--------
             
            return null;
        }

        private void elseif(bool p)
        {
            throw new NotImplementedException();
        }

        public static EdmontonFormType GetById(long id)
        {
            return GetById(id, all);
        }
    }
}