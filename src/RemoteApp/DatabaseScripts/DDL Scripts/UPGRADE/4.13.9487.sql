---------------------------------------------

CREATE TABLE [dbo].[TradeChecklistHistory](
	[Id] [bigint] NOT NULL,
	[Trade] varchar(128) NULL,	
	[Content] nvarchar(max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TradeChecklistHistory]  WITH CHECK ADD  CONSTRAINT [FK_TradeChecklistHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[TradeChecklistHistory] CHECK CONSTRAINT [FK_TradeChecklistHistory_LastModifiedByUser]
GO


GO

