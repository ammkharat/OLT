CREATE NONCLUSTERED INDEX [IDX_DeviationAlert_StartDateTime]
ON [dbo].[DeviationAlert] 
(
	[StartDateTime] ASC
);


CREATE NONCLUSTERED INDEX [IDX_DeviationAlert_CreatedDateTime]
ON [dbo].[DeviationAlert] 
(
	[CreatedDateTime] ASC
);


GO
