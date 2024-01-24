if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertVisibilityGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertVisibilityGroup]
GO

CREATE Procedure [dbo].[InsertVisibilityGroup]
	(
	@Id bigint Output,
	@Name varchar(100),
	@SiteId bigint,
	@IsSiteDefault bit
	)
AS

INSERT INTO VisibilityGroup ([Name], SiteId, IsSiteDefault, Deleted)
VALUES (@Name, @SiteId, @IsSiteDefault, 0)

SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertVisibilityGroup TO PUBLIC
GO
