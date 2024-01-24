IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_WorkPermitEdmontonPermitNumberSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_WorkPermitEdmontonPermitNumberSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_WorkPermitEdmontonPermitNumberSequence
AS

begin

	declare @NewSeqValue bigint

	set NOCOUNT ON

	insert into WorkPermitEdmontonPermitNumberSequence (SeqVal) values ('z')

	set @NewSeqValue = scope_identity()     

	delete from WorkPermitEdmontonPermitNumberSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_WorkPermitEdmontonPermitNumberSequence TO PUBLIC
GO

