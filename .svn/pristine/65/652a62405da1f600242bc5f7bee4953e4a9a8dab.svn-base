
alter table Role add IsAdministratorRole bit null;
alter table Role add IsReadOnlyRole bit null;
alter table Role add IsWorkPermitNonOperationsRole bit null;

go

update Role set IsAdministratorRole = 0;
update Role set IsReadOnlyRole = 0;
update Role set IsWorkPermitNonOperationsRole = 0;

update Role set IsAdministratorRole = 1 where Id in (37, 38);
update Role set IsReadOnlyRole = 1 where Id in (7);
update Role set IsWorkPermitNonOperationsRole = 1 where Id in (8);

go

alter table Role alter column IsAdministratorRole bit not null;
alter table Role alter column IsReadOnlyRole bit not null;
alter table Role alter column IsWorkPermitNonOperationsRole bit not null;

go
GO
