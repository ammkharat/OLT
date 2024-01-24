using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogFormPresenterHelper
    {
        public static List<FunctionalLocation> GetDefaultFlocs(IFunctionalLocationService functionalLocationService, FunctionalLocationType flocSelectionLevel)
        {
            List<FunctionalLocation> selectedFunctionalLocations = ClientSession.GetUserContext().RootsForSelectedFunctionalLocations;
            return functionalLocationService.GetDefaultFLOCs(flocSelectionLevel, selectedFunctionalLocations);
        }
    }
}
