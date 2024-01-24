  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateDeviationAlertResponse')
	BEGIN
		DROP  Procedure  UpdateDeviationAlertResponse
	END

GO

CREATE Procedure [dbo].[UpdateDeviationAlertResponse]
	(
	@Id bigint,	
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@Comments varchar(2048)
	)
AS
UPDATE    [DeviationAlertResponse]
SET       LastModifiedUserId = @LastModifiedUserId, 
          LastModifiedDateTime = @LastModifiedDateTime,          
		  Comments = @Comments
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateDeviationAlertResponse TO PUBLIC

GO


 