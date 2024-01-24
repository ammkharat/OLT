
-- alter table Tag add LastSuccessfulRead DateTime null;
-- alter table Tag add LastSuccessfulWrite DateTime null;

-- update tag set LastSuccessfulRead = GetDate();
-- update tag set LastSuccessfulWrite = GetDate();


alter table RestrictionDefinition add LastSuccessfulTagAccess DateTime null;
alter table TargetDefinition add LastSuccessfulTagAccess DateTime null;

GO

update RestrictionDefinition set LastSuccessfulTagAccess = GetDate();
update TargetDefinition set LastSuccessfulTagAccess = GetDate();

GO
