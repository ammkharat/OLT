

alter table FormTemplate add TemplateKey varchar(100) null
alter table FormTemplate add Name varchar(100) null
go

insert into FormTemplate (FormTypeId, Template, Deleted, CreatedByUserId, CreatedDateTime, TemplateKey, Name)
values (4, 'Template for PSV checklist', 0, -1, '2013-10-16 12:00', 'psv', 'PSV Checklist')

insert into FormTemplate (FormTypeId, Template, Deleted, CreatedByUserId, CreatedDateTime, TemplateKey, Name)
values (4, 'Template for non-PSV checklist', 0, -1, '2013-10-16 12:00', 'nonpsv', 'Non-PSV Checklist')




GO

