using Microsoft.AspNetCore.Mvc;
using Hotelsql.Models;
using Hotelsql.Repositories;
using Hotelsql.DTOs;

namespace Hotelsql.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly IRoomRepository _room;
    private readonly IStaffRepository _staff;

    public RoomController(ILogger<RoomController> logger, IRoomRepository _room,IStaffRepository staff)
    {
        _logger = logger;
        this._room = _room;
        _staff = staff;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomDTO>>> GetList()
    {
        var res = await _room.GetList();

        return Ok(res.Select(x => x.asDto));
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDTO>> GetById([FromRoute] int id)
    {
        var res = await _room.GetById(id);

        if (res is null)
            return NotFound();
            var dto = res.asDto;
        dto.Staff = (await _staff.GetListByRoomId(id))
                        .Select(x => x.asDto).ToList();

        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] RoomUpdatedto Data)
    {
        var existingGuest = await _room.GetById(id);

        if (existingGuest == null)
            return NotFound();

        var toUpdateGuest = existingGuest with
        {
            Price = Data.price,
        };

        var didUpdate = await _room.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}