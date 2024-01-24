if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOpmToeDefinitionComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOpmToeDefinitionComment]
GO

CREATE Procedure [dbo].[UpdateOpmToeDefinitionComment]
    (
    @Id bigint Output,
    @LastModifiedByUserId bigint,
    @Comment nvarchar(255),
    @LastModifiedDateTime datetime
    )
AS

update OpmToeDefinitionComment
set 
    LastModifiedByUserId = @LastModifiedByUserId,
	[Comment] = @Comment,
	LastModifiedDateTime = @LastModifiedDateTime
where Id = @Id
go

GRANT EXEC ON [UpdateOpmToeDefinitionComment] TO PUBLIC
GO
