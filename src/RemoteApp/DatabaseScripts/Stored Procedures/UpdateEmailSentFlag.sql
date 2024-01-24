 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateEmailSentFlag')
	BEGIN
		DROP PROCEDURE [dbo].UpdateEmailSentFlag
	END
GO
Create Procedure UpdateEmailSentFlag
(
  @Id bigint,
  @isMailSent bit
 )
 AS
 Update FormOP14Approval set isMailSent=@isMailSent
 where Id=@Id
 
GRANT EXEC ON [UpdateEmailSentFlag] TO PUBLIC