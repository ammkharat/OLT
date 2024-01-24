

alter table dbo.FormOP14Approval add ShouldBeEnabledBehaviourId int null;
alter table dbo.FormOP14Approval add Enabled bit null;
go

update dbo.FormOP14Approval set ShouldBeEnabledBehaviourId = 1;
update dbo.FormOP14Approval set Enabled = 1;
go

alter table dbo.FormOP14Approval alter column ShouldBeEnabledBehaviourId int not null;
alter table dbo.FormOP14Approval alter column Enabled bit not null;
go





GO

-- Insert clone permit request for Edmonton Contractor and Coordinator (AreaManager AD key)
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id
  from Role r,
	   RoleElement re
  where r.siteid = 8
        and re.Id in (197)
	    and r.ActiveDirectoryKey in ('Contractor', 'AreaManager')
)


GO

