exec sp_RENAME 'Log.Comments', 'RtfComments', 'COLUMN'
exec sp_RENAME 'Log.CommentsAsPlainText', 'PlainTextComments', 'COLUMN'

exec sp_RENAME 'LogDefinition.Comments', 'RtfComments', 'COLUMN'
exec sp_RENAME 'LogDefinition.CommentsAsPlainText', 'PlainTextComments', 'COLUMN'


GO
