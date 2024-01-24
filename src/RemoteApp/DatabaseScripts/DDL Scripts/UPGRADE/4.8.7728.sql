alter table SiteConfiguration add ShowCreateShiftHandoverMessageFromNewLogClick bit null;
go

update SiteConfiguration set ShowCreateShiftHandoverMessageFromNewLogClick = 0;
update SiteConfiguration set ShowCreateShiftHandoverMessageFromNewLogClick = 1 where SiteId = 2;  -- Denver
go

alter table SiteConfiguration alter column ShowCreateShiftHandoverMessageFromNewLogClick bit not null;
go


GO


alter table [dbo].DocumentLink add WorkPermitLubesId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitLubes] FOREIGN KEY([WorkPermitLubesId])
REFERENCES [dbo].[WorkPermitLubes] ([Id])
go



GO

