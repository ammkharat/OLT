IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionLocationByWorkAssignmentId')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionLocationByWorkAssignmentId
	END
GO

CREATE Procedure [dbo].QueryRestrictionLocationByWorkAssignmentId
(
	@WorkAssignmentId bigint
)
AS

SELECT   
	 RestrictionLocationId   
	FROM   
	 RestrictionLocationWorkAssignment WA 
	 JOIN RestrictionLocation RL
	 ON WA.RestrictionLocationId=RL.Id
	 AND ISNULL(RL.DELETED,0)=0
	WHERE   
	 WorkAssignmentId=@WorkAssignmentId  
GO

GRANT EXEC ON QueryRestrictionLocationByWorkAssignmentId TO PUBLIC
GO