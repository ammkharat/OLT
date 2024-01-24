using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Client
{
    public class UserContext
    {
        private readonly ClientSession clientSession;
        private readonly Dictionary<string, string> gridLayoutCache = new Dictionary<string, string>();
        private readonly List<long> readableVisibilityGroupIds = new List<long>();

        //ayman visibility group
        private readonly List<long> writeableVisibilityGroupIds = new List<long>();

        private WorkAssignment assignment;
        private List<FunctionalLocation> divisionsForSelectedFunctionalLocations;
        private Role role;
        private List<RoleDisplayConfiguration> roleDisplayConfigurations = new List<RoleDisplayConfiguration>();
        private List<RolePermission> rolePermissions;
        private RootFlocSet rootFlocSet;
        private RootFlocSet rootFlocSetForRestrictions;
        private RootFlocSet rootFlocSetForWorkPermits;
        private List<FunctionalLocation> sectionsForSelectedFunctionalLocations;
        private List<FunctionalLocation> selectedFunctionalLocations;

        private Site selectedSite;
        private SiteConfiguration siteConfiguration;
        private User user;
        private UserRoleElements userRoleElements;

        private UserShift userShift;

        public UserContext(ClientSession clientSession)
        {
            this.clientSession = clientSession;
        }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                AttemptToDefaultSelectedSite();
            }
        }

        public Role Role
        {
            get { return role; }
        }

        public UserRoleElements UserRoleElements
        {
            get { return userRoleElements; }
        }

        public List<RolePermission> RolePermissions
        {
            get { return rolePermissions; }
        }

        public List<RoleDisplayConfiguration> RoleDisplayConfigurations
        {
            get { return roleDisplayConfigurations; }
        }

        public SiteConfiguration SiteConfiguration
        {
            get { return siteConfiguration; }
            private set
            {
                siteConfiguration = value;
                if (user != null && user.WorkPermitPrintPreference != null && user.WorkPermitPrintPreference.Id == null)
                {
                    user.WorkPermitPrintPreference.NumberOfCopies =
                        siteConfiguration.DefaultNumberOfCopiesForWorkPermits;
                }

                if (siteConfiguration != null && siteConfiguration.CollectAnalyticsData)
                {
                    Analytics.Enable();
                }
                else
                {
                    Analytics.Disable();
                }
            }
        }

        public long SiteId
        {
            get { return selectedSite.IdValue; }
        }

        public Site Site
        {
            get { return selectedSite; }
            private set
            {
                selectedSite = value;
                Clock.TimeZone = value.TimeZone;
            }
        }

        public List<long> PlantIds { get; set; }

        // TODO: (2014 cleanup) move this start/stop stop stuff to the ClientSession, remove reference to client session which is a "circular" reference and have setter in ClientSession that also passes
        // the userShift to the UserContext. This is causing some Designer issues.
        public UserShift UserShift
        {
            set
            {
                userShift = value;
                if (userShift != null && clientSession != null)
                {
                    clientSession.StartShiftEndStopWatch();
                    clientSession.StartShiftGracePeriodStopWatch();
                    clientSession.ShiftHandoverAlertStopWatch(); //RITM0387753-Shift Handover creation alert(Aarti)
                }
            }
            get { return userShift; }
        }

        public long? WorkAssignmentId
        {
            get { return assignment == null ? null : assignment.Id; }
        }

        public WorkAssignment Assignment
        {
            get { return assignment; }
            set
            {
                assignment = value;
                rootFlocSetForWorkPermits = null;
                rootFlocSetForRestrictions = null;
            }
        }

        public IList<FunctionalLocation> AssignmentFunctionalLocations
        {
            get { return assignment != null ? assignment.FunctionalLocations : new List<FunctionalLocation>(); }
        }

        // TODO: 4.0 Instead of having to pass division and sections, 
        // let this method determine which ones are divisions and sections 
        // since the methods are already in this class.

        public List<FunctionalLocation> DivisionsForSelectedFunctionalLocations
        {
            get { return divisionsForSelectedFunctionalLocations; }
        }

        public List<FunctionalLocation> SectionsForSelectedFunctionalLocations
        {
            get { return sectionsForSelectedFunctionalLocations; }
        }

        public List<FunctionalLocation> RootsForSelectedFunctionalLocations
        {
            get { return RootFlocSet.FunctionalLocations; }
        }

        public RootFlocSet RootFlocSet
        {
            get { return rootFlocSet ?? (rootFlocSet = new RootFlocSet(new List<FunctionalLocation>())); }
        }

        public List<FunctionalLocation> FunctionalLocationsForWorkPermits
        {
            set { rootFlocSetForWorkPermits = new RootFlocSet(value); }
        }

        public List<FunctionalLocation> FunctionalLocationsForRestrictions
        {
            set { rootFlocSetForRestrictions = new RootFlocSet(value); }
        }

        public RootFlocSet RootFlocSetForWorkPermits
        {
            get
            {
                if (rootFlocSetForWorkPermits == null)
                {
                    return new RootFlocSet(new List<FunctionalLocation>());
                }

                return rootFlocSetForWorkPermits;
            }
        }

        public RootFlocSet RootFlocSetForRestrictions
        {
            get
            {
                if (rootFlocSetForRestrictions == null)
                {
                    return new RootFlocSet(new List<FunctionalLocation>());
                }

                return rootFlocSetForRestrictions;
            }
        }

        public RootFlocSet RootFlocSetForForms
        {
            get
            {
                if (siteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                    HasFlocsForWorkPermits)
                {
                    return RootFlocSetForWorkPermits;
                }
                return RootFlocSet;
            }
        }

        public bool HasFlocsForWorkPermits
        {
            get { return !RootFlocSetForWorkPermits.FunctionalLocations.IsEmpty(); }
        }

        public bool HasFlocsForRestrictions
        {
            get { return !RootFlocSetForRestrictions.FunctionalLocations.IsEmpty(); }
        }



        public List<FunctionalLocation> RootsForSelectedFunctionalLocationsLevelFromSiteConfig   //ayman shift hand over floc level
        {
            get
            {
                if (selectedFunctionalLocations == null)
                    return new List<FunctionalLocation>(0);

                return RootsForFunctionalLocationsLevelFromSiteConfigForShiftHandover(selectedFunctionalLocations);
            }
        }



        public List<FunctionalLocation> RootsForSelectedFunctionalLocationsLevelTwoAndLower
        {
            get
            {
                if (selectedFunctionalLocations == null)
                    return new List<FunctionalLocation>(0);

                return RootsForFunctionalLocationsLevelTwoAndLower(selectedFunctionalLocations);
            }
        }

        public List<FunctionalLocation> DivisionsAndSectionsForSelectedFunctionalLocations
        {
            get
            {
                var flocs = new List<FunctionalLocation>();
                if (DivisionsForSelectedFunctionalLocations != null)
                {
                    flocs.AddRange(DivisionsForSelectedFunctionalLocations);
                }
                if (SectionsForSelectedFunctionalLocations != null)
                {
                    flocs.AddRange(SectionsForSelectedFunctionalLocations);
                }
                return flocs;
            }
        }

        //ayman visibility group
        public List<long> WriteableVisibilityGroupIds
        {
            get
            {
                return (writeableVisibilityGroupIds == null || writeableVisibilityGroupIds.Count == 0)
                    ? null
                    : writeableVisibilityGroupIds;
            }
        }

        public List<long> ReadableVisibilityGroupIds
        {
            get
            {
                return (readableVisibilityGroupIds == null || readableVisibilityGroupIds.Count == 0)
                    ? null
                    : readableVisibilityGroupIds;
            }
        }

        public bool IsSarniaSite
        {
            get { return SiteId == Site.SARNIA_ID; }
        }

        // ayman selc
        public bool IsSelcSite
        {
            get { return SiteId == Site.SELC_ID; }
        }

        //ayman fort hills 
        public bool IsForthillsSite
        {
            get { return SiteId == Site.FORT_HILLS_ID; }
        }

        public bool IsDenverSite
        {
            get { return SiteId == Site.DENVER_ID; }
        }

        public bool IsOilsandsSite
        {
            get { return SiteId == Site.OILSAND_ID; }
        }

        public bool IsFirebagSite
        {
            get { return SiteId == Site.FIREBAG_ID; }
        }

        public bool IsSiteWideServicesSite
        {
            get { return SiteId == Site.SITE_WIDE_SERVICES_ID; }
        }

        public bool IsMackayRiverSite
        {
            get { return SiteId == Site.MACKAY_ID; }
        }

        public bool IsEdmontonSite
        {
            get { return SiteId == Site.EDMONTON_ID; }
        }

        public bool IsMontrealSite
        {
            get { return SiteId == Site.MONTREAL_ID; }
        }

        public bool IsLubesSite
        {
            get { return SiteId == Site.LUBES_ID; }
        }

        public bool IsWoodBuffaloSite
        {
            get { return SiteId == Site.WOODBUFFALO_ID; }
        }

        //RITM0268131 - mangesh
        public bool IsMontrealSulphurSite //MUDS
        {
            get { return SiteId == Site.MontrealSulphur_ID; }
        }

        public bool IsWoodBuffaloRegionSite
        {
            get { return Site.IsWoodBuffaloRegionSite(SiteId); }
        }

        //ayman USPipeline workpermit
        public bool IsUSPipelineSite
        {
            get { return SiteId == Site.USPipeline_ID; }
        }

        //mangesh SELC workpermit
        public bool IsSELCSite
        {
            get { return SiteId == Site.SELC_ID; }
        }

        public List<FunctionalLocation> SelectedFunctionalLocations
        {
            get { return selectedFunctionalLocations ?? new List<FunctionalLocation>(); }
        }

        public void SetRole(Role newRole, UserRoleElements newRoleElements,
            List<RoleDisplayConfiguration> newRoleDisplayConfigurations, List<RolePermission> newRolePermissions)
        {
            role = newRole;
            userRoleElements = newRoleElements;
            roleDisplayConfigurations = newRoleDisplayConfigurations ?? new List<RoleDisplayConfiguration>();
            rolePermissions = newRolePermissions;
        }

        private void AttemptToDefaultSelectedSite()
        {
            // If the User only has one site assigned to them, then go ahead and set the selected site to this.
            if (user != null && user.AvailableSites != null && user.AvailableSites.Count == 1)
            {
                selectedSite = user.AvailableSites[0];
            }
        }

        public void SetSite(Site site, SiteConfiguration siteConfiguration)
        {
            Site = site;
            SiteConfiguration = siteConfiguration;
        }

        public void SetSelectedFunctionalLocations(
            List<FunctionalLocation> allSelectedFlocs,
            List<FunctionalLocation> divisionsForSelectedFlocs,
            List<FunctionalLocation> sectionsForSelectedFlocs)
        {
            selectedFunctionalLocations = allSelectedFlocs;
            divisionsForSelectedFunctionalLocations = divisionsForSelectedFlocs;
            sectionsForSelectedFunctionalLocations = sectionsForSelectedFlocs;

            rootFlocSet = new RootFlocSet(selectedFunctionalLocations);
        }


        //ayman shift hand over floc level
        public List<FunctionalLocation> RootsForFunctionalLocationsLevelFromSiteConfigForShiftHandover(List<FunctionalLocation> flocs)   //ayman shift hand over floc level
        {
            
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConfiguration = siteConfigurationService.QueryBySiteId(Site.IdValue);

         
            var result = new List<FunctionalLocation>();
            if (siteConfiguration.ShiftHandoverFlocLevel == 0)    //ayman shift hand over floc
            {
                flocs = flocs.GetRoots();
                var sectionalRoots = sectionsForSelectedFunctionalLocations.FindAll(sectionFloc => !flocs.Exists(sectionFloc.IsParentOf));
                var lowerLevelRoots = flocs.FindAll(floc => floc.Type >= FunctionalLocationType.Level3);
                result.AddRange(sectionalRoots);
                result.AddRange(lowerLevelRoots);
            }
            else
            {
                var lowerLevelRoots = flocs.FindAll(floc => floc.Level >= siteConfiguration.ShiftHandoverFlocLevel);
                result.AddRange(lowerLevelRoots);
            }

            return result;
        }



        public List<FunctionalLocation> RootsForFunctionalLocationsLevelTwoAndLower(List<FunctionalLocation> flocs)
        {
            flocs = flocs.GetRoots();
            var sectionalRoots =
                sectionsForSelectedFunctionalLocations.FindAll(sectionFloc => !flocs.Exists(sectionFloc.IsParentOf));
            var lowerLevelRoots = flocs.FindAll(floc => floc.Type >= FunctionalLocationType.Level3);

            var result = new List<FunctionalLocation>();
            result.AddRange(sectionalRoots);
            result.AddRange(lowerLevelRoots);

            return result;
        }

        public void SetReadableVisibilityGroupIds(List<long> ids)
        {
            readableVisibilityGroupIds.Clear();
            readableVisibilityGroupIds.AddRange(ids);
        }


        //ayman visibility group
        public void SetWritableVisibilityGroupIds(List<long> ids)
        {
            if (ids == null)
                return;

            writeableVisibilityGroupIds.Clear();
            writeableVisibilityGroupIds.AddRange(ids);
        }


        public bool HasSameAssignment(WorkAssignment workAssignment)
        {
            if (assignment == null && workAssignment == null)
            {
                return true;
            }
            if (assignment != null && workAssignment != null && assignment.Id == workAssignment.Id)
            {
                return true;
            }

            return false;
        }

        public void ClearGridLayoutCache()
        {
            gridLayoutCache.Clear();
        }

        public void RemoveGridLayoutXml(string gridIdentifier)
        {
            if (gridLayoutCache.ContainsKey(gridIdentifier))
            {
                gridLayoutCache.Remove(gridIdentifier);
            }
        }

        public string GetGridLayoutXML(string gridIdentifier)
        {
            if (gridLayoutCache.ContainsKey(gridIdentifier))
            {
                return gridLayoutCache[gridIdentifier];
            }

            return null;
        }

        public void SetGridLayoutXML(string gridIdentifier, string xml)
        {
            if (gridLayoutCache.ContainsKey(gridIdentifier))
            {
                gridLayoutCache[gridIdentifier] = xml;
            }
            else
            {
                gridLayoutCache.Add(gridIdentifier, xml);
            }
        }
    }
}