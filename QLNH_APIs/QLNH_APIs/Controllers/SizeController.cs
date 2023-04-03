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
    public class SizeController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public SizeController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<SizeDTO>>> Get()
        {

            try
            {
                var data = await _context.SizeDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Restaurant)
                .Include(r => r.Unit)
                .Include(r => r.CreatedUser)
                .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<SizeDTO>>(data);
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
                var item = _context.SizeDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Create(Size Size)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Size.CreatedUser.Id);
                Size.CreatedUser = createdUser;

                var updatedUser = _context.UserDBSet.Find(Size.UpdatedUser.Id);
                Size.UpdatedUser = updatedUser;

                var restaurant = _context.RestaurantDBSet.Find(Size.Restaurant.Id);
                Size.Restaurant = restaurant;

                var unit = _context.UnitDBSet.Find(Size.Unit.Id);
                Size.Unit = unit;

                Size.Created = DateTime.Now;
                Size.Updated = DateTime.Now;

                _context.SizeDBSet.Add(Size);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Size
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Edit(Size Size)
        {
            try
            {
                //LINQ [Object] Query
                var size = _context.SizeDBSet.Find(Size.Id);


                if (size == null)
                {
                    return NotFound();
                }

                var unit = _context.UnitDBSet.Find(Size.Unit.Id);
                size.Unit = unit;

                size.Name = Size.Name;
                size.Description = Size.Description;
                size.Created = Size.Created;
                size.Updated = Size.Updated;
                size.Deleted = Size.Deleted;
                var updatedUser = _context.UserDBSet.Find((Size.UpdatedUser != null) ? Size.UpdatedUser.Id : 1);
                size.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = size
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
