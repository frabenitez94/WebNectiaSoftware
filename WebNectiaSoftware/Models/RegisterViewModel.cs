using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "El campo Email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required(ErrorMessage = "La confirmación de contraseña es obligatoria.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
    public required string ConfirmPassword { get; set; }
}
