CREATE TABLE [dbo].[TradeChecklist](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SequenceNumber] int NOT NULL,
	[FormGN1Id] bigint NOT NULL,
	[Trade] varchar(128) NOT NULL,	
	[ConstFieldMaintCoordApproval] bit NOT NULL,
	[OpsCoordApproval] bit NOT NULL,
	[AreaManagerApproval] bit NOT NULL,	
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_TradeChecklist] PRIMARY KEY CLUSTERED([Id] ASC) 
		WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY];
		
GO

ALTER TABLE [dbo].[TradeChecklist] ADD  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[TradeChecklist] WITH CHECK ADD CONSTRAINT [FK_TradeChecklist_FormGN1Id] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO

ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD CONSTRAINT [FK_TradeChecklist_LastModifiedUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO



GO

