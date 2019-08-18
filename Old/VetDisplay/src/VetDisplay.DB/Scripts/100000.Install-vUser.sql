create view vd.vUser
as
    select UserId = u.UserId,
           Email = u.Email,
           [Password] = case when p.[Password] is null then 0x else p.[Password] end
    from vd.tUser u
        left outer join vd.tPasswordUser p on p.UserId = u.UserId
    where u.UserId <> 0;