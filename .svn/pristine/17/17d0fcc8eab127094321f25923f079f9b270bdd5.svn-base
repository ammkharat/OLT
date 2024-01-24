CREATE INDEX [IDX_FunctionalLocation_Id_SiteId_Level_Include_FullHierarchy] 
ON [FunctionalLocation] 
(
	[SiteId] ASC,
	[Level] ASC,
    [Id]
)
INCLUDE ([FullHierarchy]) 
GO


CREATE NONCLUSTERED INDEX [IDX_RestrictionReasonCodeFLOCAssociation] ON [RestrictionReasonCodeFLOCAssociation] 
(
	[RestrictionReasonCodeId] ASC,
	[FunctionalLocationId] ASC
)

Go