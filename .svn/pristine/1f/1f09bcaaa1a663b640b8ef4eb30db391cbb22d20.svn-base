
IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn24]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formgn24] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn1]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN1] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn59]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN59] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN6]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN6] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN7]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN7] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75A]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75A] add [siteid] bigint NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75B] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Formop14]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formop14] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormTemplate]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formtemplate] add [siteid] [bigint] NULL
end 



GO



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN1ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN1ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN1ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN1 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN1ByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN59ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN59ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN59ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN59 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN59ByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN6ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN6ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN6ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN6 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN6ByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN7ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN7ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN7ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN7 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN7ByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75AByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN75AByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN75AByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN75A f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN75AByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75BByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN75BByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN75BByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN75B f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN75BByIdAndSiteId] TO PUBLIC


go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOP14ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormOP14ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormOP14ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormOP14 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormOP14ByIdAndSiteId] TO PUBLIC

go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormTemplateByFormTypeId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormTemplateByFormTypeId
	END
GO
CREATE Procedure [dbo].[QueryFormTemplateByFormTypeId]
	(
		@FormTypeId int, @siteid bigint
	)
AS

SELECT ft.*
FROM FormTemplate ft
WHERE
	ft.FormTypeId = @FormTypeId AND ft.SiteId = @siteid AND
	ft.Deleted != 1
go

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN24ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN24ByIdAndSiteId
	END
GO

CREATE Procedure [dbo].[QueryFormGN24ByIdAndSiteId]
(
	@Id bigint,
	@siteid bigint
)
AS
select form.*
from FormGN24 form
where form.Id = @Id and siteid = @siteid

go












GO

