using Microsoft.AspNetCore.Mvc;

namespace items.Controllers;

public class Item
{
    public string Id { get; set; } = null!;
    public string Description { get; set; }= null!;
}

[ApiController]
public class ItemsController : ControllerBase
{
    [HttpGet, Route("Items/AllItems")]
    public IEnumerable<Item> Get()
    {
        return new[]
        {
            new Item
            {
                Id = "123",
                Description = "An item"
            }
        };
    }
}
