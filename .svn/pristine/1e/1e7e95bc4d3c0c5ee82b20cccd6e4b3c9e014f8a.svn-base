using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IDocumentSuggestionDTODao : IDao
    {
        List<DocumentSuggestionDTO> QueryDocumentSuggestionDtos(IFlocSet flocSet, DateRange dateRange, long userId);

        List<DocumentSuggestionDTO> QueryDocumentSuggestionDtosThatAreNonDraftByFunctionalLocations(IFlocSet flocSet,
            DateTime now, long userId);
    }
}