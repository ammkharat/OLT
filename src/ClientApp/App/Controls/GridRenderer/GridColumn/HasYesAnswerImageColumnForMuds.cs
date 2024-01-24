using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class HasYesAnswerImageColumnForMuds : AbstractImageBooleanColumn<WorkPermitMudsDTO> 
    {
        private const string COLUMN_KEY = "HasAnswerImage";
        private const int WIDTH = 65;

        public HasYesAnswerImageColumnForMuds()
            : base(obj => obj.IsQuestionAnswered,
            obj => obj.IsQuestionAnswered, GetGroupByValue, GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        //(dto.MudsAnswerTextBox != String.Empty && dto.MudsAnswerTextBox != null)

        private static string GetGroupByValue<T>(T obj) where T : WorkPermitMudsDTO
        {
            return GetDisplayValue(obj.IsQuestionAnswered);
        }

        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>
            {
                new ImageMapItem<bool>(true, ResourceUtils.FLAG, GetDisplayValue(true), GetDisplayValue(true)),
                new ImageMapItem<bool>(false, ResourceUtils.NO_FLAG, GetDisplayValue(false), GetDisplayValue(false))
            };

            return items;
        }

        private static string GetDisplayValue(bool hasYesAnswer)
        {
            return hasYesAnswer ? "Question Answered" : "Question Not Answered";
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.QuestionResponses; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }
    }
}
