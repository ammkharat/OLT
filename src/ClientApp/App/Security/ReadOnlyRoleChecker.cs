using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Security
{
    public class ReadOnlyRoleChecker
    {
        public static bool ShouldBeConvertedToReadOnlyRole(User user, Role selectedRole, WorkAssignment selectedWorkAssignment, List<FunctionalLocation> selectedFunctionalLocations)
        {
            if (selectedRole == null)
            {
                return false;
            }

            if (selectedRole.IsReadOnlyRole || selectedRole.IsAdministratorRole)
            {
                return false;
            }

            UserContext userContext = ClientSession.GetUserContext();
            List<long> plantIdsForRole = SiteRolePlant.ChoosePlantIds(selectedRole, userContext.User.SiteRolePlants);

            return !AllSelectedFunctionalLocationsAreInAUserPlant(plantIdsForRole, selectedFunctionalLocations);
        }

        private static bool AllSelectedFunctionalLocationsAreInAUserPlant(List<long> plantIds, List<FunctionalLocation> selectedFunctionalLocations)
        {
            List<FunctionalLocation> selectedFunctionalLocationsThatAreNotInAnyUserPlant = selectedFunctionalLocations.FindAll(obj => !plantIds.Contains(obj.PlantId));
            return selectedFunctionalLocationsThatAreNotInAnyUserPlant.Count == 0;
        }

    }
}
