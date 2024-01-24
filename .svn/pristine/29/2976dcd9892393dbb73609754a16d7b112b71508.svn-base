if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN75A]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN75A]
GO

CREATE Procedure [dbo].[UpdateFormGN75A]
(
	@Id bigint,
	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@FromDateTime datetime,
	@ToDateTime datetime,
	
	@AssociatedFormGN75BId bigint = NULL,
	
	@Content varchar(max) = NULL,
	@PlainTextContent nvarchar(max) = NULL,
	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
			
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

UPDATE FormGN75A
	SET 
		FormStatusId = @FormStatusId,
		FunctionalLocationId = @FunctionalLocationId,
				
		FromDateTime = @FromDateTime,
		ToDateTime = @ToDateTime,
		
		AssociatedFormGN75BId = @AssociatedFormGN75BId,
		
		Content = @Content,
		PlainTextContent = @PlainTextContent,
				
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN75A TO PUBLIC
GO