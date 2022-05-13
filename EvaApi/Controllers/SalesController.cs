using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EvaApi.Models;
using EvaApi.Models.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Microsoft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly UsuariosCTX ctx;

        public SalesController(UsuariosCTX _ctx){
            this.ctx = _ctx;
        }

        public async Task<List<Sale>> Get()
        {
            return await ctx.Sale.Include(x => x.Producto).ToListAsync();
        }

        /*        
        [HttpGet("{id}/{producto}")]
        public async Task<IActionResult> Get(int id, int producto)
        {
            var sale = await ctx.Sale.Include(x=>x.IdProductoNavigation).Where(x=>x.IdProducto == producto && x.Id == id).SingleOrDefaultAsync();
            if(sale == null){
                return NotFound($"El producto no esta en la venta.");
            }
            return Ok(sale);
        }        
        /*
        [HttpGet("buscar/{id}", Name ="GetSale")]
        public async Task<IActionResult> Get(int id)
        {
            var sale = await ctx.Sale.FindAsync(id);
            if(sale == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sale);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sale sale)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                sale.Id = 0; //evitar validacion es incremental
                ctx.Sale.Add(sale);
                await ctx.SaveChangesAsync();
                return Created($"/Sale/{sale.Id}", sale);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sale sale)
        {
            try
            {
                if(sale.Id == id)
                {
                    ctx.Entry(sale).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return CreatedAtRoute("GetSale", new { id = sale.Id}, sale);
                }
                else
                {
                    return BadRequest();                    
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("eliminar/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var sale = ctx.Sale.FirstOrDefault(f => f.Id == id);
                if (sale != null)
                {
                    ctx.Sale.Remove(sale);
                    ctx.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        */
    }
}
