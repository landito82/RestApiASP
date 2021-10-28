using Microsoft.EntityFrameworkCore;
using RestApiASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiASP.Data
{
    public class ContactoContexto : DbContext
    {
        public ContactoContexto(DbContextOptions<ContactoContexto> options):base(options)
        {

        }

        //CREAR DBSET
        public DbSet<Contacto> Contactos { get; set; }

    }
}
