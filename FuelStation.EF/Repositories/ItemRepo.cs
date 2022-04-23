using FuelStation.EF.Context;
using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories;

public class ItemRepo : IEntityRepo<Item>
{
    private readonly FuelStationContext _context;
    public ItemRepo(FuelStationContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Item entity)
    {

        await _context.Items.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var foundItem = await _context.Items.SingleOrDefaultAsync(item => item.ID == id);
        if (foundItem is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");
        _context.Items.Remove(foundItem);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Item>> GetAllAsync()
    {

        return await _context.Items.AsNoTracking().ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await _context.Items.Where(item => item.ID == id).SingleOrDefaultAsync();
    }

    public async Task UpdateAsync(Guid id, Item entity)
    {
        var foundItem = await _context.Items.SingleOrDefaultAsync(item => item.ID == id);

        if (foundItem is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");
        foundItem.Code = entity.Code;
        foundItem.Description = entity.Description;
        foundItem.Price = entity.Price;
        foundItem.Cost = entity.Cost;
        await _context.SaveChangesAsync();
    }
}
