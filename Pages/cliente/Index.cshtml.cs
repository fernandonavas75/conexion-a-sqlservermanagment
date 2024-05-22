using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Conexion.Data;
using Conexion.Models;

namespace Conexion.Pages.cliente
{
    public class IndexModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public IndexModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        public IList<Clientes> Clientes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }
    }
}
