using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public abstract class BaseMergeablePermitRequest : BasePermitRequest, IMergeablePermitRequest, ISAPImportData
    {
        private readonly List<PermitRequestWorkOrderSource> workOrderSourceList =
            new List<PermitRequestWorkOrderSource>();

        protected BaseMergeablePermitRequest(long? id, Date endDate, string description, string sapDescription,
            string company, DataSource dataSource, User lastImportedByUser, DateTime? lastImportedDateTime,
            User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy, DateTime createdDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime, string workOrderNumber,
            string operationNumber, string subOperationNumber, PermitRequestCompletionStatus completionStatus)
            : base(
                id, endDate, description, sapDescription, company, dataSource, lastImportedByUser, lastImportedDateTime,
                lastSubmittedByUser,
                lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime, workOrderNumber,
                operationNumber, subOperationNumber, completionStatus)
        {
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        protected BaseMergeablePermitRequest(string templatename, string categories) 
            :base(templatename,categories)
        {
            _templateName = templatename;
            _categories = categories;
        }

        public string OperationNumberListAsString
        {
            get { return GetCommaSeparatedString(source => source.OperationNumber); }
        }

        public string SubOperationNumberListAsString
        {
            get
            {
                var opNumAndSubOpNumCombos = new List<string>();
                foreach (var workOrderSource in WorkOrderSourceList)
                {
                    if (!workOrderSource.SubOperationNumber.IsNullOrEmptyOrWhitespace())
                    {
                        opNumAndSubOpNumCombos.Add(String.Format("{0}-{1}", workOrderSource.OperationNumber,
                            workOrderSource.SubOperationNumber));
                    }
                }

                opNumAndSubOpNumCombos.Sort();
                return opNumAndSubOpNumCombos.Join(", ").EmptyToNull();
            }
        }

        public Date RequestedStartDate { get; set; }
        public string SAPWorkCentre { get; set; }

        public override bool MatchesByPermitKey(IHasPermitKey item)
        {
            return WorkOrderSourceList.Exists(wos => wos.MatchesByPermitKey(item));
        }

        public virtual List<PermitRequestWorkOrderSource> WorkOrderSourceList
        {
            get { return new List<PermitRequestWorkOrderSource>(workOrderSourceList); }
        }

        public virtual void AddWorkOrderSource(PermitRequestWorkOrderSource workOrderSource)
        {
            if (workOrderSourceList.Exists(i => i.WorkOrderNumber != workOrderSource.WorkOrderNumber))
            {
                throw new ArgumentException(
                    "Work order operations that contribute to a Permit Request must all share the same work order number.");
            }

            WorkOrderNumber = workOrderSource.WorkOrderNumber;
            workOrderSourceList.Add(workOrderSource);
        }

        public void ClearWorkOrderSources()
        {
            workOrderSourceList.Clear();
        }

        public bool ContainsWorkOrderSource(IHasPermitKey permitKey)
        {
            return WorkOrderSourceList.Exists(s => s.MatchesByPermitKey(permitKey));
        }

        public abstract PermitRequestCompletionStatus DetectIsComplete();
        public bool DoNotMerge { get; set; }

        public bool IsSubOperation
        {
            get { return SubOperationNumber != null; }
        }

        public virtual void AddWorkOrderSource(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            AddWorkOrderSource(new PermitRequestWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber));
        }

        public bool ContainsWorkOrderSource(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            return ContainsWorkOrderSource(new PermitKeyData(workOrderNumber, operationNumber, subOperationNumber));
        }

        private string GetCommaSeparatedString(Func<PermitRequestWorkOrderSource, string> getFieldValue)
        {
            var returnList = new HashSet<string>();

            foreach (var source in WorkOrderSourceList)
            {
                var fieldValue = getFieldValue(source);

                if (fieldValue != null)
                {
                    returnList.Add(fieldValue);
                }
            }

            var uniqueList = new List<string>();
            uniqueList.AddRange(returnList);

            if (uniqueList.Count > 0)
            {
                uniqueList.Sort();
                return uniqueList.ToCommaSeparatedString();
            }

            return null;
        }
    }
}