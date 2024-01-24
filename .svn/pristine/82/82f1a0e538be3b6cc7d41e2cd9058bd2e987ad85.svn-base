insert into commentcategory
values
('ILP',
'Required Information:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) ILP #' + CHAR(13) + CHAR(10) +
'2) Risk rank' + CHAR(13) + CHAR(10) +
'3) Brief description' + CHAR(13) + CHAR(10) +
'4) Additional info for ILPs with risk rank 1 or 2',
0, 0);

insert into commentcategory
values
('Containment',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Substance leaked' + CHAR(13) + CHAR(10) +
'2) Location' + CHAR(13) + CHAR(10) +
'3) Current status' + CHAR(13) + CHAR(10) +
'4) What was done to mitigate',
0, 0);

insert into commentcategory
values
('Personal Safety',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) ILP # (if any)' + CHAR(13) + CHAR(10) +
'2) Location' + CHAR(13) + CHAR(10) +
'3) Description' + CHAR(13) + CHAR(10) +
'4) Cause (if known)' + CHAR(13) + CHAR(10) +
'5) Mitigation' + CHAR(13) + CHAR(10) +
'6) Follow up required',
0, 0);

insert into commentcategory
values
('Risk Escalation',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Location' + CHAR(13) + CHAR(10) +
'2) Process stream' + CHAR(13) + CHAR(10) +
'3) Type of risk:' + CHAR(13) + CHAR(10) +
'     - Ongoing loss of containment',
0, 0);

insert into commentcategory
values
('Critical Systems Defeated',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Which point (tag#) was defeated/bypassed' + CHAR(13) + CHAR(10) +
'2) Why' + CHAR(13) + CHAR(10) +
'3) Status (returned or still defeated/bypassed)' + CHAR(13) + CHAR(10) +
'     - if still defeated/bypassed what is mitigated',
0, 0);


insert into commentcategory
values
('Environmental',
'',
0, 0);

insert into commentcategoryfunctionallocation
select c.id, f.id
from commentcategory c,
functionallocation f
where c.name != 'General Comments'
and f.level = 1
and f.siteid = 3;

update commentcategory
set logguidelines = 'Only enter comments in this section that don''t apply to the other sections available.'
where name = 'General Comments'
and id in 
(
select cf.commentcategoryid
from commentcategoryfunctionallocation cf,
functionallocation f
where cf.functionallocationid = f.id
and f.siteid = 3
and f.level = 1
);




GO
