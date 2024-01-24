IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDeviationAlertResponseHistory')
	BEGIN
		DROP  Procedure  InsertDeviationAlertResponseHistory
	END

GO

CREATE Procedure dbo.InsertDeviationAlertResponseHistory
    (
    @Id bigint,
    @ReasonCodes varchar(max),
    @UpdatedUserId bigint, 
    @UpdatedDate datetime,
	@Comments varchar(2048)
    )
AS

INSERT INTO DeviationAlertResponseHistory
(
    Id,
    ReasonCodes,
    LastModifiedUserId,
    LastModifiedDateTime,
	Comments
)
VALUES
(
    @Id,
    @ReasonCodes,
    @UpdatedUserId, 
    @UpdatedDate,
	@Comments
)
GO


GRANT EXEC ON [InsertDeviationAlertResponseHistory] TO PUBLIC
GO
