﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;


namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPopupSarniaExtension
    {
        event EventHandler SaveButtonClicked;
        event EventHandler CancelButtonClick;
        event Action FormLoad;
        DateTime? ExtensionDateTime { get; set; }
        DateTime ExpiryDateTime { get; set; }
       // string ExtensionComment { get; set; }
        void DisplayErrorMessageDialog(string message, string title);
        void DisplayInvalidPrintMessage(string message);
        bool ExtensionDateEnable { get; set; }
        bool ExtensionTimeEnable { get; set; }
        Time ExtensionTime { get; }
        //void UnlimitWork();
        void ExtensionWork(string msg);


        //  void ClearErrorProviders();

    }
}
