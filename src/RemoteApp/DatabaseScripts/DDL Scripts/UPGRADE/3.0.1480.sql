ALTER TABLE [dbo].[FutureLogReferenceCriteria]
DROP CONSTRAINT [FK_FutureLogReferenceCriteria_Log]

GO		
	
ALTER TABLE [dbo].[FutureLogReferenceCriteria]
ADD CONSTRAINT [FK_FutureLogReferenceCriteria_SummaryLog] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO

delete from roleelementtemplate where roleelementid in (90, 91, 93, 94)

GO

delete from roleelement where id = 90; -- edit in operator group
delete from roleelement where id = 91; -- edit in operating engineer group
delete from roleelement where id = 93; -- delete in operator group
delete from roleelement where id = 94; -- delete in operating engineer group

GO

update roleelement set name = 'Edit Shift Summary Logs' where id = 92

GO

update roleelement set name = 'Delete Shift Summary Logs' where id = 95;

GO

-- ------------------------- --
-- SummaryLog data migration --
-- ------------------------- -- 

alter table summarylog add TempLogId bigint null

GO

-- Log

insert into summarylog (LoggedDate, FunctionalLocationId, Comments, EHSFollowup, InspectionFollowup, ProcessControlFollowup,
OperationsFollowUp, SupervisionFollowUp, OtherFollowUp, CreatedByUserId, CreationUserShiftPatternId, LastModifiedUserId,
LastModifiedDateTime, Deleted, WorkAssignmentId, TempLogId)
select LoggedDate, FunctionalLocationId, Comments, EHSFollowUp, InspectionFollowUp, ProcessControlFollowup,
OperationsFollowup, SupervisionFollowUp, OtherFollowUp, UserId, CreationUserShiftPatternId, LastModifiedUserId,
LastModifiedDateTime, Deleted, WorkAssignmentId, Id
from log
where LogType = 2

GO

-- LogRead

insert into SummaryLogRead (SummaryLogId, UserId, DateTime)
select sl.Id, lr.UserId, lr.DateTime
from SummaryLog sl
inner join LogRead lr on lr.LogId = sl.TempLogId

GO

delete from LogRead
where LogId in (select Id from Log l where l.LogType = 2);

GO

-- LogHistory

insert into SummaryLogHistory (Id, FunctionalLocations, Comments, EHSFollowup, InspectionFollowup, ProcessControlFollowup,
OperationsFollowUp, SupervisionFollowUp, OtherFollowUp, LastModifiedUserId, LastModifiedDateTime, LiveLinkDocumentLinks, 
FutureLogReferenceCriteria)
select sl.Id, fl.FullHierarchy, lh.Comments, lh.EHSFollowup, lh.InspectionFollowup, lh.ProcessControlFollowup,
lh.OperationsFollowUp, lh.SupervisionFollowUp, lh.OtherFollowUp, lh.LastModifiedUserId, lh.LastModifiedDateTime, lh.LiveLinkDocumentLinks, null
from SummaryLog sl
inner join LogHistory lh on lh.Id = sl.TempLogId
inner join FunctionalLocation fl on fl.Id = lh.FunctionalLocationId
GO

--LiveLinkDocumentLinks for Summary Log
ALTER TABLE LiveLinkDocumentLink ADD SummaryLogId bigint NULL

ALTER TABLE [dbo].[LiveLinkDocumentLink]
ADD CONSTRAINT [FK_LiveLinkDocumentLink_SumamryLog] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO

UPDATE LiveLinkDocumentLink 
SET
	SummaryLogId = SummaryLog.Id,
	LogId = NULL
FROM 
	[SummaryLog]
WHERE 
	LiveLinkDocumentLink.LogId = [SummaryLog].[TempLogId]
GO

delete from LogHistory
where Id in (select Id from Log where LogType = 2);
GO

alter table summarylog drop column TempLogId
GO

delete from log where LogType = 2
GO

