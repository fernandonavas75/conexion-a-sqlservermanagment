using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Conexion.Data;
using Conexion.Models;

namespace Conexion.Pages.Fac
{
    public class EditModel : PageModel
    {
        private readonly Conexion.Data.ConexionContext _context;

        public EditModel(Conexion.Data.ConexionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura =  await _context.Factura.FirstOrDefaultAsync(m => m.FacturaID == id);
            if (factura == null)
            {
                return NotFound();
            }
            Factura = factura;
           ViewData["ProductoID"] = new SelectList(_context.Set<Productos>(), "ProductoID", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(Factura.FacturaID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.FacturaID == id);
        }
    }
}
