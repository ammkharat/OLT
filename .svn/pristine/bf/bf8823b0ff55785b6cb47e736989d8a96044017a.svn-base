if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertRestrictionLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertRestrictionLocation]
GO

CREATE Procedure [dbo].[InsertRestrictionLocation]
  (
    @Id bigint Output,
    @Name varchar (50),
    @LastModifiedByUserId bigint,
    @LastModifiedDateTime DATETIME,
	@SiteID bigint
    )
AS

INSERT INTO RestrictionLocation
(
    [Name],
    LastModifiedByUserId,
    LastModifiedDateTime,
	Deleted,
	SiteID
)
VALUES
(
    @Name,
    @LastModifiedByUserId, 
    @LastModifiedDateTime,
	0,
	@SiteID
)
SET @Id= SCOPE_IDENTITY() 
GO