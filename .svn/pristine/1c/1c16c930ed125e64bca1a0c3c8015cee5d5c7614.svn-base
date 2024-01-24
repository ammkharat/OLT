using System;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ShiftHandoverAnswerDTO
    {
        private readonly bool answer;
        private readonly string comments;
        private readonly int questionDisplayOrder;
        private readonly string questionText;
        private readonly long questionnaireId;
        private readonly string yesNo;//Added by ppanigrahi
        private readonly string emailList;//Added by ppanigrahi

        public ShiftHandoverAnswerDTO(long questionnaireId, bool answer, string comments, string questionText,string yesNo,string emailList,
            int questionDisplayOrder)
        {
            this.questionnaireId = questionnaireId;
            this.answer = answer;
            this.comments = comments;
            this.questionText = questionText;
            this.yesNo = yesNo;
            this.emailList = emailList;//Added by ppanigrahi
            this.questionDisplayOrder = questionDisplayOrder;//Added by ppanigrahi

        }

        public ShiftHandoverAnswerDTO(long questionnaireId, bool answer, string comments, string questionText,int questionDisplayOrder)
        {
            this.questionnaireId = questionnaireId;
            this.answer = answer;
            this.comments = comments;
            this.questionText = questionText;
            this.questionDisplayOrder = questionDisplayOrder;//Added by ppanigrahi

        }

        public long QuestionnaireId
        {
            get { return questionnaireId; }
        }

        public bool Answer
        {
            get { return answer; }
        }

        public string Comments
        {
            get { return comments; }
        }

        public string QuestionText
        {
            get { return questionText; }
        }
        public string YesNo
        {
            get { return yesNo; }
        }
        public string EmailList
        {
            get { return emailList; }
        }

        public int QuestionDisplayOrder
        {
            get { return questionDisplayOrder; }
        }
    }
}