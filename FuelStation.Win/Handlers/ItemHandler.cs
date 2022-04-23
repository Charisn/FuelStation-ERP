using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Shared.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace FuelStation.Win.Handlers;

public class ItemHandler
{
    HttpClient httpClient = new();
    public async Task<List<ItemViewModel>> GetItems()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<ItemViewModel>>("https://localhost:7060/item/");
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new List<ItemViewModel>();
        }
    }

    public async Task<List<ItemViewModel>> GetDeletedItems()
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<List<ItemViewModel>>("https://localhost:7060/item/statusfalse/");
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new List<ItemViewModel>();
        };
    }
    public async Task<ItemViewModel> GetItemByID(string ID)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            return await httpClient.GetFromJsonAsync<ItemViewModel>($"https://localhost:7060/item/{ID}/");
        }
        catch (Exception)
        {
            MessageBox.Show("Something Went Wrong!", "Warning", MessageBoxButtons.RetryCancel);
            return new ItemViewModel();
        };
    }

    public async Task CreateItem(ItemViewModel item)
    {
        if (item == null) { return; }
        var response = await httpClient.PostAsJsonAsync("https://localhost:7060/item/", item);
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }

    public async Task PutItem(ItemViewModel item)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            if (item == null) { return; }
            var response = await httpClient.PutAsJsonAsync("https://localhost:7060/item/", item);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
                MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
        }
        catch(Exception)
        {
            MessageBox.Show("Something Went Wrong! Make sure code is unique!", "Warning");
        }
        
    }

    public async Task DeleteItem(ItemViewModel item)
    {
        Cursor.Current = Cursors.WaitCursor;
        if (item == null) { return; }
        var response = await httpClient.DeleteAsync($"https://localhost:7060/item/{item.ID}/");
        response.EnsureSuccessStatusCode();
        if (!response.IsSuccessStatusCode)
            MessageBox.Show("There was an Error in inputs, Check and try again", "Warning", MessageBoxButtons.OK);
    }
    public async Task<bool> CheckCode(string code , Guid ID)
    {
        var itemList = await GetItems();
        var checkItem = itemList.Find(item => item.Code == code && item.ID != ID);
        if (checkItem != null)
        {
            MessageBox.Show("Item Code is already being used by an other product!", "Error");
            return false;
        }
        return true;
    }

}
