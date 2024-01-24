if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormTemplate]
GO

CREATE Procedure [dbo].[InsertFormTemplate]
(
	@Id bigint Output,

	@FormTypeId int,
	@Template varchar(max) = NULL,
	@Name varchar(100) = NULL,
	@TemplateKey varchar(100) = NULL,
	@CreatedByUserId bigint,
	@CreatedDateTime datetime,
	@SiteId bigint
)
AS

INSERT INTO FormTemplate
(
	FormTypeId,
	Template,
	Name,
	TemplateKey,
	CreatedByUserId,
	CreatedDateTime,
	Deleted,
	SiteId
)
VALUES
(
	@FormTypeId,
	@Template,
	@Name,
	@TemplateKey,
	@CreatedByUserId,
	@CreatedDateTime,
	0,
	@SiteId
);

SET @Id = SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertFormTemplate TO PUBLIC
GO
