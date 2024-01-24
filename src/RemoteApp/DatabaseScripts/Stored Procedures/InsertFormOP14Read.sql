   

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14Read')
    BEGIN
        DROP PROCEDURE [dbo].InsertFormOP14Read
    END
GO


CREATE Procedure dbo.InsertFormOP14Read    
(    
 @UserId BIGINT,  
 @FormOP14Id BIGINT,  
 @DateTime  DATETIME,
 @ShiftId  BIGINT
)    
AS    
  
INSERT INTO FormOP14Read (FormOP14Id, UserId,[DateTime], ShiftId) Values (@FormOP14Id,@UserId,@DateTime,@ShiftId)  
   
GRANT EXEC ON InsertFormOP14Read TO PUBLIC  