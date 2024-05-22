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
    public class DetailsModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public DetailsModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

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
    }
}
