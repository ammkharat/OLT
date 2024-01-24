-- Add WorkAssignmentId and FK to TargetDefinition
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
if not exists(select * from sys.columns 
            where Name = N'WorkAssignmentId' and Object_ID = Object_ID(N'TargetDefinition'))
begin
  ALTER TABLE [dbo].[TargetDefinition] ADD [WorkAssignmentId] bigint NULL
  ALTER TABLE [dbo].[TargetDefinition] 
  ADD  CONSTRAINT [FK_TargetDefinition_WorkAssignment]
  FOREIGN KEY ([WorkAssignmentId])
  REFERENCES [dbo].[WorkAssignment] ( [Id] )
end
GO


-- Add WorkAssignmentName to TargetDefinitionHistory
if not exists(select * from sys.columns 
            where Name = N'WorkAssignmentName' and Object_ID = Object_ID(N'TargetDefinitionHistory'))
begin
  ALTER TABLE [dbo].[TargetDefinitionHistory] ADD [WorkAssignmentName] varchar(40) NULL
end
go


GO

