using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

internal class MonthlyLedger
{
    public short Year { get; set; }
    public short Month { get; set; }
    public decimal Income { get; set; }
    public decimal Expenses { get; set; }
}
