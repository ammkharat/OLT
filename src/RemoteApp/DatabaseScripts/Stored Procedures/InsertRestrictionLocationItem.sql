if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertRestrictionLocationItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertRestrictionLocationItem]
GO

CREATE Procedure [dbo].[InsertRestrictionLocationItem]
    (
    @Id bigint,
    @Name varchar (50),
	@RestrictionLocationId bigint,
	@ParentItemId bigint = NULL,
    @FunctionalLocationId bigint = NULL
    )
AS

INSERT INTO RestrictionLocationItem
(
	Id,
	Name,
	RestrictionLocationId,
	ParentItemId,
	FunctionalLocationId,
	Deleted
)
VALUES
(
	@Id,
	@Name,
	@RestrictionLocationId,
	@ParentItemId,
	@FunctionalLocationId,
	0
)
GO