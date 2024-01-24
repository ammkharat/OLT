namespace Com.Suncor.Olt.Remote.Utilities
{
    public interface IOltGroupMembership
    {
        long PlantId { get; }
        string SiteIdentifier { get; }
        string RoleIdentifier { get; }
    }
}
