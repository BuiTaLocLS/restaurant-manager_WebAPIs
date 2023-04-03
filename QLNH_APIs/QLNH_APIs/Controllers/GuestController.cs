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

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public GuestController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDTO>>> Get()
        {

            try
            {
                var data = await _context.GuestDBSet.
                Where(r => !r.Deleted)
               .Include(r => r.CreatedUser)
               .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<GuestDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Not good");
            }

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //LINQ [Object] Query
                var item = _context.GuestDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Guest Guest)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Guest.CreatedUser.Id);
                Guest.CreatedUser = createdUser;
                var updatedUser = _context.UserDBSet.Find(Guest.UpdatedUser.Id);
                Guest.UpdatedUser = updatedUser;


                _context.GuestDBSet.Add(Guest);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Guest
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Edit(Guest Guest)
        {
            try
            {
                //LINQ [Object] Query
                var guest = _context.GuestDBSet.Find(Guest.Id);


                if (guest == null)
                {
                    return NotFound();
                }

                guest.Name = Guest.Name;
                guest.Description = Guest.Description;
                guest.Phone = Guest.Phone;
                guest.Created = Guest.Created;
                guest.Updated = Guest.Updated;
                guest.Deleted = Guest.Deleted;
                var updatedUser = _context.UserDBSet.Find((Guest.UpdatedUser != null) ? Guest.UpdatedUser.Id : 1);
                guest.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = guest
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
