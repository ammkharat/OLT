IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateApprover]') 
         AND name = 'IsDeleted'
)
begin
alter table [dbo].[FormGenericTemplateApprover] Add [IsDeleted] [bit] NOT NULL DEFAULT 0
end
Go





GO

