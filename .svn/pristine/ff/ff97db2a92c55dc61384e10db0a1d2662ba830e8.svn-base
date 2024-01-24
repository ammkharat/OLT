using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractPermitRequestPagePresenter<TDto, TDomainObject, TDetails, TPage> : AbstractDeletableDomainPagePresenter<TDto, TDomainObject, TDetails, TPage>
        where TDto : DomainObject 
        where TDomainObject : DomainObject
        where TDetails : IDeletableDetails
        where TPage : class, IDomainPage<TDto, TDetails>
    {
        protected AbstractPermitRequestPagePresenter(TPage page) : base(page)
        {
        }

        protected AbstractPermitRequestPagePresenter(TPage page, IAuthorized authorized, IRemoteEventRepeater remoteEventRepeater, IObjectLockingService objectLockingService, ITimeService timeService, IUserService userService) : 
            base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
        }       
    }
}
