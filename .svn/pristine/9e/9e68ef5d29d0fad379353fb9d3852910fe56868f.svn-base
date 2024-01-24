update RoleElement
set Name = 'Submit Permit Request'
where id = 185;

go

insert into RoleElement (Id, Name, FunctionalArea)
values (186, 'Import Permit Requests', 'Work Permits');

go


CREATE NONCLUSTERED INDEX [IDX_Permit_Request] ON [dbo].[PermitRequest] 
(
	[FunctionalLocationId] ASC,
	[StartDateTime] ASC,
	[EndDateTime] ASC,
	[Deleted] ASC
);

go

GO
