if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEvent]
GO

CREATE Procedure [dbo].[InsertEvent]
    (
    @Id bigint Output,
	@UserId bigint,
    @SiteId bigint = null,
    @Name varchar(100),
    @DateTime datetime
    )
AS

INSERT INTO Event
(
    UserId,
	SiteId,
	Name,
	DateTime
)
VALUES
(
    @UserId,
	@SiteId,
	@Name,
	@DateTime
)
SET @Id = SCOPE_IDENTITY()
GO 
GRANT EXEC ON InsertEvent TO PUBLIC
GO   