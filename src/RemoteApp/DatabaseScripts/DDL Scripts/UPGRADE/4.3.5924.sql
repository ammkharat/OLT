drop index IDX_PermitRequestEdmonton on dbo.PermitRequestEdmonton;

CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmonton] ON [dbo].[PermitRequestEdmonton] 
(
	[FunctionalLocationId] ASC,	
	[EndDate] ASC,
	[Deleted] ASC
);

alter table dbo.PermitRequestEdmonton drop column StartDate;

alter table dbo.PermitRequestEdmonton ADD StartDateTimeDay datetime null;

alter table dbo.PermitRequestEdmonton ADD StartDateTimeNight datetime null;


alter table dbo.PermitRequestEdmontonHistory DROP COLUMN StartDate;

alter table dbo.PermitRequestEdmontonHistory ADD StartDateTimeDay datetime NULL;

alter table dbo.PermitRequestEdmontonHistory ADD StartDateTimeNight datetime NULL;

GO



GO

