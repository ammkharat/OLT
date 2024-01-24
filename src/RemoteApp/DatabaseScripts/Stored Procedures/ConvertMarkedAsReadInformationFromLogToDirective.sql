IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ConvertMarkedAsReadInformationFromLogToDirective')
	BEGIN
		DROP  Procedure  ConvertMarkedAsReadInformationFromLogToDirective
	END

GO

CREATE Procedure [dbo].[ConvertMarkedAsReadInformationFromLogToDirective]
(
    @FromLogId bigint,
	@ToDirectiveId bigint
)
AS

INSERT INTO DirectiveRead (DirectiveId, UserId, DateTime)
SELECT @ToDirectiveId, UserId, DateTime
FROM LogRead
WHERE LogId = @FromLogId

GO
 