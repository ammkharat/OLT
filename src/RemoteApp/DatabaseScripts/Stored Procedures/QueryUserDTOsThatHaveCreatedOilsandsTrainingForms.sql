if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryUserDTOsThatHaveCreatedOilsandsTrainingForms]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryUserDTOsThatHaveCreatedOilsandsTrainingForms]
GO

CREATE Procedure [dbo].[QueryUserDTOsThatHaveCreatedOilsandsTrainingForms]
AS

select distinct u.Id, u.Username, u.Firstname, u.Lastname
from [User] u
inner join FormOilsandsTraining fot on fot.CreatedByUserId = u.Id
where fot.Deleted = 0 and u.Deleted = 0
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC ON QueryUserDTOsThatHaveCreatedOilsandsTrainingForms TO PUBLIC
GO