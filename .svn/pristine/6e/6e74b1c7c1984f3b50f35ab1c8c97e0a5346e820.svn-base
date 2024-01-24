if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormMontrealCsdHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormMontrealCsdHistory]
GO

CREATE Procedure [dbo].[InsertFormMontrealCsdHistory]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocations varchar(max),
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@PlainTextContent nvarchar(max) = NULL,
	@IsTheCSDForAPressureSafetyValve bit,
	@CriticalSystemDefeated varchar(255) = NULL,
	@HasBeenCommunicated bit,
	@HasAttachments bit,
	@CsdReason varchar(255) = NULL,	
	@DocumentLinks varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormMontrealCsdHistory
(
	Id,
	FormStatusId,
	
	FunctionalLocations,
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,
	
	PlainTextContent,
	IsTheCSDForAPressureSafetyValve,
	CriticalSystemDefeated,
	HasBeenCommunicated,
	HasAttachments,
	CsdReason,	
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
	@IsTheCSDForAPressureSafetyValve,
	@CriticalSystemDefeated,
	@HasBeenCommunicated,
	@HasAttachments,
	@CsdReason,	
	@DocumentLinks,	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormMontrealCsdHistory TO PUBLIC
GO
