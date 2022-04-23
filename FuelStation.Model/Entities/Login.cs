using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

public class Login
{
    
    public string Password { get; set; }
    public string Username { get; set; }
    public Guid ID { get; set; } = Guid.NewGuid();

    public Guid Token { get; set; } = Guid.NewGuid();

    public EmployeeTypeEnum EmployeeType { get; set; }
}
