IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND name = N'IDX_TagName_Site')
DROP INDEX [IDX_TagName_Site] ON [dbo].[Tag] WITH ( ONLINE = OFF )

CREATE NONCLUSTERED INDEX [IDX_TagName_SiteAndName] ON [dbo].[Tag] 
(
	[SiteId] ASC,
	[Name] ASC
)
INCLUDE ( [Id],
[Description],
[Units],
[Deleted]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]






GO
