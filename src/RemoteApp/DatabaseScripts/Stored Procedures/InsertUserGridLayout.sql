IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUserGridLayout')
	BEGIN
		DROP  Procedure  InsertUserGridLayout
	END

GO

CREATE Procedure [dbo].[InsertUserGridLayout]
(	
    @UserId bigint,
    @GridId int,
	@GridLayoutXml varchar(max)
)
AS

INSERT INTO UserGridLayout (UserId, GridId, GridLayoutXml) VALUES (@UserId, @GridId, @GridLayoutXml)
GO

GRANT EXEC ON InsertUserGridLayout TO PUBLIC
GO
 