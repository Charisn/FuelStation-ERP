using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

[Serializable]
public class Customer : Person
{
    public string CardNumber { get; set; }
}
