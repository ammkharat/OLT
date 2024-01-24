using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditTradeChecklistFormPresenter : BaseFormPresenter<IAddEditTradeChecklistView>
    {
        private readonly TradeChecklist editObject;
        private readonly bool isEditMode;        

        private List<CraftOrTrade> craftOrTrades;
        private FormTemplate formTemplate;

        private readonly UserContext userContext;

        public AddEditTradeChecklistFormPresenter(TradeChecklist editObject, bool isEditMode) : base(new AddEditTradeChecklistForm())
        {
            userContext = ClientSession.GetUserContext();

            this.editObject = editObject;
            this.isEditMode = isEditMode;            

            view.FormLoad += HandleFormLoad;
            view.SaveAndCloseButtonClick += HandleSaveAndCloseButtonClick;
            view.ViewHistoryButtonClick += HandleViewHistoryButtonClick;
        }

        private void HandleViewHistoryButtonClick()
        {
            TradeChecklistHistoryFormPresenter presenter = new TradeChecklistHistoryFormPresenter(editObject);
            presenter.Run(view);
        
        }

        private bool Validate()
        {
            bool hasErrors = false;

            if (string.IsNullOrEmpty(view.Trade))
            {
                view.ShowMustSelectATradeError();
                hasErrors = true;
            }

            return hasErrors;
        }

        private void HandleSaveAndCloseButtonClick()
        {
            bool hasErrors = Validate();

            if (hasErrors)
            {
                return;
            }

            if(editObject.HasApprovalByOtherPeople(userContext.User) && SomethingHasChanged())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {                    
                    User currentUser = ClientSession.GetUserContext().User;
                    editObject.UnapproveApprovalsNotByUser(currentUser);                    
                }
                else
                {
                    return;
                }
            }
            
            UpdateEditObjectFromView();            
            
            view.DialogResult = DialogResult.OK;            
            view.Close();
        }

        private bool SomethingHasChanged()
        {
            bool tradeHasChanged = !Equals(view.Trade, editObject.Trade);
            bool contentHasChanged = !Equals(view.PlainTextContent, editObject.PlainTextContent);

            return tradeHasChanged || contentHasChanged;
        }

        private void UpdateEditObjectFromView()
        {
            editObject.Trade = view.Trade;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
        }

        private void HandleFormLoad()
        {            
            LoadData(new List<Action>{ LoadCraftOrTradeValues, LoadTemplate });            
        }        

        protected override void AfterDataLoad()
        {
            view.TradeList = craftOrTrades.ConvertAll(cot => cot.Name);
            
            if(!isEditMode)
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();            
        }

        private void UpdateViewFromEditObject()
        {
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.LastModifiedUser = editObject.LastModifiedUser;
            view.Trade = editObject.Trade;
            view.Content = editObject.Content;
            view.TradeChecklistInformation = editObject.TradeChecklistInformationDisplayText;
        }

        private void LoadCraftOrTradeValues()
        {
            craftOrTrades = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(ClientSession.GetUserContext().Site);
        }

        private void LoadTemplate()
        {
            formTemplate = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>().QueryFormTemplateByFormTypeAndKey(EdmontonFormType.GN1, FormTemplateKeys.GN1_TRADE_CHECKLIST);            
        }
    }
}
