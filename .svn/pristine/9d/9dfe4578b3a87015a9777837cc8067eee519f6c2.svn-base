if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDirective]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertDirective]
GO

CREATE Procedure [dbo].[InsertDirective]
(
	@Id bigint Output,
	@ActiveFromDateTime DateTime,	
	@ActiveToDateTime DateTime,
	@Content varchar(max),
	@PlainTextContent varchar(max),
	@CreatedByUserId bigint,
	@CreatedByRoleId bigint,
 	@CreatedByWorkAssignmentName varchar(40),
	@CreatedDateTime DateTime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime DateTime,
	@MigrationSource varchar(50) = null,
	@ExtraInformationFromMigrationSource varchar(max) = null
)
AS

INSERT INTO Directive
(		
	ActiveFromDateTime,
	ActiveToDateTime,
	Content,
	PlainTextContent,
	CreatedByUserId,
	CreatedByRoleId,
	CreatedByWorkAssignmentName,
	CreatedDateTime,	
	LastModifiedByUserId,
	LastModifiedDateTime,
	MigrationSource,
	ExtraInformationFromMigrationSource,
	Deleted
)
VALUES
(
	@ActiveFromDateTime,	
	@ActiveToDateTime,
	@Content,
	@PlainTextContent,		
	@CreatedByUserId,
	@CreatedByRoleId,
	@CreatedByWorkAssignmentName,
	@CreatedDateTime,	
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@MigrationSource,
	@ExtraInformationFromMigrationSource,
	0
);

SET @Id = SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertDirective TO PUBLIC
GO
