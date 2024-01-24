using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class PlantHistorianOrigin : SimpleDomainObject
    {
        public static readonly PlantHistorianOrigin PlantHistorianGateway_CanReadTagValue = new PlantHistorianOrigin(0,
            "PlantHistorianGateway.CanReadTagValue");

        public static readonly PlantHistorianOrigin PlantHistorianGateway_CanWriteTagValue = new PlantHistorianOrigin(
            0, "PlantHistorianGateway.CanWriteTagValue");

        public static readonly PlantHistorianOrigin TargetAlertService_Evaluation = new PlantHistorianOrigin(0,
            "TargetAlertService.ReadActualValues");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_ReadTargetValue =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.ReadTargetValue");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_GetConfigValue_Max =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.GetConfig.Max");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_GetConfigValue_Min =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.GetConfig.Min");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_GetConfigValue_Gap =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.GetConfig.Gap");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_CheckTagValue_Insert =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.CheckTagValue.Insert");

        public static readonly PlantHistorianOrigin TargetDefinitionDao_PopulateInstance_CheckTagValue_Update =
            new PlantHistorianOrigin(0, "TargetDefinitionDao.PopulateInstance.CheckTagValue.Update");

        public static readonly PlantHistorianOrigin CustomFieldTagValueReader_GetTagValueFromPlantHistorian =
            new PlantHistorianOrigin(0, "CustomFieldTagValueReader.GetTagValueFromPlantHistorian");

        public static readonly PlantHistorianOrigin TargetDefinitionFormPresenter_GetTagValueFromPlantHistorian =
            new PlantHistorianOrigin(0, "TargetDefinitionFormPresente.GetTagValueFromPlantHistorian");

        public static readonly PlantHistorianOrigin ReportingService_GetOperatingEngineerShiftLogDataForDevEx =
            new PlantHistorianOrigin(0, "ReportingService.GetOperatingEngineerShiftLogDataForDevEx");

        public static readonly PlantHistorianOrigin ReportingService_GetOperatingEngineerShiftLogData =
            new PlantHistorianOrigin(0, "ReportingService.GetOperatingEngineerShiftLogData");

        public static readonly PlantHistorianOrigin ReportingService_GetDailyShiftLogData = new PlantHistorianOrigin(0,
            "ReportingService.GetDailyShiftLogData");

        public static readonly PlantHistorianOrigin TargetDefinitionDTODao_GetTagValue = new PlantHistorianOrigin(0,
            "TargetDefinitionDTODao.GetTagValue");

        public static readonly PlantHistorianOrigin Test = new PlantHistorianOrigin(0, "Test");

        private readonly string name;

        public PlantHistorianOrigin(long id, string name) : base(id)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }
    }
}