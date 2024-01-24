IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetTrackerReport')
    BEGIN
        DROP PROCEDURE [dbo].GetTrackerReport
    END
GO


CREATE procedure [dbo].[GetTrackerReport]
(
	@ActionItemDefinitionId bigint
)

as 

declare @temptable table (id bigint not null identity(1,1),ainame varchar(100),actionitemdefinitionid bigint,displayfield varchar(100),[timestamp] datetime)
declare @name table (id int not null identity(1,1),ainame varchar(100),displayfield varchar(100))

insert into @temptable (ainame,actionitemdefinitionid,displayfield,[timestamp]) 
select ActionItemCustomFieldName,ActionItemDefinitionId, 
DisplayField = 
case DisplayField when ('Unavailable') then null
when '' then null else DisplayField end ,[TimeStamp] = 
case DisplayField when 'Unavailable' then null 
when '' then null 
else [TimeStamp] end from ActionItemResponseTracker 

group by ActionItemCustomFieldName,ActionItemDefinitionId,DisplayField,[TimeStamp]
having ActionItemDefinitionId = @ActionItemDefinitionId and ActionItemCustomFieldName <> ''

declare @actionitemdefname varchar(100)
select @actionitemdefname =  actionitemdefinition.[Name] from ActionItemDefinition where id = @ActionItemDefinitionId

select id, @actionitemdefname as ActionItemDefinitionName, ainame as CustomFieldName, STUFF((SELECT  ',' + displayfield  
	FROM @temptable EE
    WHERE  EE.ainame=E.ainame
    FOR XML PATH('')), 1, 1, '') AS listStr,
	STUFF((SELECT  ',' + CONVERT(varchar(20),[timestamp],120)
	FROM @temptable EE
    WHERE  EE.ainame=E.ainame
    FOR XML PATH('')), 1, 1, '') AS listtime

FROM @temptable E
GROUP BY E.ainame,id

