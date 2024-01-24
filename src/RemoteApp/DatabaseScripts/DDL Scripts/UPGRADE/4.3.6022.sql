alter table dbo.LogCustomFieldEntry add TypeId int null;
alter table dbo.LogDefinitionCustomFieldEntry add TypeId int null;
alter table dbo.SummaryLogCustomFieldEntry add TypeId int null;
go

update dbo.LogCustomFieldEntry set TypeId = 0;
update dbo.LogDefinitionCustomFieldEntry set TypeId = 0;
update dbo.SummaryLogCustomFieldEntry set TypeId = 0;
go

alter table dbo.LogCustomFieldEntry alter column TypeId int not null;
alter table dbo.LogDefinitionCustomFieldEntry alter column TypeId int not null;
alter table dbo.SummaryLogCustomFieldEntry alter column TypeId int not null;
go


--- numeric field entry

alter table dbo.LogCustomFieldEntry add NumericFieldEntry decimal(18,6) null;
alter table dbo.LogDefinitionCustomFieldEntry add NumericFieldEntry decimal(18,6) null;
alter table dbo.SummaryLogCustomFieldEntry add NumericFieldEntry decimal(18,6) null;
go


GO

