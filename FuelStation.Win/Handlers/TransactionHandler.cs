using FuelStation.Model.Enums;
using FuelStation.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Win.Handlers;

public class TransactionHandler
{
    HttpClient httpClient = new HttpClient();

    public async Task<List<EmployeeViewModel>> GetEmployees()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<EmployeeViewModel>>("https://localhost:7060/employee/");
        }
        catch (Exception)
        {
            return new List<EmployeeViewModel>();
        }
    }

    public async Task <List<TransactionViewModel>> GetTransactions()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<TransactionViewModel>>("https://localhost:7060/transaction/");
        }
        catch (Exception)
        {
            return new List<TransactionViewModel>();
        }
    }
    public async Task<TransactionViewModel> GetTransactionByID(Guid ID)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<TransactionViewModel>($"https://localhost:7060/transaction/{ID}");
        }
        catch (Exception)
        {
            return new TransactionViewModel();
        }
    }

    public async Task CreateTransaction(TransactionViewModel transaction)
    {
        Cursor.Current = Cursors.WaitCursor;
        var response = await httpClient.PostAsJsonAsync("https://localhost:7060/transaction/", transaction);
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }
    public async Task PutTransaction(TransactionViewModel transaction)
    {
        Cursor.Current = Cursors.WaitCursor;
        var response = await httpClient.PutAsJsonAsync("https://localhost:7060/transaction/", transaction);
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
        MessageBox.Show("There was an Error in inputs, Check and try again", "Warning" , MessageBoxButtons.OK);

    }

    public async Task DeleteTransaction(TransactionViewModel transaction) 
    {
        Cursor.Current = Cursors.WaitCursor;
        var response = await httpClient.DeleteAsync($"https://localhost:7060/transaction/{transaction.ID}/");
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }

    public decimal CalculateNetValue(decimal quantity, decimal price)
    {
        if (quantity <= 0)
        {
            MessageBox.Show("Quantity was 0 now changed to 1", "Warning");
            return quantity = 1;
        }
        if (price <= 0)
        {
            MessageBox.Show("Price was 0 now changed to 1", "Warning");
            return price = 1;
        }
        return quantity * price;
    }

    public decimal CalculateLineTotalValue(decimal discountValue, decimal netValue)
    {
        if (discountValue < 0)
        {
            MessageBox.Show("Discount could not be negative now changed to 0", "Warning");
            return discountValue = 0;
        }
        if (netValue <= 0)
        {
            MessageBox.Show("Net Value could not be negative now changed to 0", "Warning");
            return netValue = 1;
        }
        return netValue - discountValue;
    }

    public decimal CalculateTransactionTotalValue(List<decimal> linesTotalValues)
    {
        return linesTotalValues.Sum();
    }

    public decimal ApplyTenPercentDiscount(decimal netValue, decimal discount, ItemTypeEnum type)
    {
        if (netValue <= 0)
        {
            MessageBox.Show("Net Value could not be negative now changed to 1", "Warning");
            return netValue = 1;
        }
        if (type == ItemTypeEnum.Fuel && netValue > 20)
        {
            return netValue * discount / 100;
        }

        return 0;
    }

    public void CheckDiscount(TransactionLineViewModel line)
    {
        if (line.ItemType == ItemTypeEnum.Fuel && line.NetValue > 20 && line.ItemPrice <= 20)
        {
            line.DiscountPercentage = 10M;
            return;
        }
        if (line.ItemType == ItemTypeEnum.Fuel && line.NetValue <= 20 && line.ItemPrice > 20)
        {
            line.DiscountPercentage += 10M;
            return;
        }
        if (line.ItemType == ItemTypeEnum.Fuel && line.NetValue > 20 && (line.ItemPrice * line.Quantity) == line.NetValue)
        {
            line.DiscountPercentage += 10M;
            return;
        }
    }
    public void CalculateTotal(TransactionViewModel transaction)
    {
        transaction.TotalValue = 0;
        foreach (var line in transaction.TransactionLines)
        {
            transaction.TotalValue += line.TotalValue;
        }
    }
    
    public bool CheckCardPaymentAvail(decimal totalValue)
    {
        if (totalValue < 0) throw new ArgumentException("Total Value must be a positive number");
        if (totalValue > 50)
            return false;
        return true;
    }
}
