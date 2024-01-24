-- TODO: add columns for day and for night. Both can be checked. We need datetime columns for RequestedStartDateTimeDay, RequestedStartDateTimeNight

-- The booleans can be inferred by whether there is a value in the date time column


drop index IDX_PermitRequestOssa on dbo.PermitRequestOssa;

CREATE NONCLUSTERED INDEX [IDX_PermitRequestOssa] ON [dbo].[PermitRequestOssa] 
(
	[FunctionalLocationId] ASC,	
	[EndDate] ASC,
	[Deleted] ASC
);

alter table dbo.PermitRequestOssa drop column StartDate;

alter table dbo.PermitRequestOssa ADD StartDateTimeDay datetime null;

alter table dbo.PermitRequestOssa ADD StartDateTimeNight datetime null;

alter table dbo.PermitRequestOssaHistory ADD StartDateTimeDay datetime NULL;

alter table dbo.PermitRequestOssaHistory ADD StartDateTimeNight datetime NULL;

GO




GO

