
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75BIsolationItem]') 
         AND name = 'Siteid'
)
BEGIN
Alter table FormGN75BIsolationItem add [Siteid]  [bigint]
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75BIsolationItem]') 
         AND name = 'DevicePosition'
)
BEGIN
Alter table FormGN75BIsolationItem add [DevicePosition] [varchar](20)
END

go

update FormGN75BIsolationItem set siteid = 8 where (siteid is null or siteid = 0)


GO

