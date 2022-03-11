using items.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace items.Controllers;

[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemDbContext _itemDbContext;
    
    public ItemsController(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    [HttpGet, Route("Items/AllItems")]
    public IEnumerable<Item> AllItems()
    {
        return _itemDbContext.Items.ToList();
    }

    [HttpGet, Route("Items/AddItem")]
    public Item AddItem([FromQuery] string description)
    {
        var newItem = new Item
        {
            Id = Guid.NewGuid(),
            Description = description
        };
        _itemDbContext.Items.Add(newItem);
        _itemDbContext.SaveChanges();
        return newItem;
    }
}
