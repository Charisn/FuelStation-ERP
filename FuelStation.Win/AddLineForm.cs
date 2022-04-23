using FuelStation.Model.Enums;
using FuelStation.Shared.ViewModels;
using FuelStation.Win.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win;

public partial class AddLineForm : Form
{
    private TransactionLineViewModel _transactionLine = new();
    private List<ItemViewModel> _itemList = new();
    private ItemViewModel _item = new();
    private TransactionHandler _transactionHandler = new();
    private ItemHandler _itemHandler = new();
    private Guid _transactionLineID = Guid.Empty;
    private bool _isEdit = true;
    private BindingSource bsTlines = new();

    public AddLineForm(BindingSource lines)
    {
        InitializeComponent();
        bsTlines = lines;
    }
    public AddLineForm(BindingSource lines, Guid ID)
    {
        InitializeComponent();
        _transactionLineID = ID;
    }

    private async void AddLineForm_Load(object sender, EventArgs e)
    {
        _itemList = await _itemHandler.GetItems();

        if (((List<TransactionLineViewModel>)bsTlines.DataSource).Any(x => x.ItemType == ItemTypeEnum.Fuel))
        {
            _itemList = _itemList.Where(x => x.ItemType != ItemTypeEnum.Fuel).ToList();
        }

        bsLine.DataSource = _transactionLine;
        SetDataBindings();
    }

    private void SetDataBindings()
    {
        comboItem.DataBindings.Add(new Binding("SelectedValue", bsLine, "ItemID", true));
        spinQty.DataBindings.Add(new Binding("Value", bsLine, "Quantity", true));
        spinPrice.DataBindings.Add(new Binding("Value", bsLine, "ItemPrice", true));
        spinTotal.DataBindings.Add(new Binding("Value", bsLine, "TotalValue", true));
        comboItem.DataSource = _itemList;
        comboItem.SelectedIndex = -1;
        comboItem.ValueMember = "ID";
        comboItem.DisplayMember = "Description";
        spinQty.Value = 1;
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        var selectedItem = _itemList.Find(item => item.ID.Equals(comboItem.SelectedValue));

        UpdateLine();
        if (spinPrice.Value <= 0 || comboItem.SelectedIndex == -1)
        {
            MessageBox.Show("Some values are not correct.", "Error", MessageBoxButtons.OKCancel);
            return;
        }
        else
        {
            bsTlines.Add(_transactionLine);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
    private void UpdateLine()
    {
        _transactionLine.ItemPrice = (decimal)_item.Price;
        _transactionLine.ItemType = _item.ItemType;
        _transactionLine.NetValue = _transactionHandler.CalculateNetValue((decimal)spinQty.Value, (decimal)_item.Price);
        _transactionLine.DiscountValue = _transactionHandler.ApplyTenPercentDiscount(_transactionLine.NetValue, 0.10M, _item.ItemType);
        _transactionLine.TotalValue = _transactionHandler.CalculateLineTotalValue(_transactionLine.DiscountValue, _transactionLine.NetValue);

        if (_item.ItemType == ItemTypeEnum.Fuel && spinPrice.Value > 20)
        {
            _transactionLine.DiscountPercentage = 0.1M;
        }        
    }

    private void spinQty_EditValueChanged(object sender, EventArgs e)
    {
        if (comboItem.SelectedValue is null)
        {
            return;
        }
        if (spinQty.Value < 0)
        {
            spinQty.Value = 1;
        }
        if (_item.Price is not null)
        {
            spinPrice.Value = (decimal)_item.Price;
            spinTotal.Value = (decimal)_item.Price * spinQty.Value;
            UpdateLine();
        }
    }

    private async void comboItem_DropDownClosed(object sender, EventArgs e)
    {
        if (comboItem.SelectedValue is null || spinQty.Value <= 0)
        {
            return;
        }
        else
        {
            var selectedItemID = (Guid)comboItem.SelectedValue;
            _item = await _itemHandler.GetItemByID($"{selectedItemID}");
            spinPrice.Value = (decimal)_item.Price;
            spinTotal.Value = (decimal)_transactionLine.TotalValue;
            UpdateLine();
        }

    }
}