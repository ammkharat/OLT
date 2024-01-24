

alter table dbo.WorkPermitOssaHistory add IsolationNumber varchar(100) null
go

alter table dbo.WorkPermitOssa add IsolationNumber varchar(100) null
go





GO



--- OSSA work permits are not out yet, so it is safe to just set the requested start datetimes to whatever I like here

update dbo.WorkPermitOssa
set RequestedStartDateTime = '2012/05/22 15:00';
go

update dbo.WorkPermitOssaHistory
set RequestedStartDateTime = '2012/05/22 15:00';
go

alter table dbo.WorkPermitOssa alter column RequestedStartDateTime datetime not null;
alter table dbo.WorkPermitOssaHistory alter column RequestedStartDateTime datetime not null;
go


GO

