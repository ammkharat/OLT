﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    interface IMarkAsTemplateNameForm : IForm
    {
        string WorkPermitTemplateName { get; set; }
        void SetErrorForTemplateName();
        void ClearError();
        void SetErrorForCategories();
        void SetErrorForGlobal();
        void SetErrorForIndividual();

        string Category { get; set; }

        bool Global { get; set; }
        bool Individual { get; set; }
        bool Error { get; set; }
        bool Save { get; set; }
        
        
    }
}
