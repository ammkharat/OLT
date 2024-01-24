ALTER TABLE [dbo].[ActionItemDefinition] DROP CONSTRAINT FK_ActionItemDefinition_Category

GO

drop table ActionItemDefinitionCategory

GO

sys.sp_rename 'dbo.ActionItemDefinition.ActionItemDefinitionCategoryId', 'BusinessCategoryId', 'COLUMN'

GO

ALTER TABLE [dbo].[ActionItemDefinition] ADD CONSTRAINT [FK_ActionItemDefinition_BusinessCategory] 
FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])

GO

GO
sys.sp_rename 'dbo.ActionItem.ActionItemDefinitionCategoryId', 'BusinessCategoryId', 'COLUMN'

GO

ALTER TABLE [dbo].[ActionItem] ADD CONSTRAINT [FK_ActionItem_BusinessCategory] 
FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])

GO

GO
sys.sp_rename 'dbo.ActionItemDefinitionHistory.ActionItemDefinitionCategoryId', 'BusinessCategoryId', 'COLUMN'

GO

ALTER TABLE [dbo].[ActionItemDefinitionHistory] ADD CONSTRAINT [FK_ActionItemDefinitionHistory_BusinessCategory] 
FOREIGN KEY([BusinessCategoryId])
REFERENCES [dbo].[BusinessCategory] ([Id])

GO
GO
