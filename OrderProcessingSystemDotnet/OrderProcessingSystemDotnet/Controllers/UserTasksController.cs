using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Interfaces;
using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        //private readonly TaskManagerDbContext _context;
        private readonly IUserTaskService _userTaskService;

        //public UserTasksController(TaskManagerDbContext context)
        //{
        //    _context = context;
        //}
        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        // GET: api/Products
        [HttpGet("get-all-task")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTasks()
        {
            var response = await _userTaskService.GetTasks();
            return StatusCode(response.StatusCode, response);
            //if (_context.UserTasks == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.UserTasks.ToListAsync();
        }

        //    // GET: api/Products/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Product>> GetProduct(int id)
        //    {
        //      if (_context.Products == null)
        //      {
        //          return NotFound();
        //      }
        //        var product = await _context.Products.FindAsync(id);

        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        return product;
        //    }

        //    // PUT: api/Products/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutProduct(int id, Product product)
        //    {
        //        if (id != product.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(product).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Products
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Product>> PostProduct(Product product)
        //    {
        //      if (_context.Products == null)
        //      {
        //          return Problem("Entity set 'OpsApiDbContext.Products'  is null.");
        //      }
        //        _context.Products.Add(product);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //    }

        //    // DELETE: api/Products/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteProduct(int id)
        //    {
        //        if (_context.Products == null)
        //        {
        //            return NotFound();
        //        }
        //        var product = await _context.Products.FindAsync(id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Products.Remove(product);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool ProductExists(int id)
        //    {
        //        return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }
    }
}
