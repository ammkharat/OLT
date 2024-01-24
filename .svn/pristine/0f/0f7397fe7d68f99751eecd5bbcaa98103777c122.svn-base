IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteCommunication]') 
         AND name = 'sitename'
)
begin
alter table [dbo].[SiteCommunication] add [sitename] varchar(100) NULL
end



GO

