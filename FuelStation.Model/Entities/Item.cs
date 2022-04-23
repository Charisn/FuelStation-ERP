using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

[Serializable]
public class Item : BaseEntity
{
    public string Code { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; } // den einai optimized to demical alla se megales posothtes isws to precision toy na fanei xrhsimo.

    public decimal? Cost { get; set; }

    public ItemTypeEnum ItemType { get; set; }

    public List<TransactionLine> TransactionLines { get; set; }
}
