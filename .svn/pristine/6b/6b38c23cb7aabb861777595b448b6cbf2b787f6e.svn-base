

--- Create floc association table

CREATE TABLE [dbo].[WorkPermitMontrealFunctionalLocation](
	[WorkPermitMontrealId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_WorkPermitMontrealFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[WorkPermitMontrealId] ASC,
		[FunctionalLocationId] ASC
	)
)
GO

ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]
ADD CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_WorkPermitMontreal]
FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitMontrealFunctionalLocation]
ADD CONSTRAINT [FK_WorkPermitMontrealFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

CREATE NONCLUSTERED INDEX [IDX_WorkPermitMontrealFunctionalLocation_Floc]
ON [dbo].[WorkPermitMontrealFunctionalLocation]
([FunctionalLocationId])
ON [PRIMARY];
GO

--- Copy flocs into the new table

INSERT INTO [dbo].WorkPermitMontrealFunctionalLocation
SELECT Id, FunctionalLocationId FROM [dbo].[WorkPermitMontreal]
GO


--- Prepare to drop FunctionalLocationId column

DROP INDEX [IDX_WorkPermitMontreal_DTO] ON [dbo].[WorkPermitMontreal];
GO

CREATE NONCLUSTERED INDEX [IDX_WorkPermitMontreal_DTO] ON [dbo].[WorkPermitMontreal] 
(
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WorkPermitMontreal]
DROP CONSTRAINT FK_WorkPermitMontreal_Floc
GO

--- Drop FunctionalLocationId column

alter table [dbo].[WorkPermitMontreal] drop column FunctionalLocationId
GO



GO

