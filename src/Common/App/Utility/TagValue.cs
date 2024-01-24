using System;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class TagValue
    {
        private readonly DateTime dateTime;
        private readonly string tagName;
        private readonly decimal? value;

        public TagValue(string tagName, decimal? value, DateTime dateTime)
        {
            this.tagName = tagName;
            this.value = value;
            this.dateTime = dateTime;
        }

        public string TagName
        {
            get { return tagName; }
        }

        public decimal? Value
        {
            get { return value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", dateTime, tagName, value);
        }

        // Added by Mukesh :-RITM0238302
        public Object AlphaNumericValue { get; set; }
        public TagValue(string tagName, object value, DateTime dateTime)
        {
            this.tagName = tagName;
            this.AlphaNumericValue = value;
            this.dateTime = dateTime;
        }
    }

    [Serializable]
    public class TagReadRequest
    {
        public TagReadRequest(string tagName, DateTime evaluationTime)
        {
            EvaluationTime = evaluationTime;
            TagName = tagName;
        }

        public DateTime EvaluationTime { get; private set; }
        public string TagName { get; private set; }
    }
}