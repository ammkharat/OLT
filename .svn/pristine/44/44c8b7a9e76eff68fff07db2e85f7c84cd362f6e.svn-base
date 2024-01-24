using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ApprovalShouldBeEnabledBehaviour : SimpleDomainObject
    {
        public static ApprovalShouldBeEnabledBehaviour Always = new ApprovalShouldBeEnabledBehaviour(1);
        public static ApprovalShouldBeEnabledBehaviour OP14PressureSafetyValve = new ShouldBeEnabledBehaviourOp14PSV(2);

        public static ApprovalShouldBeEnabledBehaviour TenDayValidity = new ShouldBeEnabledBehaviourTenDays(3);

        public static ApprovalShouldBeEnabledBehaviour SevenDayValidity = new ShouldBeEnabledBehaviourSevenDays(4);

        public static ApprovalShouldBeEnabledBehaviour LubesCsdPressureSafetyValve =
            new ShouldBeEnabledBehaviourLubesCsdPSV(5);

        public static ApprovalShouldBeEnabledBehaviour MontrealCsdPressureSafetyValve =
            new ShouldBeEnabledBehaviourMontrealCsdPSV(6);

        public static ApprovalShouldBeEnabledBehaviour ThreeDayValidity = new ShouldBeEnabledBehaviourThreeDays(7);

        public static ApprovalShouldBeEnabledBehaviour FiveDayValidity = new ShouldBeEnabledBehaviourFiveDays(8);

        public static ApprovalShouldBeEnabledBehaviour FiveDayDefeatedValidity =
            new ShouldBeEnabledBehaviourSystemDefeatedFiveDays(9);

        public static ApprovalShouldBeEnabledBehaviour ThreeDayValidityNoPressureSafetyValue =
            new ShouldBeEnabledBehaviourSystemDefeatedThreeDaysNoPressureSafetyValve(10);

        public static ApprovalShouldBeEnabledBehaviour MontrealCsdPressureSafetyValveAndFiveDays =
         new ShouldBeEnabledBehaviourMontrealCsdPSVAndFiveDays(11);

        //ayman Sarnia specific approvals
        public static ApprovalShouldBeEnabledBehaviour ThirtyDayValidity = new ShouldBeEnabledBehaviourThirtyDays(12);

        //generic template - mangesh
        public static ApprovalShouldBeEnabledBehaviour GenericTemplatePressureSafetyValve = new ShouldBeEnabledBehaviourGenericTemplatePSV(13);


        //DMND0010261-SELC CSD EdmontonPipeline
        public static ApprovalShouldBeEnabledBehaviour ShouldBeEnabledBehaviour72Hours = new ShouldBeEnabledBehaviour72Hours(14);
        public static ApprovalShouldBeEnabledBehaviour ShouldBeEnabledBehaviourSEUSA = new ShouldBeEnabledBehaviourSEUSA(15);
        public static ApprovalShouldBeEnabledBehaviour ShouldBeEnabledBehaviourSELC = new ShouldBeEnabledBehaviourSELC(16);
        public static ApprovalShouldBeEnabledBehaviour ShouldBeEnabledBehaviourSCADA = new ShouldBeEnabledBehaviourSCADA(17);
        
        private static readonly ApprovalShouldBeEnabledBehaviour[] all =
        {
            Always,
            OP14PressureSafetyValve,
            LubesCsdPressureSafetyValve,
            TenDayValidity,
            SevenDayValidity,
            MontrealCsdPressureSafetyValve,
            ThreeDayValidity,
            FiveDayValidity,
            FiveDayDefeatedValidity,
            ThreeDayValidityNoPressureSafetyValue,
            MontrealCsdPressureSafetyValveAndFiveDays,
            ThirtyDayValidity,                                //ayman Sarnia specific approvals
            GenericTemplatePressureSafetyValve ,// generic template - mangesh

             //DMND0010261-SELC CSD EdmontonPipeline
            ShouldBeEnabledBehaviour72Hours,
            ShouldBeEnabledBehaviourSEUSA,
            ShouldBeEnabledBehaviourSELC,
            ShouldBeEnabledBehaviourSCADA

        };

        public ApprovalShouldBeEnabledBehaviour(long id) : base(id)
        {
        }


        public override string GetName()
        {
            return null;
        }

        public static ApprovalShouldBeEnabledBehaviour GetById(long id)
        {
            return GetById(id, all);
        }

        //ayman Sarnia eip DMND0008992
        public virtual bool ShouldBeEnabledForSarnia(FormGN75B form, DateTime now)
        {
            return true;
        }


        public virtual bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            return true;
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourOp14PSV : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourOp14PSV(long id) : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var formOp14 = (FormOP14) form;
            return formOp14.IsTheCSDForAPressureSafetyValve;
        }
    }

    //Generic Template - mangesh
    [Serializable]
    public class ShouldBeEnabledBehaviourGenericTemplatePSV : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourGenericTemplatePSV(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var formGenericTemplate = (FormGenericTemplate)form;
            return formGenericTemplate.IsTheCSDForAPressureSafetyValve;
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourLubesCsdPSV : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourLubesCsdPSV(long id) : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var lubesCsdForm = (LubesCsdForm) form;
            return lubesCsdForm.IsTheCSDForAPressureSafetyValve.HasValue &&
                   lubesCsdForm.IsTheCSDForAPressureSafetyValve.Value;
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourMontrealCsdPSV : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourMontrealCsdPSV(long id) : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var montrealCsdForm = (MontrealCsd) form;
            return montrealCsdForm.IsTheCSDForAPressureSafetyValve.HasValue &&
                   montrealCsdForm.IsTheCSDForAPressureSafetyValve.Value;
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourMontrealCsdPSVAndFiveDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourMontrealCsdPSVAndFiveDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var montrealCsdForm = (MontrealCsd)form;
            if (montrealCsdForm.IsTheCSDForAPressureSafetyValve.HasValue &&
                montrealCsdForm.IsTheCSDForAPressureSafetyValve.Value)
            {
          
                var validFromToNowSpan = now - form.FromDateTime;

                return (validFromToNowSpan.TotalDays > 5);
            }
            return false;
        }
    }

    //ayman Sarnia specific approvals
    [Serializable]
    public class ShouldBeEnabledBehaviourThirtyDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourThirtyDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;

            return (validitySpan.TotalDays > 30 || validFromToNowSpan.TotalDays > 30);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourTenDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourTenDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;

            return (validitySpan.TotalDays > 10 || validFromToNowSpan.TotalDays > 10);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourSevenDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourSevenDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;

            return (validitySpan.TotalDays > 7 || validFromToNowSpan.TotalDays > 7);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourThreeDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourThreeDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;

            return (validitySpan.TotalDays > 3 || validFromToNowSpan.TotalDays > 3);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourFiveDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourFiveDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;

            return (validitySpan.TotalDays > 5 || validFromToNowSpan.TotalDays > 5);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourSystemDefeatedFiveDays : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourSystemDefeatedFiveDays(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validFromToNowSpan = now - form.FromDateTime;

            return (validFromToNowSpan.TotalDays > 5);
        }
    }

    [Serializable]
    public class ShouldBeEnabledBehaviourSystemDefeatedThreeDaysNoPressureSafetyValve : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviourSystemDefeatedThreeDaysNoPressureSafetyValve(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validFromToNowSpan = now - form.FromDateTime;

            var montrealCsdForm = (MontrealCsd) form;
            if (montrealCsdForm.IsTheCSDForAPressureSafetyValve.HasValue &&
                montrealCsdForm.IsTheCSDForAPressureSafetyValve.Value)
            {
                return false;
            }

            return (validFromToNowSpan.TotalDays > 3);
        }
    }



    //DMND0010261-SELC CSD EdmontonPipeline
     [Serializable]
    public class ShouldBeEnabledBehaviour72Hours : ApprovalShouldBeEnabledBehaviour
    {
        public ShouldBeEnabledBehaviour72Hours(long id)
            : base(id)
        {
        }

        public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            var validitySpan = form.ToDateTime - form.FromDateTime;
            var validFromToNowSpan = now - form.FromDateTime;
            
            return (validitySpan.TotalHours > 72 || validFromToNowSpan.TotalDays > 72);
        }
      

    }

     [Serializable]
     public class ShouldBeEnabledBehaviourSEUSA : ApprovalShouldBeEnabledBehaviour
     {
         public ShouldBeEnabledBehaviourSEUSA(long id)
             : base(id)
         {
         }

         public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
         {
             var Form = (FormOP14)form;
             return !Form.IsTheCSDForAPressureSafetyValve;

         }


     }
     [Serializable]
     public class ShouldBeEnabledBehaviourSELC : ApprovalShouldBeEnabledBehaviour
     {
         public ShouldBeEnabledBehaviourSELC(long id)
             : base(id)
         {
         }

         public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
         {
             var Form = (FormOP14)form;
             return Form.IsTheCSDForAPressureSafetyValve;

         }


     }

     [Serializable]
     public class ShouldBeEnabledBehaviourSCADA : ApprovalShouldBeEnabledBehaviour
     {
         public ShouldBeEnabledBehaviourSCADA(long id)
             : base(id)
         {
         }

         public override bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
         {
             var Form = (FormOP14)form;
             return Form.IsSCADASupport;
         }


     }

}