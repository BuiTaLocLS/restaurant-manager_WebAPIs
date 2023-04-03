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
    public class GuestTableController : ControllerBase
    {

        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public GuestTableController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<GuestTableDTO>>> Get()
        {

            try
            {
                var data = await _context.GuestTableDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Guest)
                .Include(r => r.Location)
                .Include(r => r.Status)
                .Include(r => r.Restaurant)
                .Include(r => r.CreatedUser)
                .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<GuestTableDTO>>(data);
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
                var item = _context.GuestTableDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(GuestTable GuestTable)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(GuestTable.CreatedUser.Id);
                GuestTable.CreatedUser = createdUser;

                var updatedUser = _context.UserDBSet.Find(GuestTable.UpdatedUser.Id);
                GuestTable.UpdatedUser = updatedUser;

                var restaurant = _context.RestaurantDBSet.Find(GuestTable.Restaurant.Id);
                GuestTable.Restaurant = restaurant;

                var location = _context.LocationDBSet.Find(GuestTable.Location.Id);
                GuestTable.Location = location;

                var status = _context.StatusDBSet.Find(GuestTable.Status.Id);
                GuestTable.Status = status;

         
                GuestTable.Created = DateTime.Now;
                GuestTable.Updated = DateTime.Now;

                _context.GuestTableDBSet.Add(GuestTable);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = GuestTable
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(GuestTable GuestTable)
        {
            try
            {
                //LINQ [Object] Query
                var guestTable = _context.GuestTableDBSet.Find(GuestTable.Id);


                if (guestTable == null)
                {
                    return NotFound();
                }

                guestTable.Name = GuestTable.Name;
                guestTable.Description = GuestTable.Description;
                guestTable.Created = GuestTable.Created;
                guestTable.Updated = GuestTable.Updated;
                guestTable.Deleted = GuestTable.Deleted;

                var updatedUser = _context.UserDBSet.Find((GuestTable.UpdatedUser != null) ? GuestTable.UpdatedUser.Id : 1);
                guestTable.UpdatedUser = updatedUser;

                var location = _context.LocationDBSet.Find((GuestTable.Location != null) ? GuestTable.Location.Id : 1);
                guestTable.Location = location;

                var status = _context.StatusDBSet.Find((GuestTable.Status != null) ? GuestTable.Status.Id : 1);
                guestTable.Status = status;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = guestTable
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}
