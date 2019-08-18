create view vd.vAuthenticationProvider
as
    select usr.UserId, usr.ProviderName
    from (select UserId = u.UserId,
              ProviderName = 'VetDisplay'
          from vd.tPasswordUser u
        ) usr
    where usr.UserId <> 0;