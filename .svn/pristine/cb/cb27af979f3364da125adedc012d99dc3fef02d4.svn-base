if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertFunctionalLocation]
GO

CREATE Procedure [dbo].[InsertFunctionalLocation]
	(
	@Id bigint Output,
	@FullHierarchy varchar(90),
	@SiteId bigint, 
	@Level tinyint,
	@Description varchar(50) = null,
	@PlantId bigint,
	@Culture varchar(5),
	@Source tinyint
	)
AS

if @PlantId in (7030,7600)
begin
	set @PlantId = 9991
end

-- Insert into Functional Location table
INSERT INTO FunctionalLocation
(SiteId, Description, FullHierarchy, Deleted, OutOfService, [Level], PlantId, Culture, Source)
VALUES     
(@SiteId, @Description, @FullHierarchy, 0, 0, @Level, @PlantId, @Culture, @Source)

SET @Id= SCOPE_IDENTITY() 

-- Insert the Ancestor records for this Functional Location	
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
	SELECT 
		c.id, a.id, a.[Level]
		FROM FunctionalLocation a
		INNER JOIN FunctionalLocation c 
			ON c.siteid = a.siteid and 
			c.[Level] > a.[Level] and
			c.Fullhierarchy like a.fullhierarchy + '-%'
		where
		c.id = @Id
)

-- Insert the Ancestor records for children now that the parent has been entered
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel]) (
    SELECT 
		c.id, a.id, a.[Level]
    FROM 
		FunctionalLocation a
    INNER JOIN FunctionalLocation c 
		ON c.siteid = a.siteid and 
		c.[Level] > a.[Level] and
		c.Fullhierarchy like a.fullhierarchy + '-%'
    where
		a.id = @Id
		and NOT EXISTS(Select [id], ancestorid from functionallocationancestor where [id] = c.id and ancestorid = a.id)
)
GO 

GRANT EXEC ON InsertFunctionalLocation TO PUBLIC
GO