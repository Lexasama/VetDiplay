if not exists(
	select * from sys.schemas s where s.[name] = 'vd')
		exec('create schema vd;');