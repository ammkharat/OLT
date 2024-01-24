
IF not EXISTS (
select * from Site where Id =19
)
Begin
INSERT site
SELECT 19,'Terra Nova','Newfoundland Standard Time','TeraNova'
END

IF not EXISTS (
select * from SiteConfigurationDefaults where SiteId =19
)
Begin


INSERT SiteConfigurationDefaults(SiteId,CopyTargetAlertResponseToLog)
SELECT 19,0

End