using System.ComponentModel.DataAnnotations;

namespace app_to_do_mysql.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string? Password { get; set; }
    }
}