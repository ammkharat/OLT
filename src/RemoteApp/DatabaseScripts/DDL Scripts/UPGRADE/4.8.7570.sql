
alter table CustomFieldCustomFieldGroup add DisplayOrder int null;
go

update CustomFieldCustomFieldGroup
set DisplayOrder = cf.DisplayOrder
from CustomFieldCustomFieldGroup cfcfg
inner join CustomField cf on cf.Id = cfcfg.CustomFieldId
go

alter table CustomFieldCustomFieldGroup alter column DisplayOrder int not null;
go

alter table CustomField drop column DisplayOrder;
go





GO

