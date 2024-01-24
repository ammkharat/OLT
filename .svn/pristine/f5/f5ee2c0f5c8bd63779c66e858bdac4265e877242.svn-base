using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditRestrictionReasonCodeLimitForm : BaseForm
    {
        private readonly List<RestrictionLocationItemReasonCodeAssociation> associations;

        public EditRestrictionReasonCodeLimitForm(List<RestrictionLocationItemReasonCodeAssociation> associations)
        {
            InitializeComponent();

            this.associations = associations;
           
            SetUpControl();

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            foreach (RestrictionLocationItemReasonCodeAssociation association in associations)
            {
                association.Limit = limitTextBox.IntegerValue;
            }
            
            Close();
        }
    
        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void SetUpControl()
        {
            limitTextBox.IntegerValue = null;

            if (associations.Count == 1)
            {
                limitTextBox.IntegerValue = associations[0].Limit;
            }
            else if(associations.Count > 1)
            {
                int? limit = associations[0].Limit;

                if (AllAssociationsHaveSameLimit(limit))
                {
                    limitTextBox.IntegerValue = limit;
                }                
            }            
        }

        private bool AllAssociationsHaveSameLimit(int? limit)
        {
            return associations.TrueForAll(association => association.Limit == limit);
        }
    }
}
