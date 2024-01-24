namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    // This is to make the code more clear in the Merging Persistance Processor.
    public interface ISAPImportData : IHasPermitKey
    {
        string SAPWorkCentre { get; }

        bool IsSubOperation { get; }
        bool DoNotMerge { get; }
        Date RequestedStartDate { get; }
        Date EndDate { get; }
    }
}