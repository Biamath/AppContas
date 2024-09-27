

using Microsoft.AspNetCore.Identity;

namespace AppContas.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
