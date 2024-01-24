drop index IDX_CokerCardCycleStepEntry_CokerCardId
on CokerCardCycleStepEntry;

go

alter table CokerCardCycleStepEntry
drop column Deleted;

go

CREATE NONCLUSTERED INDEX IDX_CokerCardCycleStepEntry_CokerCardId
ON CokerCardCycleStepEntry
(
	[CokerCardId] ASC
);

go


GO
