
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'FormWorkPermitMudsId'
)
begin
alter table [dbo].[DocumentLink] Add FormWorkPermitMudsId bigint 
end
Go


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[DocumentLink]') 
         AND name = 'PermitRequestMudsId'
)
begin
alter table [dbo].[DocumentLink] Add PermitRequestMudsId bigint 
end
Go


