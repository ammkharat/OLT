if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN59History]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN59History]
GO

CREATE Procedure [dbo].[InsertFormGN59History]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocations varchar(max),
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@PlainTextContent nvarchar(max) = NULL,
	@DocumentLinks varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormGN59History
(
	Id,
	FormStatusId,
	
	FunctionalLocations,
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,
	
	PlainTextContent,
	DocumentLinks,
	ApprovedDateTime,
	ClosedDateTime,
	
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,
	@FormStatusId,
	
	@FunctionalLocations,
	@Approvals,
	
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@PlainTextContent,

	@DocumentLinks,

	@ApprovedDateTime,
	@ClosedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormGN59History TO PUBLIC
GO
