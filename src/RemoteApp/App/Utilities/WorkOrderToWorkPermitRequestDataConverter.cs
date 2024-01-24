using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Wcf;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public abstract class WorkOrderToWorkPermitRequestDataConverter<T> where T : BasePermitRequest
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkOrderToWorkPermitRequestDataConverter<T>>();

        private readonly ITimeService timeService;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ICraftOrTradeDao craftOrTradeDao;
       
        public WorkOrderToWorkPermitRequestDataConverter(ITimeService timeService, IFunctionalLocationDao functionalLocationDao, ICraftOrTradeDao craftOrTradeDao)
        {                        
            this.timeService = timeService;
            this.functionalLocationDao = functionalLocationDao;
            this.craftOrTradeDao = craftOrTradeDao;
        }

        public List<T> ConvertToPermitRequests(List<WorkOrderRecordList> workOrderRecordLists, User userThatInitiatedImport, Site site, out List<PermitRequestImportRejection> rejectList)
        {            
            List<T> permitRequests = new List<T>();
            rejectList = new List<PermitRequestImportRejection>();

            foreach (WorkOrderRecordList workOrderRecordList in workOrderRecordLists)
            {
                WorkOrderDetails detail = workOrderRecordList.WorkOrderDetails[0];
                
                if(!string.Equals(workOrderRecordList.processStatus, WorkOrderImporter.SUCCESS_STATUS))
                {
                    string workOrderNumber = detail.WONumber.EmptyToNull();
                    string reason = workOrderNumber == null
                                        ? StringResources.PermitRequestImportValidationError_NonSuccessStatus
                                        : string.Format(StringResources.PermitRequestImportValidationError_NonSuccessStatusWithWONumber,
                                          workOrderNumber);
                   
                    PermitRequestImportRejection rejectionDueToStatus = new PermitRequestImportRejection(reason);
                    rejectList.Add(rejectionDueToStatus);
                    continue;
                }

                Operations[] operationsList = detail.Operations;

                foreach (Operations operations in operationsList)
                {
                    PermitRequestImportRejection rejection;

                    try
                    {
                        T permitRequest = BuildPermitRequest(detail, operations, userThatInitiatedImport, site, out rejection);

                        if (permitRequest != null)
                        {
                            permitRequests.Add(permitRequest);
                        }
                        else if (rejection != null)
                        {
                            rejectList.Add(rejection);
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error("There was an unexpected error processing an operation.", e);
                        rejection = new PermitRequestImportRejection(StringResources.PermitRequestRejectionExceptionMessage, e);
                        rejectList.Add(rejection);
                    }
                }                
            }
            
            return permitRequests;
        }


        private T BuildPermitRequest(
            WorkOrderDetails detail, Operations operations, User importUser, Site site, out PermitRequestImportRejection rejection)
        {
            // We ignore these. In the future, these may be turned into Action Items.
            if (SAPWorkCentre.IsInWorkCentreList(operations.WorkCenterName))
            {
                rejection = null;
                return null;
            }

            FunctionalLocation floc = functionalLocationDao.QueryByFullHierarchy(detail.FunctionalLocation, site.IdValue);

            DateTime? currentTimeAtSite = null;
            CraftOrTrade craftOrTrade = null;
            
            if (floc != null)
            {
                currentTimeAtSite = timeService.GetTime(floc.Site.TimeZone);
                craftOrTrade = craftOrTradeDao.QueryByWorkCentreCodeAndSiteId(operations.WorkCenterName, floc.Site.IdValue);
            }

            // note: On the message, WorkCenterName is what we might call the code. ie. BNP-541C. In our DB, it's the opposite.
            string trade = BuildTrade(craftOrTrade, operations.WorkCenterText, operations.WorkCenterName);

            DateTime? startDateTime = GetDateTime(operations.EarliestStartDate, operations.EarliestStartTime);
            Date endDate = GetDate(operations.EarliestFinishDate);

            string workOrderNumber = detail.WONumber;
            string operationNumber = operations.OperationNumber.EmptyToNull();
            string subOperationNumber = operations.Suboperation.EmptyToNull();

            string descriptionFromSAP = BuildDescription(operations.LongText, detail.ShortText);
            if (descriptionFromSAP != null)
            {
                descriptionFromSAP = descriptionFromSAP.Trim();
            }
            string description = descriptionFromSAP;
            string sapDescription = descriptionFromSAP;

            string company = null;
            string supervisor = null;
            
            DataSource dataSource = DataSource.SAP;
            User lastImportedByUser = importUser;
            DateTime? lastImportedDateTime = currentTimeAtSite;
            User lastSubmittedByUser = null;
            DateTime? lastSubmittedDateTime = null;
            User createdBy = importUser;
            DateTime createdDateTime = currentTimeAtSite.HasValue ? currentTimeAtSite.Value : DateTime.MinValue;
            User lastModifiedBy = importUser;
            DateTime lastModifiedDateTime = currentTimeAtSite.HasValue ? currentTimeAtSite.Value : DateTime.MinValue;
            
            T request = BuildPermitRequest(operations, detail, floc, startDateTime, endDate, workOrderNumber, operationNumber, subOperationNumber,
                                      trade, description, sapDescription, company, supervisor, dataSource, lastImportedByUser, lastImportedDateTime, 
                                      lastSubmittedByUser, lastSubmittedDateTime, createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime);            

            rejection = Validate(request, detail, operations);

            if (rejection == null)
            {
                return request;
            }

            return null;                      
        }

        protected virtual string BuildTrade(CraftOrTrade craftOrTrade, string workCenterText, string workCentreCode)
        {
            return craftOrTrade != null ? craftOrTrade.Name : null;
        }

        protected abstract T BuildPermitRequest(Operations operations,
                                                                WorkOrderDetails details,
                                                                FunctionalLocation functionalLocation,
                                                                DateTime? startDateTime,
                                                                Date endDate,
                                                                string workOrderNumber,
                                                                string operationNumber,
                                                                string subOperationNumber,
                                                                string trade,
                                                                string description,
                                                                string sapDescription,
                                                                string company,
                                                                string supervisor,
                                                                DataSource dataSource,
                                                                User lastImportedByUser,
                                                                DateTime? lastImportedDateTime,
                                                                User lastSubmittedByUser,
                                                                DateTime? lastSubmittedDateTime,
                                                                User createdBy,
                                                                DateTime createdDateTime,
                                                                User lastModifiedBy,
                                                                DateTime lastModifiedDateTime);
      

        private static Date GetDate(string dateString)
        {
            DateTime result;
            bool parsed = DateTime.TryParse(dateString, out result);

            return parsed ? new Date(result) : default(Date);
        }

        private DateTime? GetDateTime(string dateString, string timeString)
        {
            DateTime result;

            // first try to parse both the date and time.
            if (dateString.HasValue() && timeString.HasValue())
            {
                bool parsed = DateTimeExtensions.TryParse(dateString, timeString, out result);
                if (parsed)
                {
                    return result;
                }
            }

            // if that fails, try to parse just the date.
            if (dateString.HasValue())
            {
                bool parsed = DateTimeExtensions.TryParse(dateString, Time.START_OF_DAY.ToString(), out result);
                if (parsed)
                {
                    return result;
                }
            }
            return default(DateTime?);
        }

        private PermitRequestImportRejection Validate(BasePermitRequest request, WorkOrderDetails details, Operations operations)
        {
            PermitRequestImportRejection rejection = null;
            
            if (request.HasNoFunctionalLocation() && details.FunctionalLocation != null)
            {
                string message =
                    string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationNotFound, 
                        details.FunctionalLocation);

                rejection = BuildRejection(message, details, operations);
            }
            else
            {
                List<string> missingFieldList = GetMissingImportFieldList(request);

                if (missingFieldList.Count > 0)
                {                    
                    string errorMessage = string.Format(StringResources.PermitRequestImportValidationError_FieldMissing, missingFieldList.BuildCommaSeparatedList());
                    rejection = BuildRejection(errorMessage, details, operations);
                }                
                else if (request.HasAFunctionalLocationHigherThanLevel3())
                {
                    string message = string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationCannotBeLevel1Or2,
                                  request.FunctionalLocationNamesAsString);

                    rejection = BuildRejection(message, details, operations);
                }     
            }
           
            return rejection;
        }

        protected abstract List<string> GetMissingImportFieldList(BasePermitRequest permitRequest);

        private static PermitRequestImportRejection BuildRejection(string reason, WorkOrderDetails details, Operations operations)
        {
            return new PermitRequestImportRejection(
                reason, details.FunctionalLocation, operations.OperationNumber, operations.Suboperation, details.WONumber,
                operations.LongText, details.ShortText, operations.EarliestStartDate, operations.EarliestFinishDate);            
        }

        private string BuildDescription(string longText, string shortText)
        {
            if (longText.IsNullOrEmptyOrWhitespace() && shortText.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            return string.Format("{0}{1}{2}", longText, Environment.NewLine, shortText);
        }
    }
}