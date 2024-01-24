

alter table dbo.SiteConfiguration add FormsFlocSetTypeId int null;
go

update dbo.SiteConfiguration set FormsFlocSetTypeId = 0;
go

update dbo.SiteConfiguration set FormsFlocSetTypeId = 1 where SiteId = 8;  -- edmonton uses the Work Permit floc tree for Forms
go

alter table dbo.SiteConfiguration alter column FormsFlocSetTypeId int not null;
go






GO

