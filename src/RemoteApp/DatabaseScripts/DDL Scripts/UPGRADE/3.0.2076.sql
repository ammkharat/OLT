insert into shifthandoverconfiguration
values ('Daily Shift Handover', 0);

insert into shifthandoverconfigurationfunctionallocation
select s.id, f.id
from shifthandoverconfiguration s,
functionallocation f
where s.name = 'Daily Shift Handover'
and f.fullhierarchy in ('EX1', 'UP1', 'UP2');

-- note: if you change the SQL below, look at the almost identical SQL in 3.0.2147
insert into shifthandoverconfigurationrole
select s.id, r.id
from shifthandoverconfiguration s,
role r
where s.name = 'Daily Shift Handover'
and r.id in (1, 2);

insert into shifthandoverquestion
select s.id,
0,
'Any ILPs entered this shift?',
'Required information:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) ILP #' + CHAR(13) + CHAR(10) +
'2) Risk rank' + CHAR(13) + CHAR(10) +
'3) Brief description' + CHAR(13) + CHAR(10) +
'4) Additional info for ILPs with risk rank 1 or 2',
0
from shifthandoverconfiguration s
where s.name = 'Daily Shift Handover';

insert into shifthandoverquestion
select s.id,
1,
'Were there any loss of containments this shift?',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Substance leaked' + CHAR(13) + CHAR(10) +
'2) Location' + CHAR(13) + CHAR(10) +
'3) Current status' + CHAR(13) + CHAR(10) +
'4) What was done to mitigate' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'Example:' + CHAR(13) + CHAR(10) +
'Hot bitumen leak on packing of 52G300 alpha suction valve. Packing tightened. Release stopped. Steam hose was put on it. Monitoring.',
0
from shifthandoverconfiguration s
where s.name = 'Daily Shift Handover';

insert into shifthandoverquestion
select s.id,
2,
'Were there any personal safety issues on this shift (e.g. first aid, medical aids, significant near miss, etc.)?',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) ILP # (if any)' + CHAR(13) + CHAR(10) +
'2) Location' + CHAR(13) + CHAR(10) +
'3) Description' + CHAR(13) + CHAR(10) +
'4) Cause (if known)' + CHAR(13) + CHAR(10) +
'5) Mitigation' + CHAR(13) + CHAR(10) +
'6) Follow up required',
0
from shifthandoverconfiguration s
where s.name = 'Daily Shift Handover';

insert into shifthandoverquestion
select s.id,
3,
'Were there any risks escalated or risks potentially requiring escalation this shift?',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Location' + CHAR(13) + CHAR(10) +
'2) Process stream' + CHAR(13) + CHAR(10) +
'3) Type of risk:' + CHAR(13) + CHAR(10) +
'     - Ongoing loss of containment' + CHAR(13) + CHAR(10) +
'     - Unable to acheive isolation' + CHAR(13) + CHAR(10) +
'     - Emerging issue in the plant' + CHAR(13) + CHAR(10) +
'     - etc.' + CHAR(13) + CHAR(10) +
'4) What was escalated and to whom' + CHAR(13) + CHAR(10) +
'5) Ongoing mitigation' + CHAR(13) + CHAR(10) +
'6) What actions are required in the next 24 hours',
0
from shifthandoverconfiguration s
where s.name = 'Daily Shift Handover';

insert into shifthandoverquestion
select s.id,
4,
'Were there any critical systems defeated/bypassed this shift?',
'Details would include:' + CHAR(13) + CHAR(10) +
'' + CHAR(13) + CHAR(10) +
'1) Which point (tag #) was defeated/bypassed' + CHAR(13) + CHAR(10) +
'2) Why' + CHAR(13) + CHAR(10) +
'3) Status (returned or still defeated/bypassed)' + CHAR(13) + CHAR(10) +
'     - if still defeated/bypassed what is mitigated',
0
from shifthandoverconfiguration s
where s.name = 'Daily Shift Handover';



GO
