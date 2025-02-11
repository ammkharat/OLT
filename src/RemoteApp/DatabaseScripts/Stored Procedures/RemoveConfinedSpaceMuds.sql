
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveConfinedSpaceMuds')
	BEGIN
		DROP Procedure [dbo].RemoveConfinedSpaceMuds
	END
GO


Create Procedure [dbo].[RemoveConfinedSpaceMuds]
(
	@Id bigint,
	@LastModifiedDateTime datetime,
	@LastModifiedByUserId bigint
)
AS

UPDATE ConfinedSpaceMuds
  SET
  	LastModifiedDateTime = @LastModifiedDateTime,
  	LastModifiedByUserId = @LastModifiedByUserId,
    Deleted = 1
WHERE 
	Id = @Id
	
	
	
GRANT EXEC ON RemoveConfinedSpaceMuds TO PUBLIC
GO
	
