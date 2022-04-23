using FuelStation.EF.Context;
using FuelStation.Model.Entities;
using FuelStation.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories;

public class LoginRepo
{
    private readonly FuelStationContext _context;

    public LoginRepo(FuelStationContext context)
    {
        _context = context;
    }
    public async Task<bool> IsTokenValid(Guid authToken)
    {
        var credentials = await _context.Logins.AsNoTracking().SingleOrDefaultAsync(x => x.Token == authToken);
        if (credentials is null)
            return false;
        return true;
    }

    public async Task CreateNew(Login login)
    {
        await _context.Logins.AddAsync(login);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Login>> GetAllAsync()
    {
        return await _context.Logins.ToListAsync();
    }

    public async Task<Login?> ValidateEmployee(string username, string password)
    {
        var credentials = await _context.Logins.AsNoTracking().SingleOrDefaultAsync(x=>x.Password == password && x.Password == password);
        if (credentials is not null)
            return credentials;
        return null;
    }
}
