using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiASP.Data;
using RestApiASP.Models;

namespace RestApiASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContactoContexto _context;

        public ContactosController(ContactoContexto contexto)
        {
            _context = contexto;
        }

        //GET: api/contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        //POST: api/contactos
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto item)
        {
            _context.Contactos.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactos), new { id = item.Id}, item);
        }


        //DELETE: api/contactos/2
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if(contacto == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}