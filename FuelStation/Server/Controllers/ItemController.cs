using FuelStation.EF.Repositories;
using FuelStation.Model.Entities;
using FuelStation.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IEntityRepo<Item> _itemRepo;

    public ItemController(IEntityRepo<Item> itemRepo)
    {
        _itemRepo = itemRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<ItemViewModel>> GetTrue()
    {
        try
        {
            var result = await _itemRepo.GetAllAsync();

            return result.FindAll(x => x.Status == true).Select(x => new ItemViewModel
            {
                ID = x.ID,
                Code = x.Code,
                Description = x.Description,
                Price = x.Price,
                Cost = x.Cost,
                ItemType = x.ItemType
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<ItemViewModel>();
        }

    }

    [HttpGet("statusfalse")]
    public async Task<IEnumerable<ItemViewModel>> GetFalse()
    {
        try
        {
            var result = await _itemRepo.GetAllAsync();

            return result.FindAll(x => x.Status == false).Select(x => new ItemViewModel
            {
                ID = x.ID,
                Code = x.Code,
                Description = x.Description,
                Price = x.Price,
                Cost = x.Cost,
                ItemType = x.ItemType
            });
        }
        catch (Exception)
        {
            return Enumerable.Empty<ItemViewModel>();
        }
    }

    [HttpGet("{id}")]
    public async Task<ItemViewModel> GetItemByID(Guid id)
    {
        ItemViewModel item = new();
        if (id != Guid.Empty)
        {
            var foundItem = await _itemRepo.GetByIdAsync(id);
            if (foundItem != null)
            {
                item.ID = foundItem.ID;
                item.Code = foundItem.Code;
                item.Description = foundItem.Description;
                item.Cost = foundItem.Cost;
                item.Price = foundItem.Price;
                item.ItemType = foundItem.ItemType;
                item.Status = foundItem.Status;
            }
        }
        return item;
    }

    [HttpPost]

    public async Task Post(ItemViewModel item)
    {
        if (item is null) return;
        Item newItem = new Item
        {
            Code = item.Code,
            Description = item.Description,
            Price = item.Price,
            Cost = item.Cost,
            ItemType = item.ItemType
        };

        var itemsCheck = await _itemRepo.GetAllAsync();

        foreach (var itemCheckItem in itemsCheck)
        {
            if (itemCheckItem.Code == newItem.Code && itemCheckItem.ID != item.ID)
            {
                return;
            };
        }

        await _itemRepo.CreateAsync(newItem);

    }

    [HttpDelete("{ID}")]
    public async Task Delete(Guid id)
    {
        if (id == Guid.Empty) return;
        var _item = await _itemRepo.GetByIdAsync(id);
        _item.Status = !_item.Status;
        await _itemRepo.UpdateAsync(id, _item);
    }


    [HttpPut]
    public async Task<ActionResult> Put(ItemViewModel item)
    {
        if (item is null) return NotFound();
        var itemToUpdate = await _itemRepo.GetByIdAsync(item.ID);
        if (itemToUpdate.Price <= 0 || itemToUpdate.Price == null || itemToUpdate.Cost <= 0 || itemToUpdate.Cost == null)
        {
            return BadRequest();
        }

        itemToUpdate.Code = item.Code;
        itemToUpdate.Description = item.Description;
        itemToUpdate.Price = item.Price;
        itemToUpdate.Cost = item.Cost;
        itemToUpdate.ItemType = item.ItemType;

        var itemsCheck = await _itemRepo.GetAllAsync();

        foreach (var itemCheckItem in itemsCheck)
        {
            if (itemCheckItem.Code == item.Code && itemCheckItem.ID != item.ID)
            {
                return BadRequest();
            };
        }

        await _itemRepo.UpdateAsync(item.ID, itemToUpdate);
        return Ok();
    }
}