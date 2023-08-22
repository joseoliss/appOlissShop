using appOlissShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Servicio.Contrato
{
    public interface iProductoServicio
    {
        Task<List<ProductoDTO>> List(string buscar);
        Task<List<ProductoDTO>> Obtener(string categoria, string buscar);
        Task<ProductoDTO> Obtener(int id);
        Task<ProductoDTO> Crear(ProductoDTO modelo);
        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
