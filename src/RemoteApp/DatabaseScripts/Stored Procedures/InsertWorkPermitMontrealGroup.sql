if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitMontrealGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertWorkPermitMontrealGroup]
GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealGroup]
	(
	@Id bigint Output,
	@Name varchar(100),
	@DisplayOrder int
	)
AS

INSERT INTO WorkPermitMontrealGroup ([Name], DisplayOrder, Deleted)
VALUES (@Name, @DisplayOrder, 0)

SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertWorkPermitMontrealGroup TO PUBLIC
GO
