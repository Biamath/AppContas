using AppContas.Data;
using AppContas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppContas.Areas.Identity.Pages.Usuarios
{
    [Authorize]
    public class ExcluirModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ExcluirModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario != null)
            {
                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
