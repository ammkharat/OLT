IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_WorkPermitMontrealPermitNumberSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_WorkPermitMontrealPermitNumberSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_WorkPermitMontrealPermitNumberSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into WorkPermitMontrealPermitNumberSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     

	delete from WorkPermitMontrealPermitNumberSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_WorkPermitMontrealPermitNumberSequence TO PUBLIC
GO

