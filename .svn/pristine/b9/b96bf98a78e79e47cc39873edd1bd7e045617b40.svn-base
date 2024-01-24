using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class SAPImportExtensions
    {
        public static int GetResultCount(this List<PermitRequestImportResult> list)
        {
            var count = 0;

            foreach (var result in list)
            {
                count += result.NotifiedEvents.Count;
            }

            return count;
        }

        public static bool HasErrors(this List<PermitRequestImportResult> list)
        {
            return list.Exists(r => r.HasError);
        }

        public static bool HasRejections(this List<PermitRequestImportResult> results)
        {
            return results.Exists(r => r.HasRejections);
        }

        public static bool HasResults(this List<PermitRequestImportResult> results)
        {
            return results.Exists(r => r.HasResults);
        }

        public static List<NotifiedEvent> GetNotifiedEvents(this List<PermitRequestImportResult> results)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            foreach (var result in results)
            {
                notifiedEvents.AddRange(result.NotifiedEvents);
            }

            return notifiedEvents;
        }

        public static List<T> GetDomainObjects<T>(this List<PermitRequestImportResult> results) where T : DomainObject
        {
            var domainObjects = new List<T>();

            foreach (var result in results)
            {
                foreach (var notifiedEvent in result.NotifiedEvents)
                {
                    domainObjects.Add((T) notifiedEvent.DomainObject);
                }
            }

            return domainObjects;
        }

        public static List<IHasPermitKey> GetPermitKeyDataFromPermitRequests(
            this List<PermitRequestImportResult> results)
        {
            var permitKeyData = new List<IHasPermitKey>();

            foreach (var result in results)
            {
                foreach (var notifiedEvent in result.NotifiedEvents)
                {
                    if (notifiedEvent.DomainObject != null)
                    {
                        var request = (PermitRequestEdmonton) notifiedEvent.DomainObject;

                        request.WorkOrderSourceList.ForEach(
                            workOrderSource => permitKeyData.Add(new PermitKeyData(workOrderSource)));
                    }
                }
            }

            return permitKeyData;
        }

        public static List<IHasPermitKey> GetProcessedWorkOrderData(this List<PermitRequestImportResult> results)
        {
            var permitKeyData = new List<IHasPermitKey>();

            foreach (var result in results)
            {
                permitKeyData.AddRange(result.ImportedWorkOrders);
            }

            return permitKeyData;
        }


        public static List<IHasPermitKey> GetKeysForRejectedPermitRequests(this List<PermitRequestImportResult> results)
        {
            var keys = new List<IHasPermitKey>();

            foreach (var result in results)
            {
                foreach (var rejection in result.Rejections)
                {
                    keys.Add(new PermitKeyData(rejection.WorkOrderNumber, rejection.OperationNumber,
                        rejection.SubOperationNumber));
                }
            }

            return keys;
        }
        public static List<IHasPermitKey> GetPermitKeyDataFromPermitRequestsFH(
            this List<PermitRequestImportResult> results)
        {
            var permitKeyData = new List<IHasPermitKey>();

            foreach (var result in results)
            {
                foreach (var notifiedEvent in result.NotifiedEvents)
                {
                    if (notifiedEvent.DomainObject != null)
                    {
                        var request = (PermitRequestFortHills)notifiedEvent.DomainObject;

                        request.WorkOrderSourceList.ForEach(
                            workOrderSource => permitKeyData.Add(new PermitKeyData(workOrderSource)));
                    }
                }
            }

            return permitKeyData;
        }
    }
}