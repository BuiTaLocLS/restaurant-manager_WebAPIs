using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using QLNH_APIs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
            private readonly MyDBContext _context;
            private readonly IMapper _mapper;

        public FoodController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> Get()
        {

            try
            {
                var data = await _context.FoodDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Restaurant)
                .Include(r => r.ItemImage)
                .Include(r => r.Category)
                .Include(r => r.CreatedUser)
                .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<FoodDTO>>(data);
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
                var item = _context.FoodDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Food Food)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Food.CreatedUser.Id);
                Food.CreatedUser = createdUser;

                var updatedUser = _context.UserDBSet.Find(Food.UpdatedUser.Id);
                Food.UpdatedUser = updatedUser;

                var restaurant = _context.RestaurantDBSet.Find(Food.Restaurant.Id);
                Food.Restaurant = restaurant;

                var category = _context.CategoryDBSet.Find(Food.Category.Id);
                Food.Category = category;

                var image = _context.ItemImageDBSet.Find(Food.ItemImage.Id);
                Food.ItemImage = image;


                Food.Created = DateTime.Now;
                Food.Updated = DateTime.Now;

                _context.FoodDBSet.Add(Food);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Food
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(Food Food)
        {
            try
            {
                //LINQ [Object] Query
                var food = _context.FoodDBSet.Find(Food.Id);


                if (food == null)
                {
                    return NotFound();
                }

                food.Name = Food.Name;
                food.Description = Food.Description;
                food.Created = Food.Created;
                food.Updated = Food.Updated;
                food.Deleted = Food.Deleted;

                var updatedUser = _context.UserDBSet.Find((Food.UpdatedUser != null) ? Food.UpdatedUser.Id : 1);
                food.UpdatedUser = updatedUser;

                var category = _context.CategoryDBSet.Find((Food.Category != null) ? Food.Category.Id : 1);
                food.Category = category;

                var image = _context.ItemImageDBSet.Find((Food.ItemImage != null) ? Food.ItemImage.Id : 1);
                food.ItemImage = image;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = food
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
 
}
