if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertExcursionResponseHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertExcursionResponseHistory]
GO


CREATE Procedure [dbo].[InsertExcursionResponseHistory]
(
	@Id bigint,		
	@Response varchar(max),	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
	-- @Asset varchar(max),
 --@Code varchar(max)
)
AS

INSERT INTO ExcursionResponseHistory
(
	Id,
	Response,	
	LastModifiedByUserId,
	LastModifiedDateTime
	--  Asset ,
 --Code 
)
VALUES
(
	@Id,		
	@Response,	
	@LastModifiedByUserId,
	@LastModifiedDateTime
	--  @Asset,
 --@Code 
);

GO

GRANT EXEC ON InsertExcursionResponseHistory TO PUBLIC
GO
