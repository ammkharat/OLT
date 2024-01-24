

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestTemplate]') AND name = 'LastModifiedByUserId'
)
begin
ALTER TABLE PermitRequestTemplate ADD LastModifiedByUserId bigint
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestTemplate]') AND name = 'LastModifiedDateTime'
)
begin
ALTER TABLE PermitRequestTemplate ADD LastModifiedDateTime datetime 
end






