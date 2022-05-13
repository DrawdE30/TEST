using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EvaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosCTX ctx;

        public UsuariosController(UsuariosCTX _ctx){
            this.ctx = _ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await ctx.Usuario.ToListAsync();
        }

        //[HttpGet("{id}", Name ="GetUsuario")]
        [HttpGet("buscar/{id}", Name ="GetUsuario")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await ctx.Usuario.FindAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                usuario.Id = 0; //evitar validacion es incremental
                ctx.Usuario.Add(usuario);
                await ctx.SaveChangesAsync();
                return Created($"/Usuario/{usuario.Id}", usuario);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if(usuario.Id == id)
                {
                    ctx.Entry(usuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return CreatedAtRoute("GetUsuario", new { id = usuario.Id}, usuario);
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
                var usuario = ctx.Usuario.FirstOrDefault(f => f.Id == id);
                if (usuario != null)
                {
                    ctx.Usuario.Remove(usuario);
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
