using Microsoft.AspNetCore.Mvc;
using Shipmanagement.API.Models;
using Shipmanagement.Service.Contract;
using Shipmanagement.ViewModels;

namespace Shipmanagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipController : ControllerBase
{
    private readonly IShipService _shipService;

    public ShipController(IShipService shipService)
    {
        _shipService = shipService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceReponseViewModel<List<ShipViewModel>>))]
    [Produces("application/json")]
    public IActionResult Get()
    {
        var data = _shipService.GetAll();

        return Ok(new ServiceReponseViewModel<List<ShipViewModel>>
        {
            IsSuccess = true,
            Data = data,
            Message = "Ships data fetched successfully."
        });
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceReponseViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public IActionResult Post([FromBody] AddEditShipViewModel model)
    {
        bool isSaved = _shipService.Insert(model);
        return Ok(new ServiceReponseViewModel
        {
            IsSuccess = isSaved,
            Message = isSaved ? "Ship added successfully." : "Failed to add new ship"
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceReponseViewModel<AddEditShipViewModel>))]
    [Produces("application/json")]
    public IActionResult GetById(Guid id)
    {
        var data = _shipService.GetById(id);

        return Ok(new ServiceReponseViewModel<AddEditShipViewModel>
        {
            IsSuccess = data != null,
            Message = data != null ? "Ship details received successfully" : "Failed to get ship details",
            Data = data
        });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceReponseViewModel))]
    [Produces("application/json")]
    public IActionResult Put(Guid id, [FromBody] AddEditShipViewModel model)
    {
        bool isSaved = _shipService.Update(id, model);
        return Ok(new ServiceReponseViewModel
        {
            IsSuccess = isSaved,
            Message = isSaved ? "Ship updated successfully." : "Failed to save ship details"
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [Produces("application/json")]
    public IActionResult Delete(Guid id)
    {
        bool isSaved = _shipService.Delete(id);
        return Ok(new ServiceReponseViewModel
        {
            IsSuccess = isSaved,
            Message = isSaved ? "Ship deleted successfully." : "Failed to delete ship details"
        });
    }
}
