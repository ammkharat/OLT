if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN7History]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN7History]
GO

CREATE Procedure [dbo].[InsertFormGN7History]
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

INSERT INTO FormGN7History
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

GRANT EXEC ON InsertFormGN7History TO PUBLIC
GO
