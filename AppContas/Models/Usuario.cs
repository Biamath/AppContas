
using System.ComponentModel.DataAnnotations;

namespace AppContas.Models
{

    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [CustomValidation(typeof(Usuario), nameof(ValidateDataNascimento))]
        public DateTime DataNascimento { get; set; }

        // Validação personalizada para verificar se a data de nascimento não é no futuro
        public static ValidationResult ValidateDataNascimento(DateTime dataNascimento, ValidationContext context)
        {
            if (dataNascimento > DateTime.Now)
            {
                return new ValidationResult("A data de nascimento não pode ser no futuro.");
            }
            return ValidationResult.Success;
        }
    }
}
