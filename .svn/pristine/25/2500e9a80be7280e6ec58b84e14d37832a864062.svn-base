alter table FunctionalLocation
add PlantId bigint null

go

ALTER TABLE [dbo].[FunctionalLocation]
ADD CONSTRAINT [FK_FunctionalLocation_Plant]
FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([Id])

go

update FunctionalLocation
set PlantId = 4000
where SiteId = 1

go


update FunctionalLocation
set PlantId = 7000
where SiteId = 2

go

update FunctionalLocation
set PlantId = 1200
where SiteId = 3
and Division = 'EX1'

go

update FunctionalLocation
set PlantId = 1300
where SiteId = 3
and Division in ('UP1', 'UP2')

go


update FunctionalLocation
set PlantId = 1100
where SiteId = 3
and Division = 'MN1'

go

update FunctionalLocation
set PlantId = 1000
where id in
	(
		select id
		from functionallocation
		where siteid = 3 and
		(
			fullhierarchy like 'EX1-%-IFST%' or 
			fullhierarchy like 'MN1-%-IFST%' or
			fullhierarchy like 'UP1-%-IFST%' or
			fullhierarchy like 'UP2-%-IFST%' or
			fullhierarchy = 'MN1-P083'
		)
	)

go

update FunctionalLocation
set PlantId = 1400
where SiteId = 5

go

update FunctionalLocation
set PlantId = 1000
where SiteId = 6

go

update FunctionalLocation
set PlantId = 754
where SiteId = 7

go

alter table FunctionalLocation
alter column PlantId bigint not null

go

GO
