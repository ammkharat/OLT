CREATE NONCLUSTERED INDEX [IDX_TrainingBlockFunctionalLocation_Floc_TrainingBlockId]
ON [dbo].[TrainingBlockFunctionalLocation]
([FunctionalLocationId] , [TrainingBlockId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTrainingApproval_FormOilsandsTrainingId]
ON [dbo].[FormOilsandsTrainingApproval]
([FormOilsandsTrainingId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[FormOilsandsTraining] 
ADD  CONSTRAINT [FK_FormOilsandsTraining_CreatedByRoleId]
FOREIGN KEY ([CreatedByRoleId])
REFERENCES [dbo].[Role] ( [Id] )
GO

CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTrainingItem_FormOilsandsTrainingId]
ON [dbo].[FormOilsandsTrainingItem]
([FormOilsandsTrainingId])
INCLUDE ([TrainingBlockId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 95,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO


GO

