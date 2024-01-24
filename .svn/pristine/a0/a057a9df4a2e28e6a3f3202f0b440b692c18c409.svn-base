IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteEventsCreatedBeforeGivenDateTime')
	BEGIN
		DROP  Procedure  DeleteEventsCreatedBeforeGivenDateTime
	END

GO

CREATE Procedure [dbo].[DeleteEventsCreatedBeforeGivenDateTime]
(
    @GivenDateTime datetime
)
AS

DELETE FROM Property
WHERE EventId in (select Id from Event where DateTime < @GivenDateTime)

DELETE FROM Event
where DateTime < @GivenDateTime

GO
 