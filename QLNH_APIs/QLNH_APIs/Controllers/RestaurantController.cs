using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RestaurantController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var listItem = _context.RestaurantDBSet
                .Where(r => !r.Deleted)
                .Include(r => r.CreatedUser)
                .Include(r => r.UpdatedUser)
                .ToList();
            return Ok(listItem);
        } */

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> Get()
        {

            try
            {
                var data = await _context.RestaurantDBSet.
                Where(r=>!r.Deleted)
               .Include(r => r.CreatedUser)
               .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<RestaurantDTO>>(data);
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
                var item = _context.RestaurantDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        [Authorize(Policy = "AdminOnlyPolicy")]
        public IActionResult Create(Restaurant Restaurant)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Restaurant.CreatedUser.Id);
                Restaurant.CreatedUser = createdUser;
                var updatedUser = _context.UserDBSet.Find(Restaurant.UpdatedUser.Id);
                Restaurant.UpdatedUser = updatedUser;


                _context.RestaurantDBSet.Add(Restaurant);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Restaurant
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "AdminOnlyPolicy")]
        public IActionResult Edit(Restaurant Restaurant)
        {
            try
            {
                //LINQ [Object] Query
                var restaurant = _context.RestaurantDBSet.Find(Restaurant.Id);


                if (restaurant == null)
                {
                    return NotFound();
                }

                restaurant.Name = Restaurant.Name;
                restaurant.Description = Restaurant.Description;
                restaurant.Phone = Restaurant.Phone;
                restaurant.Address = Restaurant.Address;
                restaurant.Created = Restaurant.Created;
                restaurant.Updated = Restaurant.Updated;
                restaurant.Deleted = Restaurant.Deleted;
                var updatedUser = _context.UserDBSet.Find((Restaurant.UpdatedUser != null) ? Restaurant.UpdatedUser.Id : 1);
                restaurant.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = restaurant
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
