-- **********************************************************************************************
IF OBJECT_ID (N'[dbo].GetSingleRoleId', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetSingleRoleId;
GO

CREATE FUNCTION [dbo].GetSingleRoleId(@SiteId bigint, @RoleGroupId bigint) RETURNS bigint
AS
BEGIN
  IF (@SiteId=3 AND @RoleGroupId=7)
  BEGIN 
    	RETURN
    	(select TOP 1 r.Id from Role r
    	inner join Site s
    	on s.Id = r.SiteId
    	inner join RoleGroup rg
    	on rg.Id = r.RoleGroupId
    	where r.SiteId = 3
    	and rg.Id = 7
    	and r.Name = 'Process Engineer')
  END
RETURN
(select TOP 1 r.Id from Role r
inner join Site s
on s.Id = r.SiteId
inner join RoleGroup rg
on rg.Id = r.RoleGroupId
where r.SiteId = @SiteId
and rg.Id = @RoleGroupId
ORDER BY r.Id)
END

GO

GRANT EXEC ON [dbo].GetSingleRoleId TO PUBLIC

GO

-- **********************************************************************************************
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'Log' AND Column_name = 'CreatedByRoleId')
BEGIN
	ALTER TABLE [dbo].[Log] ADD [CreatedByRoleId] [bigint] NULL
END
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'LogDefinition' AND Column_name = 'CreatedByRoleId')
BEGIN
	ALTER TABLE [dbo].[LogDefinition] ADD [CreatedByRoleId] [bigint] NULL
END
GO

-- **********************************************************************************************
IF OBJECT_ID (N'[dbo].GetRoleGroupIdForLogTable', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetRoleGroupIdForLogTable;
GO

CREATE FUNCTION [dbo].GetRoleGroupIdForLogTable(@LogId bigint) RETURNS [bigint]
AS
BEGIN
DECLARE @SiteId bigint
DECLARE @CurrentRoleGroupId bigint
    SELECT @SiteId = shift.SiteId, @CurrentRoleGroupId = roleGroup.Id
    FROM [Log] logg
    INNER JOIN [SHIFT] shift
    ON logg.CreationUserShiftPatternId = shift.Id
    INNER JOIN [RoleGroup] roleGroup
    ON logg.CurrentRoleGroupId = roleGroup.Id
    WHERE logg.Id = @LogId
DECLARE @FinalResult bigint
SELECT @FinalResult = [dbo].GetSingleRoleId(@SiteId, @CurrentRoleGroupId)
RETURN @FinalResult
END  

GO

GRANT EXEC ON [dbo].GetRoleGroupIdForLogTable TO PUBLIC

GO
-- **********************************************************************************************
-- Update all rows in Log table with the CreatedByRoleId and then set column to not nullable
-- **********************************************************************************************
UPDATE [dbo].[Log] SET CreatedByRoleId = [dbo].GetRoleGroupIdForLogTable(Id);

BEGIN
	ALTER TABLE [dbo].[Log]
	ALTER COLUMN [CreatedByRoleId] [bigint] NOT NULL
END
GO

-- **********************************************************************************************
IF OBJECT_ID (N'[dbo].GetRoleGroupIdForLogDefinitionTable', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetRoleGroupIdForLogDefinitionTable;
GO

CREATE FUNCTION [dbo].GetRoleGroupIdForLogDefinitionTable(@LogDefinitionId bigint) RETURNS [bigint]
AS
BEGIN
DECLARE @SiteId bigint
DECLARE @CurrentRoleGroupId bigint
  SELECT @SiteId = fl.SiteId, @CurrentRoleGroupId = ld.CurrentRoleGroupId
  FROM LogDefinition ld
  INNER JOIN LogDefinitionFunctionalLocation logDefFl
  ON ld.Id = logDefFl.LogDefinitionId
  INNER JOIN FunctionalLocation fl
  ON logDefFl.FunctionalLocationId = fl.Id
  WHERE ld.Id = @LogDefinitionId
DECLARE @FinalResult bigint
SELECT @FinalResult = [dbo].GetSingleRoleId(@SiteId, @CurrentRoleGroupId)
RETURN @FinalResult
END

GO

GRANT EXEC ON [dbo].GetRoleGroupIdForLogDefinitionTable TO PUBLIC

GO
-- **********************************************************************************************
-- Update all rows in LogDefinition table with the CreatedByRoleId and then set column to not nullable
-- **********************************************************************************************
UPDATE LogDefinition SET CreatedByRoleId = [dbo].GetRoleGroupIdForLogDefinitionTable(Id)

BEGIN
	ALTER TABLE [dbo].[LogDefinition]
	ALTER COLUMN [CreatedByRoleId] [bigint] NOT NULL
END
GO

-- **********************************************************************************************
-- Apply Foregin Keys to Log and LogDefinition
-- **********************************************************************************************
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [FK_Log_CreatedByRoleId] 
FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO

ALTER TABLE [dbo].[LogDefinition]
ADD CONSTRAINT [FK_LogDefninition_CreatedByRoleId] 
FOREIGN KEY([CreatedByRoleId])
REFERENCES [dbo].[Role] ([Id])
GO
-- **********************************************************************************************
-- Drop custom functions
-- **********************************************************************************************
IF OBJECT_ID (N'[dbo].GetSingleRoleId', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetSingleRoleId;
GO
IF OBJECT_ID (N'[dbo].GetRoleGroupIdForLogTable', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetRoleGroupIdForLogTable;
GO
IF OBJECT_ID (N'[dbo].GetRoleGroupIdForLogDefinitionTable', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].GetRoleGroupIdForLogDefinitionTable;
GO
-- **********************************************************************************************

GO
