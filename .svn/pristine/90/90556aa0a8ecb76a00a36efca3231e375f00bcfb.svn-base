
-- I was originally going to do this the fancy way: only reseed to 1,000,000 if necessary. But if this were to fail while releasing to prod I'd feel bad, so I'm removing the fanciness.  We'll have to rebuild Andrew's test environments.

--DECLARE @StartingValue bigint
--select @StartingValue = max(isnull(PermitNumber, 1)) from WorkPermitEdmonton

--if (isnull(@StartingValue, 1) < 1000000)
  DBCC CHECKIDENT (WorkPermitEdmontonPermitNumberSequence, RESEED, 1000000)




GO

