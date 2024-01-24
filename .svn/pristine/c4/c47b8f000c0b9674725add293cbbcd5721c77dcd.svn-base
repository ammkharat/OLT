IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllRestrictionReasonCodes')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllRestrictionReasonCodes
	END
GO

CREATE Procedure [dbo].QueryAllRestrictionReasonCodes
@Siteid bigint

AS

SELECT * FROM RestrictionReasonCode 
where deleted = 0 and SiteId = @Siteid

GO

GRANT EXEC ON QueryAllRestrictionReasonCodes TO PUBLIC
GO