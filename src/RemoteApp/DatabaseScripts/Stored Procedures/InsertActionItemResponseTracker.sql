IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemResponseTracker')
    BEGIN
        DROP PROCEDURE [dbo].InsertActionItemResponseTracker
    END
GO  
  
Create Procedure [dbo].[InsertActionItemResponseTracker]  
    (  
 @ActionItemDefinitionId bigint,  
    @ActionItemId bigint,  
 @BatchNumber bigint,  
 @id bigint out,  
 @CustomFieldId bigint,  
    @CustomFieldName varchar(40),  
    @FieldEntry varchar(100),  
 @DisplayField varchar(100),  
    @DisplayOrder int,  
 @TypeId tinyint,  
 @CurrentNumericFieldEntry decimal(18,6) = null,  
 @NewNumericFieldEntry decimal(18,6) = null,  
 @PhdLinkTypeId tinyint,  
 @Comment varchar(max)  
    )  
AS  
  
declare @existingFieldEntry varchar(100)  
select @existingFieldEntry = DisplayField from ActionItemResponseTracker where BatchNumber = @BatchNumber-1 and ActionItemDefinitionId = @ActionItemDefinitionId and CustomFieldId = @CustomFieldId  
  
--if(len(ltrim(rtrim(@DisplayField))) <= 0 and LEN(ltrim(rtrim(@existingFieldEntry))) > 0)  
--begin  
--set @DisplayField = @existingFieldEntry  
--end  
  
INSERT INTO ActionItemResponseTracker  
(  
 ActionItemDefinitionId,  
 CustomFieldId,  
 ActionItemId,  
 ActionItemCustomFieldName,  
 FieldEntry,  
 DisplayField,  
 DisplayOrder,  
 TypeId,  
 [CurrentNumericFieldEntry],  
 [NewNumericFieldEntry],  
 PHDLinkTypeId,  
 [TimeStamp],  
 BatchNumber,  
 Comment  
)  
VALUES  
(  
 @ActionItemDefinitionId,  
 @CustomFieldId,  
    @ActionItemId,  
 @CustomFieldName,  
 @FieldEntry,  
 @DisplayField,  
 @DisplayOrder,  
 @TypeId,  
 @CurrentNumericFieldEntry,  
 @NewNumericFieldEntry,  
 @PhdLinkTypeId,  
 getdate(),  
 @BatchNumber,  
 @Comment  
)  
  
SET @Id= IDENT_CURRENT('ActionItemResponseTracker')  