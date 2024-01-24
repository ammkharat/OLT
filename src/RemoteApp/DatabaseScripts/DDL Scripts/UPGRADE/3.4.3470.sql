alter table UserLoginHistory
add MachineName varchar(20) null;

go

update UserLoginHistory
set MachineName = '';

go

alter table UserLoginHistory
alter column MachineName varchar(20) not null;

go


GO

GO
