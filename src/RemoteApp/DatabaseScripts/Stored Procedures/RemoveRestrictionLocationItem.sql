 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRestrictionLocationItem')
	BEGIN
		DROP  Procedure  RemoveRestrictionLocationItem
	END
GO

CREATE Procedure [dbo].RemoveRestrictionLocationItem
(
    @Id bigint
)
AS

UPDATE RestrictionLocationItem
SET	
	DELETED = 1
WHERE 
	Id = @Id
GO