

alter table dbo.FormGN24Approval add ShouldBeEnabledBehaviourId int null;
alter table dbo.FormGN24Approval add Enabled bit null;
go

update dbo.FormGN24Approval set ShouldBeEnabledBehaviourId = 1;
update dbo.FormGN24Approval set Enabled = 1;
go

alter table dbo.FormGN24Approval alter column ShouldBeEnabledBehaviourId int not null;
alter table dbo.FormGN24Approval alter column Enabled bit not null;
go



GO

