using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FunctionalLocationDTODao : AbstractManagedDao, IFunctionalLocationDTODao
    {
        private const string QueryByDescriptionSiteAndLevel = "QueryFunctionalLocationsBySearchTextInDescriptionOrFullHierarchy";

        public List<FunctionalLocationDTO> QueryBySearchTextInDescriptionOrFullHierarchy(
            string searchText,
            Site site, 
            IList<FunctionalLocationType> allowedTypes)
        {
            string cleanedSearchString = searchText.ToDatabaseSearchString();
            if (string.IsNullOrEmpty(cleanedSearchString))
            {
                return new List<FunctionalLocationDTO>();
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("@SearchText", cleanedSearchString);
            command.AddParameter("@SiteId", site.IdValue);
            string csvListOfLevelsToSearch = allowedTypes.ConvertAll(type => (int) type).ToCommaSeparatedString();
            command.AddParameter("@CsvLevelsToSearch", csvListOfLevelsToSearch);

            List<FunctionalLocationDTO> results = command.QueryForListResult<FunctionalLocationDTO>(PopulateResult, QueryByDescriptionSiteAndLevel);
            return results;
        }

        private static FunctionalLocationDTO PopulateResult(SqlDataReader reader)
        {
            return new FunctionalLocationDTO(reader.Get<long>("Id"),
                                             reader.Get<string>("FullHierarchy"));
        }
    }
}
