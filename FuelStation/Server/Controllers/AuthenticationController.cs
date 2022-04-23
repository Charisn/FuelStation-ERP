using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly LoginRepo _loginRepo;

    public AuthenticationController(LoginRepo loginrepo)
    {
        _loginRepo = loginrepo;
    }

    [HttpPost]
    public async Task<AuthenticationModel> Post(AuthenticationModel auth)
    {
        var logins = await _loginRepo.GetAllAsync();
        if (logins.Count == 0)
        {
            Login firstLogin = new()
            {
                Username = auth.Username,
                Password = auth.Password,
                EmployeeType = Model.Enums.EmployeeTypeEnum.Manager,
                ID = auth.ID,
                Token = auth.Token
            };

            await _loginRepo.CreateNew(firstLogin);
        }
        var response = await _loginRepo.ValidateEmployee( auth.Username, auth.Password);
        //An einai swsto 8a tou epistrefw olo to object Login.
        if(response != null)
        {
            auth.EmployeeType = response.EmployeeType;
            auth.ID = response.ID;
            return auth;
        };
        return new AuthenticationModel();
    }
    [HttpPost("checkifmanager")]
    public async Task<bool> CheckIfManager(AuthenticationModel auth)
    {
        if (auth == null) return false;
        if(auth.EmployeeType == Model.Enums.EmployeeTypeEnum.Manager) return true;
        return false;
    }

    [HttpPost("createnewmanager")]
    public async Task CreateNewManager(AuthenticationModel auth)
    {
        if (auth == null) return;
        Login newLogin = new()
        {
            Username = auth.Username,
            Password = auth.Password,
            EmployeeType = Model.Enums.EmployeeTypeEnum.Manager
        };

        await _loginRepo.CreateNew(newLogin);
    }

    [HttpPost("createnewstaff")]
    public async Task CreateNewStaff(AuthenticationModel auth)
    {
        if (auth == null) return;
        Login newLogin = new()
        {
            Username = auth.Username,
            Password = auth.Password,
            EmployeeType = Model.Enums.EmployeeTypeEnum.Staff
        };

        await _loginRepo.CreateNew(newLogin);
    }
    [HttpPost("createnewcashier")]
    public async Task CreateNewCashier(AuthenticationModel auth)
    {
        if (auth == null) return;
        Login newLogin = new()
        {
            Username = auth.Username,
            Password = auth.Password,
            EmployeeType = Model.Enums.EmployeeTypeEnum.Cashier
        };

        await _loginRepo.CreateNew(newLogin);
    }
}
