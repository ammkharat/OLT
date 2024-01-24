if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertProperty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertProperty]
GO

CREATE Procedure [dbo].[InsertProperty]
    (
    @Id bigint Output,
	@EventId bigint,
    @PropertyKey varchar(100),
    @TypeId bigint,
    @TextValue varchar(max) = null,
	@DateTimeValue datetime = null,
	@NumberValue decimal(18, 6) = null
    )
AS

INSERT INTO Property
(
    EventId,
	PropertyKey,
	TypeId,
	TextValue,
	DateTimeValue,
	NumberValue
)
VALUES
(
    @EventId,
	@PropertyKey,
	@TypeId,
	@TextValue,
	@DateTimeValue,
	@NumberValue
)
SET @Id = SCOPE_IDENTITY()
GO 
GRANT EXEC ON InsertProperty TO PUBLIC
GO   