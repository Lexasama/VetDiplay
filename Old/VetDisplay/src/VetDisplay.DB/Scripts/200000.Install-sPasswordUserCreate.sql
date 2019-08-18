create procedure vd.sPasswordUserCreate
(
    @Email    nvarchar(64),
    @Password varbinary(128),
	@UserId   int out
)
as
begin
	set transaction isolation level serializable;
	begin tran;

	if exists(select * from vd.tUser u where u.Email = @Email)
	begin
		rollback;
		return 1;
	end;

    insert into vd.tUser(Email) values(@Email);
    select @UserId = scope_identity();
    insert into vd.tPasswordUser(UserId,  [Password])
                           values(@UserId, @Password);
	commit;
    return 0;
end;
