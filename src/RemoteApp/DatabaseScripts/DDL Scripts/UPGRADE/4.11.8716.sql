alter table FormGN24 add PreJobMeetingSignatures varchar(max) null;
alter table FormGN24 add PlainTextPreJobMeetingSignatures varchar(max) null;
alter table FormGN24History add PlainTextPreJobMeetingSignatures varchar(max) null;
go

insert into FormTemplate (FormTypeId, Template, Deleted, CreatedByUserId, CreatedDateTime, TemplateKey, Name)
values (4, 'Template for pre-job meeting signatures', 0, -1, '2013-10-22 12:00', 'prejobsignatures', 'Pre-Job Meeting')
go