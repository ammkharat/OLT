alter table SummaryLog
add CreatedByRoleId bigint null;

go

update s
set s.CreatedByRoleId = r.Id
from SummaryLog s
inner join SummaryLogFunctionalLocation sf on s.Id = sf.SummaryLogId
inner join FunctionalLocation f on sf.FunctionalLocationId = f.Id
inner join Role r on f.SiteId = r.SiteId and r.Name = 'Supervisor';

go

alter table SummaryLog
alter column CreatedByRoleId bigint not null;

go

ALTER TABLE SummaryLog 
ADD  CONSTRAINT FK_SummaryLog_CreatedByRoleId
FOREIGN KEY(CreatedByRoleId)
REFERENCES Role (Id);

go

GO
