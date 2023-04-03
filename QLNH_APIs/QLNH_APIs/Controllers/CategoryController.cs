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
    public class CategoryController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public CategoryController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {

            try
            {
                var data = await _context.CategoryDBSet.
                Where(r => !r.Deleted)
                .Include(r => r.Restaurant)
               .Include(r => r.CreatedUser)
               .Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<CategoryDTO>>(data);
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
                var item = _context.CategoryDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(Category Category)
        {
            try
            {
                var createdUser = _context.UserDBSet.Find(Category.CreatedUser.Id);
                Category.CreatedUser = createdUser;
                var updatedUser = _context.UserDBSet.Find(Category.UpdatedUser.Id);
                Category.UpdatedUser = updatedUser;
                var restaurant = _context.RestaurantDBSet.Find(Category.Restaurant.Id);
                Category.Restaurant = restaurant;

                _context.CategoryDBSet.Add(Category);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = Category
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(Category Category)
        {
            try
            {
                //LINQ [Object] Query
                var category = _context.CategoryDBSet.Find(Category.Id);


                if (category == null)
                {
                    return NotFound();
                }

                category.Name = Category.Name;
                category.Description = Category.Description;
                category.Created = Category.Created;
                category.Updated = Category.Updated;
                category.Deleted = Category.Deleted;
                var updatedUser = _context.UserDBSet.Find((Category.UpdatedUser != null) ? Category.UpdatedUser.Id : 1);
                category.UpdatedUser = updatedUser;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = category
                    });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
