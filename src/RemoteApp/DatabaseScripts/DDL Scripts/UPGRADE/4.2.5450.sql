

CREATE TABLE [dbo].TemporaryPermitRequestMontrealFlocHistory (
  LastModifiedByUserId bigint not null,
  LastModifiedDateTime datetime not null,
  Id bigint not null,
  FunctionalLocations varchar(max) not null
)
ON [PRIMARY];
GO

insert into TemporaryPermitRequestMontrealFlocHistory (LastModifiedByUserId, LastModifiedDateTime, Id, FunctionalLocations)
select hist.LastModifiedByUserId, hist.LastModifiedDateTime, hist.Id, f.FullHierarchy
from PermitRequestMontrealHistory hist
inner join FunctionalLocation f on f.Id = hist.FunctionalLocationId;
go

alter table PermitRequestMontrealHistory
drop column FunctionalLocationId;

go

alter table PermitRequestMontrealHistory
add FunctionalLocations varchar(MAX);

go

update PermitRequestMontrealHistory
set PermitRequestMontrealHistory.FunctionalLocations = tmpHist.FunctionalLocations
from TemporaryPermitRequestMontrealFlocHistory tmpHist
where PermitRequestMontrealHistory.Id = tmphist.Id and
      PermitRequestMontrealHistory.LastModifiedByUserId = tmphist.LastModifiedByUserId and
      PermitRequestMontrealHistory.LastModifiedDateTime = tmphist.LastModifiedDateTime;

go

alter table PermitRequestMontrealHistory
alter column FunctionalLocations varchar(MAX) not null;

go

drop table TemporaryPermitRequestMontrealFlocHistory;

go


--- test method (when the FunctionalLocationId column hasn't been dropped):

--- select count(*) 
--- from PermitRequestMontrealHistory hist
--- inner join FunctionalLocation f on f.Id = hist.FunctionalLocationId
--- where f.FullHierarchy != hist.FunctionalLocations;












GO

