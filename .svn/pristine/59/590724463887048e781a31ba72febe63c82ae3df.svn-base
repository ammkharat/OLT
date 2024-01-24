using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public abstract class AbstractMergeTool<T> where T : BaseMergeablePermitRequest
    {
        protected void GetStartAndEndDateTimeInformation(out Date earliestStartDateResult, out Date latestEndDateResult, List<T> permitRequests)
        {
            Date earliestRequestedStartDate = permitRequests[0].RequestedStartDate;
            foreach (T request in permitRequests)
            {
                if (request.RequestedStartDate != null)
                {
                    if (earliestRequestedStartDate == null)
                    {
                        earliestRequestedStartDate = request.RequestedStartDate;
                    }
                    else if (request.RequestedStartDate < earliestRequestedStartDate)
                    {
                        earliestRequestedStartDate = request.RequestedStartDate;
                    }
                }
            }

            Date latestEndDate = permitRequests[0].EndDate;
            foreach (T request in permitRequests)
            {
                if (request.EndDate != null)
                {
                    if (latestEndDate == null)
                    {
                        latestEndDate = request.EndDate;
                    }
                    else if (request.EndDate > latestEndDate)
                    {
                        latestEndDate = request.EndDate;
                    }
                }
            }

            earliestStartDateResult = earliestRequestedStartDate;
            latestEndDateResult = latestEndDate;          
        }

        protected void SetWorkOrderSources(T mergedRequest, List<T> permitRequests)
        {
            foreach (T request in permitRequests)
            {
                foreach (PermitRequestWorkOrderSource workOrderSource in request.WorkOrderSourceList)
                {
                    if (!mergedRequest.WorkOrderSourceList.Exists(wos => wos.Equals(workOrderSource)))
                    {
                        mergedRequest.AddWorkOrderSource(workOrderSource);
                    }
                }
            }
        }
    }    
}
