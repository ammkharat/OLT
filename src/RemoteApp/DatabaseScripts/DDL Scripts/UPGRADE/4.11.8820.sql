﻿CREATE NONCLUSTERED INDEX [IDX_FormGN24_DTO]
ON [dbo].[FormGN24]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
WHERE (DELETED = 0)
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

CREATE NONCLUSTERED INDEX [IDX_FormGN24Approval_FormGN24Id]
ON [dbo].[FormGN24Approval]
([FormGN24Id])
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

CREATE NONCLUSTERED INDEX [IDX_FormGN59_Covering_DTO]
ON [dbo].[FormGN59]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
WHERE (DELETED = 0 )
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_FormGN24FunctionalLocation]
ON [dbo].[FormGN24FunctionalLocation]
([FunctionalLocationId] , [FormGN24Id])
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

CREATE NONCLUSTERED INDEX [IDX_FormGN6_DTO]
ON [dbo].[FormGN6]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
WHERE (DELETED = 0)
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

CREATE NONCLUSTERED INDEX [IDX_FormGN6Approval_FormGN6Id]
ON [dbo].[FormGN6Approval]
([FormGN6Id])
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

CREATE NONCLUSTERED INDEX [IDX_FormGN6FunctionalLocation]
ON [dbo].[FormGN6FunctionalLocation]
([FunctionalLocationId] , [FormGN6Id])
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

CREATE NONCLUSTERED INDEX [IDX_FormGN7_Covering_DTO]
ON [dbo].[FormGN7]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
WHERE (DELETED = 0)
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO


CREATE NONCLUSTERED INDEX [IDX_FormOilsandsTraining_TrainingDate]
ON [dbo].[FormOilsandsTraining]
([TrainingDate] , [ApprovedDateTime])
WHERE (DELETED = 0)
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

CREATE NONCLUSTERED INDEX [IDX_FormOP14_Covering_DTO]
ON [dbo].[FormOP14]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
WHERE (DELETED = 0)
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO




GO
