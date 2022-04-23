using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Shared.ViewModels;

public class TransactionViewModel
{
    public Guid ID { get; set; } = Guid.NewGuid();

    public Guid EmployeeID { get; set; }

    public Guid CustomerID { get; set; }
    public DateTime DateTime { get; set; }

    public PaymentMethodEnum PaymentMethod { get; set; }

    public List<TransactionLineViewModel> TransactionLines { get; set; } = new();

    public decimal TotalValue { get; set; }

    public bool Status { get; set; }
}
public class TransactionEditViewModel
{
    public Guid ID { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Employee { get; set; }
    public string Customer { get; set; }
    public string PaymentMethod { get; set; }
    public decimal TotalValue { get; set; }
    public List<TransactionLineViewModel> TransactionLines { get; set; } = new();
}
