using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.ViewModels;
using IronBarCode;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IEntityRepo<Customer> _customerRepo;

    public CustomerController(IEntityRepo<Customer> customerRepo)
    {
        _customerRepo = customerRepo;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CustomerViewModel>> GetTrue()
    {
        try
        {
            var result = await _customerRepo.GetAllAsync();

            return result.FindAll(x => x.Status == true).Select(x => new CustomerViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<CustomerViewModel>();
        }
    }
    [HttpGet("{id}")]
    public async Task<CustomerViewModel> GetByID(Guid ID)
    {
        CustomerViewModel customer = new();
        if (ID != Guid.Empty)
        {
            var foundCustomer = await _customerRepo.GetByIdAsync(ID);
            customer.ID = foundCustomer.ID;
            customer.Name = foundCustomer.Name;
            customer.Surname = foundCustomer.Surname;
            customer.CardNumber = foundCustomer.CardNumber;
        }
        return customer;
    }

    [HttpGet("statusfalse")]
    public async Task<IEnumerable<CustomerViewModel>> GetFalse()
    {
        try
        {
            var result = await _customerRepo.GetAllAsync();

            return result.FindAll(x => x.Status == false).Select(x => new CustomerViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<CustomerViewModel>();
        }
    }

    [HttpPost]

    public async Task Post(CustomerViewModel customer)
    {
        if (customer == null) return;
        Customer newCustomer = new()
        {
            Name = customer.Name,
            Surname = customer.Surname,
            CardNumber = customer.CardNumber
        };

        await _customerRepo.CreateAsync(newCustomer);

        GeneratedBarcode barcode = BarcodeWriter.CreateBarcode((newCustomer.CardNumber + " " + newCustomer.Name + " " + newCustomer.Surname), BarcodeEncoding.QRCode);
        barcode.SaveAsPng($"CustomerQrCodes/{newCustomer.CardNumber}.png");
    }

    [HttpDelete("{ID}")]
    public async Task Delete(Guid id)
    {
        if(id == Guid.Empty) return;
        var _customer = await _customerRepo.GetByIdAsync(id);
        if(_customer == null) return;
        _customer.Status = !_customer.Status;
        await _customerRepo.UpdateAsync(id, _customer);
    }


    [HttpPut]
    public async Task<ActionResult> Put(CustomerViewModel newCustomerView)
    {
        if(newCustomerView == null) return BadRequest();
        var customerToUpdate = await _customerRepo.GetByIdAsync(newCustomerView.ID);
        if (customerToUpdate is null) return NotFound();

        customerToUpdate.Name = newCustomerView.Name;
        customerToUpdate.Surname = newCustomerView.Surname;

        await _customerRepo.UpdateAsync(newCustomerView.ID, customerToUpdate);

        return Ok();
    }

    [HttpGet("qrImages/{filename}")]
    public async Task<IActionResult> Get(string filename)
    {
        var contentType = "image/png";

        var filePath = Path.Combine(Path.GetPathRoot(string.Empty) , contentType, $"{filename}");
        

        return PhysicalFile(filePath, contentType);
    }
}
