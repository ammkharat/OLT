

alter table ShiftHandoverEmailConfiguration drop column SendTime;
alter table ShiftHandoverEmailConfiguration add ScheduleId bigint not null;



GO

