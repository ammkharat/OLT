if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertRestrictionLocationItemReasonCodeAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertRestrictionLocationItemReasonCodeAssociation]
GO

CREATE Procedure [dbo].[InsertRestrictionLocationItemReasonCodeAssociation]
    (
    @RestrictionLocationItemId bigint,
    @RestrictionReasonCodeId bigint,
	@Limit int = NULL
    )
AS

INSERT INTO RestrictionLocationItemReasonCode
(
    RestrictionLocationItemId,
	RestrictionReasonCodeId,
	[Limit]
)
VALUES
(
    @RestrictionLocationItemId,
	@RestrictionReasonCodeId,
	@Limit
)
GO