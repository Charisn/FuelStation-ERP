using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Shared.ViewModels;

public class TransactionLineViewModel
{
    public Guid ItemID { get; set; }

    public int Quantity { get; set; }

    public decimal ItemPrice { get; set; }

    public decimal NetValue { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountValue { get; set; }

    public decimal TotalValue { get; set; }

    public bool Status { get; set; }

    public ItemTypeEnum ItemType { get; set; }

    public Guid ID { get; set; } = Guid.NewGuid();
}
public class TransactionLineEditViewModel
{
    public Guid ID { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public Guid EmployeeID { get; set; }
    public Guid CustomerID { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; }
    public decimal TotalValue { get; set; }

}
