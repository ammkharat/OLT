if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOpmExcursionResponse]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOpmExcursionResponse]
GO

CREATE Procedure [dbo].[UpdateOpmExcursionResponse]
    (
    @Id bigint Output,
    @LastModifiedByUserId bigint,
    @Response nvarchar(4000),
    @LastModifiedDateTime datetime
	--@Asset varchar(100) ,
	--@Code varchar(100)
    )
AS

update OpmExcursionResponse
set 
    LastModifiedByUserId = @LastModifiedByUserId,
	Response = @Response,
	LastModifiedDateTime = @LastModifiedDateTime
	-- Asset = @Asset ,
 --Code = @Code
where Id = @Id
go

GRANT EXEC ON [UpdateOpmExcursionResponse] TO PUBLIC
GO
