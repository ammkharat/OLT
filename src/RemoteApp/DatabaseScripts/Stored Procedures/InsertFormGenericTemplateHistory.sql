if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGenericTemplateHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGenericTemplateHistory]
GO

CREATE Procedure [dbo].[InsertFormGenericTemplateHistory]
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
	@DepartmentId int,
	@DocumentLinks varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormGenericTemplateHistory
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
	DepartmentId,
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
	@DepartmentId,	
	@DocumentLinks,	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormGenericTemplateHistory TO PUBLIC
GO

