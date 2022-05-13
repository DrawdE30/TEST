using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EvaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly UsuariosCTX ctx;

        public ProductosController(UsuariosCTX _ctx){
            this.ctx = _ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await ctx.Producto.ToListAsync();
        }

        //[HttpGet("{id}", Name ="GetUsuario")]
        [HttpGet("buscar/{id}", Name ="Getproducto")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await ctx.Producto.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(producto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                producto.Id = 0; //evitar validacion es incremental
                ctx.Producto.Add(producto);
                await ctx.SaveChangesAsync();
                return Created($"/Producto/{producto.Id}", producto);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if(producto.Id == id)
                {
                    ctx.Entry(producto).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return CreatedAtRoute("Getproducto", new { id = producto.Id}, producto);
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
                var producto = ctx.Producto.FirstOrDefault(f => f.Id == id);
                if (producto != null)
                {
                    ctx.Producto.Remove(producto);
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

    }
}
