If NOT EXISTS(SELECT * FROM RoleElement WHERE Name='Scan Work Permit' and FunctionalArea='Work Permits')
BEGIN
insert into RoleElement
select 405,'Scan Work Permit','Work Permits'
END