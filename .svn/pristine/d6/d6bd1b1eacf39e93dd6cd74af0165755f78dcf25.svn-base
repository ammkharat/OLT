if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75AHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75AHistory]
GO

CREATE Procedure [dbo].[InsertFormGN75AHistory]
(
	@Id bigint,
	@FormStatusId int,	
	@FunctionalLocation varchar(max),
	@Approvals varchar(max),	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,	
	@PlainTextContent nvarchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,	
	@AssociatedFormGN75BNumber bigint = NULL,		
	@DocumentLinks varchar(max) = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormGN75AHistory
(
	Id,
	FormStatusId,	
	FunctionalLocation,
	AssociatedFormGN75BId,
	PlainTextContent,
	FromDateTime,
	ToDateTime,
	ApprovedDateTime,
	ClosedDateTime,	
	Approvals,
	LastModifiedByUserId,
	LastModifiedDateTime,
	DocumentLinks	
)
VALUES
(
	@Id,
	@FormStatusId,	
	@FunctionalLocation,
	@AssociatedFormGN75BNumber,
	@PlainTextContent,
	@ValidFromDateTime,
	@ValidToDateTime,
	@ApprovedDateTime,
	@ClosedDateTime,	
	@Approvals,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@DocumentLinks	
);

GO

GRANT EXEC ON InsertFormGN75AHistory TO PUBLIC
GO
