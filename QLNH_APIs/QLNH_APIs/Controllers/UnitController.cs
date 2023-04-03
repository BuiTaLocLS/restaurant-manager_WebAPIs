using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using QLNH_APIs.Models;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {

        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public UnitController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<UnitDTO>>> Get()
        {

            try
            {
                var data = await _context.UnitDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Restaurant)
                .Include(r => r.CreatedUser)
                .Include(r => r.UpdatedUser)
                .ToArrayAsync();

                var model = _mapper.Map<IEnumerable<UnitDTO>>(data);

                //foreach(UnitDTO unit in model) 
                //{
                //    var sizes = await _context.SizeDBSet
                //        .AsNoTracking()
                //        .Where(s => s.Unit.Id == unit.Id)
                //        .ToArrayAsync();

                //    if (sizes != null && sizes.Count() > 0)
                //    {
                //        List<SizeDTO> listSize = new List<SizeDTO>();
                //        foreach (Models.Size size in sizes)
                //        {
                //            listSize.Add(_mapper.Map<SizeDTO>(size));
                //        }
                //        unit.Sizes = listSize;
                //    }
                //}

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
                var item = _context.UnitDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Unit Unit)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Unit.CreatedUser.Id);
                Unit.CreatedUser = createdUser;

                var updatedUser = _context.UserDBSet.Find(Unit.UpdatedUser.Id);
                Unit.UpdatedUser = updatedUser;

                var restaurant = _context.RestaurantDBSet.Find(Unit.Restaurant.Id);
                Unit.Restaurant = restaurant;

                Unit.Created = DateTime.Now;
                Unit.Updated = DateTime.Now;

                _context.UnitDBSet.Add(Unit);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Unit
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Edit(Unit Unit)
        {
            try
            {
                //LINQ [Object] Query
                var unit = _context.UnitDBSet.Find(Unit.Id);


                if (unit == null)
                {
                    return NotFound();
                }

                unit.Name = Unit.Name;
                unit.Description = Unit.Description;
                unit.Created = Unit.Created;
                unit.Updated = Unit.Updated;
                unit.Deleted = Unit.Deleted;
                var updatedUser = _context.UserDBSet.Find((Unit.UpdatedUser != null) ? Unit.UpdatedUser.Id : 1);
                unit.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = unit
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
