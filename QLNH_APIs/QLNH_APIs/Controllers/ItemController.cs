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
    public class ItemController : ControllerBase
    {


        private readonly MyDBContext _context;
        private readonly IMapper _mapper;


        public ItemController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {

            try
            {
                var data = await _context.ItemDBSet.
                Where(r => !r.Deleted)
                 .Include(r => r.Restaurant)
                  .Include(r => r.UpdatedUser)
                   .Include(r => r.CreatedUser)
                .Include(r => r.Size)
                .Include(r => r.Food).ThenInclude(x => x.ItemImage)
                 .Include(r => r.Food).ThenInclude(x => x.Category)
                .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<ItemDTO>>(data);
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
                var item = _context.ItemDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Item Item)
        {
            try
            {

                Item.Created = DateTime.Now;
                Item.Updated = DateTime.Now;

                _context.ItemDBSet.Add(Item);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Item
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(Item Item)
        {
            try
            {
                //LINQ [Object] Query
                var item = _context.ItemDBSet.Find(Item.Id);


                if (item == null)
                {
                    return NotFound();
                }

                item.Description = Item.Description;
                item.Created = Item.Created;
                item.Updated = Item.Updated;
                item.Deleted = Item.Deleted;
                item.Price = Item.Price;
                item.Discount = Item.Discount;
                item.Quantity = Item.Quantity;

                var size = _context.SizeDBSet.Find((Item.Size != null) ? Item.Size.Id : 1);
                item.Size = size;

                var food = _context.FoodDBSet.Find((Item.Food != null) ? Item.Food.Id : 1);
                item.Food = food;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = item
                    });
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
