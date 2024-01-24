if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormOvertimeFormHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormOvertimeFormHistory]
GO

CREATE Procedure [dbo].[InsertFormOvertimeFormHistory]
(
	@Id bigint,
	@FormStatusId int,	
	@FromDateTime datetime,
	@ToDateTime datetime,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,	
	@FunctionalLocation varchar(max),
	@TradeOccupation varchar(100),
	@OnSitePersonnel varchar(max),	
	@Approvals varchar(max) = NULL,	
	@DocumentLinks varchar(max) = NULL,
	@ApprovedDateTime datetime = NULL,
	@CancelledDateTime datetime = NULL		
)
AS

INSERT INTO FormOvertimeFormHistory
(
	Id,
	FormStatusId,	
	FromDateTime,
	ToDateTime,	
	LastModifiedByUserId,
	LastModifiedDateTime,	
	FunctionalLocation,
	TradeOccupation,	
	OnSitePersonnel,	
	Approvals,
	DocumentLinks,
	ApprovedDateTime,
	CancelledDateTime
	)
VALUES
(
	@Id,
	@FormStatusId,	
	@FromDateTime,
	@ToDateTime,	
	@LastModifiedByUserId,
	@LastModifiedDateTime,	
	@FunctionalLocation,
	@TradeOccupation,	
	@OnSitePersonnel,	
	@Approvals,
	@DocumentLinks,
	@ApprovedDateTime,
	@CancelledDateTime
);

GO

GRANT EXEC ON InsertFormOvertimeFormHistory TO PUBLIC
GO
