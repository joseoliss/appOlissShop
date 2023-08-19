using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Titular requerido.")]
        public string? Titular { get; set; }

        [Required(ErrorMessage = "Número de tarjeta requerido.")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Vigencia requerido.")]
        public string? Vigencia { get; set; }

        [Required(ErrorMessage = "CVV requerido.")]
        public string? CVV { get; set; }
    }
}
