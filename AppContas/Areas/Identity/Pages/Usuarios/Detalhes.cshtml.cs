
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AppContas.Areas.Identity.Pages.Usuarios
{
    public class DetalhesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetalhesModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
}
