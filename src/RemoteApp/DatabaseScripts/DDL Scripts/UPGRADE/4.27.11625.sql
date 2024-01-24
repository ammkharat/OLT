IF not EXISTS (
  select * from role where SiteId = 6  and Name like 'Cogen Field Operator'
)
begin

insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('Cogen Field Operator',0,'CogenFieldOperator', 0, 0, 0,
 6,1, 'CogenFieldOperator', 0 )
 
end



GO

IF not EXISTS (
  select * from role where SiteId = 6  and Name like 'Cogen MCR'
)
begin

insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('Cogen MCR',0,'CogenMCR', 0, 0, 0,
 6,1, 'cogenmcr', 0 )
 
end



GO

