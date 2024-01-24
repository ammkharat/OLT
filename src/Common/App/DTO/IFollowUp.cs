namespace Com.Suncor.Olt.Common.DTO
{
    public interface IFollowUp
    {
        bool InspectionFollowUp { get; }
        bool ProcessControlFollowUp { get; }
        bool OperationsFollowUp { get; }
        bool SupervisionFollowUp { get; }
        bool EnvironmentalHealthSafetyFollowUp { get; }
        bool OtherFollowUp { get; }
    }
}