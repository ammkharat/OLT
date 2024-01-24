using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class FormGN1Fixture
    {
        public static FormGN1 CreateForInsert()
        {
            DateTime now = Clock.Now;
            DateTime later = now.AddDays(3);

            return CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U008(), now, later, FormStatus.Draft);                        
        }

        public static FormGN1 CreateForInsert(FunctionalLocation floc, DateTime fromDateTime, DateTime toDateTime, FormStatus status)
        {
            DateTime now = Clock.Now;
            
            User createUser = UserFixture.CreateUserWithGivenId(1);
            long siteid = 8;
            FormGN1 form = new FormGN1(null, status, floc, "1", fromDateTime, toDateTime, createUser, now,siteid)   //ayman generic forms
            {
                Location = "Location Text",
                JobDescription = "Clean the chicken coops",
                DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()},
                PlanningWorksheetContent = "This is the planning worksheet content",
                RescuePlanContent = "This is the rescue plan content"
            };

            TradeChecklist c1 = new TradeChecklist
            {
                SequenceNumber = 0,
                Content = "This is some content for the first item",
                PlainTextContent = "Plain text content for the first item"
            };
            c1.SetOpsCoordApproval(true, createUser, now);           
            c1.Trade = "Refractionation Organizer";
            c1.LastModifiedUser = createUser;
            c1.LastModifiedDateTime = now;
            
            TradeChecklist c2 = new TradeChecklist {SequenceNumber = 1};
            c2.SetAreaManagerApproval(true, createUser, now);            
            c2.Content = "This is some content for the second item";
            c2.PlainTextContent = "Plain text content for the second item";
            c2.Trade = "Indoor Precipitation Collection Agent";
            c2.LastModifiedUser = createUser;
            c2.LastModifiedDateTime = now;
            
            form.TradeChecklists = new List<TradeChecklist> { c1, c2 };
            
            return form;
        }

        public static TradeChecklist GetTradeChecklist()
        {
            TradeChecklist tradeChecklist = new TradeChecklist();

            DateTime lastModified = new DateTime(2014, 3, 5, 4, 30, 0);

            tradeChecklist.SetConstFieldMaintApproval(false, UserFixture.CreateUserWithGivenId(1), lastModified);
            tradeChecklist.SetOpsCoordApproval(true, UserFixture.CreateUserWithGivenId(2), lastModified);
            tradeChecklist.SetAreaManagerApproval(true, UserFixture.CreateUserWithGivenId(3), lastModified);
                        
            tradeChecklist.ParentFormNumber = -1;
            tradeChecklist.Trade = "Honey Truck Operator";
            tradeChecklist.Content = "This is some content for the second item";
            tradeChecklist.PlainTextContent = "Plain text content for the second item";
            tradeChecklist.LastModifiedDateTime = lastModified;
            tradeChecklist.LastModifiedUser = UserFixture.CreateUserWithGivenId(1);

            return tradeChecklist;
        }
    }
}
