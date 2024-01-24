alter table BusinessCategoryFLOCAssociation
add LogGuideline varchar(max);

go

insert into roleelement
values (113, 'Configure Log Guidelines')

go

-- add to admin role
insert into roleelementtemplate
select 113, 37, s.Id
from [Site] s

go

GO
