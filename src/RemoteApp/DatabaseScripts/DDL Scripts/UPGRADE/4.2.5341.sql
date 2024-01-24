ALTER TABLE [dbo].[EventSinks]
 ADD [FullHierarchyList] varchar(max) NULL
GO

ALTER TABLE [dbo].[EventSinks]
DROP COLUMN [FlocIdList]
GO



GO

