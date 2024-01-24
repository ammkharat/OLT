using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public abstract class EditHistoryFormPresenter : BaseFormPresenter<IEditHistoryFormView>
    {
        private readonly DomainObject domainObject;
        protected readonly IEditHistoryService editHistoryService;

        protected EditHistoryFormPresenter(DomainObject domainObject) : base(new EditHistoryForm())
        {
            this.domainObject = domainObject;
            editHistoryService = ClientServiceRegistry.Instance.GetService<IEditHistoryService>();
            SubscribeToEvents();
        }

        protected abstract string DomainObjectTypeName { get; }
        protected abstract string DomainObjectName { get; }
        protected abstract List<DomainObjectChangeSet> GetChangeSets();

        private void SubscribeToEvents()
        {
            view.Load += View_Load;
            view.CloseButtonClicked += CloseButton_Clicked;
            view.SelectedItemChanged += SelectedItem_Changed;
        }

        private void View_Load(object sender, EventArgs e)
        {
            view.TypeGroupBoxText = DomainObjectTypeName;
            view.Name = DomainObjectName;
            if (domainObject.IsInDatabase())
            {
                view.DomainObjectChangeSets = GetChangeSets();
            }
        }

        private void SelectedItem_Changed(DomainObject o)
        {
            var selectedChangeSet = (DomainObjectChangeSet)o;
            List<PropertyChange> propertyChanges = selectedChangeSet.PropertyChanges;
            view.PropertyChanges = propertyChanges;
        }
    }
}