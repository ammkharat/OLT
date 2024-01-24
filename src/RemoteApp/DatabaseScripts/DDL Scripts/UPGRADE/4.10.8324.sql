DROP INDEX [IDX_WorkAssignmentVisibilityGroup_FilteringOtherQueries] ON [dbo].[WorkAssignmentVisibilityGroup]

CREATE UNIQUE NONCLUSTERED INDEX [IDX_WorkAssignmentVisibilityGroup_FilteringOtherQueries]
ON [dbo].[WorkAssignmentVisibilityGroup]
([VisibilityGroupId] , [VisibilityType] , [WorkAssignmentId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO



GO

