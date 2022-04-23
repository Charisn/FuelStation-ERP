using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using FuelStation.Shared.ViewModels;
using FuelStation.Win.Handlers;

namespace FuelStation.Win;

public partial class ItemListForm : Form
{
    private ItemViewModel _item = new();
    private List<ItemViewModel> _itemList = new();
    private bool _showDel = false;
    private ItemHandler _itemHandler = new();
    public ItemListForm()
    {
        InitializeComponent();
    }
    private async void ItemListForm_Load(object sender, EventArgs e)
    {
        await LoadItemsFromServer();
        TimerRefresh();
    }
    public async Task LoadItemsFromServer()
    {
        _itemList = await _itemHandler.GetItems();

        BindItemsToGrid();
    }
    public async Task LoadDeletedItemsFromServer()
    {
        _itemList = await _itemHandler.GetDeletedItems();

        BindItemsToGrid();
    }
    private async void btnNewItem_Click(object sender, EventArgs e)
    {
        NewItemForm form = new();
        form.ShowDialog();
    }
    private async void btnEditItem_Click(object sender, EventArgs e)
    {
        var item = bsItems.Current as ItemViewModel;
        if (item == null) return;

        NewItemForm form = new(item);
        form.ShowDialog();
        await _itemHandler.PutItem(item);
    }
    private async void btnDeleteItems_Click(object sender, EventArgs e)
    {
        var message =  MessageBox.Show("Delete Item?", Text, MessageBoxButtons.OKCancel);
        if (message == DialogResult.OK)
        {
            var item = bsItems.Current as ItemViewModel;
            if (item == null) return;
            await _itemHandler.DeleteItem(item);
            BindItemsToGrid();
        }
    }

    private async void btnShowCurrent_Click(object sender, EventArgs e)
    {
        _showDel = false;
        _itemList = new();
        await LoadItemsFromServer();
        BindItemsToGrid();
        btnDeleteItems.Text = "Delete Item";
        Cursor.Current = Cursors.WaitCursor;
    }

    private async void btnShowDeleted_Click(object sender, EventArgs e)
    {
        _showDel = true;
        _itemList = new();
        await LoadDeletedItemsFromServer();
        BindItemsToGrid();
        btnDeleteItems.Text = "Undo Item";
        Cursor.Current = Cursors.WaitCursor;
    }

    private void btnExitItems_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }
    private void TimerRefresh()
    {
        itemTimer.Enabled = true;
        itemTimer.Interval = 6000;
    }

    private async void itemTimer_Tick(object sender, EventArgs e)
    {        
        if (_showDel)
        {
            await LoadDeletedItemsFromServer();
            grvItems.RefreshData();
        }
        else
        {
            await LoadItemsFromServer();
            grvItems.RefreshData();
        }
    }
    private void BindItemsToGrid()
    {
        bsItems.DataSource = _itemList;
        grdItems.DataSource = bsItems;
        grvItems.Columns["ID"].Visible = false;
        grvItems.Columns["Status"].Visible = false;
        grvItems.RefreshData();
    }
}
