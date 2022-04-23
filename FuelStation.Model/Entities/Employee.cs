using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model.Entities;

public class Employee : Person
{
    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; } = null;

    public decimal? SalaryPerMonth { get; set; } 

    public EmployeeTypeEnum EmployeeType { get; set; }

    public Login? LoginCredentials { get; set; }
}
