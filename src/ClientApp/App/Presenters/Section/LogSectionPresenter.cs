using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class LogSectionPresenter : AbstractSectionPresenter
    {
        public LogSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            if (authorized.ToViewLogs(userRoleElements))
            {
                presenters.Add(new LogPagePresenter());

                if (ClientSession.GetUserContext().Assignment != null)
                {
                    presenters.Add(new LogByAssignmentPagePresenter());
                }
            }

            if (authorized.ToViewOperatingEngineerLogs(userRoleElements))
            {
                presenters.Add(new OperatingEngineerLogPagePresenter());
            }

            if (authorized.ToViewCokerCards(userRoleElements))
            {
                presenters.Add(new CokerCardPagePresenter());
            }

            if (authorized.ToViewSummaryLogs(userRoleElements))
            {
                presenters.Add(new SummaryLogPagePresenter());
            }

            if (ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives && authorized.ToViewDirectiveLogs(userRoleElements))
            {
                presenters.Add(new DailyDirectivesLogPagePresenter());
            }

            if (ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives && authorized.ToViewStandingOrders(userRoleElements))
            {
                presenters.Add(new StandingOrderPagePresenter());
            }

            if (authorized.ToViewLogDefinitions(userRoleElements))
            {
                presenters.Add(new LogDefinitionPagePresenter());
            }

            if (authorized.ToViewSAPNotifications(userRoleElements))
            {
                presenters.Add(new SAPNotificationPagePresenter());
            }

            return presenters;
        }

    }
}
