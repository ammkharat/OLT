-- Note to coworkers: We need a second configuration to test multi-configuration issues. When we have real
-- data we can remove this.


DECLARE @up2flocId BIGINT
DECLARE @shiftId BIGINT
DECLARE @cokerCardConfigId BIGINT
DECLARE @cokerCardConfigDrumId BIGINT
DECLARE @cokerCardConfigCycleStepId BIGINT

DECLARE @cokerCardId BIGINT
DECLARE @cokerCardCycleStepEntryId BIGINT

DECLARE @cokerCardHistoryId BIGINT
DECLARE @cokerCardDrumEntryHistoryId BIGINT

SELECT @shiftId = [Id] From Shift where siteid = 3 and [name] = 'D'

SELECT @up2flocId = [Id] From FunctionalLocation where SiteId = 3 and FullHierarchy = 'UP2'

INSERT INTO dbo.CokerCardConfiguration (
  [Name],
  [FunctionalLocationId],
  [Deleted]
)
VALUES ('UP2 Coker Card', @up2flocId, 0);

SET @cokerCardConfigId = @@IDENTITY

INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('t5C3', 1, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('t5C4', 2, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('t5C5', 3, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('t5C6', 4, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('t5C7', 5, @cokerCardConfigId);

INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('SQ Frac', 1, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('SQ StO', 2, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('SQ WQ', 3, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Pull TH', 4, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Drn Something Long', 5, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Pull BotH', 6, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Cut', 7, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Rhd', 8, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('ST', 9, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('VH', 10, @cokerCardConfigId);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId]) VALUES ('Feed In', 11, @cokerCardConfigId);

INSERT INTO dbo.CokerCardConfigurationWorkAssignment
	select @cokerCardConfigId, Id from WorkAssignment where [name] like '%Coker%' and [name] like '%UP2%' and siteid = 3 and deleted = 0
