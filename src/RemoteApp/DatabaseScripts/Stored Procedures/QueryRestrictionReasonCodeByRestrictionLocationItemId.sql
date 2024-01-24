IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionReasonCodeByRestrictionLocationItemId')
    BEGIN
        DROP PROCEDURE [dbo].QueryRestrictionReasonCodeByRestrictionLocationItemId
    END
GO

CREATE Procedure [dbo].QueryRestrictionReasonCodeByRestrictionLocationItemId
(
    @RestrictionLocationItemId bigint
)
AS

SELECT
    rc.Id as ReasonCodeId,
	assoc.RestrictionLocationItemId,
	assoc.[Limit]
FROM
    RestrictionLocationItemReasonCode assoc
	INNER JOIN RestrictionReasonCode rc ON rc.Id = assoc.RestrictionReasonCodeId
WHERE
    rc.Deleted = 0 and
    assoc.RestrictionLocationItemId = @RestrictionLocationItemId
GO

GRANT EXEC ON QueryRestrictionReasonCodeByRestrictionLocationItemId TO PUBLIC
GO