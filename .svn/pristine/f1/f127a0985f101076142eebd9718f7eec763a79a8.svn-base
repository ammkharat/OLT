sp_RENAME 'WorkPermitMontrealDropdownValue' , 'DropdownValue';
GO

alter table DropdownValue add SiteId bigint null;
GO

update DropdownValue set SiteId = 9;
GO

alter table DropdownValue alter column SiteId bigint not null;
GO



ALTER TABLE [dbo].[DropdownValue]
ADD CONSTRAINT [FK_DropdownValue_SiteId] 
FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealDropdownValuesByKey')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitMontrealDropdownValuesByKey
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitMontrealDropdownValues')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllWorkPermitMontrealDropdownValues
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMontrealDropdownValue')
	BEGIN
		DROP PROCEDURE [dbo].InsertWorkPermitMontrealDropdownValue
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitMontrealDropdownValue')
	BEGIN
		DROP Procedure RemoveWorkPermitMontrealDropdownValue
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitMontrealDropdownValue')
	BEGIN
		DROP Procedure UpdateWorkPermitMontrealDropdownValue
	END
GO
	



GO

