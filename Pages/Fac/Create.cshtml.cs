using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Conexion.Data;
using Conexion.Models;

namespace Conexion.Pages.Fac
{
    public class CreateModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public CreateModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductoID"] = new SelectList(_context.Set<Productos>(), "ProductoID", "Nombre");
            return Page();
        }

        [BindProperty]
        public Factura Factura { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Factura.Add(Factura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
