
alter table SiteConfiguration add ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab bit;
go

update SiteConfiguration set ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab = 1;
go

update SiteConfiguration
set showworkpermitprintingtabinpreferences = 1,
    ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab = 0
where SiteId = 8 -- Edmonton
go

alter table SiteConfiguration alter column ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab bit not null;








GO

