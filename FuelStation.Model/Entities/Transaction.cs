using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

public class Transaction : BaseEntity
{
    public DateTime DateTime { get; set; } = DateTime.Now;

    public Guid EmployeeID { get; set; }

    public Guid CustomerID { get; set; }

    public decimal TotalValue { get; set; }

    public PaymentMethodEnum PaymentMethod { get; set; }

    public List<TransactionLine> TransactionLines { get; set; }

    //NavigationProperties
    public Employee? Employee { get; set; } 

    public Customer? Customer { get; set; }
}
