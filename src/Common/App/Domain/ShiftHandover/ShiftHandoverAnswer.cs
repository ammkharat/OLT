﻿using System;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverAnswer : DomainObject
    {
        private readonly int questionDisplayOrder;
        private readonly string questionText;
        private readonly long shiftHandoverQuestionId;
        private bool answer;
        private string comments;
        private string yesNovalue;//Added by ppanigrahi
        private string emailList;

        public ShiftHandoverAnswer()
        {
        }
        //yesNoValue,emailList is added by ppanigrahi
        public ShiftHandoverAnswer(long? id, bool answer, string comments, string questionText, string yesNovalue,string emailList, int questionDisplayOrder,
           long shiftHandoverQuestionId)
        {
            this.id = id;
            this.answer = answer;
            this.comments = comments;
            this.questionText = questionText;
            this.yesNovalue = yesNovalue;
            this.emailList = emailList;
            this.questionDisplayOrder = questionDisplayOrder;
            this.shiftHandoverQuestionId = shiftHandoverQuestionId;
        }
        public ShiftHandoverAnswer(long? id, bool answer, string comments, string questionText, int questionDisplayOrder,
            long shiftHandoverQuestionId)
        {
            this.id = id;
            this.answer = answer;
            this.comments = comments;
            this.questionText = questionText;
            this.questionDisplayOrder = questionDisplayOrder;
            this.shiftHandoverQuestionId = shiftHandoverQuestionId;            
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public bool Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        //Added by ppanigrahi
        public string YesNo
        {
            get { return yesNovalue; }
            set { yesNovalue = value; }
            
        }
        //Added by ppanigrahi
        public string EmailList
        {
            get { return emailList; }
            set { emailList = value; }
        }

        public string QuestionText
        {
            get { return questionText; }
        }

        public int QuestionDisplayOrder
        {
            get { return questionDisplayOrder; }
        }

        public long ShiftHandoverQuestionId
        {
            get { return shiftHandoverQuestionId; }
        }

        public bool IsCompleted
        {
            get { return id.HasValue; }
        }

        public ShiftHandoverAnswerHistory TakeSnapshot()
        {
            return new ShiftHandoverAnswerHistory(IdValue, 0, shiftHandoverQuestionId, questionText, answer, comments);
        }

//Added By Vibhor - RITM0553278 :Shift Hanover Enhancement

        public bool CommentsAdded
        {
            get
            {
                if (comments.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //set { comments = value; }
        }

    }
}