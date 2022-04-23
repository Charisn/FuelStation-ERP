using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Shared.ViewModels;

public class CustomerViewModel
{
    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string CardNumber { get; set; }

    public bool Status { get; set; }

    public CustomerViewModel()
    {
        CardNumber = DateTime.Now.ToString("A-ddMMyy") + Guid.NewGuid().GetHashCode().ToString().Replace("-", "");
    }
}
