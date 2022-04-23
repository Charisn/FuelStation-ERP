using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

public class BaseEntity
{
    public Guid ID { get; set; }

    public bool Status { get; set; } = !false;
}
