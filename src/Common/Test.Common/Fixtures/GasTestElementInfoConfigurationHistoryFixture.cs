using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class GasTestElementInfoConfigurationHistoryFixture
    {
        public static GasTestElementInfoConfigurationHistoryList SarniaGasTestElementInfoHistoryList
        {
            get
            {
                return
                    new GasTestElementInfoConfigurationHistoryList(SarniaGasTestElementInfoHistory,
                                                                   new DateTime(2006, 06, 21, 10, 0, 0),
                                                                   UserFixture.
                                                                       CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB());
            }
        }
        
        public static List<GasTestElementInfoConfigurationHistory> SarniaGasTestElementInfoHistory
        {
            get
            {
                List<GasTestElementInfoConfigurationHistory> historyList = new List<GasTestElementInfoConfigurationHistory>();
                historyList.Add(
                    new GasTestElementInfoConfigurationHistory
                        (
                            "Oxygen",
                            "50.0-75.0",
                            "0.0-100.0",
                            "0.0-200.0",
                            "0.0-300.0",
                            GasLimitUnit.PARTS_PER_MILLION.ToString(),
                            true,
                            1,
                            new DateTime(2006,06,21,10,0,0),
                            UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB()
                        )
                    );
                historyList.Add(
                    new GasTestElementInfoConfigurationHistory
                        (
                            "LEL",
                            "75.00",
                            "100.00",
                            "200.00",
                            "300.00",
                            GasLimitUnit.PARTS_PER_MILLION.ToString(),
                            false,
                            2,
                            new DateTime(2006, 06, 21, 10, 0, 0),
                            UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB()
                        )
                    );
                return historyList;
            }
        }

        public static GasTestElementInfoConfigurationHistory CreateGasTestElementInfoHistory()
        {
            return new GasTestElementInfoConfigurationHistory
                (
                    1,
                    "Oxygen",
                    "50-75",
                    "100",
                    "200",
                    "300",
                    GasLimitUnit.PARTS_PER_MILLION.ToString(),
                    true,
                    2,
                    new DateTime(2006, 06, 21, 10, 0, 0),
                    UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB()
                );
        }
    }
}
