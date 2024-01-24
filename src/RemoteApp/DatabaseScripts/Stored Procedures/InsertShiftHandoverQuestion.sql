if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverQuestion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertShiftHandoverQuestion]
GO

CREATE Procedure [dbo].[InsertShiftHandoverQuestion]
    (
    @Id bigint Output,    
    @ConfigurationId bigint,    
	@DisplayOrder int,
	@Text varchar(150),
	@HelpText varchar(max) = null,
	@EmailList varchar(max),
	@YesNo varchar(max)
    )
AS

INSERT INTO ShiftHandoverQuestion
(
    [ShiftHandoverConfigurationId],
	[DisplayOrder],
	[Text],
	[HelpText],
	[EmailList],
	[YesNo],
	[Deleted],
	[IsCurrentQuestionVersion]
)
VALUES
(
    @ConfigurationId,
	@DisplayOrder,
	@Text,
	@HelpText,
	@EmailList,
	@YesNo,
	0,
	1
)

SET @Id= SCOPE_IDENTITY() 

GO 
GRANT EXEC ON InsertShiftHandoverQuestion TO PUBLIC
GO  