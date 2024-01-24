using System;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverQuestion : DomainObject, IHasDisplayOrder
    {
        public const string DISPLAY_ORDER_PROPERTY = "DisplayOrder";
        private long? configurationId;
        private int displayOrder;
        private string helpText;
        private string text;
        private string emaillist;//Add by ppanigrahi
        private string yesnovalue;//Add by ppanigrahi

       public ShiftHandoverQuestion(long? id, long configurationId, int displayOrder, string text, string helpText)
        {
            this.id = id;
            this.configurationId = configurationId;
            this.displayOrder = displayOrder;
            this.text = text;
            this.helpText = helpText;
        }

        public ShiftHandoverQuestion(int displayOrder, string text, string helpText,string emaillist,string yesnovalue)
        {
            this.displayOrder = displayOrder;
            this.text = text;
            this.helpText = helpText;
            this.emaillist = emaillist;
           this.yesnovalue = yesnovalue;
        }

        //New constructor has been added by ppanigrahi
        public ShiftHandoverQuestion(long? id, long configurationId, int displayOrder, string text,string yesnovalue,string emaillist, string helpText)
        {
            this.id = id;
            this.configurationId = configurationId;
            this.displayOrder = displayOrder;
            this.text = text;
            this.yesnovalue = yesnovalue;
            this.emaillist = emaillist;
            this.helpText = helpText;
        }

        public long? ConfigurationId
        {
            get { return configurationId; }
            set { configurationId = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string HelpText
        {
            get { return helpText; }
            set { helpText = value; }
        }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }
        //Add by ppanigrahi
        public string EmailList
        {

            get { return emaillist; }

            set { emaillist = value; }

        }
        //Add by ppanigrahi
        public string YesNoValue
        {
            get { return yesnovalue; }
            set { yesnovalue = value; }
        }
    }
}