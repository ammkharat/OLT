if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN59]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN59]
GO

CREATE Procedure [dbo].[UpdateFormGN59]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE FormGN59
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
		
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN59 TO PUBLIC
GO