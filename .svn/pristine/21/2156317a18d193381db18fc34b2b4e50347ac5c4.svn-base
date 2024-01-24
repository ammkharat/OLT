
alter table WorkPermitMontreal add IssuedDateTime datetime null;
alter table WorkPermitMontrealHistory add IssuedDateTime datetime null;
go

update WorkPermitMontreal
set IssuedDateTime = wpmh.LastModifiedDateTime
from WorkPermitMontreal
inner join WorkPermitMontrealHistory wpmh on wpmh.Id = WorkPermitMontreal.Id
where
wpmh.LastModifiedDateTime in
(
select min(LastModifiedDateTime) as minLastModifiedDateTime
from WorkPermitMontrealHistory wpmh_inner
where wpmh_inner.WorkPermitStatusId = 3  -- Issued
      and wpmh_inner.Id = wpmh.Id
)

go


update WorkPermitMontrealHistory
set WorkPermitMontrealHistory.IssuedDateTime = wpm.IssuedDateTime
from WorkPermitMontrealHistory
inner join WorkPermitMontreal wpm on wpm.Id = WorkPermitMontrealHistory.Id
where wpm.IssuedDateTime is not null and
      WorkPermitMontrealHistory.LastModifiedDateTime >= wpm.IssuedDateTime

go




GO

