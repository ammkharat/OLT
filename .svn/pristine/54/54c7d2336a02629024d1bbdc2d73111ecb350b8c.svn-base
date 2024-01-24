


alter table TradeChecklist add ConstFieldMaintCoordApprovalLastModifiedId bigint null;

alter table TradeChecklist add OpsCoordApprovalLastModifiedId bigint null;

alter table TradeChecklist add AreaManagerApprovalLastModifiedId bigint null;

GO

ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD CONSTRAINT [FK_TradeChecklist_ConstFieldMaintCoordApprovalLastModifiedId_LastModifiedUser] 
FOREIGN KEY([LastModifiedByUserId]) REFERENCES [dbo].[User] ([Id]);

ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD CONSTRAINT [FK_TradeChecklist_OpsCoordApprovalLastModifiedId_LastModifiedUser] 
FOREIGN KEY([LastModifiedByUserId]) REFERENCES [dbo].[User] ([Id]);

ALTER TABLE [dbo].[TradeChecklist]  WITH CHECK ADD CONSTRAINT [FK_TradeChecklist_AreaManagerApprovalLastModifiedId_LastModifiedUser] 
FOREIGN KEY([LastModifiedByUserId]) REFERENCES [dbo].[User] ([Id]);


GO

