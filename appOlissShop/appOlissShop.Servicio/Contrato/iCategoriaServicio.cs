using appOlissShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOlissShop.Servicio.Contrato
{
    public  interface iCategoriaServicio
    {
        Task<List<CategoriaDTO>> List(string buscar);
        Task<CategoriaDTO> Obtener(int id);
        Task<CategoriaDTO> Crear(CategoriaDTO modelo);
        Task<bool> Editar(CategoriaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
