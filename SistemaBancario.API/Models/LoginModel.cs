using System.ComponentModel.DataAnnotations;

namespace SistemaBancario.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatorio")]
        [DataType(DataType.EmailAddress)]//notation já vai verificar pra gente se é um email valido
        public string Email { get; set; }

        [Required(ErrorMessage = "O password é obrigatorio")]
        [DataType(DataType.Password)]//notation já vai verificar pra gente se é um password valido
        public string Password { get; set; }
    }
}
