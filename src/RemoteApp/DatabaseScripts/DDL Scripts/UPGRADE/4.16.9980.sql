alter table workassignment add ShowLubesCsdOnShiftHandoverReport bit not null default(0)
go
update workassignment set ShowLubesCsdOnShiftHandoverReport = 1 where (roleid = 121 or roleid = 129) and siteid = 10
go


GO

