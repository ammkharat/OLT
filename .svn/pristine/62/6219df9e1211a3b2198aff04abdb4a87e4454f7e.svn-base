alter table WorkPermitEdmontonDetails add FormGN1Id bigint NULL;
GO

ALTER TABLE [dbo].[WorkPermitEdmontonDetails] WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])
GO

alter table WorkPermitEdmontonDetails add GN1 bit NULL;
GO

update WorkPermitEdmontonDetails set GN1 = 0;

alter table WorkPermitEdmontonDetails alter column GN1 bit NOT NULL;
GO

alter table WorkPermitEdmontonDetails add FormGN1TradeChecklistId bigint NULL;
GO

ALTER TABLE [dbo].[WorkPermitEdmontonDetails] WITH CHECK ADD CONSTRAINT [FK_WorkPermitEdmontonDetails_TradeChecklist] FOREIGN KEY([FormGN1TradeChecklistId])
REFERENCES [dbo].[TradeChecklist] ([Id])
GO

alter table WorkPermitEdmontonDetails add FormGN1TradeChecklistDisplayNumber varchar(32) NULL;


GO

