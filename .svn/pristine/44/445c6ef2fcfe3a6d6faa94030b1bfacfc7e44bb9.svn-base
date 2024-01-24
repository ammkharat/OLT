DECLARE @SiteId bigint
DECLARE @StatusId tinyint

SET @SiteId=9 -- Montreal
SET @StatusId=9 -- Permit Not Returned

INSERT INTO WorkPermitCloseConfiguration ([SiteId], [StatusId], [RequiresLog])
SELECT @SiteId, @StatusId, 0 
   WHERE NOT EXISTS (SELECT [SiteId], [StatusId] FROM WorkPermitCloseConfiguration
                     WHERE SiteId=@SiteId and StatusId=@StatusId)

GO



GO

