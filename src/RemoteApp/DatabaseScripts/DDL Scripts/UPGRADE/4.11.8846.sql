DROP INDEX [IDX_WorkPermit_DTO_Covering] ON [dbo].[WorkPermit];
GO

ALTER TABLE WorkPermit ALTER COLUMN LastModifiedUserId BIGINT NOT NULL;
GO

ALTER TABLE [dbo].[WorkPermit] 
ADD  CONSTRAINT [FK_WorkPermit_LastModifiedUserId]
FOREIGN KEY ([LastModifiedUserId])
REFERENCES [dbo].[User] ( [Id] )
GO

ALTER TABLE [dbo].[WorkPermit] 
ADD  CONSTRAINT [FK_WorkPermit_CreatedByUserId]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] )
GO
ALTER TABLE [dbo].[WorkPermit] 
ADD  CONSTRAINT [FK_WorkPermit_ApprovedByUserId]
FOREIGN KEY ([ApprovedByUserId])
REFERENCES [dbo].[User] ( [Id] )
GO

CREATE NONCLUSTERED INDEX [IDX_WorkPermit_WorkPermitPage]
ON [dbo].[WorkPermit]
(
 [StartDateTime] , [EndDateTime], [WorkPermitStatusId], [WorkAssignmentId]
)
INCLUDE ([CraftOrTradeID] , [FunctionalLocationId] , [WorkPermitTypeId] , [CreatedByUserId] , [ApprovedByUserId] , [LastModifiedUserId])
WHERE (DELETED = 0)
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO


GO

