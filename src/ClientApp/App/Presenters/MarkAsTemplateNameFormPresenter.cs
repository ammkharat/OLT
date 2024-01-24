using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    class MarkAsTemplateNameFormPresenter
    {
        private readonly IMarkAsTemplateNameForm view;
        public string WpTemplatename;
        public string category;
        public bool global;
        public bool individual;
        public bool cancel = false;
        public bool save = false;
        

        public MarkAsTemplateNameFormPresenter()
        {
            
        }
        public MarkAsTemplateNameFormPresenter(IMarkAsTemplateNameForm view)
        {
            this.view = view;
            
        }

        public void HandleSelectButtonClicked(object sender, EventArgs e)
        {
            
            bool flag = false;
            view.ClearError();
            if (view.WorkPermitTemplateName == String.Empty)
            {
                view.SetErrorForTemplateName();
                flag = true;
            }
            if (view.Category == null)
            {
                view.SetErrorForCategories();
                flag = true;
            }
             if (!view.Global && ! view.Individual)
            {
                view.SetErrorForGlobal();
                flag = true;
            }
             if (!view.Global && !view.Individual)
             {
                 view.SetErrorForIndividual();
                 flag = true;
             }
             if (view.Error == true)
            {
                ShowError();
            }
            if (flag == false)
            {
                WpTemplatename = view.WorkPermitTemplateName;
                category = view.Category;
                global = view.Global;
                individual = view.Individual;
                view.Save = true;
                view.Close();
            }
        }
        public void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            view.Save = false;
            view.ClearError();
            view.Close();
        }

        //public bool Save { get; set; }
        //public bool Cancel { get; set; }
        //public bool Error_Flag { get; set; }

        public void ShowError()
        {
            OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                            "Cannot proceed further, please change the Temlate name and Category");
        }

        

        
    }
}
