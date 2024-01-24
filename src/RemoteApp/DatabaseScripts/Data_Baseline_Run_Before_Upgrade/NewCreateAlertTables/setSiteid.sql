if not exists (select * from Site where site.Id in (14,15,16))
begin
insert into Site (Id,Name,TimeZone,ActiveDirectoryKey) 
values
(14,'Fort Hills Major Projects','Mountain Standard Time','MajorProjects'),
(15,'Fort Hills Operations','Mountain Standard Time','FortHills'),
(16,'Montréal usine de soufre','Eastern Standard Time','MUDS')
end

