create procedure vd.sUserDelete
(
    @UserId int
)
as
begin
    delete from vd.tPasswordUser where UserId = @UserId;
    delete from vd.tUser where UserId = @UserId;
    return 0;
end;