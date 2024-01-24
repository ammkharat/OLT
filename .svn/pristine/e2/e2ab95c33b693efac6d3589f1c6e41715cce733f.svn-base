IF not EXISTS (
  select * from role where SiteId = 15  and Name like 'NPA Operator / Tech'
)
begin

insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('NPA Operator / Tech',0,'NPAOperatorTech', 0, 0, 0, 15,1, 'npaopertech', 0 )

end





GO

