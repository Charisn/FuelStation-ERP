using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuelStation.Shared.ViewModels;
using FuelStation.Model.Enums;
using FuelStation.Win.Handlers;

namespace FuelStation.Win;

public partial class NewItemForm : Form
{
    private ItemViewModel _item;
    private bool _isEditing;
    private ItemHandler _itemHandler = new();
    public NewItemForm()
    {
        InitializeComponent();
        _item = new ItemViewModel();
        _isEditing = false;
    }
    public NewItemForm(ItemViewModel item)
    {
        InitializeComponent();
        _item = item;
        _isEditing = true;
        txtCode.Properties.ReadOnly = false;
    }

    private void NewItemForm_Load(object sender, EventArgs e)
    {
        SetDataBindings();
    }

    private async void btnSaveItem_Click(object sender, EventArgs e)
    {
        if (await _itemHandler.CheckCode(txtCode.Text, _item.ID))
        {
            await SaveItem(_item);
        }
    }

    private void btnCloseItem_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }
    private void SetDataBindings()
    {
        comboItemType.DataSource = Enum.GetValues(typeof(ItemTypeEnum));
        txtCode.DataBindings.Add(new Binding("EditValue", _item, "Code", true));
        txtDescription.DataBindings.Add(new Binding("EditValue", _item , "Description", true));
        PriceEdit.DataBindings.Add(new Binding("EditValue", _item, "Price", true));
        CostEdit.DataBindings.Add(new Binding("EditValue", _item, "Cost", true));
        comboItemType.DataBindings.Add(new Binding("SelectedValue", _item, "ItemType", true));
    }

    async Task SaveItem(ItemViewModel item)
    {
        if (item.Price <= 0 || item.Cost <= 0 || item.Description == null)
        {
            MessageBox.Show("Some of the inserted values are invalid.", Text, MessageBoxButtons.OKCancel);
            return;
        }

        var dr = MessageBox.Show("Save Item?", Text, MessageBoxButtons.OKCancel);
        if(dr == DialogResult.Cancel)
        {
            return;
        }
        if (!_isEditing)
        {
            await _itemHandler.CreateItem(item);
        }
        else
        {
            await _itemHandler.PutItem(item);
        }           
        this.Close();
    }
    
}
