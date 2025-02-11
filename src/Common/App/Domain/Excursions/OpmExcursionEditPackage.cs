﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionEditPackage : DomainObject
    {
        private readonly List<OpmExcursion> excursions;
        private readonly List<ExcursionResponseEditingGridRowDTO> excursionsToUpdate;

        public OpmExcursionEditPackage(List<OpmExcursion> excursions)
        {
            this.excursions = excursions;
            excursionsToUpdate = new List<ExcursionResponseEditingGridRowDTO>();
            foreach (var opmExcursion in excursions)
            {
                excursionsToUpdate.Add(new ExcursionResponseEditingGridRowDTO(opmExcursion.IdValue,opmExcursion.OpmExcursionId,
                    opmExcursion.HistorianTag,
                    opmExcursion.ToeName, opmExcursion.ToeType, opmExcursion.Status, opmExcursion.StartDateTime,
                    opmExcursion.Peak, opmExcursion.Average,
                    opmExcursion.Duration, opmExcursion.IlpNumber, opmExcursion.ToeLimitValue,
                    opmExcursion.OpmExcursionResponse.Response, opmExcursion.OpmExcursionResponse.LastModifiedDateTime,
                    opmExcursion.OpmExcursionResponse.Id, opmExcursion.OpmTrendUrl, opmExcursion.OpmExcursionResponse.Asset, opmExcursion.OpmExcursionResponse.Code)); //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            }
        }

        public string MostRecentExcursionResponseComment
        {
            get
            {
                var orderByDescending = excursions.Where(excursion => excursion.OpmExcursionResponse.HasResponse)
                    .OrderByDescending(excursion => excursion.OpmExcursionResponse.LastModifiedDateTime).ToList();
                if (orderByDescending.Count > 0)
                {
                    return orderByDescending
                        .First()
                        .OpmExcursionResponse.Response;
                }
                return null;
            }
        }

        public string MostRecentExcursionAsset
        {
            get
            {
                var orderByDescending = excursions//.Where(excursion => excursion.OpmExcursionResponse.HasResponse)
                    .OrderByDescending(excursion => excursion.OpmExcursionResponse.LastModifiedDateTime).ToList();
                if (orderByDescending.Count > 0)
                {
                    return orderByDescending
                        .First()
                        .OpmExcursionResponse.Asset;
                }
                return null;
            }
        }

        public string MostRecentExcursionResponseCode
        {
            get
            {
                var orderByDescending = excursions//.Where(excursion => excursion.OpmExcursionResponse.HasResponse)
                    .OrderByDescending(excursion => excursion.OpmExcursionResponse.LastModifiedDateTime).ToList();
                if (orderByDescending.Count > 0)
                {
                    return orderByDescending
                        .First()
                        .OpmExcursionResponse.Code;
                }
                return null;
            }
        }

        public List<ExcursionResponseEditingGridRowDTO> ExcursionsForGridEditing
        {
            get { return excursionsToUpdate.OrderByDescending(dto => dto.StartDateTime).ToList(); }
        }

        public List<OpmExcursion> Excursions
        {
            get { return excursions; }
        }

        public OpmToeDefinition OpmToeDefinition
        {
            get
            {
                return excursions.Count > 0
                    ? excursions.OrderBy(excursion => excursion.StartDateTime).Last().OpmToeDefinition
                    : null;
            }
        }

        public bool IsUniqueToeExcursion
        {
            get { return excursions.ConvertAll(input => input.ToeName).Unique().Count == 1; }
        }

        public string ExcursionToeName
        {
            get { return ! IsUniqueToeExcursion ? string.Empty : excursions.First().ToeName; }
        }

        public string ExcursionHistorianTag
        {
            get { return ! IsUniqueToeExcursion ? string.Empty : excursions.First().HistorianTag; }
        }

        public string ExcursionUnitOfMeasure
        {
            get { return ! IsUniqueToeExcursion ? string.Empty : excursions.First().UnitOfMeasure; }
        }

        public string ToeToeName
        {
            get { return IsUniqueToeExcursion && OpmToeDefinition != null ? OpmToeDefinition.ToeName : string.Empty; }
        }

        public string ToeTagName
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null ? OpmToeDefinition.HistorianTag : string.Empty;
            }
        }

        public string ToeUnitOfMeasurement
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null ? OpmToeDefinition.UnitOfMeasure : string.Empty;
            }
        }

        public bool ToeHasCommentForEngineer
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null &&
                       !OpmToeDefinition.OpmToeDefinitionComment.Comment.IsNullOrEmptyOrWhitespace();
            }
        }

        public string ToeCommentForEngineer
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.OpmToeDefinitionComment.Comment
                    : string.Empty;
            }
            set
            {
                if (OpmToeDefinition == null) return;
                OpmToeDefinition.OpmToeDefinitionComment.Comment = value;
            }
        }

        public string ToeFloc
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.FunctionalLocation
                    : string.Empty;
            }
        }

        public DateTime? ToePublishDate
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.ToeVersionPublishDate
                    : (DateTime?) null;
            }
        }

        public string ToeCauseOfDeviation
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.CausesDescription
                    : string.Empty;
            }
        }

        public string ToeCorrectiveActions
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.CorrectiveActionDescription
                    : string.Empty;
            }
        }

        public string ToeConsequencesOfDeviation
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.ConsequencesDescription
                    : string.Empty;
            }
        }

        public string ToeReferenceDocuments
        {
            get
            {
                return IsUniqueToeExcursion && OpmToeDefinition != null
                    ? OpmToeDefinition.ReferencesDocuments
                    : string.Empty;
            }
        }


        public User ToeCommentLastModifiedBy
        {
            set
            {
                if (OpmToeDefinition == null) return;
                OpmToeDefinition.OpmToeDefinitionComment.LastModifiedBy = value;
            }
        }

        public DateTime ToeCommentLastModifiedDateTime
        {
            set
            {
                if (OpmToeDefinition == null) return;
                OpmToeDefinition.OpmToeDefinitionComment.LastModifiedDateTime = value;
            }
        }

        public bool IsToeCommentDirty { get; set; }
        public Log ExcursionLog { get; set; }

    }
}