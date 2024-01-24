if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertShiftHandoverConfiguration]
GO

CREATE Procedure [dbo].[InsertShiftHandoverConfiguration]
    (
    @Id bigint Output,    	
	@Name varchar(50)
    )
AS

INSERT INTO ShiftHandoverConfiguration
(   
	[Name],
	[Deleted]
)
VALUES
(    
	@Name,
	0
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertShiftHandoverConfiguration TO PUBLIC
GO  