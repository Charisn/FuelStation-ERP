using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication;

public class Credentials
{
    public string Username { get; set; }

    public string Password { get; set; }

    internal async Task<int> AuthToken(string username, string password)
    {
        if (username == "Manager" && password == "Manager"){ return 1; }
        if (username == "Staff" && password == "Staff") { return 2; }
        if (username == "Cashier" && password == "Cashier") { return 3; }
        return 0;
    }
}
