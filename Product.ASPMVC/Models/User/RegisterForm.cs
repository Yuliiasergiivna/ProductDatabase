using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.User
{
    public class RegisterForm
    {
        [Required(ErrorMessage = "Email est requis")]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mot de passe est requis")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Le mot de passe doit faire au moins 8 caractères")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
