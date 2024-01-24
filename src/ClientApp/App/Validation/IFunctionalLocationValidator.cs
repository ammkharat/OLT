using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Validation
{
    public interface IFunctionalLocationValidator
    {
        bool AreValid(List<FunctionalLocation> functionalLocations);
        string ErrorMessage();
    }
}
