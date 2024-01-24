if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOvertimeForm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateOvertimeForm]
GO

CREATE Procedure [dbo].[UpdateOvertimeForm]
(
	@Id bigint,
	
	@FormStatusId int,
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@ApprovedDateTime datetime = NULL,
	@CancelledDateTime datetime = NULL,

	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	
	@Trade VARCHAR(100)
)
AS

UPDATE OvertimeForm
	SET 
		FormStatusId = @FormStatusId,
		ValidFromDateTime = @ValidFromDateTime,
		ValidToDateTime = @ValidToDateTime,
		
		ApprovedDateTime = @ApprovedDateTime,
		CancelledDateTime = @CancelledDateTime,
		
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId,
		Trade = @Trade
	WHERE
		Id = @Id
GO

GRANT EXEC ON UpdateOvertimeForm TO PUBLIC
GO