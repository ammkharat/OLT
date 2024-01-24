using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TargetAlertDTOFixture
    {
        public static List<TargetAlertDTO> CreateTargetAlertDTOList()
        {
            List<TargetAlertDTO> list = new List<TargetAlertDTO> {CreateTargetAlertDTO()};
            return list;
        }

        public static TargetAlertDTO CreateTargetAlertDTO()
        {
            return new TargetAlertDTO(TargetAlertFixture.CreateATargetAlert());
        }

    }
}