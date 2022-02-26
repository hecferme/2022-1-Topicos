﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topicos.AdventureWorksLT.Model.Models;

namespace Topicos.AdventureWorksLT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var elServicio = new Topicos.AdventureWorksLT.BL.Customers();
            var elResultado = await elServicio.ListarAsync();
            return Ok(elResultado);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var elServicio = new Topicos.AdventureWorksLT.BL.Customers();
            var elResultado = await elServicio.BuscarPorIdAsync(id);

            if (elResultado == null)
            {
                return NotFound();
            }

            return Ok(elResultado);
        }

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        //}

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerId == id);
        //}
    }
}
