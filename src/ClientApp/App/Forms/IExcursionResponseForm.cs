﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IExcursionResponseForm : IAddEditBaseFormView
    {
        string ExcursionToeName { set; }
        string CurrentTagValue { set; }
        string ExcursionHistorianTag { set; get; }
        string ExcursionUnitOfMeasure { set; }
        string ToeFloc {  set; }
        DateTime? ToePublishDate {  set; }
        bool HasCommentForEngineer { get; set; }
        string ToeCommentForEngineer { get; set; }
        string ToeCauseOfDeviation {  set; }
        string ToeReferenceDocuments {set; }
        string ToeConsequencesOfDeviation {set; }
        string ToeCorrectiveActions { set; }
        List<ExcursionResponseEditingGridRowDTO> ExcursionsToUpdate { get; set; }
        string MostRecentExcursionResponseComment { set; }
        bool IsToeDefinitionCommentingEnabled { set; get; }
        string ToeOpmHistoryUrl { set; }
        bool CopyToLog { get; }
        bool EditEnabled { set; }
        void SetErrorForMissingResponses();
        void SetErrorForMissingToeCommentForEngineer();

        string MostRecentExcursionAsset { set; }
        string MostRecentExcursionResponseCode { set; }

        
        
    }
}