IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertEventSink')
    BEGIN
        DROP  Procedure  InsertEventSink
    END

GO

CREATE Procedure [dbo].InsertEventSink
(
    @Id int Output,
    @FullHierarchyList VARCHAR(MAX),
    @WorkPermitEdmontonFullHierarchyList varchar(max),
    @RestrictionFullHierarchyList varchar(max),
	@ClientReadableVisibilityGroupIdList varchar(max),
    @ClientUri varchar(500),
    @SiteId bigint
)
AS
INSERT INTO EventSinks
(
    ClientUri,
    CreationTime,
    FullHierarchyList,
	WorkPermitEdmontonFullHierarchyList,
    RestrictionFullHierarchyList,
	ClientReadableVisibilityGroupIdList,
    SiteId
)
VALUES
(
    @ClientUri,
    GetDate(),
    @FullHierarchyList,
	@WorkPermitEdmontonFullHierarchyList,
    @RestrictionFullHierarchyList,
	@ClientReadableVisibilityGroupIdList,
    @SiteId
)

SET @Id = SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertEventSink TO PUBLIC

GO
