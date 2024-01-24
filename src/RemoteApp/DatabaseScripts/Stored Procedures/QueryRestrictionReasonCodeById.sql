IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionReasonCodeById')
    BEGIN
        DROP PROCEDURE [dbo].QueryRestrictionReasonCodeById
    END
GO

CREATE Procedure [dbo].QueryRestrictionReasonCodeById
(
    @Id bigint
)
AS

SELECT
    *
FROM
    RestrictionReasonCode
WHERE
    RestrictionReasonCode.Id = @Id
GO

GRANT EXEC ON QueryRestrictionReasonCodeById TO PUBLIC
GO