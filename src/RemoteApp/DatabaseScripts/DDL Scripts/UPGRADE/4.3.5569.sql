

alter table [dbo].ShiftHandoverQuestionnaire add HasYesAnswer bit null;
go

update [dbo].ShiftHandoverQuestionnaire
set HasYesAnswer = case when CountTable.YesAnswerCount IS NULL THEN 0 ELSE 1 END
from [dbo].ShiftHandoverQuestionnaire shq
left outer join
(
	select innerShq.Id as InnerShqId, count(*) as YesAnswerCount
	from ShiftHandoverQuestionnaire innerShq
	inner join ShiftHandoverAnswer sha on sha.ShiftHandoverQuestionnaireId = innerShq.Id
	where sha.Answer = 1
	group by innerShq.Id
) CountTable on CountTable.InnerShqId = shq.Id

go

alter table [dbo].ShiftHandoverQuestionnaire alter column HasYesAnswer bit not null;
go



GO

