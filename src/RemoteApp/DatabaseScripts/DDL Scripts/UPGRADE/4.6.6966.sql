alter table TargetAlert add TypeOfViolationStatusId int null;
alter table TargetAlert add LastViolatedDateTime datetime null;
alter table TargetAlert add MaxAtEvaluation decimal(9,2) null;
alter table TargetAlert add MinAtEvaluation decimal(9,2) null;
alter table TargetAlert add NTEMaxAtEvaluation decimal(9,2) null;
alter table TargetAlert add NTEMinAtEvaluation decimal(9,2) null;
alter table TargetAlert add ActualValueAtEvaluation decimal(9,2) null;

GO

update TargetAlert set TypeOfViolationStatusId = 5; -- unknown
update TargetAlert set LastViolatedDateTime = LastModifiedDateTime;

GO

alter table TargetAlert alter column TypeOfViolationStatusId int not null;
alter table TargetAlert alter column LastViolatedDateTime datetime not null;





GO

