insert into roleelement values
(141, 'Configure Work Assignment Not Selected Warning');


insert into roleelementtemplate
select distinct 141,  roleid, siteid
from roleelementtemplate
where roleid = 37;


go

GO

GO
