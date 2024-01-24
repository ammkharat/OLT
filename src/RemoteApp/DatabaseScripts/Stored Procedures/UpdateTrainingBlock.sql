if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateTrainingBlock]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateTrainingBlock]
GO

CREATE Procedure [dbo].[UpdateTrainingBlock]
    (
	  @Id bigint,
      @Name varchar(100),
      @Code varchar(100),
      @siteid bigint
    )
AS

update TrainingBlock
set
	Name = @Name,
	Code = @Code
where Id = @Id and siteid = @siteid

GO 

GRANT EXEC ON UpdateTrainingBlock TO PUBLIC
GO  