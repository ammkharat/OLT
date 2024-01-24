if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormLubesCsdHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormLubesCsdHistory]
GO

CREATE Procedure [dbo].[InsertFormLubesCsdHistory]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocation varchar(max),
	@Location varchar(128),	
	
	@Approvals varchar(max),
	
	@ValidFromDateTime datetime,
	@ValidToDateTime datetime,
	
	@PlainTextContent nvarchar(max) = NULL,
	@IsTheCSDForAPressureSafetyValve bit,
	@CriticalSystemDefeated varchar(255) = NULL,
	@DocumentLinks varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormLubesCsdHistory
(
	Id,
	FormStatusId,
	
	FunctionalLocation,
	Location,	
	Approvals,
	
	ValidFromDateTime,
	ValidToDateTime,
	
	PlainTextContent,
	IsTheCSDForAPressureSafetyValve,
	CriticalSystemDefeated,
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
	
	@FunctionalLocation,
	@Location,
	@Approvals,
	
	@ValidFromDateTime,
	@ValidToDateTime,
	
	@PlainTextContent,
	@IsTheCSDForAPressureSafetyValve,
	@CriticalSystemDefeated,
	@DocumentLinks,	
	@ApprovedDateTime,
	@ClosedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormLubesCsdHistory TO PUBLIC
GO
