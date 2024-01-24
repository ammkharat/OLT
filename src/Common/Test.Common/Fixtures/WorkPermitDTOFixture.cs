using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitDTOFixture
    {
        public static WorkPermitDTO CreateWorkPermitDTO()
        {
            return new WorkPermitDTO(WorkPermitFixture.CreateWorkPermit());
        }

        public static List<WorkPermitDTO> CreateWorkPermitDTOList()
        {
            List<WorkPermitDTO> list = new List<WorkPermitDTO> {CreateWorkPermitDTO()};
            return list;
        }
        public static List<WorkPermitDTO> CreateWorkPermitDTOList(int numberOf)
        {
            List<WorkPermitDTO> list = new List<WorkPermitDTO>();
            for (int i = 0; i < numberOf; i++)
            {
                list.Add(CreateWorkPermitDTO());
            }
            return list;
        }

        public static List<WorkPermitDTO> CreateWorkPermitDTOListOfAllStatus()
        {
            List<WorkPermitDTO> ret = new List<WorkPermitDTO>();

            foreach (WorkPermitStatus status in WorkPermitStatus.All)
            {
                WorkPermitDTO dto = new WorkPermitDTO(WorkPermitFixture.CreateWorkPermitWithGivenStatus(status));
                ret.Add(dto);
            }
            return ret;
        }
        
        public static List<WorkPermitDTO> CreateWorkPermitDTOList(params WorkPermitStatus[] workPermitStatuses)
        {
            List<WorkPermitDTO> ret = new List<WorkPermitDTO>();

            foreach (WorkPermitStatus status in workPermitStatuses)
            {
                WorkPermitDTO dto = new WorkPermitDTO(WorkPermitFixture.CreateWorkPermitWithGivenStatus(status));
                ret.Add(dto);
            }
            return ret;
        }
    }
}