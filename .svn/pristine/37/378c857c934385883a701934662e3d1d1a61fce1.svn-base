using System;
using System.Collections.Generic;
using System.Configuration;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    public class DirectiveConversionService : IDirectiveConversionService
    {
        private const int BatchSize = 100;
        private readonly IDirectiveDao dao;
        private readonly IDirectiveHistoryDao historyDao;

        private readonly ILogDao logDao;
        private readonly ILogDefinitionService logDefinitionService;
        private readonly ILogHistoryDao logHistoryDao;
        private readonly IDirectiveReadDao readDao;
        private readonly IRolePermissionDao rolePermissionDao;

        private readonly IShiftPatternService shiftPatternService;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ISiteDao siteDao;
        private readonly ITimeService timeService;

        public DirectiveConversionService()
        {
            dao = DaoRegistry.GetDao<IDirectiveDao>();
            readDao = DaoRegistry.GetDao<IDirectiveReadDao>();
            historyDao = DaoRegistry.GetDao<IDirectiveHistoryDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            logHistoryDao = DaoRegistry.GetDao<ILogHistoryDao>();
            rolePermissionDao = DaoRegistry.GetDao<IRolePermissionDao>();

            logDefinitionService = new LogDefinitionService();
            timeService = new TimeService();
            shiftPatternService = new ShiftPatternService();
        }

        public void ChangeSiteConfigurationAndUpdateRolesToSupportNonLogBasedDirectives(long siteId)
        {
            var site = siteDao.QueryById(siteId);

            var siteConfiguration = siteConfigurationDao.QueryBySiteIdWithNoCaching(siteId);
            siteConfiguration.UseLogBasedDirectives = false;
            siteConfigurationDao.Update(siteConfiguration);

            UpdateRolesToSupportNonLogBasedDirectives(site);
        }

        public int QueryNumberOfBatches(long siteId, FunctionalLocation floc)
        {
            double count = logDao.QueryCountOfLogsByFunctionalLocation(siteId, LogType.DailyDirective,
                new List<FunctionalLocation> {floc});

            return (int) Math.Ceiling(count/BatchSize);
        }

        public void SwitchFromLogBasedDirectives(long siteId, int batchNumber, FunctionalLocation floc)
        {
            var logs = logDao.QueryLogsInBatchesByFunctionalLocation(siteId, batchNumber, BatchSize,
                LogType.DailyDirective, new List<FunctionalLocation> {floc});

            foreach (var log in logs)
            {
                var userShift = new UserShift(log.CreatedShiftPattern, log.CreatedDateTime);
                var activeToDateTime = GetActiveToDateTime(log.LogDateTime, userShift);

                var directive = new Directive(log.LogDateTime, activeToDateTime, log.RtfComments, log.PlainTextComments,   
                    log.LastModifiedBy, log.LastModifiedDate, log.CreationUser, log.CreatedByRole, log.CreatedDateTime)
                {
                    FunctionalLocations = log.FunctionalLocations,
                    DocumentLinks = log.DocumentLinks.ConvertAll(link => link.CloneWithoutId()),
                    MigrationSource = String.Format("Log Id #{0}", log.IdValue),
                    ExtraInfoFromMigrationSource = CustomFieldsString(log.CustomFieldEntries)
                };
                dao.Insert(directive);

                readDao.ConvertMarkedAsReadInformation(log.IdValue, directive.IdValue);

                // the user can't edit the logged date/time for directives so we can just use the date/time from the new directive
                var activeFromDateTimeForHistoryItems = directive.ActiveFromDateTime;
                var activeToDateTimeForHistoryItems = directive.ActiveToDateTime;

                var logHistories = logHistoryDao.GetById(log.IdValue);
                foreach (var logHistory in logHistories)
                {
                    var directiveHistory = new DirectiveHistory(directive.IdValue, logHistory.FunctionalLocations, null,
                        logHistory.DocumentLinks, activeFromDateTimeForHistoryItems, activeToDateTimeForHistoryItems,
                        logHistory.PlainTextComments, logHistory.LastModifiedBy, logHistory.LastModifiedDate);
                    historyDao.Insert(directiveHistory);
                }
            }
        }

        public void ConvertStandingOrdersToDirectiveAndThenCancelThem(long siteId, FunctionalLocation floc)
        {
            var site = siteDao.QueryById(siteId);
            var currentTimeAtSite = GetCurrentTimeAtSite(siteId);

            try
            {
                Clock.Enable();
                Clock.UseTimeService(timeService);
                Clock.TimeZone = timeService.GetTimeZoneInfo(ConfigurationManager.AppSettings["ServerTimeZone"]);

                var logDefinitions = logDefinitionService.QueryAllForScheduling();
                foreach (var logDefinition in logDefinitions)
                {
                    if (logDefinition.LogType == LogType.DailyDirective && logDefinition.FunctionalLocations.Count > 0 &&
                        logDefinition.FunctionalLocations[0].Site.IdValue == siteId &&
                        logDefinition.FunctionalLocations.Exists(floc.IsOrIsAncestorOfOrIsDescendantOf))
                    {
                        var activeFromDateTime = logDefinition.Schedule.NextInvokeDateTime;

                        if (activeFromDateTime.ToDate() < DateTime.MaxValue.ToDate())
                        {
                            var shift = shiftPatternService.GetShiftBySiteAndDateTime(site, activeFromDateTime);
                            var userShift = new UserShift(shift, activeFromDateTime);

                            var directive = new Directive(activeFromDateTime,                   
                                GetActiveToDateTime(activeFromDateTime, userShift), logDefinition.RtfComments,
                                logDefinition.PlainTextComments, logDefinition.LastModifiedBy,
                                logDefinition.LastModifiedDate, logDefinition.CreatedBy, logDefinition.CreatedByRole,
                                logDefinition.CreatedDateTime);
                            directive.FunctionalLocations = logDefinition.FunctionalLocations;
                            directive.DocumentLinks =
                                logDefinition.DocumentLinks.ConvertAll(link => link.CloneWithoutId());
                            directive.MigrationSource = String.Format("LogDefinition Id #{0}", logDefinition.IdValue);
                            directive.ExtraInfoFromMigrationSource = CustomFieldsString(logDefinition.CustomFieldEntries);
                            dao.Insert(directive);

                            historyDao.Insert(directive.TakeSnapshot());

                            logDefinitionService.Cancel(logDefinition, currentTimeAtSite);
                        }
                    }
                }
            }
            finally
            {
                Clock.UseTimeService(null);
                Clock.TimeZone = null;
                Clock.Disable();
            }
        }

        private DateTime GetCurrentTimeAtSite(long siteId)
        {
            var site = siteDao.QueryById(siteId);
            return GetCurrentTimeAtSite(site);
        }

        private DateTime GetCurrentTimeAtSite(Site site)
        {
            return timeService.GetTime(site.TimeZone);
        }

        private string CustomFieldsString(List<CustomFieldEntry> customFieldEntries)
        {
            var customFieldStrings = new List<string>();

            foreach (var customFieldEntry in customFieldEntries)
            {
                customFieldStrings.Add(String.Format("{0}: [{1}] {2}: [{3}]",
                    StringResources.DirectiveExtraInfo_CustomFieldName, customFieldEntry.CustomFieldName,
                    StringResources.DirectiveExtraInfo_CustomFieldValue, customFieldEntry.FieldEntryForDisplay));
            }

            if (customFieldStrings.Count > 0)
            {
                return customFieldStrings.Join(" | ");
            }
            return null;
        }

        private void UpdateRolesToSupportNonLogBasedDirectives(Site site)
        {
            var roleDao = DaoRegistry.GetDao<IRoleDao>();
            var roleElementDao = DaoRegistry.GetDao<IRoleElementDao>();
            var roleElementTemplateDao = DaoRegistry.GetDao<IRoleElementTemplateDao>();

            var roles = roleDao.QueryBySiteId(site.IdValue);

            List<Role> editNewDirectiveRoles = new List<Role>();
            List<Role> deleteNewDirectiveRoles = new List<Role>();

            foreach (var role in roles)
            {
                var roleElements = roleElementDao.QueryTemplate(role, false);

                // Map the old log-based directive role elements to the new directives

                // Logs, View Priorities - Directives (220) --> +Directives, View Priorities - Directives (267)
                if (roleElements.Contains(RoleElement.VIEW_LOG_BASED_DIRECTIVES_PRIORITIES))
                {
                    if (!roleElements.Contains(RoleElement.VIEW_NEW_DIRECTIVES_PRIORITIES))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.VIEW_NEW_DIRECTIVES_PRIORITIES.Name);
                    }
                }

                // Logs - Directives, View Directives (96) --> +Directives, View Directives (268)
                if (roleElements.Contains(RoleElement.VIEW_LOG_BASED_DIRECTIVES))
                {
                    if (!roleElements.Contains(RoleElement.VIEW_DIRECTIVE_NAVIGATION))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.VIEW_DIRECTIVE_NAVIGATION.Name);
                    }

                    if (!roleElements.Contains(RoleElement.VIEW_DIRECTIVES_FUTURE))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.VIEW_DIRECTIVES_FUTURE.Name);
                    }

                    if (!roleElements.Contains(RoleElement.VIEW_NEW_DIRECTIVES))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.VIEW_NEW_DIRECTIVES.Name);
                    }
                }

                // Logs - Directives, Create Directives (97) --> +Directives, Create Directives (269)
                if (roleElements.Contains(RoleElement.CREATE_LOG_BASED_DIRECTIVES))
                {
                    if (!roleElements.Contains(RoleElement.CREATE_NEW_DIRECTIVES))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.CREATE_NEW_DIRECTIVES.Name);
                    }
                }

                // Logs - Directives, Edit Directives (98) --> +Directives, Edit Directives (270)
                if (roleElements.Contains(RoleElement.EDIT_LOG_BASED_DIRECTIVES))
                {
                    if (!roleElements.Contains(RoleElement.EDIT_NEW_DIRECTIVES))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.EDIT_NEW_DIRECTIVES.Name);

                        editNewDirectiveRoles.Add(role);
                    }
                }

                // Logs - Directives, Delete Directives (99) --> +Directives, Delete Directives (271)
                if (roleElements.Contains(RoleElement.DELETE_LOG_BASED_DIRECTIVES))
                {
                    if (!roleElements.Contains(RoleElement.DELETE_NEW_DIRECTIVES))
                    {
                        roleElementTemplateDao.InsertRoleElementTemplate(site, role.Name,
                            RoleElement.DELETE_NEW_DIRECTIVES.Name);

                        deleteNewDirectiveRoles.Add(role);
                    }
                }

                // Delete the log-based directive role element template items

                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.VIEW_LOG_BASED_DIRECTIVES_PRIORITIES.Name); // 220

                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.VIEW_LOG_BASED_DIRECTIVES.Name); // 96
                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.CREATE_LOG_BASED_DIRECTIVES.Name); // 97
                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.EDIT_LOG_BASED_DIRECTIVES.Name); // 98
                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.DELETE_LOG_BASED_DIRECTIVES.Name); // 99

                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name, RoleElement.VIEW_STANDING_ORDERS.Name);
                // 178
                roleElementTemplateDao.DeleteRoleElementTemplate(site, role.Name,
                    RoleElement.CANCEL_STANDING_ORDERS.Name); // 177
            }

            var rolesCanCreateNewDirectives = roleDao.QueryAllAvailableInSiteWithAnyRoleElement(site.IdValue,
                new List<RoleElement> {RoleElement.CREATE_NEW_DIRECTIVES});

            foreach (var role in roles)
            {
                // Delete existing RolePermission items for "Edit Log Based Directives", "Delete Log Based Directives", and "Cancel Standing Orders"
                var rolePermissions = rolePermissionDao.QueryByRoleId(role.IdValue);
                foreach (var rolePermission in rolePermissions)
                {
                    if ((rolePermission.RoleElementId == RoleElement.EDIT_LOG_BASED_DIRECTIVES.Id) ||
                        (rolePermission.RoleElementId == RoleElement.DELETE_LOG_BASED_DIRECTIVES.Id) ||
                        (rolePermission.RoleElementId == RoleElement.CANCEL_STANDING_ORDERS.Id))
                    {
                        rolePermissionDao.Delete(rolePermission);
                    }
                }

                // Add new RolePermission items - for each role that can create new directives, allow this role to edit and delete directives created by them.
                if (editNewDirectiveRoles.Contains(role))
                {
                    InsertRolePermissionForCreatedByRoles(role, RoleElement.EDIT_NEW_DIRECTIVES,
                        rolesCanCreateNewDirectives);
                }

                if (deleteNewDirectiveRoles.Contains(role))
                {
                    InsertRolePermissionForCreatedByRoles(role, RoleElement.DELETE_NEW_DIRECTIVES,
                        rolesCanCreateNewDirectives);
                }
            }
        }

        private void InsertRolePermissionForCreatedByRoles(Role role, RoleElement roleElement, List<Role> createdByRoles)
        {
            foreach (var createdByRole in createdByRoles)
            {
                rolePermissionDao.Insert(new RolePermission(role.IdValue, roleElement.IdValue, createdByRole.IdValue));
            }
        }

        private DateTime GetActiveToDateTime(DateTime activeFromDateTime, UserShift userShift)
        {
            return Directive.CreateDefaultEndTime(activeFromDateTime, userShift);
        }
    }
}