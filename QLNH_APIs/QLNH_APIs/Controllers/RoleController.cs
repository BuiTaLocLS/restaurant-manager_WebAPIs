using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNH_APIs.Data;
using QLNH_APIs.Models;
using System;
using System.Linq;

namespace QLNH_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly MyDBContext _context;

        public RoleController(MyDBContext context)
        {
            _context = context;

        }


        /// <summary>
        /// Lấy User với Id
        /// </summary>
        /// <returns>User</returns>
        /// <param name="Id">Tham số là Id của User</param>
        [HttpGet]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult GetAll()
        {
            var listItem = _context.RoleDBSet.ToList();
            return Ok(listItem);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "StaffOnlyPolicy")]
        public IActionResult GetById(int id)
        {
            try
            {
                //LINQ [Object] Query
                var item = _context.RoleDBSet.ToList().SingleOrDefault(item => item.Id == id);
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
        [Authorize(Policy = "AdminOnlyPolicy")]
        public IActionResult Create(Role paramItem)
        {
            try
            {
                _context.RoleDBSet.Add(paramItem);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Data = paramItem
                });
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
