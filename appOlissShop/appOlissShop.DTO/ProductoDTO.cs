using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Nombre requerido.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Descripción requerido.")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Precio requerido.")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Precio oferta requerido.")]
        public decimal? PrecioOferta { get; set; }

        [Required(ErrorMessage = "Cantidad requerido.")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Imagen requerido.")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}

