using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FunctionalLocationOperationalModeDTOFixture
    {
        public static FunctionalLocationOperationalModeDTO MakeConstrainedOpModeDto()
        {
            return MakeConstrainedOpModeDto(1, "TST1-HAHA-KAKA");
        }

        public static FunctionalLocationOperationalModeDTO MakeConstrainedOpModeDto(long flocId, string flocFullHierarchy)
        {
            return new FunctionalLocationOperationalModeDTO(
                    flocId, flocFullHierarchy, "Fake Description", OperationalMode.Constrained,
                        AvailabilityReason.None, DateTimeFixture.DateTimeNow);
        }

        public static FunctionalLocationOperationalModeDTO MakeShutDownOpModeDto()
        {
            return new FunctionalLocationOperationalModeDTO(
                    1, "TST1-HAHA-KAKA", "Fake Description", OperationalMode.ShutDown,
                        AvailabilityReason.None, DateTimeFixture.DateTimeNow);
        }
        
        public static FunctionalLocationOperationalModeDTO MakeNormalOpModeDto()
        {
            return new FunctionalLocationOperationalModeDTO(
                    1, "TST1-HAHA-KAKA", "Fake Description", OperationalMode.Normal,
                        AvailabilityReason.None, DateTimeFixture.DateTimeNow);
        }

        public static FunctionalLocationOperationalModeDTO MakeDto(OperationalMode mode)
        {
            return new FunctionalLocationOperationalModeDTO(
                    1, "TST1-HAHA-KAKA", "Fake Description", mode,
                        AvailabilityReason.None, DateTimeFixture.DateTimeNow);
        }

        public static FunctionalLocationOperationalModeDTO MakeNormalOpModeDto(long id)
        {
            return new FunctionalLocationOperationalModeDTO(
                    id, "TST1-HAHA-KAKA", "Fake Description", OperationalMode.Normal,
                        AvailabilityReason.None, DateTimeFixture.DateTimeNow);
        }
        
        public static List<FunctionalLocationOperationalModeDTO> GetList(int number)
        {       
            List<FunctionalLocationOperationalModeDTO> list = new List<FunctionalLocationOperationalModeDTO>(number);
            
            for(int i = 0; i < number; i++)
            {
                list.Add(MakeNormalOpModeDto(i));
            }

            return list;
        }
    }
}
