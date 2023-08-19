using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.DTO
{
    public class CategoriaDTO
    {
        public int IdCategotia { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        public string? Nombre { get; set; }

    }
}
