alter table FormGN75AHistory drop column FunctionalLocations;
GO

alter table FormGN75AHistory add DocumentLinks varchar(max) NULL;
GO

-- EXEC sp_rename 'FormGN75AHistory.DaysToDisplayInactiveActionItemsBackwardsOnPriorityPage', 'DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage', 'COLUMN';

alter table FormGN75AHistory drop constraint FK_FormGN75AHistory_FunctionalLocation;
GO

alter table FormGN75AHistory drop column FunctionalLocationId;
GO

alter table FormGN75AHistory add FunctionalLocation varchar(max) NOT NULL;
GO





GO

