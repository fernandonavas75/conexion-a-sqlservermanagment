using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Conexion.Models;

namespace Conexion.Data
{
    public class ConexionContext : DbContext
    {
        public ConexionContext (DbContextOptions<ConexionContext> options)
            : base(options)
        {
        }

        public DbSet<Conexion.Models.Clientes> Clientes { get; set; } = default!;
        public DbSet<Conexion.Models.Factura> Factura { get; set; } = default!;
        public DbSet<Conexion.Models.Productos> Productos { get; set; } = default!;
    }
}
