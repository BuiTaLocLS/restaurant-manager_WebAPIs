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
    public class OrderController : ControllerBase
    {
        

            private readonly MyDBContext _context;
            private readonly IMapper _mapper;

            public OrderController(MyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Get(int restaurantID)
            {

                try
                {
                    var data = await _context.OrderDBSet
                    .Where(r => r.Restaurant.Id == restaurantID)
                    .Include(r => r.Restaurant).ToArrayAsync();
                    var model = _mapper.Map<IEnumerable<OrderDTO>>(data);
                    return new JsonResult(model);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest("Not good");
                }

            }


            [HttpGet("{id}")]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult GetById(int restaurantID, int id)
            {
                try
                {
                    //LINQ [Object] Query
                    var item = _context.OrderDBSet
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
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Create(Order Order)
            {
                try
                {
                    var restaurant = _context.RestaurantDBSet.Find(Order.Restaurant.Id);
                    Order.Restaurant = restaurant;

                    Order.Created = DateTime.Now;
                    Order.Updated = DateTime.Now;

                    _context.OrderDBSet.Add(Order);

                    _context.SaveChanges();

                    int id = Order.Id;
                    return Ok(new
                    {
                        Success = true,
                        Data = Order
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }

            [HttpPut]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Edit(Order Order)
            {
                try
                {
                    //LINQ [Object] Query
                    var order = _context.OrderDBSet.Find(Order.Id);


                    if (order == null)
                    {
                        return NotFound();
                    }

                    order.Description = Order.Description;
                    order.Created = Order.Created;
                    order.Updated = Order.Updated;
                    order.Deleted = Order.Deleted;
             

                    _context.SaveChanges();
                    return Ok(
                        new
                        {
                            Success = true,
                            Data = order
                        });
                }
                catch
                {
                    return BadRequest();
                }
            }

        }
}
