using Microsoft.AspNetCore.Mvc;
using Hotelsql.Models;
using Hotelsql.Repositories;
using Hotelsql.DTOs;

namespace Hotelsql.Controllers;

[ApiController]
[Route("api/staff")]
public class StaffController : ControllerBase
{
    private readonly ILogger<StaffController> _logger;

    private readonly IStaffRepository _staff;

    private readonly IRoomRepository _room;


    public StaffController(ILogger<StaffController> logger , IStaffRepository staff, IRoomRepository room)
    {
        _logger = logger;
        _staff = staff;
        _room = room;
    }

    [HttpGet]
    public async Task<ActionResult<List<StaffDTO>>> GetList()
    {
        var res = await _staff.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _staff.GetById(id);

        if (res is null)
            return NotFound();

            var dto = res.asDto;

            dto.Rooms = (await _room.GetListByStaffId(id)).asDto;

        return Ok(dto);
    }

     [HttpPost]
    public async Task<ActionResult> Create([FromBody] StaffCreatedto Data)
    {
         var toCreateStaff = new Staff
        {

            
            Name = Data.Name,
            DateOfBirth = Data.DateOfBirth,
            Gender = Data.Gender,
            Mobile = Data.Mobile,
            Shift = Data.Shift,

        };

        var res = await _staff.Create(toCreateStaff);

        return StatusCode(StatusCodes.Status201Created, res.asDto);

    }




    [HttpPut("{id}")]
     public async Task<ActionResult> UpdateUser([FromRoute] int id,
    [FromBody] StaffUpdatedto Data)
    {
        var existing = await _staff.GetById(id);
        if (existing is null)
            return NotFound("No user found with given schedule id");

        var toUpdateUser = existing with
        {
        
           Mobile = Data.Mobile,
           Shift = Data.Shift
            
        };

        var didUpdate = await _staff.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }
    

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var existing = await _staff.GetById(id);

        if (existing is null)
            return NotFound("No user found with given staff id");

        var didDelete = await _staff.Delete(id);

        return NoContent();

    }

}