if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCraftOrTrade]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCraftOrTrade]
GO

CREATE Procedure [dbo].[InsertCraftOrTrade]
	(
	@Id bigint Output,
	@Name varchar(50),
	@WorkCenter varchar(10) = null,
	@SiteId bigint
	)
AS

INSERT INTO CraftOrTrade ([Name], WorkCenter, SiteId)
VALUES     (@Name, @WorkCenter, @SiteId)


SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertCraftOrTrade TO PUBLIC
GO