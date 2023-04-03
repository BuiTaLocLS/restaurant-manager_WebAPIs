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
using Microsoft.AspNetCore.Authorization;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public OrderItemController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> Get()
        {

            try
            {
                var data = await _context.OrderItemDBSet.
                Where(r => !r.Deleted)
                .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<OrderItemDTO>>(data);
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
                var orderItem = _context.OrderItemDBSet.ToList().SingleOrDefault(orderItem => orderItem.Id == id);
                if (orderItem == null)
                {
                    return NotFound();
                }
                return Ok(orderItem);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Create(OrderItem OrderItem)
        {
            try
            {

                var restaurant = _context.RestaurantDBSet.Find(OrderItem.Restaurant.Id);
                OrderItem.Restaurant = restaurant;

                var item = _context.ItemDBSet.Find(OrderItem.Item.Id);
                OrderItem.Item = item;

                var order = _context.OrderDBSet.Find(OrderItem.Order.Id);
                OrderItem.Order = order;

                OrderItem.Created = DateTime.Now;
                OrderItem.Updated = DateTime.Now;



                _context.OrderItemDBSet.Add(OrderItem);

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = OrderItem
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult Edit(OrderItem OrderItem)
        {
            try
            {
                //LINQ [Object] Query
                var orderItem = _context.OrderItemDBSet.Find(OrderItem.Id);


                if (orderItem == null)
                {
                    return NotFound();
                }

                orderItem.Description = OrderItem.Description;
                orderItem.Created = OrderItem.Created;
                orderItem.Updated = OrderItem.Updated;
                orderItem.Deleted = OrderItem.Deleted;

                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Success = true,
                        Data = orderItem
                    });
            }
            catch
            {
                return BadRequest();
            }
        }

    }

}
