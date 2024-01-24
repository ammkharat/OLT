
delete from [roleelement] where id = 87;  -- 'change target values' role element

declare @constraint_name VARCHAR(MAX)
declare @sql NVARCHAR(MAX) 

select 
    --col.name, 
    --col.column_id, 
    --col.default_object_id, 
    --OBJECTPROPERTY(col.default_object_id, N'IsDefaultCnst') as is_defcnst, 
    @constraint_name = dobj.name 
from sys.columns col 
    left outer join sys.objects dobj 
        on dobj.object_id = col.default_object_id and dobj.type = 'D' 
where col.object_id = object_id(N'dbo.TargetDefinition') 
and dobj.name is not null
and [col].[name] = 'ExtensionParentTargetDefinitionId'

set @sql = 'alter table TargetDefinition DROP CONSTRAINT ' + @constraint_name
EXEC sp_executesql @sql

alter table dbo.[TargetDefinition]
drop column ExtensionParentTargetDefinitionId

go


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'df_rename')
BEGIN
	DROP Procedure dbo.df_rename
end
GO

GO
