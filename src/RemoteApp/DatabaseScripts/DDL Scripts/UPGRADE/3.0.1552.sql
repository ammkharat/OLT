insert into roleelement values (120, 'Edit Shift Handover Configurations')

GO

-- roleid 37 = Administrator

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 120, 37, id from site;

GO

GO
