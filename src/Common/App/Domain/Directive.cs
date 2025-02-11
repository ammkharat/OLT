﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Directive : ModifiableDomainObject, IFunctionalLocationRelevant, IVisibilityGroupRelevant,
        IDocumentLinksObject, IReadable
    {
        public Directive(DateTime activeFromDateTime, DateTime activeToDateTime, string content, string plainTextContent,                  
            User lastModifiedBy, DateTime lastModifiedDateTime, User createdBy, Role createdByRole, DateTime createdDateTime)
            : base(lastModifiedBy, lastModifiedDateTime)
        {
            
            ActiveToDateTime = activeToDateTime;
            ActiveFromDateTime = activeFromDateTime;
            Content = content;
            PlainTextContent = plainTextContent;

            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;

            CreatedByRole = createdByRole;

            WorkAssignments = new List<WorkAssignment>();
            FunctionalLocations = new List<FunctionalLocation>();
            DocumentLinks = new List<DocumentLink>();
        }


        public List<WorkAssignment> WorkAssignments { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public DateTime ActiveFromDateTime { get; set; }
        public DateTime ActiveToDateTime { get; set; }

        public string Content { get; set; }

        public string PlainTextContent { get; set; }

        public User CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Role CreatedByRole { get; private set; }
        public DataSource Source { get; set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        public string MigrationSource { get; set; }

        public string ExtraInfoFromMigrationSource { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }
        public string CreatedByWorkAssignmentName { get; set; }
        
        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionsFullHierarchies, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                    return true;
            }
            return false;
        }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(WorkAssignments).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public DirectiveHistory TakeSnapshot()
        {
            var functionalLocations = FunctionalLocations.FullHierarchyListToString(true, false);
            var workAssignments = WorkAssignments.BuildNameStringFromWorkAssignmentList();
            var documentLinks = DocumentLinks.AsString(link => link.TitleWithUrl);

            return new DirectiveHistory(Id.Value, functionalLocations, workAssignments, documentLinks,
                ActiveFromDateTime, ActiveToDateTime, PlainTextContent, LastModifiedBy, LastModifiedDateTime);
        }

        public bool IsActive(DateTime now)
        {
            return (now <= ActiveToDateTime && now >= ActiveFromDateTime);
        }

        public void ConvertToClone(UserShift currentShift, User createdByUser, Role createdByRole,
            List<FunctionalLocation> userSelectedFLOCRoots)
        {
            var now = Clock.Now;

            Id = null;

            ActiveFromDateTime = now;
            ActiveToDateTime = CreateDefaultEndTime(now, currentShift);

            CreatedDateTime = now;
            CreatedBy = createdByUser;
            CreatedByRole = createdByRole;
            LastModifiedDateTime = now;
            LastModifiedBy = createdByUser;

            FunctionalLocations = GetFunctionalLocationsThatAreInCurrentActiveSet(userSelectedFLOCRoots,
                FunctionalLocations);

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
        }

        private List<FunctionalLocation> GetFunctionalLocationsThatAreInCurrentActiveSet(
            List<FunctionalLocation> userSelectedFLOCRoots, List<FunctionalLocation> directiveFlocs)
        {
            var flocs = new List<FunctionalLocation>();
            foreach (var originalFloc in directiveFlocs)
            {
                if (
                    userSelectedFLOCRoots.Exists(
                        activeFloc => activeFloc.Id == originalFloc.Id || activeFloc.IsParentOf(originalFloc)))
                {
                    flocs.Add(originalFloc);
                }
            }
            return flocs;
        }

        public static DateTime CreateDefaultEndTime(DateTime now, UserShift currentShift)
        {
            var currentShiftEndTime = new Time(currentShift.EndDateTime);
            var tomorrow = new Date(now.AddDays(1));
            return tomorrow.CreateDateTime(currentShiftEndTime);
        }

        //vibhor

        public List<ImageUploader> Imagelist { get; set; }  


        //Added by ppanigrahi

        public List<ItemReadBy> itemReadBy { get; set; }
    }
}