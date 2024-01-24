alter table SummaryLogHistory add LogDateTime datetime null;

GO

update SummaryLogHistory set LogDateTime = 
(select CreatedDateTime from SummaryLog where SummaryLogHistory.Id = SummaryLog.Id);

GO

alter table SummaryLogHistory alter column LogDateTime datetime not null;

GO

-- ficksing a speling mistaek
update RoleGroup set [Name] = 'Process Engineer' where Id = 7;

GO

GO
