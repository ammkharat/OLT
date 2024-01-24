insert into roleelement values (114, 'View Shift Handover')
insert into roleelement values (115, 'Create Shift Handover Questionnaire')
insert into roleelement values (116, 'Edit Shift Handover Questionnaire')
insert into roleelement values (117, 'Delete Shift Handover Questionnaire')

go

-- only oilsands gets shift shift handover, id: 3

insert into roleelementtemplate
select 114, id, 3 from role where id in (1, 2, 5, 7, 37, 38)

insert into roleelementtemplate
select 115, id, 3 from role where id in (1, 2)

insert into roleelementtemplate
select 116, id, 3 from role where id in (1, 2)

insert into roleelementtemplate
select 117, id, 3 from role where id in (1, 2)

go


GO
