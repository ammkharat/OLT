-- Add SourceId PermitRequestMontrealHistory
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
if not exists(select * from sys.columns 
            where Name = N'SourceId' and Object_ID = Object_ID(N'PermitRequestMontrealHistory'))
begin
  ALTER TABLE [dbo].[PermitRequestMontrealHistory] ADD [SourceId] int NOT NULL DEFAULT 0
end
GO



GO

