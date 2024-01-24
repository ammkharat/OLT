IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardConfigurationByWorkAssignment')
	BEGIN
		DROP  Procedure dbo.QueryCokerCardConfigurationByWorkAssignment
	END
GO

CREATE Procedure dbo.QueryCokerCardConfigurationByWorkAssignment
	(
		@WorkAssignmentId bigint
	)

AS
select distinct CokerCardConfiguration.Id
from 
  CokerCardConfiguration
  INNER JOIN CokerCardConfigurationWorkAssignment
    ON dbo.CokerCardConfiguration.Id = dbo.CokerCardConfigurationWorkAssignment.CokerCardConfigurationId
  inner join WorkAssignment 
    ON CokerCardConfigurationWorkAssignment.WorkAssignmentId = WorkAssignment.Id
where
  dbo.CokerCardConfigurationWorkAssignment.WorkAssignmentId = @workAssignmentId
  and dbo.WorkAssignment.Deleted = 0
  and dbo.CokerCardConfiguration.Deleted = 0
GO

GRANT EXEC ON dbo.QueryCokerCardConfigurationByWorkAssignment TO PUBLIC
GO
 