IF  EXISTS (select * from sys.tables where object_id = OBJECT_ID(N'[dbo].[EventSinks]'))
truncate table [dbo].[EventSinks]


