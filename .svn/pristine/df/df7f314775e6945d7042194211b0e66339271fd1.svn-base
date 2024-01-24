using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FunctionalLocationService : IFunctionalLocationService
    {
        private readonly IFunctionalLocationDao dao;
        private readonly IFunctionalLocationOperationalModeDao opModeDao;
        private readonly ITimeService timeService;

        public FunctionalLocationService()
        {
            dao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            opModeDao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeDao>();
            timeService = new TimeService();
        }

        public FunctionalLocation QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public FunctionalLocation QueryByFullHierarchy(string fullHierarchy, long siteId)
        {
            return dao.QueryByFullHierarchy(fullHierarchy, siteId);
        }

        public FunctionalLocation QueryByFullHierarchyIncludeDeleted(string fullHierarchy, long siteId)
        {
            return dao.QueryByFullHierarchyIncludeDeleted(fullHierarchy, siteId);
        }

        public void UndoRemove(FunctionalLocation functionalLocation)
        {
            dao.UndoRemove(functionalLocation);
        }

        public FunctionalLocation Insert(FunctionalLocation functionalLocation)
        {
            dao.Insert(functionalLocation);
            InsertDefault(functionalLocation);
            return functionalLocation;
        }

        public void RemoveByFullHierarchy(FunctionalLocation functionalLocation)
        {
            var functionalLocationWithId =
                dao.QueryByFullHierarchy(functionalLocation.FullHierarchy, functionalLocation.Site.IdValue);
            if (functionalLocationWithId != null)
            {
                dao.RemoveAndAllDescendants(functionalLocationWithId);
            }
        }

        public void Update(FunctionalLocation functionalLocation)
        {
            dao.Update(functionalLocation);
        }

        public List<FunctionalLocation> GetUnitLevelAndHigherFunctionalLocationsForSite(long siteId)
        {
            return dao.QueryDivSecUnitBySiteId(siteId);
        }

        public List<FunctionalLocation> GetSectionLevelFunctionalLocation(FunctionalLocation functionalLocation)
        {
            if (functionalLocation.Type == FunctionalLocationType.Level1)
            {
                return dao.QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations(functionalLocation);
            }

            return GetNonDivisionFlocList(functionalLocation);
        }

        public List<FunctionalLocation> GetDefaultFLOCs(FunctionalLocationType highestLevelAllowedFlocType,
            List<FunctionalLocation> userSelectedRoots)
        {
            if (userSelectedRoots == null || userSelectedRoots.Count == 0)
            {
                return new List<FunctionalLocation>(0);
            }

            var outputList = new List<FunctionalLocation>();

            var first3LevelsOfFlocs = GetUnitLevelAndHigherFunctionalLocationsForSite(userSelectedRoots[0].Site.IdValue);

            userSelectedRoots.Sort((f1, f2) => f1.Level.CompareTo(f2.Level));

            foreach (var root in userSelectedRoots)
            {
                if (root.Type < highestLevelAllowedFlocType)
                {
                    // grab all the next generation of children that are the max level allowed
                    var descendants = GetDecendantsOfAGivenLevel(root, first3LevelsOfFlocs, highestLevelAllowedFlocType);
                    outputList.AddRange(descendants);
                }
                else if (root.Type >= highestLevelAllowedFlocType)
                {
                    // if a higher level one isn't already in the list, add it
                    if (!ListContainsAncestors(outputList, root))
                    {
                        outputList.Add(root);
                    }
                }
            }

            return outputList;
        }

        public List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermits(long workAssignmentId)
        {
            return dao.QueryByWorkAssignmentIdForWorkPermits(workAssignmentId);
        }

        public List<FunctionalLocation> QueryByWorkAssignmentIdForRestrictionFlocs(long workAssignmentId)
        {
            return dao.QueryByWorkAssignmentIdRestrictionFlocs(workAssignmentId);
        }

        public void InsertDefault(FunctionalLocation unitLevelFunctionalLocation)
        {
            /*Amit Shukla Comment this line and test the complete thing Request No 11 */
            /*Older Code commented start*/
            //if (FunctionalLocationType.Level3 != unitLevelFunctionalLocation.Type)
            //{
            //    return;
            //}
            /*Older Code commented End*/

            /*New Code Start Amit Shukla*/
            // Allowing system to insert data for functional location operational mode for Level 2 and 1 locations also
            if (!(FunctionalLocationType.Level3 == unitLevelFunctionalLocation.Type || FunctionalLocationType.Level2 == unitLevelFunctionalLocation.Type || FunctionalLocationType.Level1 == unitLevelFunctionalLocation.Type))
            {
                return;
            }
            /*New Code End Amit Shukla*/
            var currentTimeAtSite = timeService.GetTime(unitLevelFunctionalLocation.Site.TimeZone);

            var functionalLocationOperationalMode =
                new FunctionalLocationOperationalMode(unitLevelFunctionalLocation.IdValue,
                    OperationalMode.Normal,
                    AvailabilityReason.None, currentTimeAtSite);

            opModeDao.Insert(functionalLocationOperationalMode);
        }

        private List<FunctionalLocation> GetNonDivisionFlocList(FunctionalLocation functionalLocation)
        {
            var foundLocation = functionalLocation;
            var flocList = new List<FunctionalLocation>();
            if (functionalLocation.Type != FunctionalLocationType.Level2)
            {
                foundLocation =
                    dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(functionalLocation);
            }
            flocList.Add(foundLocation);
            return flocList;
        }

        private List<FunctionalLocation> GetDecendantsOfAGivenLevel(FunctionalLocation ancestor,
            List<FunctionalLocation> sourceFlocs, FunctionalLocationType highestLevelAllowedFlocType)
        {
            var result = new List<FunctionalLocation>();

            foreach (var floc in sourceFlocs)
            {
                if (floc.Type == highestLevelAllowedFlocType && ancestor.IsParentOf(floc))
                {
                    result.Add(floc);
                }
            }

            return result;
        }

        private bool ListContainsAncestors(List<FunctionalLocation> listPossiblyContainingAncestors,
            FunctionalLocation floc)
        {
            foreach (var possibleAncestor in listPossiblyContainingAncestors)
            {
                if (possibleAncestor.IsParentOf(floc))
                {
                    return true;
                }
            }

            return false;
        }
    }
}