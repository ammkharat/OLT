
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowAdminToCreateAndEditPastDateLog'
)
BEGIN
ALTER TABLE SiteConfiguration ADD AllowAdminToCreateAndEditPastDateLog BIT NOT NULL DEFAULT '0'
END


GO

