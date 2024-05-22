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
    public class DeleteModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public DeleteModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes != null)
            {
                Clientes = clientes;
                _context.Clientes.Remove(Clientes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
