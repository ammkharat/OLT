

CREATE TABLE [dbo].ConfiguredDocumentLink (
	Id bigint IDENTITY(1, 1) not null,
	Title varchar(100) not null,
	Link varchar(1000) not null,
	LinkType varchar(100) not null,   -- 'Document' or 'Path', currently
    Location varchar(100) not null,   -- 'WorkPermitMontreal' or 'ConfinedSpaceMontreal', currently	
	DisplayOrder int not null,
	Deleted bit not null,
CONSTRAINT [PK_ConfiguredDocumentLink]
PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY]
)
ON [PRIMARY];
GO


insert into [dbo].ConfiguredDocumentLink (Title, Link, LinkType, Location, DisplayOrder, Deleted)
select 'Règlement', Reglement, 'Document', 'WorkPermitMontreal', 0, 0
from WorkPermitMontrealLinks;

insert into [dbo].ConfiguredDocumentLink (Title, Link, LinkType, Location, DisplayOrder, Deleted)
select 'Protections respiratoires', ProtectionsRespiratoires, 'Document', 'WorkPermitMontreal', 1, 0
from WorkPermitMontrealLinks;

insert into [dbo].ConfiguredDocumentLink (Title, Link, LinkType, Location, DisplayOrder, Deleted)
select 'Fiches Signalitiques de Suncor', FicheSignalitiquesDePetroCanada, 'Document', 'WorkPermitMontreal', 2, 0
from WorkPermitMontrealLinks;

insert into [dbo].ConfiguredDocumentLink (Title, Link, LinkType, Location, DisplayOrder, Deleted)
select 'Fiches Signalitiques des fournisseurs', FichesSignalitiquesDesFournisseurs, 'Document', 'WorkPermitMontreal', 3, 0
from WorkPermitMontrealLinks;

insert into [dbo].ConfiguredDocumentLink (Title, Link, LinkType, Location, DisplayOrder, Deleted)
select 'Plans de sauvetage', PlanDeSauvetage, 'Path', 'ConfinedSpaceMontreal', 0, 0
from WorkPermitMontrealLinks;
		
go

drop table WorkPermitMontrealLinks;

go





GO

