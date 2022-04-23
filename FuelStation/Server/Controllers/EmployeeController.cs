using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEntityRepo<Employee> _employeeRepo;

    public EmployeeController(IEntityRepo<Employee> employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeViewModel>> GetTrue()
    {
        try
        {
            var result = await _employeeRepo.GetAllAsync();

            return result.FindAll(x => x.Status == true).Select(x => new EmployeeViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                SalaryPerMonth = x.SalaryPerMonth,
                EmployeeType = x.EmployeeType
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<EmployeeViewModel>();
        }
        
    }

    [HttpGet("statusfalse")]
    public async Task<IEnumerable<EmployeeViewModel>> GetFalse()
    {
        try
        {
            var result = await _employeeRepo.GetAllAsync();

            return result.FindAll(x => x.Status == false).Select(x => new EmployeeViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                SalaryPerMonth = x.SalaryPerMonth,
                EmployeeType = x.EmployeeType
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<EmployeeViewModel>();
        }
    }

    [HttpPost]

    public async Task Post(EmployeeViewModel employee)
    {
        if (employee == null) return;
        Employee newEmployee = new Employee
        {
            Name = employee.Name,
            Surname = employee.Surname,
            StartDate = DateTime.Now,
            SalaryPerMonth = employee.SalaryPerMonth,
            EmployeeType = employee.EmployeeType
        };

        await _employeeRepo.CreateAsync(newEmployee);
    }

    [HttpDelete("{ID}")]
    public async Task Delete(Guid id)
    {
        if(id == Guid.Empty) return;
        var _employee = await _employeeRepo.GetByIdAsync(id);
        _employee.Status = !_employee.Status;
        _employee.EndDate = DateTime.Now;
        await _employeeRepo.UpdateAsync(id , _employee);
    }
    [HttpDelete("{ID}/undo/")]
    public async Task UndoDelete(Guid id)
    {
        if (id == Guid.Empty) return; 
        var _employee = await _employeeRepo.GetByIdAsync(id);
        _employee.Status = !_employee.Status;
        _employee.EndDate = null;
        await _employeeRepo.UpdateAsync(id, _employee);
    }


    [HttpPut]
    public async Task<ActionResult> Put(EmployeeViewModel employee)
    {
        if (employee == null) return NotFound();
        var employeeToUpdate = await _employeeRepo.GetByIdAsync(employee.ID);
        if (employeeToUpdate is null) return NotFound();


        employeeToUpdate.Name = employee.Name;
        employeeToUpdate.Surname = employee.Surname;
        employeeToUpdate.SalaryPerMonth = employee.SalaryPerMonth;
        employeeToUpdate.EmployeeType = employee.EmployeeType;

        await _employeeRepo.UpdateAsync(employee.ID, employeeToUpdate);

        return Ok();
    }
}
