using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.DTO;
using QLNH_APIs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImageController : ControllerBase
    {
        
            private readonly MyDBContext _context;
            private readonly IMapper _mapper;

            public ItemImageController(MyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<ItemImageDTO>>> Get(int restaurantID)
            {

                try
                {
                    var data = await _context.ItemImageDBSet
                    .Where(r => r.Restaurant.Id == restaurantID)
                    .Include(r => r.Restaurant)
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser).ToArrayAsync();
                    var model = _mapper.Map<IEnumerable<ItemImageDTO>>(data);
                    return new JsonResult(model);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest("Not good");
                }

            }


            [HttpGet("{id}")]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult GetById(int restaurantID,int id)
            {
                try
                {
                    //LINQ [Object] Query
                    var item = _context.ItemImageDBSet
                          .Where(r => r.Restaurant.Id == restaurantID)
                    .ToList().SingleOrDefault(item => item.Id == id);
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
        public IActionResult Create(ItemImage ItemImage)
            {
                try
                {
                    var createdUser = _context.UserDBSet.Find(ItemImage.CreatedUser.Id);
                    ItemImage.CreatedUser = createdUser;

                    var updatedUser = _context.UserDBSet.Find(ItemImage.UpdatedUser.Id);
                    ItemImage.UpdatedUser = updatedUser;

                    var restaurant = _context.RestaurantDBSet.Find(ItemImage.Restaurant.Id);
                    ItemImage.Restaurant = restaurant;

                    ItemImage.Created = DateTime.Now;
                    ItemImage.Updated = DateTime.Now;

                    _context.ItemImageDBSet.Add(ItemImage);

                    _context.SaveChanges();
                    return Ok(new
                    {
                        Success = true,
                        Data = ItemImage
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }

            [HttpPut]
        [Authorize(Policy = "ManageOnlyPolicy")]
        public IActionResult Edit(ItemImage ItemImage)
            {
                try
                {
                    //LINQ [Object] Query
                    var itemImage = _context.ItemImageDBSet.Find(ItemImage.Id);


                    if (itemImage == null)
                    {
                        return NotFound();
                    }

                    itemImage.Name = ItemImage.Name;
                    itemImage.Description = ItemImage.Description;
                    itemImage.Created = ItemImage.Created;
                    itemImage.Updated = ItemImage.Updated;
                    itemImage.Deleted = ItemImage.Deleted;
                    var updatedUser = _context.UserDBSet.Find((ItemImage.UpdatedUser != null) ? ItemImage.UpdatedUser.Id : 1);
                    itemImage.UpdatedUser = updatedUser;

                    _context.SaveChanges();
                    return Ok(
                        new
                        {
                            Success = true,
                            Data = itemImage
                        });
                }
                catch
                {
                    return BadRequest();
                }
            }
        
    }
}
