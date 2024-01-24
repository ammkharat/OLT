

--- Create floc association table

CREATE TABLE [dbo].[PermitRequestMontrealFunctionalLocation](
	[PermitRequestMontrealId] bigint NOT NULL,
	[FunctionalLocationId] bigint NOT NULL
			
	CONSTRAINT [PK_PermitRequestMontrealFunctionalLocation] PRIMARY KEY CLUSTERED
	(
		[PermitRequestMontrealId] ASC,
		[FunctionalLocationId] ASC
	)
)
GO

ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]
ADD CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_PermitRequestMontreal]
FOREIGN KEY([PermitRequestMontrealId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
GO

ALTER TABLE [dbo].[PermitRequestMontrealFunctionalLocation]
ADD CONSTRAINT [FK_PermitRequestMontrealFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestMontrealFunctionalLocation_Floc]
ON [dbo].[PermitRequestMontrealFunctionalLocation]
([FunctionalLocationId])
ON [PRIMARY];
GO

--- Copy flocs into the new table

INSERT INTO [dbo].PermitRequestMontrealFunctionalLocation
SELECT Id, FunctionalLocationId FROM [dbo].[PermitRequestMontreal]
GO


--- Prepare to drop FunctionalLocationId column

DROP INDEX [IDX_Permit_Request] ON [dbo].[PermitRequestMontreal];
GO

CREATE NONCLUSTERED INDEX [IDX_Permit_Request] ON [dbo].[PermitRequestMontreal] 
(
	[StartDate] ASC,
	[EndDate] ASC,
	[Deleted] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PermitRequestMontreal]
DROP CONSTRAINT FK_PermitRequestMontreal_FunctionalLocation
GO

--- Drop FunctionalLocationId column

alter table [dbo].[PermitRequestMontreal] drop column FunctionalLocationId
GO



GO




GO

