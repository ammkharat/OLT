 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRoleDisplayConfiguration')
	BEGIN
		DROP  Procedure  InsertRoleDisplayConfiguration
	END

GO

CREATE Procedure [dbo].InsertRoleDisplayConfiguration
	(
		@Id bigint Output,
		@RoleId bigint,
		@SectionId int,
		@PrimaryDefaultPageId int,
		@SecondaryDefaultPageId int = NULL
	)

AS

insert into RoleDisplayConfiguration
(
	RoleId,
	SectionId,
	PrimaryDefaultPageId,
	SecondaryDefaultPageId
)
values
(
	@RoleId,
	@SectionId,
	@PrimaryDefaultPageId,
	@SecondaryDefaultPageId
)

SET @Id= SCOPE_IDENTITY() 

GO

GRANT EXEC ON InsertRoleDisplayConfiguration TO PUBLIC

GO


