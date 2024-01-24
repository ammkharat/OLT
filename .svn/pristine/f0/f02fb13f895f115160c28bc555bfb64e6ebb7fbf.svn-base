using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface IVisibilityGroupRelevant
    {
        bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds);
    }

    public class StandardVisibilityGroupRelevance
    {
        private readonly List<long> itemWriteableVisibilityGroupIds = new List<long>();

        public StandardVisibilityGroupRelevance(List<WorkAssignmentVisibilityGroup> itemWorkAssignmentVisibilityGroups)
        {
            if (itemWorkAssignmentVisibilityGroups != null)
            {
                itemWriteableVisibilityGroupIds =
                    itemWorkAssignmentVisibilityGroups.FindAll(wavg => wavg.VisibilityType == VisibilityType.Write)
                        .ConvertAll(wavg => wavg.VisibilityGroupId);
            }
            else
            {
                itemWriteableVisibilityGroupIds = null;
            }
        }

        public StandardVisibilityGroupRelevance(List<WorkAssignment> assignments)
            : this(
                assignments.IsEmpty()
                    ? null
                    : assignments.ConvertAll(a => a.WriteWorkAssignmentVisibilityGroups).Flatten())
        {
        }

        public StandardVisibilityGroupRelevance(WorkAssignment workAssignment)
            : this(workAssignment == null ? null : new List<WorkAssignment> {workAssignment})
        {
        }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            if (itemWriteableVisibilityGroupIds == null)
            {
                return true;
            }

            return itemWriteableVisibilityGroupIds.Exists(vgId => clientReadableVisibilityGroupIds.Contains(vgId));
        }
    }
}