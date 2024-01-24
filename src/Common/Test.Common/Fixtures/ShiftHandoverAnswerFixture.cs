using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class ShiftHandoverAnswerFixture
    {
        public static ShiftHandoverAnswer GetShiftHandoverAnswerToInsert(string comments, string questionText,string yesNo,string emailList)
        {
            return GetShiftHandoverAnswerToInsert(comments, questionText,yesNo,emailList,false);//yesNo is added by ppanigrahi
        }

        public static ShiftHandoverAnswer GetShiftHandoverAnswerToInsert(string comments, string questionText,string yesNo,string emailList, bool answer)//yesNo is added by ppanigrahi
        {
            return new ShiftHandoverAnswer(
                null,
                answer,
                comments,
                questionText,
                yesNo,
                emailList,
                1,
                1);
        }

    }
}