create procedure vd.sUserUpdate
(
    @UserId int,
    @Email  nvarchar(64)
)
as
begin
    update vd.tUser
    set Email = @Email
    where UserId = @UserId;
    return 0;
end;