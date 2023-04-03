using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public StatusController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> Get()
        {

            try
            {
                var data = await _context.StatusDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Restaurant)
               .Include(r => r.CreatedUser)
               .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<StatusDTO>>(data);
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
                var item = _context.StatusDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Status Status)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Status.CreatedUser.Id);
                Status.CreatedUser = createdUser;

                var updatedUser = _context.UserDBSet.Find(Status.UpdatedUser.Id);
                Status.UpdatedUser = updatedUser;

                var restaurant = _context.RestaurantDBSet.Find(Status.Restaurant.Id);
                Status.Restaurant = restaurant;

                _context.StatusDBSet.Add(Status);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Status
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(Status Status)
        {
            try
            {
                //LINQ [Object] Query
                var status = _context.StatusDBSet.Find(Status.Id);


                if (status == null)
                {
                    return NotFound();
                }

                status.Name = Status.Name;
                status.Description = Status.Description;
                status.Created = Status.Created;
                status.Updated = Status.Updated;
                status.Deleted = Status.Deleted;
                var updatedUser = _context.UserDBSet.Find((Status.UpdatedUser != null) ? Status.UpdatedUser.Id : 1);
                status.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = status
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
