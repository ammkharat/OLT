alter table SummaryLogFunctionalLocation
drop PK_SummaryLogFunctionalLocation

go

alter table SummaryLogFunctionalLocation
add CONSTRAINT PK_SummaryLogFunctionalLocation PRIMARY KEY CLUSTERED 
	(
		[SummaryLogId] ASC,
		[FunctionalLocationId] ASC
	)


go

alter table SummaryLogFunctionalLocation
drop column Id

go

-- -------------------------------


ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] 
ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocation_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

go

GO
