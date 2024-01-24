using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class SAPNotificationDTOFixture
    {
        public static SAPNotificationDTO GetSAPNotificationDTOEI()
        {
            SAPNotificationDTO dto = new SAPNotificationDTO
                                                (
                                                    1,
                                                    "SAP Fixture Test",
                                                    "SRx-PL3-HYDU",
                                                    SAPNotificationType.EmergencyIncident,
                                                    "000001",
                                                    new DateTime(2006, 2, 4, 9, 0, 0),
                                                    false,
                                                    "Short text",
                                                    "I00000000"
                                                );
            return dto;
        }
    }
}