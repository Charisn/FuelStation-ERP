using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly IEntityRepo<Transaction> _transactionRepo;
    private readonly IEntityRepo<Item> _itemRepo;

    public TransactionController(IEntityRepo<Transaction> transactionRepo)
    {
        _transactionRepo = transactionRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<TransactionViewModel>> Get()
    {
        try
        {
            var result = await _transactionRepo.GetAllAsync();

            var transaction = result.FindAll(x=>x.Status is true).Select(x => new TransactionViewModel
            {
                ID = x.ID,
                CustomerID = x.CustomerID,
                EmployeeID = x.EmployeeID,
                TotalValue = x.TotalValue,
                DateTime = x.DateTime
            });

            return transaction;
        }
        catch (Exception)
        {
            return new List<TransactionViewModel>();
        }
    }
    [HttpGet("{id}")]
    public async Task<TransactionViewModel> Get(Guid ID)
    {
        TransactionViewModel transaction = new();
        if (ID != Guid.Empty)
        {
            var foundTransaction = await _transactionRepo.GetByIdAsync(ID);
            if (foundTransaction != null)
            {
                transaction.ID = foundTransaction.ID;
                transaction.DateTime = foundTransaction.DateTime;
                transaction.CustomerID = foundTransaction.CustomerID;
                transaction.EmployeeID = foundTransaction.EmployeeID;
                transaction.PaymentMethod = foundTransaction.PaymentMethod;
                transaction.TotalValue = foundTransaction.TotalValue;

                transaction.TransactionLines = foundTransaction.TransactionLines.Select(x => new TransactionLineViewModel
                {
                    ID = x.ID,
                    ItemID = x.ItemID,
                    Quantity = x.Quantity,
                    ItemPrice = Convert.ToDecimal(x.Item.Price),
                    ItemType = x.Item.ItemType,
                    NetValue = x.NetValue,
                    DiscountPercentage = x.DiscountPercentage,
                    DiscountValue = x.DiscountValue,
                    TotalValue = x.TotalValue

                }).ToList();
            }
        }
        return transaction;
    }

    [HttpPost]

    public async Task Post(TransactionViewModel transaction)
    {
        var newTransaction = new Transaction()
        {
            EmployeeID = transaction.EmployeeID,
            CustomerID = transaction.CustomerID,
            PaymentMethod = transaction.PaymentMethod,
            TotalValue = transaction.TotalValue,
            TransactionLines = transaction.TransactionLines.Select(x => new TransactionLine
            {
                ItemID = x.ItemID,
                Quantity = x.Quantity,
                ItemPrice = x.ItemPrice,
                NetValue = x.NetValue,
                DiscountPercentage = x.DiscountPercentage,
                DiscountValue = x.DiscountValue,
                TotalValue = x.TotalValue,

            }).ToList()
        };
        try
        {
            await _transactionRepo.CreateAsync(newTransaction);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult> Put(TransactionViewModel transaction)
    {
        var trans = await _transactionRepo.GetByIdAsync(transaction.ID);
        trans.DateTime = transaction.DateTime;
        trans.CustomerID = transaction.CustomerID;
        trans.EmployeeID = transaction.EmployeeID;
        trans.PaymentMethod = transaction.PaymentMethod;
        trans.TotalValue = transaction.TotalValue;
        trans.TransactionLines = transaction.TransactionLines.Select(x => new TransactionLine
        {
            ID = x.ID,
            ItemID = x.ItemID,
            Quantity = x.Quantity,
            ItemPrice = x.ItemPrice,
            NetValue = x.NetValue,
            DiscountPercentage = x.DiscountPercentage,
            DiscountValue = x.DiscountValue,
            TotalValue = x.TotalValue

        }).ToList();
        try
        {
            await _transactionRepo.UpdateAsync(transaction.ID, trans);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return Ok();
    }

    [HttpDelete("{ID}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _transactionRepo.DeleteAsync(id);
        return Ok();
    }
}