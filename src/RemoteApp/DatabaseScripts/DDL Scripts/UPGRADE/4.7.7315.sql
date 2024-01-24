
declare @roleId bigint;

select @roleId = Id from Role where SiteId = 8 and Name = 'TA Team Leader'

update Role set Name = 'TA Support', Alias = 'tasupport' where Id = @roleId




GO

