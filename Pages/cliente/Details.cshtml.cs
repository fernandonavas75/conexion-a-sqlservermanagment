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
    public class DetailsModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public DetailsModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        public Clientes Clientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FirstOrDefaultAsync(m => m.ClienteID == id);
            if (clientes == null)
            {
                return NotFound();
            }
            else
            {
                Clientes = clientes;
            }
            return Page();
        }
    }
}
