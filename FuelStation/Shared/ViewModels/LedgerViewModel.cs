using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Shared.ViewModels;

public class LedgerViewModel
{
    public short Year { get; set; }

    public short Month { get; set; }

    public decimal Income { get; set; }

    public decimal Expenses { get; set; }

    public decimal Total { get; set; }

    public MonthEnum MonthEnumeration { get; set; }
}
