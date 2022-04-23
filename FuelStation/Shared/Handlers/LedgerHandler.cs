using FuelStation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Shared.Handlers;

public class LedgerHandler
{
    public decimal GetIncome(List<decimal> transactions)
    {
        return transactions.Sum();
    }

    public decimal GetExpenses(List<Employee> employees, List<Transaction> transactionList, decimal rent)
    {
        decimal products = 0;
        decimal salaries = 0;

        foreach (var transaction in transactionList)
        {
            products += transaction.TransactionLines.Select(x => Convert.ToDecimal(x.Item.Cost)).Sum();
        }

        salaries += employees.Select(x => Convert.ToDecimal(x.SalaryPerMonth)).Sum();

        return (products + salaries + rent);
    }
}
