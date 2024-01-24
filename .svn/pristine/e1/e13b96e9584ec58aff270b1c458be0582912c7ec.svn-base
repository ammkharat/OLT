
IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormTemplate]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formtemplate] add [siteid] [bigint] NULL
end 
go
update formTemplate set SiteId = 8 where templatekey != 'lubescriticalsystemdefeat' or templatekey is null;
GO
update formTemplate set SiteId = 10 where templatekey = 'lubescriticalsystemdefeat';
GO

IF OBJECT_ID('dbo.[FK_FormTemplate_SiteId]', 'F') IS NULL 
begin
ALTER TABLE [dbo].formTemplate
ADD CONSTRAINT [FK_FormTemplate_SiteId] 
FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
end

GO

