alter table PermitRequest
add SourceId int null;

go

update PermitRequest
set SourceId = 0;

go

alter table PermitRequest
alter column SourceId int not null;

go


alter table PermitRequestHistory
add SourceId int null;

go

update PermitRequestHistory
set SourceId = 0;

go

alter table PermitRequestHistory
alter column SourceId int not null;

go


-- ---------------------------------------


alter table PermitRequest
add LastImportedByUserId bigint null;

alter table PermitRequest
add LastImportedDateTime datetime null;

go

alter table PermitRequest
ADD  CONSTRAINT FK_PermitRequest_LastImportedByUser
FOREIGN KEY(LastImportedByUserId)
REFERENCES [User] ([Id]);

go

alter table PermitRequestHistory
add LastImportedByUserId bigint null;

alter table PermitRequestHistory
add LastImportedDateTime datetime null;

go

-- ---------------------------------------

alter table PermitRequest
add LastSubmittedByUserId bigint null;

alter table PermitRequest
add LastSubmittedDateTime datetime null;

go

alter table PermitRequest
ADD  CONSTRAINT FK_PermitRequest_LastSubmittedByUser
FOREIGN KEY(LastSubmittedByUserId)
REFERENCES [User] ([Id]);

go

alter table PermitRequestHistory
add LastSubmittedByUserId bigint null;

alter table PermitRequestHistory
add LastSubmittedDateTime datetime null;

go

GO
