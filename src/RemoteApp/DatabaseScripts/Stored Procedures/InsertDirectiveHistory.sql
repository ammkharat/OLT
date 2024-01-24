if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDirectiveHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertDirectiveHistory]
GO

CREATE Procedure [dbo].[InsertDirectiveHistory]
(
	@Id bigint,		
	@FunctionalLocations varchar(max),
	@WorkAssignments varchar(max),			
	@ActiveFromDateTime datetime,	
	@ActiveToDateTime datetime,	
	@PlainTextContent varchar(max),	
	@DocumentLinks varchar(max),	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO DirectiveHistory
(
	Id,
	FunctionalLocations,
	WorkAssignments,			
	ActiveFromDateTime,	
	ActiveToDateTime,	
	PlainTextContent,	
	DocumentLinks,		
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,		
	@FunctionalLocations,
	@WorkAssignments,			
	@ActiveFromDateTime,	
	@ActiveToDateTime,	
	@PlainTextContent,	
	@DocumentLinks,	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertDirectiveHistory TO PUBLIC
GO
