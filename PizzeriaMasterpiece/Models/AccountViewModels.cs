using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaMasterpiece.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar usuario")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [StringLength(8, ErrorMessage = "El {0} debe tener {2} caracteres.", MinimumLength = 8)]
        [Display(Name = "DNI")]
        public string Document { get; set; }

        [Required(ErrorMessage ="Debe ingresar su(s) nombre(s)")]
        [Display(Name = "Nombre(s)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe ingresar sus apellidos")]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar su dirección")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Debe ingresar su teléfono")]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Debe ingresar su correo")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        [StringLength(100, ErrorMessage = "La {0} debe tener almenos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class UpdateViewModel
    {
        [Required]
        [Display(Name = "Nombre(s)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }        
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener almenos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}
