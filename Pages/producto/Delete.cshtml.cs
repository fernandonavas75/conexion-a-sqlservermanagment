using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Conexion.Data;
using Conexion.Models;

namespace Conexion.Pages.producto
{
    public class DeleteModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public DeleteModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Productos Productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FirstOrDefaultAsync(m => m.ProductoID == id);

            if (productos == null)
            {
                return NotFound();
            }
            else
            {
                Productos = productos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                Productos = productos;
                _context.Productos.Remove(Productos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
