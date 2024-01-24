DROP INDEX [IDX_WorkPermit_FLOC] ON [dbo].[WorkPermit] WITH ( ONLINE = OFF )

CREATE NONCLUSTERED INDEX [IDX_WorkPermit_DTO_Covering] ON [dbo].[WorkPermit] 
(
	[WorkPermitStatusId] ASC,
	[Deleted] ASC,
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[CraftOrTradeID] ASC,
	[FunctionalLocationId] ASC,
	[WorkPermitTypeId] ASC,
	[CreatedByUserId] ASC,
	[ApprovedByUserId] ASC,
	[LastModifiedUserId] ASC,
	[WorkAssignmentId] ASC
)
INCLUDE ( [Id]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]



GO
