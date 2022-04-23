using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.Handlers;
using FuelStation.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LedgerController : ControllerBase
{
    private readonly IEntityRepo<Transaction> _transactionRepo;
    private readonly IEntityRepo<Employee> _employeeRepo;
    private readonly LedgerHandler _ledgerHandler;

    public LedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Employee> employeeRepo, LedgerHandler ledgerHandler)
    {
        _transactionRepo = transactionRepo;
        _employeeRepo = employeeRepo;
        _ledgerHandler = ledgerHandler;
    }

    [HttpGet("ledgerof/{year}/{month}")]
    public async Task<LedgerViewModel> Get(short year, short month)
    {
        var ledger = new LedgerViewModel()
        {
            Year = year,
            Month = month
        };
        var dateToCompare = new DateTime(year, month, DateTime.DaysInMonth(ledger.Year ,ledger.Month));

        var transactions = (await _transactionRepo.GetAllAsync()).Where(transaction => transaction.DateTime.Year == ledger.Year && transaction.DateTime.Month == ledger.Month);

        var employeesInMonth = (await _employeeRepo.GetAllAsync()).Where(employee => employee.StartDate <= dateToCompare.Date);
                
        ledger.Income = _ledgerHandler.GetIncome(transactions.Select(x => x.TotalValue).ToList());

        ledger.Expenses = _ledgerHandler.GetExpenses(employeesInMonth.ToList(), transactions.ToList(), 5000);

        ledger.Total = ledger.Income - ledger.Expenses;

        return ledger;
    }
}
