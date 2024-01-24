update FormGN1 set FormStatusId = 3 where FormGN1.ToDateTime < GETDATE() and siteid = 8
update FormGN6 set FormStatusId = 3 where FormGN6.ValidToDateTime < GETDATE() and siteid = 8
update FormGN7 set FormStatusId = 3 where FormGn7.ValidToDateTime < GETDATE() and siteid = 8
update FormGN24 set FormStatusId = 3 where FormGN24.ValidToDateTime < GETDATE() and siteid = 8
update FormGN59 set FormStatusId = 3 where FormGN59.ValidToDateTime < GETDATE() and siteid = 8
update FormGN75a set FormStatusId = 3 where FormGN75a.ToDateTime < GETDATE() and siteid = 8






GO

