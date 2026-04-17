using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.User
{
    public class LoginForm
    {
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
            [Required(ErrorMessage = "Email est requis")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Mot de passe est requis")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }


