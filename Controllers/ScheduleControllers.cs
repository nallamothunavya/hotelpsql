using Microsoft.AspNetCore.Mvc;
using Hotelsql.Models;
using Hotelsql.Repositories;
using Hotelsql.DTOs;

namespace Hotelsql.Controllers;

[ApiController]
[Route("api/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;

    private readonly IScheduleRepository _schedule;

    private readonly IGuestRepository _guest;

    private readonly IRoomRepository _room;
    public ScheduleController(ILogger<ScheduleController> logger , IScheduleRepository schedule , IGuestRepository guest, IRoomRepository room)
    {
        _logger = logger;

        _schedule = schedule;

        _guest = guest;

        _room = room;
    }   

    [HttpGet]
    public async Task<ActionResult<List<ScheduleDTO>>> GetList()
    {
        var res = await _schedule.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _schedule.GetById(id);

        if (res is null)
            return NotFound();

        var dto = res.asDto;
        dto.Guests = (await _guest.GetListByScheduleId(id)).asDto;
                        
        dto.Rooms = (await _room.GetScheduleRoomId(id)).asDto;

        return Ok(dto);
    }


    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ScheduleCreatedto Data)
    {
         var toCreateSchedule = new Schedule
        {

            
            CheckIn = Data.CheckIn,
            CheckOut = Data.CheckOut,
            GuestCount = Data.GuestCount,
            Price = Data.Price,
            CreatedAt=Data.CreatedAt,
            GuestId = Data.GuestId,
            RoomId = Data.RoomId,

        };

        var res = await _schedule.Create(toCreateSchedule);

        return StatusCode(StatusCodes.Status201Created, res.asDto);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] int id,
    [FromBody] ScheduleUpdatedto Data)
    {
        var existing = await _schedule.GetById(id);
        if (existing is null)
            return NotFound("No user found with given schedule id");

        var toUpdateUser = existing with
        {
            CheckIn = Data.CheckIn.UtcDateTime,
            CheckOut = Data.CheckOut.UtcDateTime,
            GuestCount = Data.GuestCount
            
        };

        var didUpdate = await _schedule.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var existing = await _schedule.GetById(id);

        if (existing is null)
            return NotFound("No user found with given schedule id");

        var didDelete = await _schedule.Delete(id);

        return NoContent();

    }
}