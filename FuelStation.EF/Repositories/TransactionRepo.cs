using FuelStation.EF.Context;
using FuelStation.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories;

public class TransactionRepo : IEntityRepo<Transaction>
{
    private readonly FuelStationContext _context;
    public TransactionRepo(FuelStationContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Transaction entity)
    {
        await _context.Transactions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction is not null)
        {
            transaction.Status = false;
            await _context.SaveChangesAsync();
            return;
        }
    }

    public async Task<List<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.AsNoTracking()
                                          .Include(transaction => transaction.Employee)
                                          .Include(transaction => transaction.Customer)
                                          .Include(transaction => transaction.TransactionLines)
                                          .ThenInclude(transactionLine => transactionLine.Item)
                                          .ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.AsNoTracking()
                                          .Include(transaction => transaction.Employee)
                                          .Include(transaction => transaction.Customer)
                                          .Include(transaction => transaction.TransactionLines)
                                          .ThenInclude(transactionLine => transactionLine.Item)
                                          .SingleOrDefaultAsync(transaction => transaction.ID == id);
    }

    public async Task UpdateAsync(Guid id, Transaction entity)
    {
        var transaction = await _context.Transactions.Include(x => x.TransactionLines).SingleOrDefaultAsync(x => x.ID == id);
        if (transaction is not null)
        {
            transaction.CustomerID = entity.CustomerID;
            transaction.EmployeeID = entity.EmployeeID;
            transaction.PaymentMethod = entity.PaymentMethod;
            transaction.TotalValue = entity.TotalValue;
            transaction.Status = entity.Status;

            foreach (var line in entity.TransactionLines)
            {
                var existLine = await _context.TransactionLines.SingleOrDefaultAsync(x => x.ID == line.ID);
                if (existLine is not null)
                {
                    existLine.ItemID = line.ItemID;
                    existLine.ItemPrice = line.ItemPrice;
                    existLine.DiscountPercentage = line.DiscountPercentage;
                    existLine.DiscountValue = line.DiscountValue;
                    existLine.NetValue = line.NetValue;
                    existLine.Quantity = line.Quantity;
                    existLine.TotalValue = line.TotalValue;
                    _context.TransactionLines.Update(existLine);
                }
            }
            try
            {
                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            throw new KeyNotFoundException("Transaction not found");
        }
    }
}
