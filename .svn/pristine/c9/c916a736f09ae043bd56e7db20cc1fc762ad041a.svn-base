using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public static class EdmontonContextFactory
    {
        public static IMultiGridContext GetContext(EdmontonFormType formType)
        {
            var clientServiceRegistry = ClientServiceRegistry.Instance;

            return GetContext(clientServiceRegistry.GetService<IFormEdmontonService>(),
                clientServiceRegistry.GetService<IWorkPermitEdmontonService>(),
                formType,
                new MultiGridFormPage());
        }


        public static IMultiGridContext GetContext(IFormEdmontonService service,
            IWorkPermitEdmontonService workPermitEdmontonService, EdmontonFormType formType,
            MultiGridFormPage multiGridPage)
        {
            IMultiGridContext context;

            if (EdmontonFormType.GN7.Equals(formType))
            {
                context = new EdmontonGN7FormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.GN59.Equals(formType))
            {
                context = new EdmontonGN59FormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.OP14.Equals(formType))
            {
                context = new EdmontonOP14FormContext(service, multiGridPage);
            }
            else if (EdmontonFormType.GN24.Equals(formType))
            {
                context = new EdmontonGN24FormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.GN6.Equals(formType))
            {
                context = new EdmontonGN6FormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.GN75A.Equals(formType))
            {
                context = new EdmontonGN75AFormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.GN75B.Equals(formType))
            {
                context = new EdmontonGN75BFormContext(service, multiGridPage);
            }

            //ayman Sarnia eip DMND0008992
            else if (EdmontonFormType.GN75BTemplate.Equals(formType))
            {
                context = new EdmontonGN75BTemplateContext(service, multiGridPage);
            }
            else if (EdmontonFormType.GN75BSarniaEIP.Equals((formType)))
            {
                context = new EdmontonGN75BSarniaEIPContext(service, multiGridPage);
            }
            else if (EdmontonFormType.GN1.Equals(formType))
            {
                context = new EdmontonGN1FormContext(service, workPermitEdmontonService, multiGridPage);
            }
            else if (EdmontonFormType.Overtime.Equals(formType))
            {
                context = new EdmontonOvertimeFormContext(service, multiGridPage);
            }
            else if (EdmontonFormType.MontrealCsd.Equals(formType))
            {
                context = new MontrealCsdFormContext(service, multiGridPage);
            }
            else if (EdmontonFormType.LubesCsd.Equals(formType))
            {
                context = new LubesCsdFormContext(service, multiGridPage);
            }
            else if (EdmontonFormType.LubesAlarmDisable.Equals(formType))
            {
                context = new LubesAlarmDisableFormContext(service, multiGridPage);
            }
            //RITM0268131 - mangesh
            else if (EdmontonFormType.TemporaryInstallationsMuds.Equals(formType))
            {
                context = new TemporaryInstallationsFormContext(service, multiGridPage);
            }
            //generic type - mangesh
            else if (EdmontonFormType.OdourNoiseComplaint.Equals(formType)
                    || EdmontonFormType.Deviation.Equals(formType)
                    || EdmontonFormType.RoadClosure.Equals(formType)
                    || EdmontonFormType.GN11GroundDisturbance.Equals(formType)
                    || EdmontonFormType.GN27FreezePlug.Equals(formType)
                    || EdmontonFormType.HazardAssessment.Equals(formType)
                    || EdmontonFormType.FortHillOilSample.Equals(formType)  //RITM0341710 - mangesh
                    || EdmontonFormType.FortHillDailyInspection.Equals(formType)
                    || EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType) //TASK0593631 - mangesh
                )
            {
                context = new GenericTemplateFormContext(service, multiGridPage,formType.IdValue);
            }
             //-----
            else
            {
                throw new OLTException("Unknown form type");
            }

            return context;
        }
    }
}