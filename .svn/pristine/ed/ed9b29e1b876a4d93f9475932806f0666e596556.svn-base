IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewMontrealSeqVal_MontrealFormIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewMontrealSeqVal_MontrealFormIdSequence
	END
GO

CREATE Procedure [dbo].GetNewMontrealSeqVal_MontrealFormIdSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into MontrealFormIdSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     
	
	delete from MontrealFormIdSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewMontrealSeqVal_MontrealFormIdSequence TO PUBLIC
GO

