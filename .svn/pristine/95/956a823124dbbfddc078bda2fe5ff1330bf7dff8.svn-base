alter table PermitRequestEdmonton add FormGN1TradeChecklistId bigint NULL;
GO

ALTER TABLE [dbo].[PermitRequestEdmonton] WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_TradeChecklist] FOREIGN KEY([FormGN1TradeChecklistId])
REFERENCES [dbo].[TradeChecklist] ([Id])

-- forgot this in a previous check in:
ALTER TABLE [dbo].[PermitRequestEdmonton] WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmonton_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])

GO

