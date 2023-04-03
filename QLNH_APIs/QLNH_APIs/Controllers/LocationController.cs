using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
            private readonly MyDBContext _context;
            private readonly IMapper _mapper;

            public LocationController(MyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> Get()
            {

                try
                {
                    var data = await _context.LocationDBSet.
                    Where(r => !r.Deleted)
                    .Include(r => r.Restaurant)
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser).ToArrayAsync();
                    var model = _mapper.Map<IEnumerable<LocationDTO>>(data);
                    return new JsonResult(model);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest("Not good");
                }

            }


            [HttpGet("{id}")]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult GetById(int id)
            {
                try
                {
                    //LINQ [Object] Query
                    var item = _context.LocationDBSet.ToList().SingleOrDefault(item => item.Id == id);
                    if (item == null)
                    {
                        return NotFound();
                    }
                    return Ok(item);
                }
                catch
                {
                    return BadRequest();
                }
            }

          
        [HttpPost]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Create(Location Location)
            {
                try
                {
                    var createdUser = _context.UserDBSet.Find(Location.CreatedUser.Id);
                    Location.CreatedUser = createdUser;

                    var updatedUser = _context.UserDBSet.Find(Location.UpdatedUser.Id);
                    Location.UpdatedUser = updatedUser;

                    var restaurant = _context.RestaurantDBSet.Find(Location.Restaurant.Id);
                    Location.Restaurant = restaurant;

                    Location.Created = DateTime.Now;
                    Location.Updated = DateTime.Now;

                    _context.LocationDBSet.Add(Location);

                    _context.SaveChanges();
                    return Ok(new
                    {
                        Success = true,
                        Data = Location
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }

            [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(Location Location)
            {
                try
                {
                    //LINQ [Object] Query
                    var location = _context.LocationDBSet.Find(Location.Id);


                    if (location == null)
                    {
                        return NotFound();
                    }

                    location.Name = Location.Name;
                    location.Description = Location.Description;
                    location.Created = Location.Created;
                    location.Updated = Location.Updated;
                    location.Deleted = Location.Deleted;
                    var updatedUser = _context.UserDBSet.Find((Location.UpdatedUser != null) ? Location.UpdatedUser.Id : 1);
                    location.UpdatedUser = updatedUser;

                    _context.SaveChanges();
                    return Ok(
                        new
                        {
                            Success = true,
                            Data = location
                        });
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
}
