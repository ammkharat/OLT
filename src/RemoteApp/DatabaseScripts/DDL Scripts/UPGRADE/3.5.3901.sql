declare @up1CokerCardConfigId BIGINT
SELECT @up1CokerCardConfigId = [Id] From CokercardConfiguration where [name] = 'UP1 Coker Card';

INSERT INTO dbo.CokerCardConfigurationWorkAssignment
	select @up1CokerCardConfigId, Id from WorkAssignment where roleid = 2 and [name] like '%Coker%' and [name] like '%UP1%' and siteid = 3 and deleted = 0

INSERT INTO dbo.CokerCardConfigurationWorkAssignment
	select @up1CokerCardConfigId, Id from WorkAssignment where roleid = 1 and [name] like '%UP1%' and siteid = 3 and deleted = 0

go


GO
