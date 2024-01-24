alter table SiteConfiguration add ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab bit;
GO

update SiteConfiguration set ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab = 0;
GO

update SiteConfiguration set ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab = 1 where Siteid = 8; 
update SiteConfiguration set ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab = 1 where SiteId = 8;
GO

alter table SiteConfiguration alter column ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab bit not null;
GO

update SiteConfiguration set DefaultNumberOfCopiesForWorkPermits = 3 where SiteId = 8;
GO

alter table UserPrintPreference add NumberOfTurnaroundCopies int;
GO
update UserPrintPreference set NumberOfTurnaroundCopies = 3;
GO
alter table UserPrintPreference alter column NumberOfTurnaroundCopies int not null;




GO

