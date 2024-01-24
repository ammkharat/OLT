

IF OBJECT_ID('QueryPermitRequestFortHillsByWorkOrderNumberAndSAPWorkCentre', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsByWorkOrderNumberAndSAPWorkCentre
GO 


    
CREATE Procedure [dbo].QueryPermitRequestFortHillsByWorkOrderNumberAndSAPWorkCentre    
(    
 @SourceId int,    
 @WorkOrderNumber varchar(25),    
 @SAPWorkCentre varchar(40)    
)    
AS    
    
select * from PermitRequestFortHills pre    
where     
pre.Deleted = 0    
and pre.DataSourceId=@SourceId    
and pre.WorkOrderNumber=@WorkOrderNumber    
and pre.SAPWorkCentre=@SAPWorkCentre    



GRANT EXEC ON QueryPermitRequestFortHillsByWorkOrderNumberAndSAPWorkCentre TO PUBLIC  