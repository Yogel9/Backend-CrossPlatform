﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly FDeclaration _function;

        public OrdersController(TodoContext context, FDeclaration fun)
        {
            _context = context;
            _function = fun;
        }

       // [Authorize(Roles = "admin")]
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> GetOrders()
        {
            return _function.ShowAllOrder(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList());
            //return await _context.Orders.ToListAsync();
        }

        [HttpGet("OrdForEdit")]
        public async Task<ActionResult<IEnumerable<Order>>> GetNotInf()
        {
           // return _function.ShowAllOrder(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList());
            return  _context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList();
        }

        [HttpGet("OneOrdForEdit")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrd( long ORD)
        {
            return _function.GetOneOrderForEdit(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList(), ORD).ToList();
        }

     
        [HttpGet("ExpOrder")]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> GetExpensiveOrder()
        {
            return _function.ShowExpensiveOrder(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList());
            //return await _context.Orders.ToListAsync();
        }

        //[HttpGet("AddersSort")]
        //public async Task<ActionResult<IEnumerable<OrderInfo>>> GetOrderByAddress()
        //{

        //    return _function.ShowOrderByAddress(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList());
        //    //return await _context.Orders.ToListAsync();
        //}


        //[Authorize(Roles = "admin")]
        [HttpGet("CustExpOrder")]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> GetExpensiveOrder2(int k)
        {
            return _function.ShowExpensiveOrder2(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList(),k);
            //return await _context.Orders.ToListAsync();
        }

        [HttpGet("OrderClient")]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> ShowClientOrder(long IdClient)
        {
            return _function.ShowClientOrder(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList(), IdClient);
            //return await _context.Orders.ToListAsync();
        }

        [HttpGet("MyFur")]
        public async Task<ActionResult<IEnumerable<Furniture>>> ShowMyFur (int IdClient)
        {
            return _function.ShowMyFurniture(_context.Orders.Include(a => a.Furnitures).Include(b => b.Сlient).ToList(), IdClient);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

   
        [HttpPut]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       // [Authorize]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

      
        [HttpDelete]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
