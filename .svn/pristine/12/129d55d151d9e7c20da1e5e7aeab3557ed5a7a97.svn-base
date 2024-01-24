


--- to see the action item definitions that we will be using the history to set the created attributes for:
/*  
with cte (row_num, id, lastmodifieddatetime, lastmodifieduserid)
as
(
select ROW_NUMBER() OVER (PARTITION BY aidh.Id ORDER BY aidh.LastModifiedDateTime ASC) as row_num, aidh.Id, aidh.LastModifiedDateTime, aidh.LastModifiedUserId
from ActionItemDefinitionHistory aidh
)
select aid.*, cte.*
from ActionItemDefinition aid
inner join cte on cte.Id = aid.Id and cte.row_num = 1
*/

--- to see what cte actually is:
/*  
with cte (row_num, id, lastmodifieddatetime, lastmodifieduserid)
as
(
select ROW_NUMBER() OVER (PARTITION BY aidh.Id ORDER BY aidh.LastModifiedDateTime ASC) as row_num, aidh.Id, aidh.LastModifiedDateTime, aidh.LastModifiedUserId
from ActionItemDefinitionHistory aidh
)
select * from cte
*/


alter table ActionItemDefinition add CreatedByUserId bigint null
alter table ActionItemDefinition add CreatedDateTime datetime null
go

/* for rows that have history, set createdby and createddatetime using the first history item */

with cte (row_num, id, lastmodifieddatetime, lastmodifieduserid)
as
(
select ROW_NUMBER() OVER (PARTITION BY aidh.Id ORDER BY aidh.LastModifiedDateTime ASC) as row_num, aidh.Id, aidh.LastModifiedDateTime, aidh.LastModifiedUserId
from ActionItemDefinitionHistory aidh
)
update aid
set aid.CreatedByUserId = cte.LastModifiedUserId, aid.CreatedDateTime = cte.LastModifiedDateTime
from ActionItemDefinition as aid
inner join cte on cte.Id = aid.Id and cte.row_num = 1

go

/* for rows that don't have history (516 in prod), we will just set the created by and created datetime attributes using the last modified ones */

update ActionItemDefinition
set CreatedByUserId = LastModifiedUserId, CreatedDateTime = LastModifiedDateTime
where CreatedByUserId is null and CreatedDateTime is null

go

alter table ActionItemDefinition alter column CreatedByUserId bigint not null
alter table ActionItemDefinition alter column CreatedDateTime datetime not null
go

ALTER TABLE [dbo].[ActionItemDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ActionItemDefinition_CreatedByUser] FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO





GO

