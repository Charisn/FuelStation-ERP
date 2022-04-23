using FuelStation.Shared.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Win.Handlers;

public class CustomerHandler
{
    HttpClient httpClient = new();
    public async Task<List<CustomerViewModel>> GetCustomers()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<CustomerViewModel>>("https://localhost:7060/customer/");
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new List<CustomerViewModel>();
        }
    }

    public async Task<List<CustomerViewModel>> GetDeletedCustomers()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<CustomerViewModel>>("https://localhost:7060/customer/statusfalse/");
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new List<CustomerViewModel>();
        }
    }
    public async Task<CustomerViewModel> GetCustomerByID(Guid ID)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            var customer = await httpClient.GetFromJsonAsync<CustomerViewModel>($"https://localhost:7060/customer/{ID}");
            return customer;
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new CustomerViewModel();
        }
    }
    public async Task CreateCustomer(CustomerViewModel customer)
    {
        Cursor.Current = Cursors.WaitCursor;
        if (customer == null) { return; }
        var response = await httpClient.PostAsJsonAsync("https://localhost:7060/customer/", customer);
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }

    public async Task PutCustomer(CustomerViewModel customer)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            if (customer == null) { return; }
            var response = await httpClient.PutAsJsonAsync("https://localhost:7060/customer/", customer);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong.", "Error");
        }
    }

    public async Task DeleteCustomer(CustomerViewModel customer)
    {
        Cursor.Current = Cursors.WaitCursor;
        if (customer == null) { return; }
        var response = await httpClient.DeleteAsync($"https://localhost:7060/customer/{customer.ID}/");
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }
}
