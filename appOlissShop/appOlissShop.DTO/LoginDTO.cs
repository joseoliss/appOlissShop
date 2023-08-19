using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese el correo electrónico.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña.")]
        public string? Clave { get; set; }
    }
}
