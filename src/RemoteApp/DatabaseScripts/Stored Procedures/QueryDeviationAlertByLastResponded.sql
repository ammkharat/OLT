IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertByLastResponded')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertByLastResponded
	END
GO

CREATE Procedure [dbo].QueryDeviationAlertByLastResponded
(
    @RestrictionDefinitionId int
)
AS

SELECT a.*
FROM
    DeviationAlert a
	inner join DeviationAlertResponse r on a.DeviationAlertResponseId = r.Id
WHERE
    a.RestrictionDefinitionId = @RestrictionDefinitionId
	and r.LastModifiedDateTime =
	(
		select max(sub_r.LastModifiedDateTime)
		from DeviationAlert sub_a
			 inner join DeviationAlertResponse sub_r on sub_a.DeviationAlertResponseId = sub_r.Id
		where sub_a.RestrictionDefinitionId = @RestrictionDefinitionId
	)
GO

GRANT EXEC ON [QueryDeviationAlertByLastResponded] TO PUBLIC
GO